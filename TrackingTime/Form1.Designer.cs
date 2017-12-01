namespace TrackingTime
{
    partial class Form1
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
            this.txtHour = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtSecond = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.btnViewLog = new System.Windows.Forms.Button();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timerSlide = new System.Windows.Forms.Timer(this.components);
            this.btnCopy = new System.Windows.Forms.Button();
            this.listViewTime = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCheckIn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnMinimum = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtHour
            // 
            this.txtHour.BackColor = System.Drawing.Color.PaleGreen;
            this.txtHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHour.Enabled = false;
            this.txtHour.Font = new System.Drawing.Font("MS UI Gothic", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtHour.ForeColor = System.Drawing.SystemColors.Window;
            this.txtHour.Location = new System.Drawing.Point(11, 20);
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(74, 74);
            this.txtHour.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(88, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 67);
            this.label1.TabIndex = 1;
            this.label1.Text = ":";
            // 
            // txtMin
            // 
            this.txtMin.BackColor = System.Drawing.Color.PaleGreen;
            this.txtMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMin.Enabled = false;
            this.txtMin.Font = new System.Drawing.Font("MS UI Gothic", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtMin.Location = new System.Drawing.Point(105, 20);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(74, 74);
            this.txtMin.TabIndex = 2;
            // 
            // txtSecond
            // 
            this.txtSecond.BackColor = System.Drawing.Color.PaleGreen;
            this.txtSecond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecond.Enabled = false;
            this.txtSecond.Font = new System.Drawing.Font("MS UI Gothic", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSecond.Location = new System.Drawing.Point(199, 20);
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.Size = new System.Drawing.Size(74, 74);
            this.txtSecond.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(182, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 67);
            this.label2.TabIndex = 3;
            this.label2.Text = ":";
            // 
            // tmr
            // 
            this.tmr.Enabled = true;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // btnViewLog
            // 
            this.btnViewLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnViewLog.FlatAppearance.BorderSize = 0;
            this.btnViewLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewLog.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnViewLog.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnViewLog.Location = new System.Drawing.Point(11, 100);
            this.btnViewLog.Margin = new System.Windows.Forms.Padding(0);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(185, 35);
            this.btnViewLog.TabIndex = 7;
            this.btnViewLog.Text = "Show";
            this.btnViewLog.UseVisualStyleBackColor = false;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // TrayIcon
            // 
            this.TrayIcon.Text = "Tracking Time";
            this.TrayIcon.Visible = true;
            this.TrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            // 
            // TrayIconContextMenu
            // 
            this.TrayIconContextMenu.Name = "TrayIconContextMenu";
            this.TrayIconContextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // timerSlide
            // 
            this.timerSlide.Interval = 1;
            this.timerSlide.Tick += new System.EventHandler(this.timerSlide_Tick);
            // 
            // btnCopy
            // 
            this.btnCopy.AutoSize = true;
            this.btnCopy.BackColor = System.Drawing.Color.Gold;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCopy.Location = new System.Drawing.Point(134, 144);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(139, 24);
            this.btnCopy.TabIndex = 13;
            this.btnCopy.Text = "デスクトップにコピー";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // listViewTime
            // 
            this.listViewTime.BackColor = System.Drawing.Color.White;
            this.listViewTime.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colCheckIn,
            this.colEnd});
            this.listViewTime.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.listViewTime.ForeColor = System.Drawing.Color.Black;
            this.listViewTime.FullRowSelect = true;
            this.listViewTime.GridLines = true;
            this.listViewTime.HoverSelection = true;
            this.listViewTime.LabelWrap = false;
            this.listViewTime.Location = new System.Drawing.Point(9, 177);
            this.listViewTime.Margin = new System.Windows.Forms.Padding(0);
            this.listViewTime.Name = "listViewTime";
            this.listViewTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listViewTime.Scrollable = false;
            this.listViewTime.Size = new System.Drawing.Size(266, 34);
            this.listViewTime.TabIndex = 12;
            this.listViewTime.UseCompatibleStateImageBehavior = false;
            this.listViewTime.View = System.Windows.Forms.View.Details;
            this.listViewTime.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listViewTime_ColumnWidthChanging);
            // 
            // colDate
            // 
            this.colDate.Text = "日付";
            this.colDate.Width = 110;
            // 
            // colCheckIn
            // 
            this.colCheckIn.Text = "入室時間";
            this.colCheckIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCheckIn.Width = 75;
            // 
            // colEnd
            // 
            this.colEnd.Text = "退室時間";
            this.colEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colEnd.Width = 75;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(83, 144);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(40, 24);
            this.comboBoxMonth.TabIndex = 11;
            this.comboBoxMonth.SelectionChangeCommitted += new System.EventHandler(this.comboBoxMonth_SelectionChangeCommitted);
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYear.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(9, 144);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(63, 24);
            this.comboBoxYear.TabIndex = 10;
            this.comboBoxYear.SelectionChangeCommitted += new System.EventHandler(this.comboBoxYear_SelectionChangeCommitted);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEdit.Location = new System.Drawing.Point(199, 100);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(74, 35);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "編集";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnMinimum
            // 
            this.btnMinimum.FlatAppearance.BorderSize = 0;
            this.btnMinimum.Image = global::TrackingTime.Properties.Resources.substract;
            this.btnMinimum.Location = new System.Drawing.Point(234, -1);
            this.btnMinimum.Name = "btnMinimum";
            this.btnMinimum.Size = new System.Drawing.Size(20, 20);
            this.btnMinimum.TabIndex = 16;
            this.btnMinimum.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimum.UseVisualStyleBackColor = true;
            this.btnMinimum.Click += new System.EventHandler(this.btnMinimum_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Image = global::TrackingTime.Properties.Resources.close_button;
            this.btnClose.Location = new System.Drawing.Point(260, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 15;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 139);
            this.Controls.Add(this.btnMinimum);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.listViewTime);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.btnViewLog);
            this.Controls.Add(this.txtSecond);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHour);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "時間追跡 (JikanTsuiseki)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtSecond;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmr;
        private System.Windows.Forms.Button btnViewLog;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip TrayIconContextMenu;
        private System.Windows.Forms.Timer timerSlide;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colCheckIn;
        private System.Windows.Forms.ColumnHeader colEnd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.ListView listViewTime;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimum;
    }
}

