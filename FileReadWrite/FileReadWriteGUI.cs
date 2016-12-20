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

        private void btnExeInputForm_Click(object sender, EventArgs e)
        {
            string message = "Input: ";
            string caption = "Confirm";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            inputStr = txtLineAmount.Text;
            inputStr = (string.IsNullOrEmpty(inputStr)) ? "0" : inputStr;

            result = MessageBox.Show(message + inputStr, caption, buttons);

            if (result == DialogResult.OK)
            {
                Close();
            }
        }
    }
}