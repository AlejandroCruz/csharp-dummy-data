namespace FileReadWrite
{
    partial class FileWriteGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExeInputForm = new System.Windows.Forms.Button();
            this.txtLineAmount = new System.Windows.Forms.TextBox();
            this.lblLineAmount = new System.Windows.Forms.Label();
            this.lblElementIndex = new System.Windows.Forms.Label();
            this.txtElementIndex = new System.Windows.Forms.TextBox();
            this.radioEditHeaders = new System.Windows.Forms.RadioButton();
            this.lblNewFilePath = new System.Windows.Forms.Label();
            this.txtNewFilePath = new System.Windows.Forms.TextBox();
            this.btnNewFileBrowse = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblFilePathInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExeInputForm
            // 
            this.btnExeInputForm.CausesValidation = false;
            this.btnExeInputForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExeInputForm.Location = new System.Drawing.Point(151, 248);
            this.btnExeInputForm.Name = "btnExeInputForm";
            this.btnExeInputForm.Size = new System.Drawing.Size(75, 23);
            this.btnExeInputForm.TabIndex = 5;
            this.btnExeInputForm.Text = "Submit";
            this.btnExeInputForm.UseVisualStyleBackColor = true;
            this.btnExeInputForm.Click += new System.EventHandler(this.btnExeInputForm_Click);
            // 
            // txtLineAmount
            // 
            this.txtLineAmount.Location = new System.Drawing.Point(138, 145);
            this.txtLineAmount.Name = "txtLineAmount";
            this.txtLineAmount.Size = new System.Drawing.Size(100, 20);
            this.txtLineAmount.TabIndex = 1;
            this.txtLineAmount.TextChanged += new System.EventHandler(this.txtLineAmount_TextChanged);
            // 
            // lblLineAmount
            // 
            this.lblLineAmount.AutoSize = true;
            this.lblLineAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineAmount.Location = new System.Drawing.Point(60, 147);
            this.lblLineAmount.Name = "lblLineAmount";
            this.lblLineAmount.Size = new System.Drawing.Size(70, 16);
            this.lblLineAmount.TabIndex = 0;
            this.lblLineAmount.Text = "Total lines";
            // 
            // lblElementIndex
            // 
            this.lblElementIndex.AutoSize = true;
            this.lblElementIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElementIndex.Location = new System.Drawing.Point(60, 172);
            this.lblElementIndex.Name = "lblElementIndex";
            this.lblElementIndex.Size = new System.Drawing.Size(60, 16);
            this.lblElementIndex.TabIndex = 0;
            this.lblElementIndex.Text = "Columns";
            // 
            // txtElementIndex
            // 
            this.txtElementIndex.Location = new System.Drawing.Point(138, 170);
            this.txtElementIndex.Name = "txtElementIndex";
            this.txtElementIndex.Size = new System.Drawing.Size(100, 20);
            this.txtElementIndex.TabIndex = 2;
            // 
            // radioEditHeaders
            // 
            this.radioEditHeaders.AutoCheck = false;
            this.radioEditHeaders.AutoSize = true;
            this.radioEditHeaders.CausesValidation = false;
            this.radioEditHeaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioEditHeaders.Location = new System.Drawing.Point(63, 196);
            this.radioEditHeaders.Name = "radioEditHeaders";
            this.radioEditHeaders.Size = new System.Drawing.Size(105, 20);
            this.radioEditHeaders.TabIndex = 0;
            this.radioEditHeaders.TabStop = true;
            this.radioEditHeaders.Text = "Edit Headers";
            this.radioEditHeaders.UseVisualStyleBackColor = true;
            // 
            // lblNewFilePath
            // 
            this.lblNewFilePath.AutoSize = true;
            this.lblNewFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewFilePath.Location = new System.Drawing.Point(37, 88);
            this.lblNewFilePath.Name = "lblNewFilePath";
            this.lblNewFilePath.Size = new System.Drawing.Size(54, 16);
            this.lblNewFilePath.TabIndex = 0;
            this.lblNewFilePath.Text = "Save to";
            // 
            // txtNewFilePath
            // 
            this.txtNewFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewFilePath.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtNewFilePath.Location = new System.Drawing.Point(103, 86);
            this.txtNewFilePath.Name = "txtNewFilePath";
            this.txtNewFilePath.Size = new System.Drawing.Size(178, 20);
            this.txtNewFilePath.TabIndex = 0;
            this.txtNewFilePath.TabStop = false;
            this.txtNewFilePath.Text = " C:\\";
            this.txtNewFilePath.Enter += new System.EventHandler(this.txtNewFilePath_Focus);
            this.txtNewFilePath.Leave += new System.EventHandler(this.txtNewFilePath_Leave);
            // 
            // btnNewFileBrowse
            // 
            this.btnNewFileBrowse.Location = new System.Drawing.Point(287, 85);
            this.btnNewFileBrowse.Name = "btnNewFileBrowse";
            this.btnNewFileBrowse.Size = new System.Drawing.Size(52, 23);
            this.btnNewFileBrowse.TabIndex = 6;
            this.btnNewFileBrowse.Text = "Browse";
            this.btnNewFileBrowse.UseVisualStyleBackColor = true;
            this.btnNewFileBrowse.Click += new System.EventHandler(this.btnNewFileBrowse_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.saveFileDialog1.Title = "Create New File";
            // 
            // lblFilePathInfo
            // 
            this.lblFilePathInfo.AutoSize = true;
            this.lblFilePathInfo.CausesValidation = false;
            this.lblFilePathInfo.Enabled = false;
            this.lblFilePathInfo.Location = new System.Drawing.Point(37, 26);
            this.lblFilePathInfo.Name = "lblFilePathInfo";
            this.lblFilePathInfo.Size = new System.Drawing.Size(187, 13);
            this.lblFilePathInfo.TabIndex = 0;
            this.lblFilePathInfo.Text = "Include name of file in path or Browse:";
            // 
            // FileReadWriteGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 300);
            this.Controls.Add(this.lblFilePathInfo);
            this.Controls.Add(this.btnNewFileBrowse);
            this.Controls.Add(this.txtNewFilePath);
            this.Controls.Add(this.lblNewFilePath);
            this.Controls.Add(this.radioEditHeaders);
            this.Controls.Add(this.txtElementIndex);
            this.Controls.Add(this.lblElementIndex);
            this.Controls.Add(this.lblLineAmount);
            this.Controls.Add(this.txtLineAmount);
            this.Controls.Add(this.btnExeInputForm);
            this.Name = "FileReadWriteGUI";
            this.Text = "Input Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExeInputForm;
        private System.Windows.Forms.TextBox txtLineAmount;
        private System.Windows.Forms.Label lblLineAmount;
        private System.Windows.Forms.Label lblElementIndex;
        private System.Windows.Forms.TextBox txtElementIndex;
        private System.Windows.Forms.RadioButton radioEditHeaders;
        private System.Windows.Forms.Label lblNewFilePath;
        private System.Windows.Forms.TextBox txtNewFilePath;
        private System.Windows.Forms.Button btnNewFileBrowse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblFilePathInfo;
    }
}