using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileReadWrite
{
    public partial class FileReadWriteGUI : Form
    {
        string tmpInputStr = "0";

        public FileReadWriteGUI()
        {}

        public int CallbackGUI()
        {
            InitializeComponent();
            this.ShowDialog();
            return int.Parse(tmpInputStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tmpInputStr = txtLineAmount.Text;
            MessageBox.Show("Input: " + tmpInputStr);
        }
    }
}
