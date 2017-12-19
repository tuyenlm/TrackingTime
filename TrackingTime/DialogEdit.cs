using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TrackingTime
{
    public partial class DialogEdit : Form
    {
        private readonly Form1 _mainForm;
        private string _linkFile;
        public DialogEdit()
        {
            InitializeComponent();
        }
        public DialogEdit(Form callingForm)
        {
            _mainForm = callingForm as Form1;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = GetLink();
            UTF8Encoding utf8 = new UTF8Encoding();
            StreamWriter sw = new StreamWriter(path, false, utf8);
            sw.Write(richTxtEdit.Text);
            sw.Close();
            _mainForm.ChangeComboBox();
            Close();
        }
        public void SetLink(string link)
        {
            _linkFile = link;
        }
        private string GetLink()
        {
            return _linkFile;
        }
    }
}
