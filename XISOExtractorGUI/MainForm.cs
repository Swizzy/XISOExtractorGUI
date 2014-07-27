namespace XISOExtractorGUI {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;
    using XISOExtractorGUI.Properties;

    internal sealed partial class MainForm: Form {
        private readonly Dictionary<int, BwArgs> _queDict = new Dictionary<int, BwArgs>();
        private int _id;

        internal MainForm() {
            InitializeComponent();
            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            Text = string.Format(Text, ver.Major, ver.Minor, ver.Build);
            XisoExtractor.FileProgress += XisoExtractorFileProgress;
            XisoExtractor.IsoProgress += XisoExtractorTotalProgress;
            XisoExtractor.Operation += XisoExtractorOnOperation;
            XisoExtractor.Status += XisoExtractorOnStatus;
            XisoExtractor.TotalProgress += XisoExtractorQueueProgress;
            ResetButtons();
#if NOFTP
            ftpbox.Visible = false;
#endif
        }

        private void XisoExtractorOnStatus(object sender, EventArg<string> e) {
            if(InvokeRequired) {
                BeginInvoke(new EventHandler<EventArg<string>>(XisoExtractorOnStatus), new[] {
                                                                                                 sender, e
                                                                                             });
                return;
            }
            status.Text = e.Data;
            logbox.AppendText(e.Data + Environment.NewLine);
        }

        private void XisoExtractorOnOperation(object sender, EventArg<string> e) {
            if(InvokeRequired) {
                BeginInvoke(new EventHandler<EventArg<string>>(XisoExtractorOnOperation), new[] {
                                                                                                    sender, e
                                                                                                });
                return;
            }
            operation.Text = e.Data;
            //logbox.AppendText(e.Data + Environment.NewLine);
        }

        private void XisoExtractorFileProgress(object sender, EventArg<double> e) {
            if(InvokeRequired) {
                BeginInvoke(new EventHandler<EventArg<double>>(XisoExtractorFileProgress), new[] {
                                                                                                     sender, e
                                                                                                 });
                return;
            }
            SetProgress(ref fileprogressbar, (int)e.Data);
        }

        private static void SetProgress(ref ProgressBar pbar, int value) {
            if(pbar == null)
                return;
            if(value > pbar.Maximum)
                pbar.Value = pbar.Maximum;
            else if(value < pbar.Minimum)
                pbar.Value = pbar.Minimum;
            else
                pbar.Value = value;
        }

        private static void SetProgress(ref ToolStripProgressBar pbar, int value) {
            if(pbar == null)
                return;
            if(value > pbar.Maximum)
                pbar.Value = pbar.Maximum;
            else if(value < pbar.Minimum)
                pbar.Value = pbar.Minimum;
            else
                pbar.Value = value;
        }

        private void XisoExtractorTotalProgress(object sender, EventArg<double> e) {
            if(InvokeRequired) {
                BeginInvoke(new EventHandler<EventArg<double>>(XisoExtractorTotalProgress), new[] {
                                                                                                      sender, e
                                                                                                  });
                return;
            }
            SetProgress(ref isoprogressbar, (int)e.Data);
        }

        private void XisoExtractorQueueProgress(object sender, EventArg<double> e) {
            if(InvokeRequired) {
                BeginInvoke(new EventHandler<EventArg<double>>(XisoExtractorQueueProgress), new[] {
                                                                                                      sender, e
                                                                                                  });
                return;
            }
            SetProgress(ref queueprogressbar, (int)e.Data);
        }

        private void SeltargetbtnClick(object sender, EventArgs e) {
#if !NOFTP
            if(!ftpbox.Checked) {
#endif
            var sfd = new FolderSelectDialog {
                                                 Title = "Select where to save the extracted data",
                                                 InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"
                                             };
            if(!string.IsNullOrEmpty(srcbox.Text))
                sfd.FileName = string.Format("{0}\\{1}", Path.GetDirectoryName(srcbox.Text), Path.GetFileNameWithoutExtension(srcbox.Text));
            if(sfd.ShowDialog())
                targetbox.Text = sfd.FileName;
#if !NOFTP
            }
            else {
                var form = new FTPSettings();
                if(form.ShowDialog() == DialogResult.OK) {}
            }
#endif
        }

        private void SelsrcbtnClick(object sender, EventArgs e) {
            if(ofd.ShowDialog() != DialogResult.OK)
                return;
            srcbox.Text = ofd.FileName;
            ofd.FileName = Path.GetFileName(ofd.FileName);
        }

        private void ExtractbtnClick(object sender, EventArgs e) {
            SetBusyState();
            bw.RunWorkerCompleted += SingleExtractCompleted;
            bw.DoWork += SingleExtractDoWork;
            bw.RunWorkerAsync(new BwArgs {
                                             Source = srcbox.Text,
                                             Target = targetbox.Text,
                                             SkipSystemUpdate = skipsysbox.Checked,
                                             GenerateFileList = genfilelistbox.Checked,
                                             DeleteIsoOnCompletion = delIsobox.Checked
                                         });
        }

        private void SetBusyState() {
            extractbtn.Enabled = false;
            processbtn.Enabled = false;
            addbtn.Visible = false;
            abortbtn.Visible = true;
            abortbtn.Enabled = true;
            AllowDrop = false;
        }

        private void AbortOperation(object sender, EventArgs eventArgs) { XisoExtractor.Abort = true; }

        private static void SingleExtractDoWork(object sender, DoWorkEventArgs e) {
            if(!(e.Argument is BwArgs)) {
                e.Cancel = true;
                return;
            }
            var args = e.Argument as BwArgs;
            e.Result = XisoExtractor.ExtractXiso(new XisoOptions {
                                                                     Source = args.Source,
                                                                     Target = args.Target,
                                                                     ExcludeSysUpdate = args.SkipSystemUpdate,
                                                                     GenerateFileList = args.GenerateFileList,
                                                                     //GenerateSfv = args.GenerateSFV,
                                                                     DeleteIsoOnCompletion = args.DeleteIsoOnCompletion
                                                                 });
        }

        private void SingleExtractCompleted(object sender, RunWorkerCompletedEventArgs e) {
            bw.RunWorkerCompleted -= SingleExtractCompleted;
            bw.DoWork -= SingleExtractDoWork;
            ResetButtons();
        }

        private void ResetButtons() {
            addbtn.Text = Resources.AddToQueueBtnText;
            addbtn.Visible = true;
            abortbtn.Visible = false;
            abortbtn.Size = addbtn.Size;
            SrcboxTextChanged(null, null);
            AllowDrop = true;
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            if(bw.IsBusy) {
                AbortOperation(sender, e);
                while(bw.IsBusy) {
                    Thread.Sleep(100);
                    Application.DoEvents();
                }
            }
#if !NOFTP
            if(XISOFTP.IsConnected)
                XISOFTP.Disconnect();
#endif
            e.Cancel = false;
        }

        private void SrcboxTextChanged(object sender, EventArgs e) {
            extractbtn.Enabled = (!string.IsNullOrEmpty(srcbox.Text) && File.Exists(srcbox.Text));
            addbtn.Enabled = extractbtn.Enabled;
        }

        private void DoDragEnter(object sender, DragEventArgs e) { e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None; }

        private void MainFormDragDrop(object sender, DragEventArgs e) {
            var fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach(var s in fileList) {
                if(!s.EndsWith(".iso", StringComparison.CurrentCultureIgnoreCase) && !s.EndsWith(".xiso", StringComparison.CurrentCultureIgnoreCase) &&
                   !s.EndsWith(".360", StringComparison.CurrentCultureIgnoreCase) && !s.EndsWith(".000", StringComparison.CurrentCultureIgnoreCase))
                    continue;
                srcbox.Text = s;
                return;
            }
        }

        private void AddbtnClick(object sender, EventArgs e) { AddQueueItem(true); }

        private void AddQueueItem(bool resetTarget) {
            if(string.IsNullOrEmpty(srcbox.Text))
                return;
            var viewitem = new ListViewItem(_id.ToString(CultureInfo.InvariantCulture));
            viewitem.SubItems.Add(srcbox.Text);
            var target = targetbox.Text;
            if(!resetTarget && !string.IsNullOrEmpty(target))
                target = Path.Combine(target, Path.GetFileNameWithoutExtension(srcbox.Text));
            if(string.IsNullOrEmpty(target))
                target = string.Format("{0}\\{1}", Path.GetDirectoryName(srcbox.Text), Path.GetFileNameWithoutExtension(srcbox.Text));
            viewitem.SubItems.Add(target);
            var queueitem = new BwArgs {
                                           Source = srcbox.Text,
                                           Target = target,
                                           SkipSystemUpdate = skipsysbox.Checked,
                                           GenerateFileList = genfilelistbox.Checked,
                                           //GenerateSfv = gensfvbox.Checked,
                                           DeleteIsoOnCompletion = delIsobox.Checked
                                       };
            var opt = Program.GetOptString(queueitem);
            viewitem.SubItems.Add(opt);
            queview.Items.Add(viewitem);
            _queDict.Add(_id, queueitem);
            _id++;

            if(resetTarget)
                targetbox.Text = "";
            srcbox.Text = "";
            processbtn.Enabled = true;
        }

        private void ProcessbtnClick(object sender, EventArgs e) {
            SetBusyState();
            var list = new List<BwArgs>();
            foreach(var key in _queDict.Keys)
                list.Add(_queDict[key]);
            bw.DoWork += MultiExtractDoWork;
            bw.RunWorkerCompleted += MultiExtractCompleted;
            bw.RunWorkerAsync(list);
            _queDict.Clear();
            queview.Items.Clear();
        }

        private void QueviewMouseClick(object sender, MouseEventArgs e) {
            if(e.Button != MouseButtons.Right || !queview.FocusedItem.Bounds.Contains(e.Location) || queview.SelectedItems.Count <= 0)
                return;
            queueMenu.Show(Cursor.Position);
        }

        private void RemoveQueueItem(object sender, EventArgs e) {
            foreach(ListViewItem entry in queview.SelectedItems) {
                int id;
                if(!int.TryParse(entry.SubItems[0].Text, out id))
                    continue;
                if(_queDict.ContainsKey(id))
                    _queDict.Remove(id);
                queview.Items.Remove(entry);
            }
        }

        private void EditQueueItem(object sender, EventArgs e) {
            //TODO: Make edit function
        }

        private void MultiExtractDoWork(object sender, DoWorkEventArgs e) {
            var sw = new Stopwatch();
            sw.Start();
            if(!(e.Argument is List<BwArgs>)) {
                e.Cancel = true;
                return;
            }
            var args = e.Argument as List<BwArgs>;
            XisoExtractor.MultiSize = 0;
            var list = new XisoListAndSize[args.Count];
            for(var i = 0; i < args.Count; i++) {
                if(XisoExtractor.Abort)
                    return;
                BinaryReader br;
                args[i].Result = XisoExtractor.GetFileListAndSize(new XisoOptions {
                                                                                      Source = args[i].Source,
                                                                                      Target = args[i].Target,
                                                                                      ExcludeSysUpdate = args[i].SkipSystemUpdate,
                                                                                      GenerateFileList = args[i].GenerateFileList,
                                                                                      //GenerateSfv = args[i].GenerateSFV,
                                                                                      DeleteIsoOnCompletion = args[i].DeleteIsoOnCompletion
                                                                                  }, out list[i], out br);
                if(br != null)
                    br.Close();
                if(args[i].Result)
                    XisoExtractor.MultiSize += list[i].Size;
                args[i].ErrorMsg = XisoExtractor.GetLastError();
                GC.Collect();
            }
            for(var i = 0; i < args.Count; i++) {
                if(XisoExtractor.Abort)
                    return;
                if(!args[i].Result)
                    continue;
                args[i].Result = XisoExtractor.ExtractXiso(new XisoOptions {
                                                                               Source = args[i].Source,
                                                                               Target = args[i].Target,
                                                                               ExcludeSysUpdate = args[i].SkipSystemUpdate,
                                                                               GenerateFileList = args[i].GenerateFileList,
                                                                               //GenerateSfv = args[i].GenerateSFV,
                                                                               DeleteIsoOnCompletion = args[i].DeleteIsoOnCompletion
                                                                           }, list[i]);
                args[i].ErrorMsg = XisoExtractor.GetLastError();
            }

            var failed = 0;
            foreach(var result in args) {
                if(!result.Result)
                    failed++;
            }
            e.Result = failed == 0 ? (object)true : args;
            sw.Stop();
            var msg = string.Format("Completed Queue after {0:F0} Minute(s) and {1} Second(s)", sw.Elapsed.TotalMinutes, sw.Elapsed.Seconds);
            XisoExtractorOnOperation(null, new EventArg<string>(msg));
            logbox.AppendText(msg + Environment.NewLine);
        }

        private void MultiExtractCompleted(object sender, RunWorkerCompletedEventArgs e) {
            bw.DoWork -= MultiExtractDoWork;
            bw.RunWorkerCompleted -= MultiExtractCompleted;
            ResetButtons();
            if(XisoExtractor.Abort) {
                SetAbortState();
                return;
            }
            if(!(e.Result is List<BwArgs>) || MessageBox.Show(Resources.MultiExtractFailed, Resources.ExtractFailed, MessageBoxButtons.OKCancel, MessageBoxIcon.Error) != DialogResult.OK)
                return;
            var res = new ExtractionResults();
            res.Show(e.Result as List<BwArgs>);
        }

        private void SetAbortState() {
            SetProgress(ref fileprogressbar, fileprogressbar.Minimum);
            SetProgress(ref isoprogressbar, fileprogressbar.Minimum);
            SetProgress(ref queueprogressbar, fileprogressbar.Minimum);
            status.Text = Resources.OperationAbortedByUser;
            operation.Text = Resources.OperationAbortedByUser;
            logbox.AppendText(Resources.OperationAbortedByUser + Environment.NewLine);
        }

        private void queview_DragDrop(object sender, DragEventArgs e) {
            var fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach(var s in fileList) {
                if(File.Exists(s)) {
                    if(!s.EndsWith(".iso", StringComparison.CurrentCultureIgnoreCase) && !s.EndsWith(".xiso", StringComparison.CurrentCultureIgnoreCase) &&
                       !s.EndsWith(".360", StringComparison.CurrentCultureIgnoreCase) && !s.EndsWith(".000", StringComparison.CurrentCultureIgnoreCase))
                        continue;
                    srcbox.Text = s;
                    AddQueueItem(false);
                }
                else
                    ScanDragDropMulti(s);
            }
        }

        private void ScanDragDropMulti(string dir) {
            foreach(var s in Directory.GetFiles(dir)) {
                if(!s.EndsWith(".iso", StringComparison.CurrentCultureIgnoreCase) && !s.EndsWith(".xiso", StringComparison.CurrentCultureIgnoreCase) &&
                   !s.EndsWith(".360", StringComparison.CurrentCultureIgnoreCase) && !s.EndsWith(".000", StringComparison.CurrentCultureIgnoreCase))
                    continue;
                srcbox.Text = s;
                AddQueueItem(false);
            }
            foreach(var s in Directory.GetDirectories(dir))
                ScanDragDropMulti(s);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            var sfd = new SaveFileDialog();
            if(sfd.ShowDialog() != DialogResult.OK)
                return;
            File.WriteAllLines(sfd.FileName, logbox.Lines);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e) { logbox.Text = ""; }
    }

    public sealed class BwArgs {
        internal bool DeleteIsoOnCompletion;
        internal string ErrorMsg;
        internal bool GenerateFileList;
        internal bool GenerateSfv;
        internal bool Result;
        internal bool SkipSystemUpdate;
        internal string Source;
        internal string Target;
    }
}