using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileReadWrite
{
    partial class FileWriteGUI : FileReadWriteGUI
    {
        private bool inputEditHeaders;
        private int lineAmount;
        private string inputElementIndex;
        private string inputLineAmount;
        private string newFileName;
        private string newFilePath;
        private List<int> elementIndex;

        public bool InputEditHeaders { get { return inputEditHeaders; } }
        public int LineAmount { get { return lineAmount; } }
        public string NewFileName { get { return newFileName; } }
        public string NewFilePath { get { return newFilePath; } }

        public List<int> ElementIndex { get { return elementIndex; } }

        public void CallbackGUI()
        {
            InitializeComponent();
            ShowDialog();
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
            showNewFilePath = "Save to: ";
            buttons = MessageBoxButtons.OKCancel;
            icon = MessageBoxIcon.Information;

            result = MessageBox.Show(
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

        private void txtLineAmount_TextChanged(object sender, EventArgs e)
        {
            // Validate only numbers
        }
    }
}