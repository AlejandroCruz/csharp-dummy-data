using System;
using System.Windows.Forms;

namespace FileReadWrite
{
    public partial class FileReadWriteGUI : Form
    {
        string tmpInputStr;

        public FileReadWriteGUI()
        {}

        public int CallbackGUI()
        {
            InitializeComponent();
            return int.Parse(tmpInputStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tmpInputStr = txtLineAmount.Text;
            MessageBox.Show("Input: " + tmpInputStr);
        }
    }
}
