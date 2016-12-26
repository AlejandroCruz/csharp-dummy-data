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
        private string PATH_WATERMARK;
        private string inputElementIndex;
        private string inputLineAmount;
        private string fileSource;
        private string newFileName;
        private string newFilePath;
        private string oldFileName;
        private string oldFilePath;
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
            PATH_WATERMARK = "C:\\";
            ShowDialog();
        }

        private void txtOldFilePath_Focus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(oldFileName))
            {
                txtOldFilePath.Clear();
            }
        }
        private void txtOldFilePath_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOldFilePath.Text))
            {
                txtOldFilePath.Text = PATH_WATERMARK;
            }
            else
            {
                string[] tmp = ExtractFileNameAndDirPath(txtOldFilePath.Text);
                oldFileName = tmp[0];
                oldFilePath = tmp[1];
            }
        }
        private void btnOldFileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult openFileResult = openFileDialog1.ShowDialog();
            if (openFileResult == DialogResult.OK)
            {
                fileSource = openFileDialog1.FileName;
                txtOldFilePath.Text = fileSource;
                string[] tmp = ExtractFileNameAndDirPath(fileSource);
                oldFileName = tmp[0];
                oldFilePath = tmp[1];
            }
        }

        private void txtNewFilePath_Focus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newFileName))
            {
                txtNewFilePath.Clear();
            }
        }
        private void txtNewFilePath_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewFilePath.Text))
            {
                txtNewFilePath.Text = PATH_WATERMARK;
            }
            else
            {
                string[] tmp = ExtractFileNameAndDirPath(txtNewFilePath.Text);
                newFileName = tmp[0];
                newFilePath = tmp[1];
            }
        }
        private void btnNewFileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult openFileResult = saveFileDialog1.ShowDialog();
            if (openFileResult == DialogResult.OK)
            {
                fileSource = saveFileDialog1.FileName;
                txtNewFilePath.Text = fileSource;
                string[] tmp = ExtractFileNameAndDirPath(fileSource);
                newFileName = tmp[0];
                newFilePath = tmp[1];
            }
        }

        private void btnExeInputForm_Click(object sender, EventArgs e)
        {
            string caption;
            string showEditHeaders;
            string showElementIndex;
            string showLineAmount;
            string showOldFilePath;
            string showNewFilePath;
            List<string> elementList;
            MessageBoxButtons buttons;
            MessageBoxIcon icon;
            DialogResult result;

            inputEditHeaders = radioEditHeaders.Checked;
            inputLineAmount = string.IsNullOrEmpty(txtLineAmount.Text) ? "0" : txtLineAmount.Text;
            inputElementIndex = string.IsNullOrEmpty(txtElementIndex.Text) ? "0" : txtElementIndex.Text;

            caption = "Confirm";
            showEditHeaders = "Edit Headers: ";
            showElementIndex = "Columns: ";
            showLineAmount = "Total lines: ";
            showOldFilePath = "File from: ";
            showNewFilePath = "Save to: ";
            buttons = MessageBoxButtons.OKCancel;
            icon = MessageBoxIcon.Information;

            result = MessageBox.Show(
                            showOldFilePath + oldFilePath + "\n" +
                            showNewFilePath + newFilePath + "\n" +
                            showEditHeaders + inputEditHeaders + "\n" +
                            showLineAmount + inputLineAmount + "\n" +
                            showElementIndex + inputElementIndex,
                            caption, buttons, icon
                            );

            if (result == DialogResult.OK)
            {
                lineAmount = int.Parse(inputLineAmount);
                elementIndex = new List<int>();
                elementList = new List<string>(ProcessLines.SplitValues(inputElementIndex, ','));

                for (int i = 0; i < elementList.Count; i++)
                {
                    elementIndex.Add(int.Parse(elementList[i]));
                }

                Close();
            }
        }

        private string[] ExtractFileNameAndDirPath(string sourcePath)
        {
            int position = sourcePath.LastIndexOf('\\');
            string[]  fileNameAndDirPath = new string[2];

            fileNameAndDirPath[0] = sourcePath.Substring(position + 1);
            fileNameAndDirPath[1] = sourcePath.Substring(0, (sourcePath.Length - fileNameAndDirPath[0].Length));

            return fileNameAndDirPath;
        }

    }
}