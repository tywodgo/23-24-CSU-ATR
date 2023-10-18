namespace CSUATRv2
{
    partial class LoadDataForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelNote = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxFile = new System.Windows.Forms.ComboBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelFoldername = new System.Windows.Forms.Label();
            this.comboBoxFolder = new System.Windows.Forms.ComboBox();
            this.labelFilename = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelNote, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxFile, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonOk, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelFoldername, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxFolder, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelFilename, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(653, 282);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelNote, 3);
            this.labelNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote.Location = new System.Drawing.Point(3, 0);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(648, 64);
            this.labelNote.TabIndex = 24;
            this.labelNote.Text = "Note: All folders and files are confined to the same\r\n          folder which cont" +
    "ains this project executable\r\n";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(392, 219);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(173, 55);
            this.buttonCancel.TabIndex = 27;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxFile
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxFile, 2);
            this.comboBoxFile.FormattingEnabled = true;
            this.comboBoxFile.Location = new System.Drawing.Point(203, 166);
            this.comboBoxFile.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.comboBoxFile.Name = "comboBoxFile";
            this.comboBoxFile.Size = new System.Drawing.Size(356, 39);
            this.comboBoxFile.TabIndex = 29;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(203, 219);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(173, 55);
            this.buttonOk.TabIndex = 26;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelFoldername
            // 
            this.labelFoldername.AutoSize = true;
            this.labelFoldername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFoldername.Location = new System.Drawing.Point(3, 106);
            this.labelFoldername.Name = "labelFoldername";
            this.labelFoldername.Size = new System.Drawing.Size(189, 32);
            this.labelFoldername.TabIndex = 21;
            this.labelFoldername.Text = "Folder Name";
            // 
            // comboBoxFolder
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxFolder, 2);
            this.comboBoxFolder.FormattingEnabled = true;
            this.comboBoxFolder.Location = new System.Drawing.Point(203, 113);
            this.comboBoxFolder.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.comboBoxFolder.Name = "comboBoxFolder";
            this.comboBoxFolder.Size = new System.Drawing.Size(356, 39);
            this.comboBoxFolder.TabIndex = 28;
            this.comboBoxFolder.SelectedIndexChanged += new System.EventHandler(this.comboBoxFolder_SelectedIndexChanged);
            // 
            // labelFilename
            // 
            this.labelFilename.AutoSize = true;
            this.labelFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilename.Location = new System.Drawing.Point(3, 159);
            this.labelFilename.Name = "labelFilename";
            this.labelFilename.Size = new System.Drawing.Size(153, 32);
            this.labelFilename.TabIndex = 22;
            this.labelFilename.Text = "File Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(629, 42);
            this.label1.TabIndex = 30;
            this.label1.Text = "Caution! This will overwrite your current dataset!\r\n";
            // 
            // LoadDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(653, 282);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MinimumSize = new System.Drawing.Size(685, 370);
            this.Name = "LoadDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Data";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxFile;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelFoldername;
        private System.Windows.Forms.ComboBox comboBoxFolder;
        private System.Windows.Forms.Label labelFilename;
        private System.Windows.Forms.Label label1;
    }
}