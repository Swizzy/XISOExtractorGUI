namespace XISOExtractorGUI
{
    internal sealed partial class ExtractionResults
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
            this.resultbox = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // resultbox
            // 
            this.resultbox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.resultbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultbox.FullRowSelect = true;
            this.resultbox.GridLines = true;
            this.resultbox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.resultbox.Location = new System.Drawing.Point(0, 0);
            this.resultbox.MultiSelect = false;
            this.resultbox.Name = "resultbox";
            this.resultbox.Size = new System.Drawing.Size(653, 147);
            this.resultbox.TabIndex = 0;
            this.resultbox.UseCompatibleStateImageBehavior = false;
            this.resultbox.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Result";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Source";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Target";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Options";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Error Message";
            this.columnHeader5.Width = 99;
            // 
            // ExtractionResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(653, 147);
            this.Controls.Add(this.resultbox);
            this.Name = "ExtractionResults";
            this.Text = "ExtractionResults";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView resultbox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}