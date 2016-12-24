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
        private string inputNewFileName;
        private string inputNewFilePath;
        private string inputOldFileName;
        private string inputOldFilePath;
        private List<int> elementIndex;

        public bool InputEditHeaders { get { return inputEditHeaders; } }
        public int LineAmount { get { return lineAmount; } }
        public string InputNewFileName { get { return inputNewFileName; } } //; set; } = "newData.csv";
        public string InputNewFilePath { get { return inputNewFilePath; } }
        public string InputOldFileName { get { return inputOldFileName; } } //; set; } = "rawData.csv";
        public string InputOldFilePath { get { return inputOldFilePath; } }
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
                inputOldFilePath = openFileDialog1.FileName;
                inputOldFileName = ExtractFileName(inputOldFilePath);
            }
        }

        private void btnNewFileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult openFileResult = saveFileDialog1.ShowDialog();
            if (openFileResult == DialogResult.OK)
            {
                inputNewFilePath = saveFileDialog1.FileName;
                inputNewFileName = ExtractFileName(inputNewFilePath);
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
                showOldFilePath + inputOldFilePath + "\n" +
                showNewFilePath + inputNewFilePath,
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

        private string ExtractFileName(string filePath)
        {
            // If path ends with a "\", it's a path only so return String.Empty.
            if (filePath.Trim().EndsWith(@"\"))
            {
                return string.Empty;
            }

            int position = filePath.LastIndexOf('\\');
            if (position == -1)
            {
                // Determine whether file exists in the current directory.
                if (File.Exists(Environment.CurrentDirectory + Path.DirectorySeparatorChar + filePath))
                {
                    return filePath;
                }
                else
                {
                    return String.Empty;
                }
            }
            else
            {
                // Determine whether file exists using filepath.
                if (File.Exists(filePath))
                {
                    // Return filename without file path.
                    return filePath.Substring(position + 1);
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}