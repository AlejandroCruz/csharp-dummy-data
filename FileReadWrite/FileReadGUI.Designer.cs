namespace FileReadWrite
{
    partial class FileReadGUI
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
            this.lblFilePathInfo = new System.Windows.Forms.Label();
            this.btnOldFileBrowse = new System.Windows.Forms.Button();
            this.txtOldFilePath = new System.Windows.Forms.TextBox();
            this.lblOldFilePath = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lblFilePathInfo
            // 
            this.lblFilePathInfo.AutoSize = true;
            this.lblFilePathInfo.CausesValidation = false;
            this.lblFilePathInfo.Enabled = false;
            this.lblFilePathInfo.Location = new System.Drawing.Point(28, 18);
            this.lblFilePathInfo.Name = "lblFilePathInfo";
            this.lblFilePathInfo.Size = new System.Drawing.Size(187, 13);
            this.lblFilePathInfo.TabIndex = 1;
            this.lblFilePathInfo.Text = "Include name of file in path or Browse:";
            // 
            // btnOldFileBrowse
            // 
            this.btnOldFileBrowse.Location = new System.Drawing.Point(278, 50);
            this.btnOldFileBrowse.Name = "btnOldFileBrowse";
            this.btnOldFileBrowse.Size = new System.Drawing.Size(52, 23);
            this.btnOldFileBrowse.TabIndex = 9;
            this.btnOldFileBrowse.Text = "Browse";
            this.btnOldFileBrowse.UseVisualStyleBackColor = true;
            this.btnOldFileBrowse.Click += new System.EventHandler(this.btnOldFileBrowse_Click);
            // 
            // txtOldFilePath
            // 
            this.txtOldFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldFilePath.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtOldFilePath.Location = new System.Drawing.Point(94, 51);
            this.txtOldFilePath.Name = "txtOldFilePath";
            this.txtOldFilePath.Size = new System.Drawing.Size(178, 20);
            this.txtOldFilePath.TabIndex = 7;
            this.txtOldFilePath.TabStop = false;
            this.txtOldFilePath.Text = " C:\\";
            this.txtOldFilePath.Enter += new System.EventHandler(this.txtOldFilePath_Focus);
            this.txtOldFilePath.Leave += new System.EventHandler(this.txtOldFilePath_Leave);
            // 
            // lblOldFilePath
            // 
            this.lblOldFilePath.AutoSize = true;
            this.lblOldFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldFilePath.Location = new System.Drawing.Point(28, 53);
            this.lblOldFilePath.Name = "lblOldFilePath";
            this.lblOldFilePath.Size = new System.Drawing.Size(59, 16);
            this.lblOldFilePath.TabIndex = 8;
            this.lblOldFilePath.Text = "File from";
            // 
            // FileReadGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 115);
            this.Controls.Add(this.btnOldFileBrowse);
            this.Controls.Add(this.txtOldFilePath);
            this.Controls.Add(this.lblOldFilePath);
            this.Controls.Add(this.lblFilePathInfo);
            this.Name = "FileReadGUI";
            this.Text = "FileReadGUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFilePathInfo;
        private System.Windows.Forms.Button btnOldFileBrowse;
        private System.Windows.Forms.TextBox txtOldFilePath;
        private System.Windows.Forms.Label lblOldFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}