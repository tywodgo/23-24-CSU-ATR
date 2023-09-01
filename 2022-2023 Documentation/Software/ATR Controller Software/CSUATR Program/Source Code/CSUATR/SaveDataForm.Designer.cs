namespace CSUATR
{
    partial class SaveDataForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textBoxFilename = new System.Windows.Forms.TextBox();
            this.labelNote = new System.Windows.Forms.Label();
            this.textBoxFoldername = new System.Windows.Forms.TextBox();
            this.labelFilename = new System.Windows.Forms.Label();
            this.labelFoldername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(163, 95);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(65, 23);
            this.buttonCancel.TabIndex = 20;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(92, 95);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(65, 23);
            this.buttonOk.TabIndex = 19;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textBoxFilename
            // 
            this.textBoxFilename.Location = new System.Drawing.Point(92, 69);
            this.textBoxFilename.Name = "textBoxFilename";
            this.textBoxFilename.Size = new System.Drawing.Size(136, 20);
            this.textBoxFilename.TabIndex = 18;
            this.textBoxFilename.TextChanged += new System.EventHandler(this.textBoxFilename_TextChanged);
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote.Location = new System.Drawing.Point(10, 9);
            this.labelNote.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(246, 26);
            this.labelNote.TabIndex = 17;
            this.labelNote.Text = "Note: All folders and files are confined to the same\r\n          folder which cont" +
    "ains this project executable\r\n";
            // 
            // textBoxFoldername
            // 
            this.textBoxFoldername.Location = new System.Drawing.Point(92, 43);
            this.textBoxFoldername.Name = "textBoxFoldername";
            this.textBoxFoldername.Size = new System.Drawing.Size(136, 20);
            this.textBoxFoldername.TabIndex = 16;
            this.textBoxFoldername.TextChanged += new System.EventHandler(this.textBoxFoldername_TextChanged);
            // 
            // labelFilename
            // 
            this.labelFilename.AutoSize = true;
            this.labelFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilename.Location = new System.Drawing.Point(25, 72);
            this.labelFilename.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelFilename.Name = "labelFilename";
            this.labelFilename.Size = new System.Drawing.Size(63, 13);
            this.labelFilename.TabIndex = 15;
            this.labelFilename.Text = "File Name";
            // 
            // labelFoldername
            // 
            this.labelFoldername.AutoSize = true;
            this.labelFoldername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFoldername.Location = new System.Drawing.Point(10, 46);
            this.labelFoldername.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelFoldername.Name = "labelFoldername";
            this.labelFoldername.Size = new System.Drawing.Size(78, 13);
            this.labelFoldername.TabIndex = 22;
            this.labelFoldername.Text = "Folder Name";
            // 
            // SaveDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 126);
            this.Controls.Add(this.labelFoldername);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxFilename);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.textBoxFoldername);
            this.Controls.Add(this.labelFilename);
            this.MaximumSize = new System.Drawing.Size(276, 165);
            this.MinimumSize = new System.Drawing.Size(276, 165);
            this.Name = "SaveDataForm";
            this.Text = "Save Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textBoxFilename;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.TextBox textBoxFoldername;
        private System.Windows.Forms.Label labelFilename;
        private System.Windows.Forms.Label labelFoldername;
    }
}