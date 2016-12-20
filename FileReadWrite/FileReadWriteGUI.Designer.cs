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
            this.SuspendLayout();
            // 
            // btnExeInputForm
            // 
            this.btnExeInputForm.Location = new System.Drawing.Point(96, 121);
            this.btnExeInputForm.Name = "btnExeInputForm";
            this.btnExeInputForm.Size = new System.Drawing.Size(75, 23);
            this.btnExeInputForm.TabIndex = 0;
            this.btnExeInputForm.Text = "Submit";
            this.btnExeInputForm.UseVisualStyleBackColor = true;
            this.btnExeInputForm.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLineAmount
            // 
            this.txtLineAmount.Location = new System.Drawing.Point(86, 95);
            this.txtLineAmount.Name = "txtLineAmount";
            this.txtLineAmount.Size = new System.Drawing.Size(100, 20);
            this.txtLineAmount.TabIndex = 1;
            // 
            // FileReadWriteGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
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
    }
}