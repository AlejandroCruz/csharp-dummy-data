﻿using System;
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
            txtOldFilePath.Text = " C:\\";
            txtNewFilePath.Text = " C:\\";
            ShowDialog();
        }

        private void txtOldFilePath_Focus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOldFilePath.Text))
            {
                txtOldFilePath.Clear();
            }
        }
        private void txtOldFilePath_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOldFilePath.Text))
            {
                txtOldFilePath.Text = "C:\\";
            }
        }
        private void btnOldFileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult openFileResult = openFileDialog1.ShowDialog();
            if (openFileResult == DialogResult.OK)
            {
                fileSource = openFileDialog1.FileName;
                txtOldFilePath.Text = fileSource;
                ExtractFileName(fileSource);
                oldFileName = fileName;
                oldFilePath = filePath;
            }
        }

        private void txtNewFilePath_Focus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewFilePath.Text))
            {
                txtNewFilePath.Clear();
            }
        }

        private void txtNewFilePath_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewFilePath.Text))
            {
                txtNewFilePath.Text = "C:\\";
            }
        }
        private void btnNewFileBrowse_Click(object sender, EventArgs e)
        {
            DialogResult openFileResult = saveFileDialog1.ShowDialog();
            if (openFileResult == DialogResult.OK)
            {
                fileSource = saveFileDialog1.FileName;
                txtNewFilePath.Text = fileSource;
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
            inputLineAmount = string.IsNullOrEmpty(txtLineAmount.Text) ? "0" : txtLineAmount.Text;
            inputElementIndex = string.IsNullOrEmpty(txtElementIndex.Text) ? "0" : txtElementIndex.Text;



            if (string.IsNullOrEmpty(txtOldFilePath.Text) || string.IsNullOrEmpty(txtNewFilePath.Text))
            {
                MessageBox.Show("Please add Read/Save file path.", caption, buttons, icon);
            }
            else if
            {
                result = MessageBox.Show(
                                showOldFilePath + oldFilePath + "\n" +
                                showNewFilePath + newFilePath + "\n" +
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
                        elementIndex.Add(int.Parse(elementList[i]));
                    }

                    Close();
                }
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