namespace CSUATRv2
{
    partial class BoundariesForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lowerHorizontal = new System.Windows.Forms.NumericUpDown();
            this.lowerVertical = new System.Windows.Forms.NumericUpDown();
            this.lowerDepth = new System.Windows.Forms.NumericUpDown();
            this.lowerAzimuth = new System.Windows.Forms.NumericUpDown();
            this.lowerElevation = new System.Windows.Forms.NumericUpDown();
            this.upperHorizontal = new System.Windows.Forms.NumericUpDown();
            this.upperVertical = new System.Windows.Forms.NumericUpDown();
            this.upperDepth = new System.Windows.Forms.NumericUpDown();
            this.upperAzimuth = new System.Windows.Forms.NumericUpDown();
            this.upperElevation = new System.Windows.Forms.NumericUpDown();
            this.lowerPolarization = new System.Windows.Forms.NumericUpDown();
            this.upperPolarization = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxEnforceBounds = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowerHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerAzimuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperAzimuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerPolarization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperPolarization)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(640, 49);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSave,
            this.menuLoad});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(137, 48);
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
            this.menuHelp.Size = new System.Drawing.Size(92, 48);
            this.menuHelp.Text = "Help";
            this.menuHelp.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 465);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Position Boundaries";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lowerHorizontal, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lowerVertical, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lowerDepth, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lowerAzimuth, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lowerElevation, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.upperHorizontal, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.upperVertical, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.upperDepth, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.upperAzimuth, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.upperElevation, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.lowerPolarization, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.upperPolarization, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxEnforceBounds, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 34);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(634, 428);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 59);
            this.label2.TabIndex = 16;
            this.label2.Text = "Horizontal (cm):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 59);
            this.label3.TabIndex = 18;
            this.label3.Text = "Vertical (cm):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 59);
            this.label4.TabIndex = 19;
            this.label4.Text = "Depth (cm):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 251);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(199, 59);
            this.label11.TabIndex = 20;
            this.label11.Text = "Azimuth (deg):";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 310);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(215, 59);
            this.label12.TabIndex = 21;
            this.label12.Text = "Elevation (deg):";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lowerHorizontal
            // 
            this.lowerHorizontal.DecimalPlaces = 2;
            this.lowerHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowerHorizontal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerHorizontal.Location = new System.Drawing.Point(258, 84);
            this.lowerHorizontal.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.lowerHorizontal.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.lowerHorizontal.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.lowerHorizontal.Name = "lowerHorizontal";
            this.lowerHorizontal.Size = new System.Drawing.Size(179, 39);
            this.lowerHorizontal.TabIndex = 63;
            this.lowerHorizontal.ValueChanged += new System.EventHandler(this.lowerHorizontal_ValueChanged);
            // 
            // lowerVertical
            // 
            this.lowerVertical.DecimalPlaces = 2;
            this.lowerVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowerVertical.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerVertical.Location = new System.Drawing.Point(258, 143);
            this.lowerVertical.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.lowerVertical.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.lowerVertical.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.lowerVertical.Name = "lowerVertical";
            this.lowerVertical.Size = new System.Drawing.Size(179, 39);
            this.lowerVertical.TabIndex = 64;
            this.lowerVertical.ValueChanged += new System.EventHandler(this.lowerVertical_ValueChanged);
            // 
            // lowerDepth
            // 
            this.lowerDepth.DecimalPlaces = 2;
            this.lowerDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowerDepth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerDepth.Location = new System.Drawing.Point(258, 202);
            this.lowerDepth.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.lowerDepth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.lowerDepth.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.lowerDepth.Name = "lowerDepth";
            this.lowerDepth.Size = new System.Drawing.Size(179, 39);
            this.lowerDepth.TabIndex = 65;
            this.lowerDepth.ValueChanged += new System.EventHandler(this.lowerDepth_ValueChanged);
            // 
            // lowerAzimuth
            // 
            this.lowerAzimuth.DecimalPlaces = 2;
            this.lowerAzimuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowerAzimuth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerAzimuth.Location = new System.Drawing.Point(258, 261);
            this.lowerAzimuth.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.lowerAzimuth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.lowerAzimuth.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.lowerAzimuth.Name = "lowerAzimuth";
            this.lowerAzimuth.Size = new System.Drawing.Size(179, 39);
            this.lowerAzimuth.TabIndex = 66;
            this.lowerAzimuth.ValueChanged += new System.EventHandler(this.lowerAzimuth_ValueChanged);
            // 
            // lowerElevation
            // 
            this.lowerElevation.DecimalPlaces = 2;
            this.lowerElevation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowerElevation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerElevation.Location = new System.Drawing.Point(258, 320);
            this.lowerElevation.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.lowerElevation.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.lowerElevation.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.lowerElevation.Name = "lowerElevation";
            this.lowerElevation.Size = new System.Drawing.Size(179, 39);
            this.lowerElevation.TabIndex = 67;
            this.lowerElevation.ValueChanged += new System.EventHandler(this.lowerElevation_ValueChanged);
            // 
            // upperHorizontal
            // 
            this.upperHorizontal.DecimalPlaces = 2;
            this.upperHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upperHorizontal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperHorizontal.Location = new System.Drawing.Point(447, 84);
            this.upperHorizontal.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.upperHorizontal.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.upperHorizontal.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.upperHorizontal.Name = "upperHorizontal";
            this.upperHorizontal.Size = new System.Drawing.Size(179, 39);
            this.upperHorizontal.TabIndex = 68;
            this.upperHorizontal.ValueChanged += new System.EventHandler(this.upperHorizontal_ValueChanged);
            // 
            // upperVertical
            // 
            this.upperVertical.DecimalPlaces = 2;
            this.upperVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upperVertical.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperVertical.Location = new System.Drawing.Point(447, 143);
            this.upperVertical.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.upperVertical.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.upperVertical.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.upperVertical.Name = "upperVertical";
            this.upperVertical.Size = new System.Drawing.Size(179, 39);
            this.upperVertical.TabIndex = 69;
            this.upperVertical.ValueChanged += new System.EventHandler(this.upperVertical_ValueChanged);
            // 
            // upperDepth
            // 
            this.upperDepth.DecimalPlaces = 2;
            this.upperDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upperDepth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperDepth.Location = new System.Drawing.Point(447, 202);
            this.upperDepth.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.upperDepth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.upperDepth.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.upperDepth.Name = "upperDepth";
            this.upperDepth.Size = new System.Drawing.Size(179, 39);
            this.upperDepth.TabIndex = 70;
            this.upperDepth.ValueChanged += new System.EventHandler(this.upperDepth_ValueChanged);
            // 
            // upperAzimuth
            // 
            this.upperAzimuth.DecimalPlaces = 2;
            this.upperAzimuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upperAzimuth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperAzimuth.Location = new System.Drawing.Point(447, 261);
            this.upperAzimuth.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.upperAzimuth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.upperAzimuth.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.upperAzimuth.Name = "upperAzimuth";
            this.upperAzimuth.Size = new System.Drawing.Size(179, 39);
            this.upperAzimuth.TabIndex = 71;
            this.upperAzimuth.ValueChanged += new System.EventHandler(this.upperAzimuth_ValueChanged);
            // 
            // upperElevation
            // 
            this.upperElevation.DecimalPlaces = 2;
            this.upperElevation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upperElevation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperElevation.Location = new System.Drawing.Point(447, 320);
            this.upperElevation.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.upperElevation.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.upperElevation.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.upperElevation.Name = "upperElevation";
            this.upperElevation.Size = new System.Drawing.Size(179, 39);
            this.upperElevation.TabIndex = 72;
            this.upperElevation.ValueChanged += new System.EventHandler(this.upperElevation_ValueChanged);
            // 
            // lowerPolarization
            // 
            this.lowerPolarization.DecimalPlaces = 2;
            this.lowerPolarization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowerPolarization.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerPolarization.Location = new System.Drawing.Point(258, 379);
            this.lowerPolarization.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.lowerPolarization.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.lowerPolarization.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.lowerPolarization.Name = "lowerPolarization";
            this.lowerPolarization.Size = new System.Drawing.Size(179, 39);
            this.lowerPolarization.TabIndex = 73;
            this.lowerPolarization.ValueChanged += new System.EventHandler(this.lowerPolarization_ValueChanged);
            // 
            // upperPolarization
            // 
            this.upperPolarization.DecimalPlaces = 2;
            this.upperPolarization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upperPolarization.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperPolarization.Location = new System.Drawing.Point(447, 379);
            this.upperPolarization.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.upperPolarization.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.upperPolarization.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.upperPolarization.Name = "upperPolarization";
            this.upperPolarization.Size = new System.Drawing.Size(179, 39);
            this.upperPolarization.TabIndex = 74;
            this.upperPolarization.ValueChanged += new System.EventHandler(this.upperPolarization_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(256, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 32);
            this.label5.TabIndex = 75;
            this.label5.Text = "Lower";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(445, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 32);
            this.label6.TabIndex = 76;
            this.label6.Text = "Upper";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxEnforceBounds
            // 
            this.checkBoxEnforceBounds.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxEnforceBounds, 2);
            this.checkBoxEnforceBounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEnforceBounds.Location = new System.Drawing.Point(3, 3);
            this.checkBoxEnforceBounds.Name = "checkBoxEnforceBounds";
            this.checkBoxEnforceBounds.Size = new System.Drawing.Size(303, 36);
            this.checkBoxEnforceBounds.TabIndex = 77;
            this.checkBoxEnforceBounds.Text = "Enforce Boundaries";
            this.checkBoxEnforceBounds.UseVisualStyleBackColor = true;
            this.checkBoxEnforceBounds.CheckedChanged += new System.EventHandler(this.checkBoxEnforceBounds_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 59);
            this.label1.TabIndex = 22;
            this.label1.Text = "Polarization (deg):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BoundariesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(640, 514);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BoundariesForm";
            this.Text = "BoundariesForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowerHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerAzimuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperAzimuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerPolarization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperPolarization)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuLoad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown lowerHorizontal;
        private System.Windows.Forms.NumericUpDown lowerVertical;
        private System.Windows.Forms.NumericUpDown lowerDepth;
        private System.Windows.Forms.NumericUpDown lowerAzimuth;
        private System.Windows.Forms.NumericUpDown lowerElevation;
        private System.Windows.Forms.NumericUpDown upperHorizontal;
        private System.Windows.Forms.NumericUpDown upperVertical;
        private System.Windows.Forms.NumericUpDown upperDepth;
        private System.Windows.Forms.NumericUpDown upperAzimuth;
        private System.Windows.Forms.NumericUpDown upperElevation;
        private System.Windows.Forms.NumericUpDown lowerPolarization;
        private System.Windows.Forms.NumericUpDown upperPolarization;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxEnforceBounds;
    }
}