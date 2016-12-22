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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExeInputForm
            // 
            this.btnExeInputForm.CausesValidation = false;
            this.btnExeInputForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExeInputForm.Location = new System.Drawing.Point(101, 226);
            this.btnExeInputForm.Name = "btnExeInputForm";
            this.btnExeInputForm.Size = new System.Drawing.Size(75, 23);
            this.btnExeInputForm.TabIndex = 5;
            this.btnExeInputForm.Text = "Submit";
            this.btnExeInputForm.UseVisualStyleBackColor = true;
            this.btnExeInputForm.Click += new System.EventHandler(this.btnExeInputForm_Click);
            // 
            // txtLineAmount
            // 
            this.txtLineAmount.Location = new System.Drawing.Point(106, 62);
            this.txtLineAmount.Name = "txtLineAmount";
            this.txtLineAmount.Size = new System.Drawing.Size(100, 20);
            this.txtLineAmount.TabIndex = 1;
            // 
            // lblLineAmount
            // 
            this.lblLineAmount.AutoSize = true;
            this.lblLineAmount.Location = new System.Drawing.Point(45, 66);
            this.lblLineAmount.Name = "lblLineAmount";
            this.lblLineAmount.Size = new System.Drawing.Size(55, 13);
            this.lblLineAmount.TabIndex = 0;
            this.lblLineAmount.Text = "Total lines";
            // 
            // lblElementIndex
            // 
            this.lblElementIndex.AutoSize = true;
            this.lblElementIndex.Location = new System.Drawing.Point(45, 91);
            this.lblElementIndex.Name = "lblElementIndex";
            this.lblElementIndex.Size = new System.Drawing.Size(47, 13);
            this.lblElementIndex.TabIndex = 0;
            this.lblElementIndex.Text = "Columns";
            // 
            // txtElementIndex
            // 
            this.txtElementIndex.Location = new System.Drawing.Point(106, 87);
            this.txtElementIndex.Name = "txtElementIndex";
            this.txtElementIndex.Size = new System.Drawing.Size(100, 20);
            this.txtElementIndex.TabIndex = 2;
            // 
            // radioEditHeaders
            // 
            this.radioEditHeaders.AutoCheck = false;
            this.radioEditHeaders.AutoSize = true;
            this.radioEditHeaders.CausesValidation = false;
            this.radioEditHeaders.Location = new System.Drawing.Point(45, 23);
            this.radioEditHeaders.Name = "radioEditHeaders";
            this.radioEditHeaders.Size = new System.Drawing.Size(86, 17);
            this.radioEditHeaders.TabIndex = 0;
            this.radioEditHeaders.TabStop = true;
            this.radioEditHeaders.Text = "Edit Headers";
            this.radioEditHeaders.UseVisualStyleBackColor = true;
            // 
            // lblOldFilePath
            // 
            this.lblOldFilePath.AutoSize = true;
            this.lblOldFilePath.Location = new System.Drawing.Point(20, 153);
            this.lblOldFilePath.Name = "lblOldFilePath";
            this.lblOldFilePath.Size = new System.Drawing.Size(72, 13);
            this.lblOldFilePath.TabIndex = 0;
            this.lblOldFilePath.Text = "Read from file";
            // 
            // txtOldFilePath
            // 
            this.txtOldFilePath.Location = new System.Drawing.Point(98, 149);
            this.txtOldFilePath.Name = "txtOldFilePath";
            this.txtOldFilePath.Size = new System.Drawing.Size(100, 20);
            this.txtOldFilePath.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FileReadWriteGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
    }
}