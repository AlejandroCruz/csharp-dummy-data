using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileReadWrite
{
    public partial class FileReadWriteGUI : Form
    {
        private bool inEditHeaders;
        private string inLineAmount;
        private string inElementIndex;
        private string inOldFilePath;
        private int lineAmount;
        private List<int> elementIndex;

        public bool EditHeaders { get { return inEditHeaders; } }
        public int LineAmount { get { return lineAmount; } }
        public List<int> ElementIndex { get { return elementIndex; } }

        public void CallbackGUI()
        {
            InitializeComponent();
            ShowDialog();
        }

        private void btnExeInputForm_Click(object sender, EventArgs e)
        {
            string caption = "Confirm";
            string showEditHeaders = "Edit Headers: ";
            string showLineAmount = "Total lines: ";
            string showElementIndex = "Columns: ";
            string showOldFilePath = "File from: ";
            List<string> elementList;
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            inEditHeaders = radioEditHeaders.Checked;
            inLineAmount = txtLineAmount.Text;
            inElementIndex = txtElementIndex.Text;
            inOldFilePath = txtOldFilePath.Text;
            inLineAmount = (string.IsNullOrEmpty(inLineAmount)) ? "0" : inLineAmount;
            inElementIndex = (string.IsNullOrEmpty(inElementIndex)) ? "0" : inElementIndex;
            inOldFilePath = (string.IsNullOrEmpty(inElementIndex)) ? TextLines.OldFilePath : inOldFilePath;

            result = MessageBox.Show(showEditHeaders + inEditHeaders + "\n" +
                showLineAmount + inLineAmount + "\n" +
                showElementIndex + inElementIndex + "\n" +
                showOldFilePath + inOldFilePath, caption, buttons, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                lineAmount = int.Parse(inLineAmount);
                elementIndex = new List<int>();
                elementList = new List<string>(ProcessLines.SplitValues(inElementIndex, ','));

                for (int i = 0; i < elementList.Count; i++)
                {
                    elementIndex.Add( int.Parse(elementList[i]) );
                }

                Close();
            }
        }
    }
}