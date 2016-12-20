using System;
using System.Windows.Forms;

namespace FileReadWrite
{
    public partial class FileReadWriteGUI : Form
    {
        private string inputStr;

        public int CallbackGUI()
        {
            InitializeComponent();
            ShowDialog();
            return int.Parse(inputStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            inputStr = txtLineAmount.Text;
            inputStr = (string.IsNullOrEmpty(inputStr)) ? "0" : inputStr;
            Close();
            //MessageBox.Show("Input: " + tmpInputStr);
        }
    }
}