using System;
using System.Windows.Forms;

namespace FileReadWrite
{
    public partial class FileReadWriteGUI : Form
    {
        private string tmpInputStr;

        public int CallbackGUI()
        {
            InitializeComponent();
            ShowDialog();
            return int.Parse(tmpInputStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tmpInputStr = txtLineAmount.Text;
            tmpInputStr = (string.IsNullOrEmpty(tmpInputStr)) ? "0" : tmpInputStr;
            Close();
            //MessageBox.Show("Input: " + tmpInputStr);
        }
    }
}