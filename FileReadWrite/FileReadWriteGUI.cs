using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileReadWrite
{
    public partial class FileReadWriteGUI : Form
    {

        private bool inputEditHeaders;
        private int lineAmount;
        private string inputElementIndex;
        private string inputLineAmount;
        private string inputNewFileName;
        private string inputNewFilePath;
        private string inputOldFileName;
        private string inputOldFilePath;
        private List<int> elementIndex;

        public bool InputEditHeaders { get; } // { return inputEditHeaders; } }
        public int LineAmount { get; } // { return lineAmount; } }
        public string InputNewFileName { get; set; } = "newData.csv";
        public string InputNewFilePath { get { return inputNewFilePath; } }
        public string InputOldFileName { get; set; } = "rawData.csv";
        public string InputOldFilePath { get { return inputOldFilePath; } }
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
            string showElementIndex = "Columns: ";
            string showLineAmount = "Total lines: ";
            string showNewFilePath = "Save to: ";
            string showOldFilePath = "File from: ";
            List<string> elementList;
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;


            inputEditHeaders = radioEditHeaders.Checked;
            inputLineAmount = txtLineAmount.Text;
            inputElementIndex = txtElementIndex.Text;
            inputOldFilePath = txtOldFilePath.Text;
            inputLineAmount = (string.IsNullOrEmpty(inputLineAmount)) ? "0" : inputLineAmount;
            inputElementIndex = (string.IsNullOrEmpty(inputElementIndex)) ? "0" : inputElementIndex;
            inputOldFilePath = (string.IsNullOrEmpty(inputElementIndex)) ? @"C:\" : inputOldFilePath;

            result = MessageBox.Show(
                showOldFilePath + inputOldFilePath + "\n" +
                showNewFilePath + inputNewFilePath + "\n" +
                showEditHeaders + inputEditHeaders + "\n" +
                showLineAmount + inputLineAmount + "\n" +
                showElementIndex + inputElementIndex,
                caption, buttons, MessageBoxIcon.Information
                );

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

        private void btnOldFileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult openFileResult = openFileDialog1.ShowDialog();
            if (openFileResult == DialogResult.OK)
            {
                txtOldFilePath.Clear();
                inputOldFilePath = openFileDialog1.SafeFileName;
                txtOldFilePath.Text = inputOldFilePath;
            }
            else if(openFileResult == DialogResult.Cancel)
            {
                txtOldFilePath.Clear();
            }
        }

        private void btnNewFileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult openFileResult = saveFileDialog1.ShowDialog();
            if (openFileResult == DialogResult.OK)
            {
                txtNewFilePath.Clear();
                inputNewFilePath = ;
                txtNewFilePath.Text = inputNewFilePath;
            }
            else if (openFileResult == DialogResult.Cancel)
            {
                txtNewFilePath.Clear();
            }
        }
    }
}