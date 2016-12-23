using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FileReadWrite
{
    public partial class FileReadWriteGUI : Form
    {

        private bool inputEditHeaders;
        private int lineAmount;
        private string inputLineAmount;
        private string inputElementIndex;
        private string inputOldFilePath;
        private List<int> elementIndex;

        public string OldFilePath { get; set; }
        public string NewFilePath { get; set; }
        public string OldFileName { get; } // = "rawData.csv";
        public string NewFileName { get; } // = "newData.csv";
        public bool EditHeaders { get { return inputEditHeaders; } }
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

            inputEditHeaders = radioEditHeaders.Checked;
            inputLineAmount = txtLineAmount.Text;
            inputElementIndex = txtElementIndex.Text;
            OldFilePath = txtOldFilePath.Text;
            inputLineAmount = (string.IsNullOrEmpty(inputLineAmount)) ? "0" : inputLineAmount;
            inputElementIndex = (string.IsNullOrEmpty(inputElementIndex)) ? "0" : inputElementIndex;
            inputOldFilePath = (string.IsNullOrEmpty(inputElementIndex)) ? @"C:\" : OldFilePath;

            result = MessageBox.Show(showEditHeaders + inputEditHeaders + "\n" +
                showLineAmount + inputLineAmount + "\n" +
                showElementIndex + inputElementIndex + "\n" +
                showOldFilePath + inputOldFilePath, caption, buttons, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                lineAmount = int.Parse(inputLineAmount);
                elementIndex = new List<int>();
                elementList = new List<string>(ProcessLines.SplitValues(inputElementIndex, ','));

                for (int i = 0; i < elementList.Count; i++)
                {
                    elementIndex.Add( int.Parse(elementList[i]) );
                }

                Close();
            }
        }

        private void btnOldFilePath_Click(object sender, EventArgs e)
        {
            DialogResult openFileResult = openFileDialog1.ShowDialog();
            if (openFileResult == DialogResult.OK)
            {
                txtOldFilePath.AppendText(openFileDialog1.ToString());
                //txtOldFilePath.Paste();
                inputOldFilePath = openFileDialog1.ToString();
            }
        }
    }
}