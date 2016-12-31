using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FileReadWrite
{
    public partial class FileReadWriteGUI : Form
    {
        private const string PATH_WATERMARK = "C:\\";

        private bool inputEditHeaders;
        private int lineAmount;
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

                if (tmp[1].Equals("false"))
                {
                    txtOldFilePath.Text = PATH_WATERMARK;
                    MessageBox.Show("Directory not found!", "Warning", MessageBoxButtons.OK);
                }
                else
                {
                    oldFileName = tmp[0];
                    oldFilePath = tmp[1];
                }
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
            List<string> elementList;
            DialogResult result;

            inputEditHeaders = radioEditHeaders.Checked;
            inputLineAmount = string.IsNullOrEmpty(txtLineAmount.Text) ? "0" : txtLineAmount.Text;
            inputElementIndex = string.IsNullOrEmpty(txtElementIndex.Text) ? "0" : txtElementIndex.Text;

            result = MessageBox.Show(
                            "File from: " + oldFilePath + "\n" +
                            "Save to: " + newFilePath + "\n" +
                            "Edit Headers: " + inputEditHeaders + "\n" +
                            "Total lines: " + inputLineAmount + "\n" +
                            "Columns: " + inputElementIndex,
                            "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information
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

        public string[] ExtractFileNameAndDirPath(string sourcePath)
        {
            int position = sourcePath.LastIndexOf('\\');
            string[] fileNameAndDirPath = new string[2];

            fileNameAndDirPath[0] = sourcePath.Substring(position + 1);
            fileNameAndDirPath[1] = sourcePath.Substring(0, (sourcePath.Length - fileNameAndDirPath[0].Length));

            if (string.IsNullOrWhiteSpace(fileNameAndDirPath[1]))
            {
                fileNameAndDirPath[1] = "false";
            }

            return fileNameAndDirPath;
        }
    }
}