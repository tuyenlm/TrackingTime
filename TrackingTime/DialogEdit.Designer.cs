namespace TrackingTime
{
    partial class DialogEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogEdit));
            this.richTxtEdit = new System.Windows.Forms.RichTextBox();
            this.lblNameFileEdit = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTxtEdit
            // 
            this.richTxtEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTxtEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.richTxtEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTxtEdit.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.richTxtEdit.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.richTxtEdit.Location = new System.Drawing.Point(4, 36);
            this.richTxtEdit.Name = "richTxtEdit";
            this.richTxtEdit.Size = new System.Drawing.Size(185, 592);
            this.richTxtEdit.TabIndex = 0;
            this.richTxtEdit.Text = "";
            // 
            // lblNameFileEdit
            // 
            this.lblNameFileEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNameFileEdit.AutoSize = true;
            this.lblNameFileEdit.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblNameFileEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNameFileEdit.Location = new System.Drawing.Point(12, 8);
            this.lblNameFileEdit.Name = "lblNameFileEdit";
            this.lblNameFileEdit.Size = new System.Drawing.Size(49, 15);
            this.lblNameFileEdit.TabIndex = 1;
            this.lblNameFileEdit.Text = "label1";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.GreenYellow;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(114, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "更新";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DialogEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(194, 648);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblNameFileEdit);
            this.Controls.Add(this.richTxtEdit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(210, 200);
            this.Name = "DialogEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "編集";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.RichTextBox richTxtEdit;
        public System.Windows.Forms.Label lblNameFileEdit;
        private System.Windows.Forms.Button btnSave;
    }
}