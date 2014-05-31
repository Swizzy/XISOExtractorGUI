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
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.queueMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // selsrcbtn
            // 
            this.selsrcbtn.Location = new System.Drawing.Point(391, 12);
            this.selsrcbtn.Name = "selsrcbtn";
            this.selsrcbtn.Size = new System.Drawing.Size(31, 23);
            this.selsrcbtn.TabIndex = 0;
            this.selsrcbtn.Text = "...";
            this.selsrcbtn.UseVisualStyleBackColor = true;
            this.selsrcbtn.Click += new System.EventHandler(this.SelsrcbtnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source:";
            // 
            // srcbox
            // 
            this.srcbox.Location = new System.Drawing.Point(62, 14);
            this.srcbox.Name = "srcbox";
            this.srcbox.Size = new System.Drawing.Size(323, 20);
            this.srcbox.TabIndex = 0;
            this.srcbox.TextChanged += new System.EventHandler(this.SrcboxTextChanged);
            // 
            // queview
            // 
            this.queview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.queview.FullRowSelect = true;
            this.queview.GridLines = true;
            this.queview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.queview.Location = new System.Drawing.Point(428, 12);
            this.queview.Name = "queview";
            this.queview.ShowGroups = false;
            this.queview.Size = new System.Drawing.Size(393, 151);
            this.queview.TabIndex = 3;
            this.queview.UseCompatibleStateImageBehavior = false;
            this.queview.View = System.Windows.Forms.View.Details;
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
            this.seltargetbtn.Location = new System.Drawing.Point(391, 41);
            this.seltargetbtn.Name = "seltargetbtn";
            this.seltargetbtn.Size = new System.Drawing.Size(31, 23);
            this.seltargetbtn.TabIndex = 0;
            this.seltargetbtn.Text = "...";
            this.seltargetbtn.UseVisualStyleBackColor = true;
            this.seltargetbtn.Click += new System.EventHandler(this.SeltargetbtnClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Target:";
            // 
            // targetbox
            // 
            this.targetbox.Location = new System.Drawing.Point(62, 43);
            this.targetbox.Name = "targetbox";
            this.targetbox.Size = new System.Drawing.Size(323, 20);
            this.targetbox.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ftpbox);
            this.groupBox1.Controls.Add(this.genfilelistbox);
            this.groupBox1.Controls.Add(this.delIsobox);
            this.groupBox1.Controls.Add(this.gensfvbox);
            this.groupBox1.Controls.Add(this.skipsysbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 65);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // ftpbox
            // 
            this.ftpbox.AutoSize = true;
            this.ftpbox.Location = new System.Drawing.Point(137, 19);
            this.ftpbox.Name = "ftpbox";
            this.ftpbox.Size = new System.Drawing.Size(68, 17);
            this.ftpbox.TabIndex = 11;
            this.ftpbox.Text = "Use FTP";
            this.ftpbox.UseVisualStyleBackColor = true;
            // 
            // genfilelistbox
            // 
            this.genfilelistbox.AutoSize = true;
            this.genfilelistbox.Location = new System.Drawing.Point(137, 42);
            this.genfilelistbox.Name = "genfilelistbox";
            this.genfilelistbox.Size = new System.Drawing.Size(105, 17);
            this.genfilelistbox.TabIndex = 0;
            this.genfilelistbox.Text = "Generate FileList";
            this.genfilelistbox.UseVisualStyleBackColor = true;
            // 
            // delIsobox
            // 
            this.delIsobox.AutoSize = true;
            this.delIsobox.Location = new System.Drawing.Point(248, 42);
            this.delIsobox.Name = "delIsobox";
            this.delIsobox.Size = new System.Drawing.Size(156, 17);
            this.delIsobox.TabIndex = 0;
            this.delIsobox.Text = "Delete ISO after completion";
            this.delIsobox.UseVisualStyleBackColor = true;
            // 
            // gensfvbox
            // 
            this.gensfvbox.AutoSize = true;
            this.gensfvbox.Enabled = false;
            this.gensfvbox.Location = new System.Drawing.Point(6, 19);
            this.gensfvbox.Name = "gensfvbox";
            this.gensfvbox.Size = new System.Drawing.Size(93, 17);
            this.gensfvbox.TabIndex = 0;
            this.gensfvbox.Text = "Generate SFV";
            this.gensfvbox.UseVisualStyleBackColor = true;
            // 
            // skipsysbox
            // 
            this.skipsysbox.AutoSize = true;
            this.skipsysbox.Checked = true;
            this.skipsysbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skipsysbox.Location = new System.Drawing.Point(6, 42);
            this.skipsysbox.Name = "skipsysbox";
            this.skipsysbox.Size = new System.Drawing.Size(125, 17);
            this.skipsysbox.TabIndex = 0;
            this.skipsysbox.Text = "Skip $SystemUpdate";
            this.skipsysbox.UseVisualStyleBackColor = true;
            // 
            // addbtn
            // 
            this.addbtn.Enabled = false;
            this.addbtn.Location = new System.Drawing.Point(12, 140);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(410, 23);
            this.addbtn.TabIndex = 5;
            this.addbtn.Text = "Add To Queue";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.AddbtnClick);
            // 
            // processbtn
            // 
            this.processbtn.Enabled = false;
            this.processbtn.Location = new System.Drawing.Point(12, 169);
            this.processbtn.Name = "processbtn";
            this.processbtn.Size = new System.Drawing.Size(410, 23);
            this.processbtn.TabIndex = 5;
            this.processbtn.Text = "Process Queue";
            this.processbtn.UseVisualStyleBackColor = true;
            this.processbtn.Click += new System.EventHandler(this.ProcessbtnClick);
            // 
            // extractbtn
            // 
            this.extractbtn.Enabled = false;
            this.extractbtn.Location = new System.Drawing.Point(12, 198);
            this.extractbtn.Name = "extractbtn";
            this.extractbtn.Size = new System.Drawing.Size(410, 23);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 252);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(833, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(76, 17);
            this.toolStripStatusLabel1.Text = "File Progress:";
            // 
            // fileprogressbar
            // 
            this.fileprogressbar.Name = "fileprogressbar";
            this.fileprogressbar.Size = new System.Drawing.Size(50, 16);
            // 
            // operation
            // 
            this.operation.Name = "operation";
            this.operation.Size = new System.Drawing.Size(122, 17);
            this.operation.Text = "Waiting for user input";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "ISO Progress:";
            // 
            // isoprogressbar
            // 
            this.isoprogressbar.Location = new System.Drawing.Point(520, 169);
            this.isoprogressbar.Name = "isoprogressbar";
            this.isoprogressbar.Size = new System.Drawing.Size(301, 23);
            this.isoprogressbar.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Queue Progress:";
            // 
            // queueprogressbar
            // 
            this.queueprogressbar.Location = new System.Drawing.Point(520, 198);
            this.queueprogressbar.Name = "queueprogressbar";
            this.queueprogressbar.Size = new System.Drawing.Size(301, 23);
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
            this.statusStrip2.Location = new System.Drawing.Point(0, 230);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(833, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 9;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(122, 17);
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
            this.queueMenu.Size = new System.Drawing.Size(93, 48);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveQueueItem);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.EditQueueItem);
            // 
            // abortbtn
            // 
            this.abortbtn.Enabled = false;
            this.abortbtn.Location = new System.Drawing.Point(12, 140);
            this.abortbtn.Name = "abortbtn";
            this.abortbtn.Size = new System.Drawing.Size(260, 23);
            this.abortbtn.TabIndex = 10;
            this.abortbtn.Text = "Abort Operation";
            this.abortbtn.UseVisualStyleBackColor = true;
            this.abortbtn.Visible = false;
            this.abortbtn.Click += new System.EventHandler(this.AbortOperation);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(833, 274);
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
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(849, 312);
            this.MinimumSize = new System.Drawing.Size(849, 312);
            this.Name = "MainForm";
            this.Text = "XISO Extractor GUI v{0}.{1} (Build: {2}) By Swizzy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainFormDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainFormDragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.queueMenu.ResumeLayout(false);
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
    }
}