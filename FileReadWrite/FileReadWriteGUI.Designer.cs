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
            this.SuspendLayout();
            // 
            // btnExeInputForm
            // 
            this.btnExeInputForm.CausesValidation = false;
            this.btnExeInputForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExeInputForm.Location = new System.Drawing.Point(101, 226);
            this.btnExeInputForm.Name = "btnExeInputForm";
            this.btnExeInputForm.Size = new System.Drawing.Size(75, 23);
            this.btnExeInputForm.TabIndex = 2;
            this.btnExeInputForm.Text = "Submit";
            this.btnExeInputForm.UseVisualStyleBackColor = true;
            this.btnExeInputForm.Click += new System.EventHandler(this.btnExeInputForm_Click);
            // 
            // txtLineAmount
            // 
            this.txtLineAmount.Location = new System.Drawing.Point(130, 103);
            this.txtLineAmount.Name = "txtLineAmount";
            this.txtLineAmount.Size = new System.Drawing.Size(100, 20);
            this.txtLineAmount.TabIndex = 0;
            // 
            // lblLineAmount
            // 
            this.lblLineAmount.AutoSize = true;
            this.lblLineAmount.Location = new System.Drawing.Point(69, 107);
            this.lblLineAmount.Name = "lblLineAmount";
            this.lblLineAmount.Size = new System.Drawing.Size(55, 13);
            this.lblLineAmount.TabIndex = 2;
            this.lblLineAmount.Text = "Total lines";
            // 
            // lblElementIndex
            // 
            this.lblElementIndex.AutoSize = true;
            this.lblElementIndex.Location = new System.Drawing.Point(69, 132);
            this.lblElementIndex.Name = "lblElementIndex";
            this.lblElementIndex.Size = new System.Drawing.Size(47, 13);
            this.lblElementIndex.TabIndex = 3;
            this.lblElementIndex.Text = "Columns";
            // 
            // txtElementIndex
            // 
            this.txtElementIndex.Location = new System.Drawing.Point(130, 128);
            this.txtElementIndex.Name = "txtElementIndex";
            this.txtElementIndex.Size = new System.Drawing.Size(100, 20);
            this.txtElementIndex.TabIndex = 1;
            // 
            // radioEditHeaders
            // 
            this.radioEditHeaders.AutoSize = true;
            this.radioEditHeaders.CausesValidation = false;
            this.radioEditHeaders.Location = new System.Drawing.Point(69, 64);
            this.radioEditHeaders.Name = "radioEditHeaders";
            this.radioEditHeaders.Size = new System.Drawing.Size(86, 17);
            this.radioEditHeaders.TabIndex = 5;
            this.radioEditHeaders.TabStop = true;
            this.radioEditHeaders.Text = "Edit Headers";
            this.radioEditHeaders.UseVisualStyleBackColor = true;
            // 
            // FileReadWriteGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
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
    }
}