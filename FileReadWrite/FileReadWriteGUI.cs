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
        private string inputElementIndex;
        private string inputLineAmount;
        private string fileName;
        private string filePath;
        private string fileSource;
        private string oldFilePath;
        private string oldFileName;
        private string newFilePath;
        private string newFileName;
        private List<int> elementIndex;

        public bool InputEditHeaders { get { return inputEditHeaders; } }
        public int LineAmount { get { return lineAmount; } }
        public string NewFileName { get { return newFileName; } }
        public string NewFilePath { get { return newFilePath; } }
        public string OldFileName { get { return oldFileName; } }
        public string OldFilePath { get { return oldFilePath; } }
        public List<int> ElementIndex { get { return elementIndex; } }

        public void CallbackGUI()
        {
            InitializeComponent();
            ShowDialog();
        }

        private void btnOldFileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult openFileResult = openFileDialog1.ShowDialog();
            if (openFileResult == DialogResult.OK)
            {
                fileSource = openFileDialog1.FileName;
                ExtractFileName(fileSource);
                oldFileName = fileName;
                oldFilePath = filePath;
            }
        }

        private void btnNewFileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult openFileResult = saveFileDialog1.ShowDialog();
            if (openFileResult == DialogResult.OK)
            {
                fileSource = saveFileDialog1.FileName;
                ExtractFileName(fileSource);
                newFileName = fileName;
                newFilePath = filePath;
            }
        }

        private void btnExeInputForm_Click(object sender, EventArgs e)
        {
            string caption = "Confirm";
            string showEditHeaders = "Edit Headers: ";
            string showElementIndex = "Columns: ";
            string showLineAmount = "Total lines: ";
            string showOldFilePath = "File from: ";
            string showNewFilePath = "Save to: ";
            List<string> elementList;
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            inputEditHeaders = radioEditHeaders.Checked;
            inputLineAmount = txtLineAmount.Text;
            inputElementIndex = txtElementIndex.Text;
            inputLineAmount = string.IsNullOrEmpty(inputLineAmount) ? "0" : inputLineAmount;
            inputElementIndex = string.IsNullOrEmpty(inputElementIndex) ? "0" : inputElementIndex;

            result = MessageBox.Show(
                showEditHeaders + inputEditHeaders + "\n" +
                showLineAmount + inputLineAmount + "\n" +
                showElementIndex + inputElementIndex+ "\n" +
                showOldFilePath + oldFilePath + "\n" +
                showNewFilePath + newFilePath,
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

        private void ExtractFileName(string inPath)
        {
            int position = inPath.LastIndexOf('\\');

            fileName = inPath.Substring(position + 1);
            filePath = inPath.Substring(0, (inPath.Length - fileName.Length));
        }
    }
}