namespace CSUATRv2
{
    partial class PositioningForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.waitTime = new System.Windows.Forms.NumericUpDown();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonEngageElevation = new System.Windows.Forms.Button();
            this.moveByElevation = new System.Windows.Forms.NumericUpDown();
            this.buttonEngageAzimuth = new System.Windows.Forms.Button();
            this.buttonEngageDepth = new System.Windows.Forms.Button();
            this.moveToElevation = new System.Windows.Forms.NumericUpDown();
            this.buttonEngageHorizontal = new System.Windows.Forms.Button();
            this.moveByAzimuth = new System.Windows.Forms.NumericUpDown();
            this.buttonEngageVertical = new System.Windows.Forms.Button();
            this.moveByDepth = new System.Windows.Forms.NumericUpDown();
            this.buttonEngagePolar = new System.Windows.Forms.Button();
            this.moveByHorizontal = new System.Windows.Forms.NumericUpDown();
            this.moveToAzimuth = new System.Windows.Forms.NumericUpDown();
            this.moveToDepth = new System.Windows.Forms.NumericUpDown();
            this.moveByVertical = new System.Windows.Forms.NumericUpDown();
            this.moveToVertical = new System.Windows.Forms.NumericUpDown();
            this.moveToHorizontal = new System.Windows.Forms.NumericUpDown();
            this.buttonMoveTo = new System.Windows.Forms.Button();
            this.buttonMoveBy = new System.Windows.Forms.Button();
            this.moveToPolar = new System.Windows.Forms.NumericUpDown();
            this.moveByPolar = new System.Windows.Forms.NumericUpDown();
            this.addWait = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByAzimuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToAzimuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToPolar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByPolar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(16, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(868, 55);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSave,
            this.menuLoad});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(137, 45);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            this.menuSave.Size = new System.Drawing.Size(197, 46);
            this.menuSave.Text = "Save";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuLoad
            // 
            this.menuLoad.Name = "menuLoad";
            this.menuLoad.Size = new System.Drawing.Size(197, 46);
            this.menuLoad.Text = "Load";
            this.menuLoad.Click += new System.EventHandler(this.menuLoad_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(92, 45);
            this.menuHelp.Text = "Help";
            this.menuHelp.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 60);
            this.label1.TabIndex = 21;
            this.label1.Text = "Polarization (deg):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 60);
            this.label2.TabIndex = 14;
            this.label2.Text = "Horizontal (cm):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 60);
            this.label3.TabIndex = 17;
            this.label3.Text = "Vertical (cm):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 60);
            this.label4.TabIndex = 18;
            this.label4.Text = "Depth (cm):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 299);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(199, 60);
            this.label11.TabIndex = 19;
            this.label11.Text = "Azimuth (deg):";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 359);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(215, 60);
            this.label12.TabIndex = 20;
            this.label12.Text = "Elevation (deg):";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.waitTime, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonHome, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonStop, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonEngageElevation, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.moveByElevation, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonEngageAzimuth, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonEngageDepth, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.moveToElevation, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonEngageHorizontal, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.moveByAzimuth, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonEngageVertical, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.moveByDepth, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonEngagePolar, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.moveByHorizontal, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.moveToAzimuth, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.moveToDepth, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.moveByVertical, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.moveToVertical, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.moveToHorizontal, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonMoveTo, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonMoveBy, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.moveToPolar, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.moveByPolar, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.addWait, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 39);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(852, 479);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // waitTime
            // 
            this.waitTime.DecimalPlaces = 3;
            this.waitTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.waitTime.Location = new System.Drawing.Point(472, 10);
            this.waitTime.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.waitTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.waitTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.waitTime.Name = "waitTime";
            this.waitTime.Size = new System.Drawing.Size(179, 39);
            this.waitTime.TabIndex = 76;
            this.waitTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // buttonHome
            // 
            this.buttonHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHome.Location = new System.Drawing.Point(3, 63);
            this.buttonHome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(123, 52);
            this.buttonHome.TabIndex = 74;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.Location = new System.Drawing.Point(357, 63);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(107, 52);
            this.buttonStop.TabIndex = 73;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonEngageElevation
            // 
            this.buttonEngageElevation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEngageElevation.Location = new System.Drawing.Point(256, 363);
            this.buttonEngageElevation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEngageElevation.Name = "buttonEngageElevation";
            this.buttonEngageElevation.Size = new System.Drawing.Size(208, 52);
            this.buttonEngageElevation.TabIndex = 61;
            this.buttonEngageElevation.Text = "Unengaged";
            this.buttonEngageElevation.UseVisualStyleBackColor = true;
            this.buttonEngageElevation.Click += new System.EventHandler(this.buttonEngageElevation_Click);
            // 
            // moveByElevation
            // 
            this.moveByElevation.DecimalPlaces = 2;
            this.moveByElevation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveByElevation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveByElevation.Location = new System.Drawing.Point(661, 369);
            this.moveByElevation.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.moveByElevation.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.moveByElevation.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.moveByElevation.Name = "moveByElevation";
            this.moveByElevation.Size = new System.Drawing.Size(179, 39);
            this.moveByElevation.TabIndex = 72;
            // 
            // buttonEngageAzimuth
            // 
            this.buttonEngageAzimuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEngageAzimuth.Location = new System.Drawing.Point(256, 303);
            this.buttonEngageAzimuth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEngageAzimuth.Name = "buttonEngageAzimuth";
            this.buttonEngageAzimuth.Size = new System.Drawing.Size(208, 52);
            this.buttonEngageAzimuth.TabIndex = 60;
            this.buttonEngageAzimuth.Text = "Unengaged";
            this.buttonEngageAzimuth.UseVisualStyleBackColor = true;
            this.buttonEngageAzimuth.Click += new System.EventHandler(this.buttonEngageAzimuth_Click);
            // 
            // buttonEngageDepth
            // 
            this.buttonEngageDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEngageDepth.Location = new System.Drawing.Point(256, 243);
            this.buttonEngageDepth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEngageDepth.Name = "buttonEngageDepth";
            this.buttonEngageDepth.Size = new System.Drawing.Size(208, 52);
            this.buttonEngageDepth.TabIndex = 59;
            this.buttonEngageDepth.Text = "Unengaged";
            this.buttonEngageDepth.UseVisualStyleBackColor = true;
            this.buttonEngageDepth.Click += new System.EventHandler(this.buttonEngageDepth_Click);
            // 
            // moveToElevation
            // 
            this.moveToElevation.DecimalPlaces = 2;
            this.moveToElevation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveToElevation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveToElevation.Location = new System.Drawing.Point(472, 369);
            this.moveToElevation.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.moveToElevation.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.moveToElevation.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.moveToElevation.Name = "moveToElevation";
            this.moveToElevation.Size = new System.Drawing.Size(179, 39);
            this.moveToElevation.TabIndex = 66;
            // 
            // buttonEngageHorizontal
            // 
            this.buttonEngageHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEngageHorizontal.Location = new System.Drawing.Point(256, 123);
            this.buttonEngageHorizontal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEngageHorizontal.Name = "buttonEngageHorizontal";
            this.buttonEngageHorizontal.Size = new System.Drawing.Size(208, 52);
            this.buttonEngageHorizontal.TabIndex = 58;
            this.buttonEngageHorizontal.Text = "Unengaged";
            this.buttonEngageHorizontal.UseVisualStyleBackColor = true;
            this.buttonEngageHorizontal.Click += new System.EventHandler(this.buttonEngageHorizontal_Click);
            // 
            // moveByAzimuth
            // 
            this.moveByAzimuth.DecimalPlaces = 2;
            this.moveByAzimuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveByAzimuth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveByAzimuth.Location = new System.Drawing.Point(661, 309);
            this.moveByAzimuth.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.moveByAzimuth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.moveByAzimuth.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.moveByAzimuth.Name = "moveByAzimuth";
            this.moveByAzimuth.Size = new System.Drawing.Size(179, 39);
            this.moveByAzimuth.TabIndex = 69;
            // 
            // buttonEngageVertical
            // 
            this.buttonEngageVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEngageVertical.Location = new System.Drawing.Point(256, 183);
            this.buttonEngageVertical.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEngageVertical.Name = "buttonEngageVertical";
            this.buttonEngageVertical.Size = new System.Drawing.Size(208, 52);
            this.buttonEngageVertical.TabIndex = 57;
            this.buttonEngageVertical.Text = "Unengaged";
            this.buttonEngageVertical.UseVisualStyleBackColor = true;
            this.buttonEngageVertical.Click += new System.EventHandler(this.buttonEngageVertical_Click);
            // 
            // moveByDepth
            // 
            this.moveByDepth.DecimalPlaces = 2;
            this.moveByDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveByDepth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveByDepth.Location = new System.Drawing.Point(661, 249);
            this.moveByDepth.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.moveByDepth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.moveByDepth.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.moveByDepth.Name = "moveByDepth";
            this.moveByDepth.Size = new System.Drawing.Size(179, 39);
            this.moveByDepth.TabIndex = 70;
            // 
            // buttonEngagePolar
            // 
            this.buttonEngagePolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEngagePolar.Location = new System.Drawing.Point(256, 423);
            this.buttonEngagePolar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEngagePolar.Name = "buttonEngagePolar";
            this.buttonEngagePolar.Size = new System.Drawing.Size(208, 52);
            this.buttonEngagePolar.TabIndex = 53;
            this.buttonEngagePolar.Text = "Unengaged";
            this.buttonEngagePolar.UseVisualStyleBackColor = true;
            this.buttonEngagePolar.Click += new System.EventHandler(this.buttonEngagePolar_Click);
            // 
            // moveByHorizontal
            // 
            this.moveByHorizontal.DecimalPlaces = 2;
            this.moveByHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveByHorizontal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveByHorizontal.Location = new System.Drawing.Point(661, 129);
            this.moveByHorizontal.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.moveByHorizontal.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.moveByHorizontal.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.moveByHorizontal.Name = "moveByHorizontal";
            this.moveByHorizontal.Size = new System.Drawing.Size(179, 39);
            this.moveByHorizontal.TabIndex = 71;
            // 
            // moveToAzimuth
            // 
            this.moveToAzimuth.DecimalPlaces = 2;
            this.moveToAzimuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveToAzimuth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveToAzimuth.Location = new System.Drawing.Point(472, 309);
            this.moveToAzimuth.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.moveToAzimuth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.moveToAzimuth.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.moveToAzimuth.Name = "moveToAzimuth";
            this.moveToAzimuth.Size = new System.Drawing.Size(179, 39);
            this.moveToAzimuth.TabIndex = 64;
            // 
            // moveToDepth
            // 
            this.moveToDepth.DecimalPlaces = 2;
            this.moveToDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveToDepth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveToDepth.Location = new System.Drawing.Point(472, 249);
            this.moveToDepth.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.moveToDepth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.moveToDepth.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.moveToDepth.Name = "moveToDepth";
            this.moveToDepth.Size = new System.Drawing.Size(179, 39);
            this.moveToDepth.TabIndex = 63;
            // 
            // moveByVertical
            // 
            this.moveByVertical.DecimalPlaces = 2;
            this.moveByVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveByVertical.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveByVertical.Location = new System.Drawing.Point(661, 189);
            this.moveByVertical.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.moveByVertical.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.moveByVertical.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.moveByVertical.Name = "moveByVertical";
            this.moveByVertical.Size = new System.Drawing.Size(179, 39);
            this.moveByVertical.TabIndex = 68;
            // 
            // moveToVertical
            // 
            this.moveToVertical.DecimalPlaces = 2;
            this.moveToVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveToVertical.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveToVertical.Location = new System.Drawing.Point(472, 189);
            this.moveToVertical.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.moveToVertical.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.moveToVertical.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.moveToVertical.Name = "moveToVertical";
            this.moveToVertical.Size = new System.Drawing.Size(179, 39);
            this.moveToVertical.TabIndex = 65;
            // 
            // moveToHorizontal
            // 
            this.moveToHorizontal.DecimalPlaces = 2;
            this.moveToHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveToHorizontal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveToHorizontal.Location = new System.Drawing.Point(472, 129);
            this.moveToHorizontal.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.moveToHorizontal.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.moveToHorizontal.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.moveToHorizontal.Name = "moveToHorizontal";
            this.moveToHorizontal.Size = new System.Drawing.Size(179, 39);
            this.moveToHorizontal.TabIndex = 62;
            // 
            // buttonMoveTo
            // 
            this.buttonMoveTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveTo.Location = new System.Drawing.Point(470, 63);
            this.buttonMoveTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonMoveTo.Name = "buttonMoveTo";
            this.buttonMoveTo.Size = new System.Drawing.Size(179, 52);
            this.buttonMoveTo.TabIndex = 55;
            this.buttonMoveTo.Text = "Move-To\r\n";
            this.buttonMoveTo.UseVisualStyleBackColor = true;
            this.buttonMoveTo.Click += new System.EventHandler(this.buttonMoveTo_Click);
            // 
            // buttonMoveBy
            // 
            this.buttonMoveBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMoveBy.Location = new System.Drawing.Point(659, 63);
            this.buttonMoveBy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonMoveBy.Name = "buttonMoveBy";
            this.buttonMoveBy.Size = new System.Drawing.Size(179, 52);
            this.buttonMoveBy.TabIndex = 56;
            this.buttonMoveBy.Text = "Move-By\r\n";
            this.buttonMoveBy.UseVisualStyleBackColor = true;
            this.buttonMoveBy.Click += new System.EventHandler(this.buttonMoveBy_Click);
            // 
            // moveToPolar
            // 
            this.moveToPolar.DecimalPlaces = 2;
            this.moveToPolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveToPolar.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveToPolar.Location = new System.Drawing.Point(472, 429);
            this.moveToPolar.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.moveToPolar.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.moveToPolar.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.moveToPolar.Name = "moveToPolar";
            this.moveToPolar.Size = new System.Drawing.Size(179, 39);
            this.moveToPolar.TabIndex = 54;
            // 
            // moveByPolar
            // 
            this.moveByPolar.DecimalPlaces = 2;
            this.moveByPolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveByPolar.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveByPolar.Location = new System.Drawing.Point(661, 429);
            this.moveByPolar.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.moveByPolar.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.moveByPolar.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.moveByPolar.Name = "moveByPolar";
            this.moveByPolar.Size = new System.Drawing.Size(179, 39);
            this.moveByPolar.TabIndex = 67;
            // 
            // addWait
            // 
            this.addWait.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.addWait, 2);
            this.addWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addWait.Location = new System.Drawing.Point(3, 3);
            this.addWait.Name = "addWait";
            this.addWait.Size = new System.Drawing.Size(389, 36);
            this.addWait.TabIndex = 75;
            this.addWait.Text = "Add wait before movement";
            this.addWait.UseVisualStyleBackColor = true;
            this.addWait.CheckedChanged += new System.EventHandler(this.addWait_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(216, 267);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 73;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Size = new System.Drawing.Size(868, 525);
            this.groupBox1.TabIndex = 74;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Positioning";
            // 
            // PositioningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(868, 582);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MinimumSize = new System.Drawing.Size(900, 670);
            this.Name = "PositioningForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSUATR - Positioner";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waitTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByAzimuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToAzimuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToPolar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByPolar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown moveByElevation;
        private System.Windows.Forms.NumericUpDown moveByHorizontal;
        private System.Windows.Forms.NumericUpDown moveByDepth;
        private System.Windows.Forms.NumericUpDown moveByAzimuth;
        private System.Windows.Forms.NumericUpDown moveByVertical;
        private System.Windows.Forms.NumericUpDown moveByPolar;
        private System.Windows.Forms.NumericUpDown moveToElevation;
        private System.Windows.Forms.NumericUpDown moveToVertical;
        private System.Windows.Forms.NumericUpDown moveToAzimuth;
        private System.Windows.Forms.NumericUpDown moveToDepth;
        private System.Windows.Forms.NumericUpDown moveToHorizontal;
        private System.Windows.Forms.Button buttonEngageElevation;
        private System.Windows.Forms.Button buttonEngageAzimuth;
        private System.Windows.Forms.Button buttonEngageDepth;
        private System.Windows.Forms.Button buttonEngageHorizontal;
        private System.Windows.Forms.Button buttonEngageVertical;
        private System.Windows.Forms.Button buttonMoveBy;
        private System.Windows.Forms.Button buttonMoveTo;
        private System.Windows.Forms.NumericUpDown moveToPolar;
        private System.Windows.Forms.Button buttonEngagePolar;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown waitTime;
        private System.Windows.Forms.CheckBox addWait;
    }
}