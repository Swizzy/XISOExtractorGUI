using System.Windows.Forms;

namespace XISOExtractorGUI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Net;
    using XISOExtractorGUI.Properties;

    public partial class FTPSettings : Form {
        public static XISOFTP.FTPSettingsData Settings = new XISOFTP.FTPSettingsData();
        private static readonly ImageList Imglist = new ImageList();
        delegate void SetNodeCallback(TreeNode node);
        delegate void SetNodeCallback2(TreeNode node, TreeNode src);

        private class NodeListItem {
            public TreeNode Node;
            public string Src;
        }

        private class FTPConnectionSettings
        {
            public string Host;
            public string User = "xbox";
            public string Password = "xbox";
            public int Port = 21;
            public FtpDataConnectionType DataConnectionType = FtpDataConnectionType.PASVEX;
        }

        public FTPSettings() {
            InitializeComponent();
            if (Imglist.Images.Empty) {
                Imglist.Images.Add("folder", Resources.folder);
                Imglist.Images.Add("file", Resources.file);
            }
            treeView1.ImageList = Imglist;
        }

        private FtpDataConnectionType GetConnectionType() {
            if (PASV.Checked)
                return FtpDataConnectionType.PASV;
            return PORT.Checked ? FtpDataConnectionType.PORT : FtpDataConnectionType.PASVEX;
        }

        private void SetState(bool state) {
            pathbox.Enabled = state;
            transmode.Enabled = state;
            hostbox.Enabled = state;
            userbox.Enabled = state;
            passbox.Enabled = state;
            portbox.Enabled = state;
        }

        private void ConnectbtnClick(object sender, EventArgs e)
        {
            Connectbtn.Enabled = false;
            SetState(false);
            status.Text = string.Format(Resources.ConnectingToOnPort, hostbox.Text, portbox.Value);
            conworker.RunWorkerAsync(new FTPConnectionSettings
            {
                Host = hostbox.Text,
                User = userbox.Text,
                Password = passbox.Text,
                Port = (int)portbox.Value,
                DataConnectionType = GetConnectionType()
            });
        }

        private void AddList(string src = null, TreeNode node = null) {
            status.Text = src == null ? Resources.GettingRootDirInfoFTP : string.Format(Resources.GettingDirInfoFTP, src.Replace('\\', '/'));
            var bw = new BackgroundWorker();
            bw.DoWork += BWOnDoWork;
            bw.RunWorkerCompleted += BWOnRunWorkerCompleted;
            bw.RunWorkerAsync(new NodeListItem{ Node = node, Src = src });
        }

        private void BWOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs) {
            status.Text = Resources.DoneWaitingForFurtherInstructions;
        }

        private void BWOnDoWork(object sender, DoWorkEventArgs e) {
            if (!(e.Argument is NodeListItem))
                return;
            var src = e.Argument as NodeListItem;
            var list = new List<XISOFTP.FTPDirList>();
            if (!XISOFTP.GetDirListing(src.Src, ref list))
                return;
            foreach (var ftpDirList in list)
            {
                var node = new TreeNode(ftpDirList.Name)
                {
                    ImageKey = ftpDirList.IsDirectory ? "folder" : "file",
                    SelectedImageKey = ftpDirList.IsDirectory ? "folder" : "file"
                };
                switch (src.Src)
                {
                    case null:
                        AddNewNode(node);
                        break;
                    default:
                        AddNewChildNode(node, src.Node);
                        break;
                }
            }
        }

        private void AddNewNode(TreeNode node) {
            if (InvokeRequired) {
                SetNodeCallback d = AddNewNode;
                Invoke(d, new object[] { node });
            }
            else if (!treeView1.Nodes.ContainsKey(node.Text))
                    treeView1.Nodes.Add(node);
        }

        private void AddNewChildNode(TreeNode node, TreeNode src) {
            if (InvokeRequired)
            {
                SetNodeCallback2 d = AddNewChildNode;
                Invoke(d, new object[] { node, src });
            }
            else if (!src.Nodes.ContainsKey(node.Text))
                src.Nodes.Add(node);
        }

        private void FTPSettingsLoad(object sender, EventArgs e)
        {
            hostbox.Text = Settings.Host;
            userbox.Text = Settings.User;
            passbox.Text = Settings.Password;
            portbox.Value = Settings.Port;
            pathbox.Text = Settings.Path;
            switch (Settings.DataConnectionType) {
                case FtpDataConnectionType.PASV:
                    PASV.Checked = true;
                    break;
                case FtpDataConnectionType.PORT:
                    PORT.Checked = true;
                    break;
                default:
                    PASVEX.Checked = true;
                    break;
            }
        }

        private void SaveBtnClick(object sender, EventArgs e)
        {
            XISOFTP.Disconnect();
            Settings.Host = hostbox.Text;
            Settings.User = userbox.Text;
            Settings.Password = passbox.Text;
            Settings.Port = (int) portbox.Value;
            Settings.DataConnectionType = GetConnectionType();
            Settings.Path = pathbox.Text;
        }

        private void HostboxTextChanged(object sender, EventArgs e)
        {
            Connectbtn.Enabled = hostbox.Text.Length > 0 && !XISOFTP.IsConnected;
            Connectbtn.Visible = hostbox.Text.Length > 0 && !XISOFTP.IsConnected;
        }

        private void ConworkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (!(e.Argument is FTPConnectionSettings))
                return;
            var settings = e.Argument as FTPConnectionSettings;
            e.Result = XISOFTP.Connect(settings.Host, settings.Port, settings.DataConnectionType, settings.User, settings.Password);
        }

        private void ConworkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Result is Boolean))
                return;
            if (!(bool)e.Result)
            {
                Connectbtn.Enabled = true;
                SetState(true);
                MessageBox.Show(XISOFTP.LastError);
                return;
            }
            treeView1.Nodes.Clear();
            AddList();
            SetState(true);
            disconnectbtn.Visible = true;
            disconnectbtn.Enabled = true;
            Connectbtn.Enabled = false;
            Connectbtn.Visible = false;
        }

        private void TreeView1MouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // ReSharper disable LocalizableElement
            var node = treeView1.SelectedNode;
            if (node.GetNodeCount(false) == 0 && node.ImageKey == "folder")
            {
                pathbox.Text = "/" + node.FullPath.Replace('\\', '/') + "/";
                AddList("/" + node.FullPath, node);
            }
            // ReSharper restore LocalizableElement
        }

        private void TreeView1KeyPress(object sender, KeyPressEventArgs e)
        {
            if (treeView1.SelectedNode == null || e.KeyChar != (char)Keys.Return)
                return;
            TreeView1MouseDoubleClick(null, null);
            e.Handled = true;
        }

        private void TreeView1KeyUp(object sender, KeyEventArgs e)
        {
            if (treeView1.SelectedNode == null || e.KeyCode != Keys.Right)
                return;
            TreeView1MouseDoubleClick(null, null);
            e.Handled = true;
        }

        private void DisconnectbtnClick(object sender, EventArgs e)
        {
            XISOFTP.Disconnect();
            HostboxTextChanged(null, null);
            disconnectbtn.Visible = false;
            disconnectbtn.Enabled = false;
        }

        private void FTPSettingsFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (XISOFTP.IsConnected)
                XISOFTP.Disconnect();
            e.Cancel = false;
        }
    }
}