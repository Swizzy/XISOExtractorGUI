namespace XISOExtractorGUI
{
    internal sealed partial class FTPSettings
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
            this.transmode = new System.Windows.Forms.GroupBox();
            this.PORT = new System.Windows.Forms.RadioButton();
            this.PASVEX = new System.Windows.Forms.RadioButton();
            this.PASV = new System.Windows.Forms.RadioButton();
            this.Connectbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hostbox = new System.Windows.Forms.TextBox();
            this.userbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passbox = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.portbox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pathbox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.conworker = new System.ComponentModel.BackgroundWorker();
            this.disconnectbtn = new System.Windows.Forms.Button();
            this.transmode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portbox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // transmode
            // 
            this.transmode.Controls.Add(this.PORT);
            this.transmode.Controls.Add(this.PASVEX);
            this.transmode.Controls.Add(this.PASV);
            this.transmode.Location = new System.Drawing.Point(12, 38);
            this.transmode.Name = "transmode";
            this.transmode.Size = new System.Drawing.Size(130, 88);
            this.transmode.TabIndex = 0;
            this.transmode.TabStop = false;
            this.transmode.Text = "Transfer Mode";
            // 
            // PORT
            // 
            this.PORT.AutoSize = true;
            this.PORT.Location = new System.Drawing.Point(6, 65);
            this.PORT.Name = "PORT";
            this.PORT.Size = new System.Drawing.Size(55, 17);
            this.PORT.TabIndex = 0;
            this.PORT.Text = "Active";
            this.PORT.UseVisualStyleBackColor = true;
            // 
            // PASVEX
            // 
            this.PASVEX.AutoSize = true;
            this.PASVEX.Checked = true;
            this.PASVEX.Location = new System.Drawing.Point(6, 19);
            this.PASVEX.Name = "PASVEX";
            this.PASVEX.Size = new System.Drawing.Size(110, 17);
            this.PASVEX.TabIndex = 0;
            this.PASVEX.TabStop = true;
            this.PASVEX.Text = "Passive Extended";
            this.PASVEX.UseVisualStyleBackColor = true;
            // 
            // PASV
            // 
            this.PASV.AutoSize = true;
            this.PASV.Location = new System.Drawing.Point(6, 42);
            this.PASV.Name = "PASV";
            this.PASV.Size = new System.Drawing.Size(62, 17);
            this.PASV.TabIndex = 0;
            this.PASV.Text = "Passive";
            this.PASV.UseVisualStyleBackColor = true;
            // 
            // Connectbtn
            // 
            this.Connectbtn.Enabled = false;
            this.Connectbtn.Location = new System.Drawing.Point(12, 132);
            this.Connectbtn.Name = "Connectbtn";
            this.Connectbtn.Size = new System.Drawing.Size(130, 23);
            this.Connectbtn.TabIndex = 0;
            this.Connectbtn.Text = "Connect";
            this.Connectbtn.UseVisualStyleBackColor = true;
            this.Connectbtn.Click += new System.EventHandler(this.ConnectbtnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Host:";
            // 
            // hostbox
            // 
            this.hostbox.Location = new System.Drawing.Point(50, 161);
            this.hostbox.Name = "hostbox";
            this.hostbox.Size = new System.Drawing.Size(92, 20);
            this.hostbox.TabIndex = 3;
            this.hostbox.TextChanged += new System.EventHandler(this.HostboxTextChanged);
            // 
            // userbox
            // 
            this.userbox.Location = new System.Drawing.Point(50, 188);
            this.userbox.Name = "userbox";
            this.userbox.Size = new System.Drawing.Size(92, 20);
            this.userbox.TabIndex = 4;
            this.userbox.Text = "xbox";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "User:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pass:";
            // 
            // passbox
            // 
            this.passbox.Location = new System.Drawing.Point(50, 214);
            this.passbox.Name = "passbox";
            this.passbox.Size = new System.Drawing.Size(92, 20);
            this.passbox.TabIndex = 4;
            this.passbox.Text = "xbox";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(148, 38);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(302, 251);
            this.treeView1.TabIndex = 5;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1MouseDoubleClick);
            this.treeView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TreeView1KeyPress);
            this.treeView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TreeView1KeyUp);
            // 
            // portbox
            // 
            this.portbox.Location = new System.Drawing.Point(50, 240);
            this.portbox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portbox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.portbox.Name = "portbox";
            this.portbox.Size = new System.Drawing.Size(92, 20);
            this.portbox.TabIndex = 6;
            this.portbox.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Port:";
            // 
            // savebtn
            // 
            this.savebtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.savebtn.Location = new System.Drawing.Point(12, 266);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(130, 23);
            this.savebtn.TabIndex = 7;
            this.savebtn.Text = "Save Settings";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.SaveBtnClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Selected Path:";
            // 
            // pathbox
            // 
            this.pathbox.Location = new System.Drawing.Point(95, 12);
            this.pathbox.Name = "pathbox";
            this.pathbox.Size = new System.Drawing.Size(355, 20);
            this.pathbox.TabIndex = 9;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 297);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(462, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(131, 17);
            this.status.Text = "Waiting for user input...";
            // 
            // conworker
            // 
            this.conworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ConworkerDoWork);
            this.conworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ConworkerRunWorkerCompleted);
            // 
            // disconnectbtn
            // 
            this.disconnectbtn.Enabled = false;
            this.disconnectbtn.Location = new System.Drawing.Point(12, 132);
            this.disconnectbtn.Name = "disconnectbtn";
            this.disconnectbtn.Size = new System.Drawing.Size(130, 23);
            this.disconnectbtn.TabIndex = 11;
            this.disconnectbtn.Text = "Disconnect";
            this.disconnectbtn.UseVisualStyleBackColor = true;
            this.disconnectbtn.Visible = false;
            this.disconnectbtn.Click += new System.EventHandler(this.DisconnectbtnClick);
            // 
            // FTPSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 319);
            this.Controls.Add(this.disconnectbtn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pathbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.portbox);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.passbox);
            this.Controls.Add(this.userbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hostbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Connectbtn);
            this.Controls.Add(this.transmode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(478, 357);
            this.Name = "FTPSettings";
            this.Text = "FTPSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FTPSettingsFormClosing);
            this.Load += new System.EventHandler(this.FTPSettingsLoad);
            this.transmode.ResumeLayout(false);
            this.transmode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portbox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox transmode;
        private System.Windows.Forms.RadioButton PASV;
        private System.Windows.Forms.RadioButton PORT;
        private System.Windows.Forms.RadioButton PASVEX;
        private System.Windows.Forms.Button Connectbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hostbox;
        private System.Windows.Forms.TextBox userbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passbox;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.NumericUpDown portbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pathbox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.ComponentModel.BackgroundWorker conworker;
        private System.Windows.Forms.Button disconnectbtn;
    }
}