namespace BusinessManagementSoftware
{
    partial class BMSoftware3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BMSoftware3));
            this.lstBoxReport = new System.Windows.Forms.ListBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.SuspendLayout();
            // 
            // lstBoxReport
            // 
            this.lstBoxReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxReport.Font = new System.Drawing.Font("David", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lstBoxReport.FormattingEnabled = true;
            this.lstBoxReport.ItemHeight = 19;
            this.lstBoxReport.Location = new System.Drawing.Point(0, 0);
            this.lstBoxReport.Name = "lstBoxReport";
            this.lstBoxReport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lstBoxReport.ScrollAlwaysVisible = true;
            this.lstBoxReport.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstBoxReport.Size = new System.Drawing.Size(874, 473);
            this.lstBoxReport.TabIndex = 0;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // BMSoftware3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 473);
            this.Controls.Add(this.lstBoxReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BMSoftware3";
            this.Text = "BMSsoftware3";
            this.Load += new System.EventHandler(this.BMSsoftware3_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Drawing.Printing.PrintDocument printDocument1;
        public System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        public System.Windows.Forms.ListBox lstBoxReport;
    }
}