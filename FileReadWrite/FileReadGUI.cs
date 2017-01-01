using System;
using System.Windows.Forms;

namespace FileReadWrite
{
    partial class FileReadGUI : FileReadWriteGUI
    {
        private string oldFileName;
        private string oldFilePath;

        public FileReadGUI()
        {
            InitializeComponent();
            ShowDialog();
        }

        public string OldFileName { get { return oldFileName; } }
        public string OldFilePath { get { return oldFilePath; } }

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

                Close();
            }
        }

    }
}
