using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnrealClassRenamer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RenamerController.Get().SetForm(this);
            
        }

        public void SetURLLabel(string url)
        {
            label_FolderURL.Text = url;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                RenamerController.Get().OnFolderSelected(dialog.SelectedPath);
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            RenamerController.Get().OnClickRename(textBox_OldClassName.Text, textBox_NewClassName.Text);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RenamerController.Get().RegenerateProject();
        }
    }
}
