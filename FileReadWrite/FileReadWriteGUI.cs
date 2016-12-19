using System;
using System.Windows.Forms;

namespace FileReadWrite
{
    public partial class FileReadWriteGUI : Form
    {
        public FileReadWriteGUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tmpInputStr = txtLineAmount.Text;
            MessageBox.Show("Input: " + tmpInputStr);
            ActiveForm.Close();
        }
    }
}
