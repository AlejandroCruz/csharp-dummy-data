using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileReadWrite
{
    public partial class FileReadWriteGUI : Form
    {
        private bool inEditHeaders;
        private string inLineAmount;
        private string inElementIndex;
        private int lineAmount;
        private List<int> elementIndex;

        public bool EditHeaders { get { return inEditHeaders; } }
        public int LineAmount { get { return lineAmount; } }
        public List<int> ElementIndex { get { return elementIndex; } }

        public void CallbackGUI()
        {
            InitializeComponent();
            ShowDialog();
        }

        private void btnExeInputForm_Click(object sender, EventArgs e)
        {
            string showEditHeaders = "Edit Headers: ";
            string showLineAmount = "Total lines: ";
            string showElementIndex = "Columns: ";
            string caption = "Confirm";
            List<string> elementList;
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            inEditHeaders = radioEditHeaders.Checked;
            inLineAmount = txtLineAmount.Text;
            inElementIndex = txtElementIndex.Text;
            inLineAmount = (string.IsNullOrEmpty(inLineAmount)) ? "0" : inLineAmount;
            inElementIndex = (string.IsNullOrEmpty(inElementIndex)) ? "0" : inElementIndex;

            result = MessageBox.Show(showEditHeaders + inEditHeaders + "\n" +
                showLineAmount + inLineAmount + "\n" +
                showElementIndex + inElementIndex, caption, buttons);

            if (result == DialogResult.OK)
            {
                lineAmount = int.Parse(inLineAmount);
                elementIndex = new List<int>();
                elementList = new List<string>(ProcessLines.SplitValues(inElementIndex, ','));

                for (int i = 0; i < elementList.Count; i++)
                {
                    var tmp = int.Parse(elementList[i]);
                    elementIndex.Add( tmp );
                }

                Close();
            }
        }
    }
}