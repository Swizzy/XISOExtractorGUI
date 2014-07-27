namespace XISOExtractorGUI
{
    internal sealed partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.selsrcbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.srcbox = new System.Windows.Forms.TextBox();
            this.queview = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.seltargetbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.targetbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ftpbox = new System.Windows.Forms.CheckBox();
            this.genfilelistbox = new System.Windows.Forms.CheckBox();
            this.delIsobox = new System.Windows.Forms.CheckBox();
            this.gensfvbox = new System.Windows.Forms.CheckBox();
            this.skipsysbox = new System.Windows.Forms.CheckBox();
            this.addbtn = new System.Windows.Forms.Button();
            this.processbtn = new System.Windows.Forms.Button();
            this.extractbtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fileprogressbar = new System.Windows.Forms.ToolStripProgressBar();
            this.operation = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.isoprogressbar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.queueprogressbar = new System.Windows.Forms.ProgressBar();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.queueMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abortbtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.logbox = new System.Windows.Forms.RichTextBox();
            this.logMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.queueMenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.logMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // selsrcbtn
            // 
            this.selsrcbtn.Location = new System.Drawing.Point(521, 15);
            this.selsrcbtn.Margin = new System.Windows.Forms.Padding(4);
            this.selsrcbtn.Name = "selsrcbtn";
            this.selsrcbtn.Size = new System.Drawing.Size(41, 28);
            this.selsrcbtn.TabIndex = 0;
            this.selsrcbtn.Text = "...";
            this.selsrcbtn.UseVisualStyleBackColor = true;
            this.selsrcbtn.Click += new System.EventHandler(this.SelsrcbtnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source:";
            // 
            // srcbox
            // 
            this.srcbox.Location = new System.Drawing.Point(83, 17);
            this.srcbox.Margin = new System.Windows.Forms.Padding(4);
            this.srcbox.Name = "srcbox";
            this.srcbox.Size = new System.Drawing.Size(429, 22);
            this.srcbox.TabIndex = 0;
            this.srcbox.TextChanged += new System.EventHandler(this.SrcboxTextChanged);
            // 
            // queview
            // 
            this.queview.AllowDrop = true;
            this.queview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.queview.FullRowSelect = true;
            this.queview.GridLines = true;
            this.queview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.queview.Location = new System.Drawing.Point(571, 15);
            this.queview.Margin = new System.Windows.Forms.Padding(4);
            this.queview.Name = "queview";
            this.queview.ShowGroups = false;
            this.queview.Size = new System.Drawing.Size(523, 185);
            this.queview.TabIndex = 3;
            this.queview.UseCompatibleStateImageBehavior = false;
            this.queview.View = System.Windows.Forms.View.Details;
            this.queview.DragDrop += new System.Windows.Forms.DragEventHandler(this.queview_DragDrop);
            this.queview.DragEnter += new System.Windows.Forms.DragEventHandler(this.DoDragEnter);
            this.queview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.QueviewMouseClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ID";
            this.columnHeader4.Width = 35;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Source";
            this.columnHeader1.Width = 103;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Target";
            this.columnHeader2.Width = 113;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Options";
            this.columnHeader3.Width = 135;
            // 
            // seltargetbtn
            // 
            this.seltargetbtn.Location = new System.Drawing.Point(521, 50);
            this.seltargetbtn.Margin = new System.Windows.Forms.Padding(4);
            this.seltargetbtn.Name = "seltargetbtn";
            this.seltargetbtn.Size = new System.Drawing.Size(41, 28);
            this.seltargetbtn.TabIndex = 0;
            this.seltargetbtn.Text = "...";
            this.seltargetbtn.UseVisualStyleBackColor = true;
            this.seltargetbtn.Click += new System.EventHandler(this.SeltargetbtnClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Target:";
            // 
            // targetbox
            // 
            this.targetbox.Location = new System.Drawing.Point(83, 53);
            this.targetbox.Margin = new System.Windows.Forms.Padding(4);
            this.targetbox.Name = "targetbox";
            this.targetbox.Size = new System.Drawing.Size(429, 22);
            this.targetbox.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ftpbox);
            this.groupBox1.Controls.Add(this.genfilelistbox);
            this.groupBox1.Controls.Add(this.delIsobox);
            this.groupBox1.Controls.Add(this.gensfvbox);
            this.groupBox1.Controls.Add(this.skipsysbox);
            this.groupBox1.Location = new System.Drawing.Point(16, 85);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(547, 80);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // ftpbox
            // 
            this.ftpbox.AutoSize = true;
            this.ftpbox.Location = new System.Drawing.Point(394, 23);
            this.ftpbox.Margin = new System.Windows.Forms.Padding(4);
            this.ftpbox.Name = "ftpbox";
            this.ftpbox.Size = new System.Drawing.Size(85, 21);
            this.ftpbox.TabIndex = 11;
            this.ftpbox.Text = "Use FTP";
            this.ftpbox.UseVisualStyleBackColor = true;
            // 
            // genfilelistbox
            // 
            this.genfilelistbox.AutoSize = true;
            this.genfilelistbox.Location = new System.Drawing.Point(183, 52);
            this.genfilelistbox.Margin = new System.Windows.Forms.Padding(4);
            this.genfilelistbox.Name = "genfilelistbox";
            this.genfilelistbox.Size = new System.Drawing.Size(138, 21);
            this.genfilelistbox.TabIndex = 0;
            this.genfilelistbox.Text = "Generate FileList";
            this.genfilelistbox.UseVisualStyleBackColor = true;
            // 
            // delIsobox
            // 
            this.delIsobox.AutoSize = true;
            this.delIsobox.Location = new System.Drawing.Point(183, 23);
            this.delIsobox.Margin = new System.Windows.Forms.Padding(4);
            this.delIsobox.Name = "delIsobox";
            this.delIsobox.Size = new System.Drawing.Size(203, 21);
            this.delIsobox.TabIndex = 0;
            this.delIsobox.Text = "Delete ISO after completion";
            this.delIsobox.UseVisualStyleBackColor = true;
            // 
            // gensfvbox
            // 
            this.gensfvbox.AutoSize = true;
            this.gensfvbox.Enabled = false;
            this.gensfvbox.Location = new System.Drawing.Point(8, 23);
            this.gensfvbox.Margin = new System.Windows.Forms.Padding(4);
            this.gensfvbox.Name = "gensfvbox";
            this.gensfvbox.Size = new System.Drawing.Size(120, 21);
            this.gensfvbox.TabIndex = 0;
            this.gensfvbox.Text = "Generate SFV";
            this.gensfvbox.UseVisualStyleBackColor = true;
            // 
            // skipsysbox
            // 
            this.skipsysbox.AutoSize = true;
            this.skipsysbox.Checked = true;
            this.skipsysbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skipsysbox.Location = new System.Drawing.Point(8, 52);
            this.skipsysbox.Margin = new System.Windows.Forms.Padding(4);
            this.skipsysbox.Name = "skipsysbox";
            this.skipsysbox.Size = new System.Drawing.Size(161, 21);
            this.skipsysbox.TabIndex = 0;
            this.skipsysbox.Text = "Skip $SystemUpdate";
            this.skipsysbox.UseVisualStyleBackColor = true;
            // 
            // addbtn
            // 
            this.addbtn.Enabled = false;
            this.addbtn.Location = new System.Drawing.Point(16, 172);
            this.addbtn.Margin = new System.Windows.Forms.Padding(4);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(547, 28);
            this.addbtn.TabIndex = 5;
            this.addbtn.Text = "Add To Queue";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.AddbtnClick);
            // 
            // processbtn
            // 
            this.processbtn.Enabled = false;
            this.processbtn.Location = new System.Drawing.Point(16, 208);
            this.processbtn.Margin = new System.Windows.Forms.Padding(4);
            this.processbtn.Name = "processbtn";
            this.processbtn.Size = new System.Drawing.Size(547, 28);
            this.processbtn.TabIndex = 5;
            this.processbtn.Text = "Process Queue";
            this.processbtn.UseVisualStyleBackColor = true;
            this.processbtn.Click += new System.EventHandler(this.ProcessbtnClick);
            // 
            // extractbtn
            // 
            this.extractbtn.Enabled = false;
            this.extractbtn.Location = new System.Drawing.Point(16, 244);
            this.extractbtn.Margin = new System.Windows.Forms.Padding(4);
            this.extractbtn.Name = "extractbtn";
            this.extractbtn.Size = new System.Drawing.Size(547, 28);
            this.extractbtn.TabIndex = 5;
            this.extractbtn.Text = "Just Extract";
            this.extractbtn.UseVisualStyleBackColor = true;
            this.extractbtn.Click += new System.EventHandler(this.ExtractbtnClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.fileprogressbar,
            this.operation});
            this.statusStrip1.Location = new System.Drawing.Point(0, 503);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1108, 26);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(95, 21);
            this.toolStripStatusLabel1.Text = "File Progress:";
            // 
            // fileprogressbar
            // 
            this.fileprogressbar.Name = "fileprogressbar";
            this.fileprogressbar.Size = new System.Drawing.Size(67, 20);
            // 
            // operation
            // 
            this.operation.Name = "operation";
            this.operation.Size = new System.Drawing.Size(153, 21);
            this.operation.Text = "Waiting for user input";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(589, 214);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "ISO Progress:";
            // 
            // isoprogressbar
            // 
            this.isoprogressbar.Location = new System.Drawing.Point(693, 208);
            this.isoprogressbar.Margin = new System.Windows.Forms.Padding(4);
            this.isoprogressbar.Name = "isoprogressbar";
            this.isoprogressbar.Size = new System.Drawing.Size(401, 28);
            this.isoprogressbar.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(571, 250);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Queue Progress:";
            // 
            // queueprogressbar
            // 
            this.queueprogressbar.Location = new System.Drawing.Point(693, 244);
            this.queueprogressbar.Margin = new System.Windows.Forms.Padding(4);
            this.queueprogressbar.Name = "queueprogressbar";
            this.queueprogressbar.Size = new System.Drawing.Size(401, 28);
            this.queueprogressbar.TabIndex = 8;
            // 
            // ofd
            // 
            this.ofd.DefaultExt = "iso";
            this.ofd.FileName = "xiso.iso";
            this.ofd.Filter = "Xbox ISO Files|*.iso|All Files|*.*";
            this.ofd.Title = "Select XISO to Extract";
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip2.Location = new System.Drawing.Point(0, 478);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip2.Size = new System.Drawing.Size(1108, 25);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 9;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(153, 20);
            this.status.Text = "Waiting for user input";
            // 
            // queueMenu
            // 
            this.queueMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.queueMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.editToolStripMenuItem});
            this.queueMenu.Name = "queueMenu";
            this.queueMenu.ShowImageMargin = false;
            this.queueMenu.Size = new System.Drawing.Size(108, 52);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveQueueItem);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.EditQueueItem);
            // 
            // abortbtn
            // 
            this.abortbtn.Enabled = false;
            this.abortbtn.Location = new System.Drawing.Point(16, 172);
            this.abortbtn.Margin = new System.Windows.Forms.Padding(4);
            this.abortbtn.Name = "abortbtn";
            this.abortbtn.Size = new System.Drawing.Size(347, 28);
            this.abortbtn.TabIndex = 10;
            this.abortbtn.Text = "Abort Operation";
            this.abortbtn.UseVisualStyleBackColor = true;
            this.abortbtn.Visible = false;
            this.abortbtn.Click += new System.EventHandler(this.AbortOperation);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.logbox);
            this.groupBox2.Location = new System.Drawing.Point(12, 279);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1084, 196);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // logbox
            // 
            this.logbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logbox.Location = new System.Drawing.Point(3, 18);
            this.logbox.Name = "logbox";
            this.logbox.ReadOnly = true;
            this.logbox.Size = new System.Drawing.Size(1078, 175);
            this.logbox.TabIndex = 0;
            this.logbox.Text = "";
            // 
            // logMenu
            // 
            this.logMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.logMenu.Name = "contextMenuStrip1";
            this.logMenu.Size = new System.Drawing.Size(113, 52);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1108, 529);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.queueprogressbar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.isoprogressbar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.extractbtn);
            this.Controls.Add(this.processbtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.queview);
            this.Controls.Add(this.targetbox);
            this.Controls.Add(this.srcbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seltargetbtn);
            this.Controls.Add(this.selsrcbtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.abortbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1126, 373);
            this.Name = "MainForm";
            this.Text = "XISO Extractor GUI v{0}.{1} (Build: {2}) By Swizzy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainFormDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DoDragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.queueMenu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.logMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selsrcbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox srcbox;
        private System.Windows.Forms.ListView queview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button seltargetbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox targetbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox genfilelistbox;
        private System.Windows.Forms.CheckBox gensfvbox;
        private System.Windows.Forms.CheckBox skipsysbox;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Button processbtn;
        private System.Windows.Forms.Button extractbtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel operation;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar fileprogressbar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar isoprogressbar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar queueprogressbar;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ContextMenuStrip queueMenu;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button abortbtn;
        private System.Windows.Forms.CheckBox ftpbox;
        private System.Windows.Forms.CheckBox delIsobox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox logbox;
        private System.Windows.Forms.ContextMenuStrip logMenu;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}