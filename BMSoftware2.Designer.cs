using System;
using System.Drawing;
using System.Windows.Forms;

namespace BusinessManagementSoftware
{
    partial class BMSoftware2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BMSoftware2));
            this.btnDraft = new System.Windows.Forms.Button();
            this.lblDraft = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDraft
            // 
            this.btnDraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDraft.Location = new System.Drawing.Point(77, 178);
            this.btnDraft.Name = "btnDraft";
            this.btnDraft.Size = new System.Drawing.Size(187, 39);
            this.btnDraft.TabIndex = 1;
            this.btnDraft.Text = "לחץ להצגת הדו\"ח";
            this.btnDraft.UseVisualStyleBackColor = true;
            this.btnDraft.Click += new System.EventHandler(this.btnDraft_Click);
            // 
            // lblDraft
            // 
            this.lblDraft.AutoSize = true;
            this.lblDraft.BackColor = System.Drawing.Color.Red;
            this.lblDraft.Font = new System.Drawing.Font("David", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblDraft.Location = new System.Drawing.Point(163, 159);
            this.lblDraft.Name = "lblDraft";
            this.lblDraft.Size = new System.Drawing.Size(0, 16);
            this.lblDraft.TabIndex = 25;
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.DropDownWidth = 135;
            this.cboYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.ItemHeight = 16;
            this.cboYear.Location = new System.Drawing.Point(199, 59);
            this.cboYear.Name = "cboYear";
            this.cboYear.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboYear.Size = new System.Drawing.Size(135, 24);
            this.cboYear.TabIndex = 26;
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.DropDownWidth = 135;
            this.cboMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.ItemHeight = 16;
            this.cboMonth.Location = new System.Drawing.Point(12, 59);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboMonth.Size = new System.Drawing.Size(135, 24);
            this.cboMonth.TabIndex = 27;
            // 
            // lblYear
            // 
            this.lblYear.Font = new System.Drawing.Font("David", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblYear.ForeColor = System.Drawing.Color.Black;
            this.lblYear.Location = new System.Drawing.Point(244, 33);
            this.lblYear.Name = "lblYear";
            this.lblYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblYear.Size = new System.Drawing.Size(54, 23);
            this.lblYear.TabIndex = 28;
            this.lblYear.Text = "שנה";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblMonth
            // 
            this.lblMonth.Font = new System.Drawing.Font("David", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblMonth.ForeColor = System.Drawing.Color.Black;
            this.lblMonth.Location = new System.Drawing.Point(48, 33);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMonth.Size = new System.Drawing.Size(54, 23);
            this.lblMonth.TabIndex = 29;
            this.lblMonth.Text = "חודש";
            this.lblMonth.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BMSoftware2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(341, 261);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.lblDraft);
            this.Controls.Add(this.btnDraft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BMSoftware2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "בחר תאריך";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblDraft;
        private Label lblYear;
        private Label lblMonth;
        public ComboBox cboYear;
        public ComboBox cboMonth;
        public Button btnDraft;
    }
}