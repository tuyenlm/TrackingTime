using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TrackingTime
{
    public partial class Form1 : Form
    {
        private readonly string _imageLink2 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\images\";
        private static readonly string LogFileLink2 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\files\";
        private ToolStripMenuItem _closeMenuItem;
        private const int WmNchittest = 0x84;
        private const int Htclient = 0x1;
        private const int Htcaption = 0x2;
        private readonly int _heightOrigin;
        private Boolean _hide = true;
        public Form1()
        {
            InitializeComponent();
            InitializeTrayIcon();
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            var add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
	        if (add != null)
	        {
		        add.SetValue("TrackingTime",
			        Application.StartupPath + @"\" + Process.GetCurrentProcess().ProcessName + ".exe");
		        if (add.GetValue("TrackingTime") == null)
			        add.SetValue("TrackingTime",
				        Application.StartupPath + @"\" + Process.GetCurrentProcess().ProcessName + ".exe");
	        }
	        createData("start");
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
            Application.ApplicationExit += OnApplicationExit;
            _heightOrigin = Height;
            var rcScreen = Screen.PrimaryScreen.WorkingArea;
            Location = new Point((rcScreen.Left + rcScreen.Right) / 2 - Width / 2, 50);
            InitializeComboBox();
            btnClose.TabStop = btnMinimum.TabStop = false;
            btnClose.FlatStyle = btnMinimum.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = btnMinimum.FlatAppearance.BorderSize = 0;
            SystemEvents.SessionEnding += SystemEvents_SessionEnded;
        }
        void SystemEvents_SessionEnded(object sender, SessionEndingEventArgs e)
        {
            if (e.Reason == SessionEndReasons.SystemShutdown || e.Reason == SessionEndReasons.Logoff)
            {
                createData("shutdown");
            }
        }
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);
            if (message.Msg == WmNchittest && (int)message.Result == Htclient)
                message.Result = (IntPtr)Htcaption;
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
            DirectoryInfo d = new DirectoryInfo(LogFileLink2);
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
            ChangeComboBox();
        }
        public void ChangeComboBox()
        {
            listViewTime.Items.Clear();
            string yearC = comboBoxYear.SelectedItem.ToString();
            string monthC = comboBoxMonth.SelectedItem.ToString();
            if (yearC != string.Empty && monthC != string.Empty)
            {
                string path = LogFileLink2 + Environment.GetEnvironmentVariable("UserName") + "_" + yearC + "_" + monthC + ".txt";
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);
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
            TrayIcon.Icon = new Icon(_imageLink2 + "time-ico2.ico");
            //Optional - Add a context menu to the TrayIcon:
            _closeMenuItem = new ToolStripMenuItem();
            TrayIconContextMenu.SuspendLayout();
            // 
            // TrayIconContextMenu
            // 
            TrayIconContextMenu.Items.AddRange(new ToolStripItem[] {
            _closeMenuItem});
            TrayIconContextMenu.Name = "TrayIconContextMenu";
            TrayIconContextMenu.Size = new Size(153, 70);
            // 
            // CloseMenuItem
            // 
            _closeMenuItem.Name = "CloseMenuItem";
            _closeMenuItem.Size = new Size(152, 22);
            _closeMenuItem.Text = @"トレイアイコンプログラムを閉じる";
            _closeMenuItem.Click += CloseMenuItem_Click;
            TrayIconContextMenu.ResumeLayout(false);
            TrayIcon.ContextMenuStrip = TrayIconContextMenu;
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"アプリケーションを終了しますか？", @"閉じる", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
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
            Timer tmrr = new Timer
            {
                Interval = 1000//ticks every 1 second
            };
            tmrr.Tick += tmr_Tick;
            tmrr.Stop();
        }

        private void createData(string status)
        {
            try
            {
                string yearNow = DateTime.Now.ToString("yyyy");
                string monthNow = DateTime.Now.ToString("MM");
                string dayNow = DateTime.Now.ToString("dd");
                string hourNow = DateTime.Now.ToString("HH");
                string minNow = DateTime.Now.ToString("mm");
                string path = LogFileLink2 + Environment.GetEnvironmentVariable("UserName") + "_" + yearNow + "_" + monthNow + ".txt";
                string timeD = yearNow + "-" + monthNow + "-" + dayNow;
                string timeH = hourNow + ":" + minNow;
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
                            string s;
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
                            string s;
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
            if (_hide)
            {
                btnViewLog.Text = @"Hide";
                ChangeComboBox();
            }
            else btnViewLog.Text = @"Show";
            timerSlide.Start();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                TrayIcon.Visible = true;
                Hide();
            }
            else if (FormWindowState.Normal == WindowState)
            {
                TrayIcon.Visible = false;
            }
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                WindowState = FormWindowState.Minimized;
                Hide();
            }
        }

        private void timerSlide_Tick(object sender, EventArgs e)
        {
            if (_hide)
            {
                Rectangle rcScreen = Screen.PrimaryScreen.WorkingArea;
                Height += 24;
                listViewTime.Height += 21;
                if (Height >= (rcScreen.Bottom - 100 - _heightOrigin))
                {
                    timerSlide.Stop();
                    Refresh();
                    _hide = false;
                }
            }
            else
            {
                Height -= 24;
                listViewTime.Height -= 21;
                if (Height <= _heightOrigin)
                {
                    timerSlide.Stop();
                    Refresh();
                    _hide = true;
                }
            }
        }

        private void comboBoxMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ChangeComboBox();
        }

        private void comboBoxYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ChangeComboBox();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string yearC = comboBoxYear.SelectedItem.ToString();
            string monthC = comboBoxMonth.SelectedItem.ToString();
            string fileName = Environment.GetEnvironmentVariable("UserName") + "_" + yearC + "_" + monthC + ".txt";
            string sourcePath = LogFileLink2;
            string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\追跡時間\";
            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            File.Copy(sourceFile, destFile, true);
        }

        private void listViewTime_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listViewTime.Columns[e.ColumnIndex].Width;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogEdit dialogEdit = new DialogEdit(this);
            string yearC = comboBoxYear.SelectedItem.ToString();
            string monthC = comboBoxMonth.SelectedItem.ToString();
            string path = LogFileLink2 + Environment.GetEnvironmentVariable("UserName") + "_" + yearC + "_" + monthC + ".txt";
            dialogEdit.lblNameFileEdit.Text = yearC + @"-" + monthC;
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    dialogEdit.richTxtEdit.Text += s + '\n';
                }
            }
            dialogEdit.SetLink(path);
            Rectangle rcScreen = Screen.PrimaryScreen.WorkingArea;
            dialogEdit.Location = new Point(Location.X + 300, Location.Y);
            if ((rcScreen.Right - dialogEdit.Location.X) > 200) dialogEdit.Location = new Point(Location.X + 300, Location.Y);
            else dialogEdit.Location = new Point(Location.X - 250, Location.Y);
            dialogEdit.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(@"アプリケーションを終了しますか？", @"閉じる", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
                TrayIcon.Visible = false;
            }
        }

        private void btnMinimum_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Hide();
        }
    }
}