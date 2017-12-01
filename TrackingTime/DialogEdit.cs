using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TrackingTime
{
    public partial class DialogEdit : Form
    {
        private Form1 mainForm = null;
        private string linkFile;
        public DialogEdit()
        {
            InitializeComponent();
        }
        public DialogEdit(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = getLink();
            UTF8Encoding utf8 = new UTF8Encoding();
            StreamWriter sw = new StreamWriter(path, false, utf8);
            sw.Write(richTxtEdit.Text);
            sw.Close();
            this.mainForm.changeComboBox();
            this.Close();
        }
        public void setLink(string link)
        {
            this.linkFile = link;
        }
        private string getLink()
        {
            return linkFile;
        }
    }
}
