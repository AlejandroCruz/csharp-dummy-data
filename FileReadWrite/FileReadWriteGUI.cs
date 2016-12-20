using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileReadWrite
{
    public partial class FileReadWriteGUI : Form
    {
        private string inLineAmount;
        private int lineAmount;
        private string inElementIndex;
        private List<int> elementIndex;

        public int LineAmount { get { return lineAmount; } }
        public List<int> ElementIndex { get { return elementIndex; } }

        public void CallbackGUI()
        {
            InitializeComponent();
            ShowDialog();
        }

        private void btnExeInputForm_Click(object sender, EventArgs e)
        {
            string showLineAmount = "Total lines: ";
            string showElementIndex = "Columns: ";
            string caption = "Confirm";
            List<string> elementList = new List<string>();
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            inLineAmount = txtLineAmount.Text;
            inElementIndex = txtElementIndex.Text;
            inLineAmount = (string.IsNullOrEmpty(inLineAmount)) ? "0" : inLineAmount;
            inElementIndex = (string.IsNullOrEmpty(inElementIndex)) ? "0" : inElementIndex;

            result = MessageBox.Show(showLineAmount + inLineAmount +
                    showElementIndex + inElementIndex, caption, buttons);

            if (result == DialogResult.OK)
            {
                lineAmount = int.Parse(inLineAmount);
                elementList = ProcessLines.SplitValues(inElementIndex, ',');

                for (int i = 0; i < elementList.Count; i++)
                {
                    elementIndex.Add( int.Parse(elementList[i]) );
                }
                Close();
            }
        }
    }
}