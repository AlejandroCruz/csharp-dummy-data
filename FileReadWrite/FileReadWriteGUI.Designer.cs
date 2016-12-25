namespace FileReadWrite
{
    partial class FileReadWriteGUI
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
            this.lblOldFilePath = new System.Windows.Forms.Label();
            this.txtOldFilePath = new System.Windows.Forms.TextBox();
            this.btnOldFileBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblNewFilePath = new System.Windows.Forms.Label();
            this.txtNewFilePath = new System.Windows.Forms.TextBox();
            this.btnNewFileBrowse = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnExeInputForm
            // 
            this.btnExeInputForm.CausesValidation = false;
            this.btnExeInputForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExeInputForm.Location = new System.Drawing.Point(153, 261);
            this.btnExeInputForm.Name = "btnExeInputForm";
            this.btnExeInputForm.Size = new System.Drawing.Size(75, 23);
            this.btnExeInputForm.TabIndex = 5;
            this.btnExeInputForm.Text = "Submit";
            this.btnExeInputForm.UseVisualStyleBackColor = true;
            this.btnExeInputForm.Click += new System.EventHandler(this.btnExeInputForm_Click);
            // 
            // txtLineAmount
            // 
            this.txtLineAmount.Location = new System.Drawing.Point(144, 187);
            this.txtLineAmount.Name = "txtLineAmount";
            this.txtLineAmount.Size = new System.Drawing.Size(100, 20);
            this.txtLineAmount.TabIndex = 1;
            // 
            // lblLineAmount
            // 
            this.lblLineAmount.AutoSize = true;
            this.lblLineAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineAmount.Location = new System.Drawing.Point(65, 189);
            this.lblLineAmount.Name = "lblLineAmount";
            this.lblLineAmount.Size = new System.Drawing.Size(70, 16);
            this.lblLineAmount.TabIndex = 0;
            this.lblLineAmount.Text = "Total lines";
            // 
            // lblElementIndex
            // 
            this.lblElementIndex.AutoSize = true;
            this.lblElementIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElementIndex.Location = new System.Drawing.Point(65, 214);
            this.lblElementIndex.Name = "lblElementIndex";
            this.lblElementIndex.Size = new System.Drawing.Size(60, 16);
            this.lblElementIndex.TabIndex = 0;
            this.lblElementIndex.Text = "Columns";
            // 
            // txtElementIndex
            // 
            this.txtElementIndex.Location = new System.Drawing.Point(144, 212);
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
            this.radioEditHeaders.Location = new System.Drawing.Point(65, 146);
            this.radioEditHeaders.Name = "radioEditHeaders";
            this.radioEditHeaders.Size = new System.Drawing.Size(105, 20);
            this.radioEditHeaders.TabIndex = 0;
            this.radioEditHeaders.TabStop = true;
            this.radioEditHeaders.Text = "Edit Headers";
            this.radioEditHeaders.UseVisualStyleBackColor = true;
            // 
            // lblOldFilePath
            // 
            this.lblOldFilePath.AutoSize = true;
            this.lblOldFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldFilePath.Location = new System.Drawing.Point(37, 46);
            this.lblOldFilePath.Name = "lblOldFilePath";
            this.lblOldFilePath.Size = new System.Drawing.Size(59, 16);
            this.lblOldFilePath.TabIndex = 0;
            this.lblOldFilePath.Text = "File from";
            // 
            // txtOldFilePath
            // 
            this.txtOldFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldFilePath.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtOldFilePath.Location = new System.Drawing.Point(103, 44);
            this.txtOldFilePath.Name = "txtOldFilePath";
            this.txtOldFilePath.Size = new System.Drawing.Size(178, 20);
            this.txtOldFilePath.TabIndex = 0;
            this.txtOldFilePath.TabStop = false;
            this.txtOldFilePath.Enter += new System.EventHandler(this.txtOldFilePath_Focus);
            this.txtOldFilePath.Leave += new System.EventHandler(this.txtOldFilePath_Leave);
            // 
            // btnOldFileBrowse
            // 
            this.btnOldFileBrowse.Location = new System.Drawing.Point(287, 43);
            this.btnOldFileBrowse.Name = "btnOldFileBrowse";
            this.btnOldFileBrowse.Size = new System.Drawing.Size(52, 23);
            this.btnOldFileBrowse.TabIndex = 6;
            this.btnOldFileBrowse.Text = "Browse";
            this.btnOldFileBrowse.UseVisualStyleBackColor = true;
            this.btnOldFileBrowse.Click += new System.EventHandler(this.btnOldFileBrowse_Click);
            // 
            // lblNewFilePath
            // 
            this.lblNewFilePath.AutoSize = true;
            this.lblNewFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewFilePath.Location = new System.Drawing.Point(37, 82);
            this.lblNewFilePath.Name = "lblNewFilePath";
            this.lblNewFilePath.Size = new System.Drawing.Size(54, 16);
            this.lblNewFilePath.TabIndex = 0;
            this.lblNewFilePath.Text = "Save to";
            // 
            // txtNewFilePath
            // 
            this.txtNewFilePath.Location = new System.Drawing.Point(103, 80);
            this.txtNewFilePath.Name = "txtNewFilePath";
            this.txtNewFilePath.Size = new System.Drawing.Size(178, 20);
            this.txtNewFilePath.TabIndex = 0;
            this.txtNewFilePath.TabStop = false;
            this.txtNewFilePath.Enter += new System.EventHandler(this.txtNewFilePath_Focus);
            this.txtNewFilePath.Leave += new System.EventHandler(this.txtNewFilePath_Leave);
            // 
            // btnNewFileBrowse
            // 
            this.btnNewFileBrowse.Location = new System.Drawing.Point(287, 79);
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
            // FileReadWriteGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 317);
            this.Controls.Add(this.btnNewFileBrowse);
            this.Controls.Add(this.txtNewFilePath);
            this.Controls.Add(this.btnOldFileBrowse);
            this.Controls.Add(this.lblNewFilePath);
            this.Controls.Add(this.txtOldFilePath);
            this.Controls.Add(this.lblOldFilePath);
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
        private System.Windows.Forms.Label lblOldFilePath;
        private System.Windows.Forms.TextBox txtOldFilePath;
        private System.Windows.Forms.Button btnOldFileBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblNewFilePath;
        private System.Windows.Forms.TextBox txtNewFilePath;
        private System.Windows.Forms.Button btnNewFileBrowse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}