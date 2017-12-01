using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace TrackingTime
{
    public partial class Form1 : Form
    {
        private string imageLink2 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\";
        private static string logFileLink2 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\files\";
        private ToolStripMenuItem CloseMenuItem;
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private int heightOrigin;
        private Boolean hide = true;
        public Form1()
        {
            InitializeComponent();
            InitializeTrayIcon();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            add.SetValue("TrackingTime", Application.StartupPath + @"\" + Process.GetCurrentProcess().ProcessName + ".exe");
            if (add.GetValue("TrackingTime") == null) add.SetValue("TrackingTime", Application.StartupPath + @"\" + Process.GetCurrentProcess().ProcessName + ".exe");
            createData("start");
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            heightOrigin = this.Height;
            Rectangle rcScreen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new System.Drawing.Point((rcScreen.Left + rcScreen.Right) / 2 - (this.Width / 2), 50);
            InitializeComboBox();
            btnClose.TabStop = btnMinimum.TabStop = false;
            btnClose.FlatStyle = btnMinimum.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = btnMinimum.FlatAppearance.BorderSize = 0;
            Microsoft.Win32.SystemEvents.SessionEnding += new Microsoft.Win32.SessionEndingEventHandler(SystemEvents_SessionEnded);
        }
        void SystemEvents_SessionEnded(object sender, Microsoft.Win32.SessionEndingEventArgs e)
        {
            if (e.Reason == SessionEndReasons.SystemShutdown || e.Reason == SessionEndReasons.Logoff)
            {
                createData("shutdown");
            }
        }
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);
            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }
        private void OnProcessExit(object sender, EventArgs e)
        {
            createData("shutdown");
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            createData("shutdown");
        }
        private void InitializeComboBox()
        {
            DirectoryInfo d = new DirectoryInfo(logFileLink2);
            List<string> yearCollection = new List<string>();
            List<string> monthCollection = new List<string>();
            foreach (var file in d.GetFiles("*.txt"))
            {
                string[] fileSp = file.Name.Split('.');
                string[] fileSp2 = fileSp[0].Split('_');
                yearCollection.Add(fileSp2[1]);
                monthCollection.Add(fileSp2[2]);
            }
            List<string> noDupesY = yearCollection.Distinct().ToList();
            List<string> noDupesM = monthCollection.Distinct().ToList();
            for (int i = 0; i < noDupesY.Count(); i++)
            {
                comboBoxYear.Items.Add(noDupesY[i]);
            }
            for (int i = 0; i < noDupesM.Count(); i++)
            {
                comboBoxMonth.Items.Add(noDupesM[i]);
            }
            comboBoxYear.SelectedIndex = comboBoxYear.Items.Count - 1;
            comboBoxMonth.SelectedIndex = comboBoxMonth.Items.Count - 1;
            changeComboBox();
        }
        public void changeComboBox()
        {
            listViewTime.Items.Clear();
            string yearC = comboBoxYear.SelectedItem.ToString();
            string monthC = comboBoxMonth.SelectedItem.ToString();
            if (yearC != string.Empty && monthC != string.Empty)
            {
                string path = logFileLink2 + System.Environment.GetEnvironmentVariable("UserName") + "_" + yearC + "_" + monthC + ".txt";
                if (File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(path);
                    ListViewItem item = new ListViewItem();
                    foreach (string line in lines)
                    {
                        string[] lineSp = line.Trim().Split('|');
                        if (lineSp.Count() < 3) item = new ListViewItem(new[] { lineSp[0], lineSp[1], "" });
                        else if (lineSp.Count() == 3) item = new ListViewItem(new[] { lineSp[0], lineSp[1], lineSp[2] });
                        listViewTime.Items.Add(item);
                    }
                    listViewTime.EnsureVisible(listViewTime.Items.Count - 1);
                    listViewTime.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    listViewTime.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
                else createData("start");
            }
            listViewTime.Refresh();
        }
        private void InitializeTrayIcon()
        {
            TrayIcon.Visible = true;
            //The icon is added to the project resources.
            //Here I assume that the name of the file is 'TrayIcon.ico'
            TrayIcon.Icon = new Icon(imageLink2 + "time-ico2.ico");
            //Optional - Add a context menu to the TrayIcon:
            CloseMenuItem = new ToolStripMenuItem();
            TrayIconContextMenu.SuspendLayout();
            // 
            // TrayIconContextMenu
            // 
            this.TrayIconContextMenu.Items.AddRange(new ToolStripItem[] {
            this.CloseMenuItem});
            this.TrayIconContextMenu.Name = "TrayIconContextMenu";
            this.TrayIconContextMenu.Size = new Size(153, 70);
            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.Size = new Size(152, 22);
            this.CloseMenuItem.Text = "トレイアイコンプログラムを閉じる";
            this.CloseMenuItem.Click += new EventHandler(this.CloseMenuItem_Click);
            TrayIconContextMenu.ResumeLayout(false);
            TrayIcon.ContextMenuStrip = TrayIconContextMenu;
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("アプリケーションを終了しますか？", "閉じる", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
                TrayIcon.Visible = false;
            }
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            txtHour.Text = DateTime.Now.ToString("HH");
            txtMin.Text = DateTime.UtcNow.ToString("mm");
            txtSecond.Text = DateTime.UtcNow.ToString("ss");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer tmr = new Timer
            {
                Interval = 1000//ticks every 1 second
            };
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Stop();
        }

        private void createData(string status)
        {
            try
            {
                string YearNow = DateTime.Now.ToString("yyyy");
                string MonthNow = DateTime.Now.ToString("MM");
                string DayNow = DateTime.Now.ToString("dd");
                string HourNow = DateTime.Now.ToString("HH");
                string MinNow = DateTime.Now.ToString("mm");
                string path = logFileLink2 + System.Environment.GetEnvironmentVariable("UserName") + "_" + YearNow + "_" + MonthNow + ".txt";
                string timeD = YearNow + "-" + MonthNow + "-" + DayNow;
                string timeH = HourNow + ":" + MinNow;
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(timeD + "|" + timeH);
                        sw.Close();
                    }
                }
                else
                {
                    if (status.Equals("shutdown"))
                    {
                        string result = "";
                        using (StreamReader sr = File.OpenText(path))
                        {
                            string s = "";
                            while ((s = sr.ReadLine()) != null)
                            {
                                string[] sSp = s.Split('|');
                                if (sSp[0].Equals(timeD))
                                {
                                    if (sSp.Count() > 2) result = sSp[0] + "|" + sSp[1] + "|" + sSp[2];
                                    else result = sSp[0] + "|" + sSp[1];
                                }
                            }
                            sr.Close();
                        }
                        string[] resultSp = result.Split('|');
                        string str = File.ReadAllText(path);
                        if (resultSp.Count() < 3) str = str.Replace(result, result + "|" + timeH);
                        else if (resultSp.Count() == 3) str = str.Replace(result, resultSp[0] + "|" + resultSp[1] + "|" + timeH);
                        File.WriteAllText(path, str);
                    }
                    else
                    {
                        bool sts = false;
                        using (StreamReader sr = File.OpenText(path))
                        {
                            string s = "";
                            while ((s = sr.ReadLine()) != null)
                            {
                                string[] sSp = s.Split('|');
                                if (sSp[0].Equals(timeD)) sts = true;
                            }
                            sr.Close();
                        }
                        if (!sts)
                        {
                            using (StreamWriter sw = File.AppendText(path))
                            {
                                sw.WriteLine(timeD + "|" + timeH);
                                sw.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            if (hide)
            {
                btnViewLog.Text = "Hide";
                changeComboBox();
            }
            else btnViewLog.Text = "Show";
            timerSlide.Start();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                TrayIcon.Visible = true;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                TrayIcon.Visible = false;
            }
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
        }

        private void timerSlide_Tick(object sender, EventArgs e)
        {
            if (hide)
            {
                Rectangle rcScreen = Screen.PrimaryScreen.WorkingArea;
                this.Height += 24;
                listViewTime.Height += 21;
                if (this.Height >= (rcScreen.Bottom - 100 - heightOrigin))
                {
                    timerSlide.Stop();
                    this.Refresh();
                    hide = false;
                }
            }
            else
            {
                this.Height -= 24;
                listViewTime.Height -= 21;
                if (this.Height <= heightOrigin)
                {
                    timerSlide.Stop();
                    this.Refresh();
                    hide = true;
                }
            }
        }

        private void comboBoxMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            changeComboBox();
        }

        private void comboBoxYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            changeComboBox();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string yearC = comboBoxYear.SelectedItem.ToString();
            string monthC = comboBoxMonth.SelectedItem.ToString();
            string fileName = System.Environment.GetEnvironmentVariable("UserName") + "_" + yearC + "_" + monthC + ".txt";
            string sourcePath = logFileLink2;
            string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\追跡時間\";
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }
            System.IO.File.Copy(sourceFile, destFile, true);
        }

        private void listViewTime_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewTime.Columns[e.ColumnIndex].Width;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogEdit DialogEdit = new DialogEdit(this);
            string yearC = comboBoxYear.SelectedItem.ToString();
            string monthC = comboBoxMonth.SelectedItem.ToString();
            string path = logFileLink2 + System.Environment.GetEnvironmentVariable("UserName") + "_" + yearC + "_" + monthC + ".txt";
            DialogEdit.lblNameFileEdit.Text = yearC + "-" + monthC;
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    DialogEdit.richTxtEdit.Text += s + "\n";
                }
            }
            DialogEdit.setLink(path);
            Rectangle rcScreen = Screen.PrimaryScreen.WorkingArea;
            DialogEdit.Location = new Point(this.Location.X + 300, this.Location.Y);
            if ((rcScreen.Right - DialogEdit.Location.X) > 200) DialogEdit.Location = new Point(this.Location.X + 300, this.Location.Y);
            else DialogEdit.Location = new Point(this.Location.X - 250, this.Location.Y);
            DialogEdit.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("アプリケーションを終了しますか？", "閉じる", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
                TrayIcon.Visible = false;
            }
        }

        private void btnMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }
    }
}