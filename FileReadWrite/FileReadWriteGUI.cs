using System;
using System.Windows.Forms;

namespace FileReadWrite
{
    public partial class FileReadWriteGUI : Form
    {
        private string inputStr;
        private int lineAmount;

        public int LineAmount { get { return lineAmount; } }

        public void CallbackGUI()
        {
            InitializeComponent();
            ShowDialog();
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
                lineAmount = int.Parse(inputStr);
                Close();
            }
        }
    }
}