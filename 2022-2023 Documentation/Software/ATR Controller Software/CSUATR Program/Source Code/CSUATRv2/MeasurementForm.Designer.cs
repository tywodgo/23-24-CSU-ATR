namespace CSUATRv2
{
    partial class MeasurementForm
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
            this.sweepPoints = new System.Windows.Forms.NumericUpDown();
            this.stopFrequency = new System.Windows.Forms.NumericUpDown();
            this.buttonSetSourcePower = new System.Windows.Forms.Button();
            this.averagePoints = new System.Windows.Forms.NumericUpDown();
            this.startFrequency = new System.Windows.Forms.NumericUpDown();
            this.sourcePower = new System.Windows.Forms.NumericUpDown();
            this.buttonMeasure = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSetSweepPoints = new System.Windows.Forms.Button();
            this.buttonSetAveragePoints = new System.Windows.Forms.Button();
            this.buttonSetIfBandwidth = new System.Windows.Forms.Button();
            this.buttonSetStopFrequency = new System.Windows.Forms.Button();
            this.buttonSetStartFrequency = new System.Windows.Forms.Button();
            this.ifBandwidth = new System.Windows.Forms.NumericUpDown();
            this.sParameter = new System.Windows.Forms.ComboBox();
            this.buttonSetSParameter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSetAll = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sweepPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.averagePoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ifBandwidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(658, 55);
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
            // sweepPoints
            // 
            this.sweepPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sweepPoints.Location = new System.Drawing.Point(315, 336);
            this.sweepPoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sweepPoints.Maximum = new decimal(new int[] {
            10001,
            0,
            0,
            0});
            this.sweepPoints.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.sweepPoints.Name = "sweepPoints";
            this.sweepPoints.Size = new System.Drawing.Size(205, 39);
            this.sweepPoints.TabIndex = 43;
            this.sweepPoints.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // stopFrequency
            // 
            this.stopFrequency.DecimalPlaces = 3;
            this.stopFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopFrequency.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.stopFrequency.Location = new System.Drawing.Point(315, 232);
            this.stopFrequency.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stopFrequency.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.stopFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.stopFrequency.Name = "stopFrequency";
            this.stopFrequency.Size = new System.Drawing.Size(205, 39);
            this.stopFrequency.TabIndex = 42;
            this.stopFrequency.Value = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            // 
            // buttonSetSourcePower
            // 
            this.buttonSetSourcePower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetSourcePower.Location = new System.Drawing.Point(526, 124);
            this.buttonSetSourcePower.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSetSourcePower.Name = "buttonSetSourcePower";
            this.buttonSetSourcePower.Size = new System.Drawing.Size(112, 52);
            this.buttonSetSourcePower.TabIndex = 41;
            this.buttonSetSourcePower.Text = "Set";
            this.buttonSetSourcePower.UseVisualStyleBackColor = true;
            this.buttonSetSourcePower.Click += new System.EventHandler(this.buttonSetSourcePower_Click);
            // 
            // averagePoints
            // 
            this.averagePoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.averagePoints.Location = new System.Drawing.Point(315, 388);
            this.averagePoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.averagePoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.averagePoints.Name = "averagePoints";
            this.averagePoints.Size = new System.Drawing.Size(205, 39);
            this.averagePoints.TabIndex = 40;
            this.averagePoints.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // startFrequency
            // 
            this.startFrequency.DecimalPlaces = 3;
            this.startFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startFrequency.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.startFrequency.Location = new System.Drawing.Point(315, 180);
            this.startFrequency.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startFrequency.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.startFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.startFrequency.Name = "startFrequency";
            this.startFrequency.Size = new System.Drawing.Size(205, 39);
            this.startFrequency.TabIndex = 39;
            this.startFrequency.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // sourcePower
            // 
            this.sourcePower.DecimalPlaces = 3;
            this.sourcePower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sourcePower.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.sourcePower.Location = new System.Drawing.Point(315, 124);
            this.sourcePower.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sourcePower.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.sourcePower.Name = "sourcePower";
            this.sourcePower.Size = new System.Drawing.Size(205, 39);
            this.sourcePower.TabIndex = 38;
            this.sourcePower.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // buttonMeasure
            // 
            this.buttonMeasure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMeasure.Location = new System.Drawing.Point(3, 2);
            this.buttonMeasure.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonMeasure.Name = "buttonMeasure";
            this.buttonMeasure.Size = new System.Drawing.Size(160, 52);
            this.buttonMeasure.TabIndex = 44;
            this.buttonMeasure.Text = "Measure";
            this.buttonMeasure.UseVisualStyleBackColor = true;
            this.buttonMeasure.Click += new System.EventHandler(this.buttonMeasure_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(260, 32);
            this.label14.TabIndex = 6;
            this.label14.Text = "Source Power (dB):";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(306, 32);
            this.label12.TabIndex = 8;
            this.label12.Text = "Start Frequency (MHz):";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 230);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(305, 32);
            this.label13.TabIndex = 7;
            this.label13.Text = "Stop Frequency (MHz):";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 282);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(261, 32);
            this.label11.TabIndex = 9;
            this.label11.Text = "IF Bandwidth (kHz):";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(3, 334);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(220, 32);
            this.label21.TabIndex = 10;
            this.label21.Text = "# Sweep Points:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(3, 386);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(262, 32);
            this.label22.TabIndex = 11;
            this.label22.Text = "# Averaging Points:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 32);
            this.label1.TabIndex = 47;
            this.label1.Text = "S Parameter:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSetSweepPoints
            // 
            this.buttonSetSweepPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetSweepPoints.Location = new System.Drawing.Point(526, 336);
            this.buttonSetSweepPoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSetSweepPoints.Name = "buttonSetSweepPoints";
            this.buttonSetSweepPoints.Size = new System.Drawing.Size(112, 48);
            this.buttonSetSweepPoints.TabIndex = 47;
            this.buttonSetSweepPoints.Text = "Set";
            this.buttonSetSweepPoints.UseVisualStyleBackColor = true;
            this.buttonSetSweepPoints.Click += new System.EventHandler(this.buttonSetSweepPoints_Click);
            // 
            // buttonSetAveragePoints
            // 
            this.buttonSetAveragePoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetAveragePoints.Location = new System.Drawing.Point(526, 388);
            this.buttonSetAveragePoints.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSetAveragePoints.Name = "buttonSetAveragePoints";
            this.buttonSetAveragePoints.Size = new System.Drawing.Size(112, 48);
            this.buttonSetAveragePoints.TabIndex = 48;
            this.buttonSetAveragePoints.Text = "Set";
            this.buttonSetAveragePoints.UseVisualStyleBackColor = true;
            this.buttonSetAveragePoints.Click += new System.EventHandler(this.buttonSetAveragePoints_Click);
            // 
            // buttonSetIfBandwidth
            // 
            this.buttonSetIfBandwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetIfBandwidth.Location = new System.Drawing.Point(526, 284);
            this.buttonSetIfBandwidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSetIfBandwidth.Name = "buttonSetIfBandwidth";
            this.buttonSetIfBandwidth.Size = new System.Drawing.Size(112, 48);
            this.buttonSetIfBandwidth.TabIndex = 47;
            this.buttonSetIfBandwidth.Text = "Set";
            this.buttonSetIfBandwidth.UseVisualStyleBackColor = true;
            this.buttonSetIfBandwidth.Click += new System.EventHandler(this.buttonSetIfBandwidth_Click);
            // 
            // buttonSetStopFrequency
            // 
            this.buttonSetStopFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetStopFrequency.Location = new System.Drawing.Point(526, 232);
            this.buttonSetStopFrequency.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSetStopFrequency.Name = "buttonSetStopFrequency";
            this.buttonSetStopFrequency.Size = new System.Drawing.Size(112, 48);
            this.buttonSetStopFrequency.TabIndex = 48;
            this.buttonSetStopFrequency.Text = "Set";
            this.buttonSetStopFrequency.UseVisualStyleBackColor = true;
            this.buttonSetStopFrequency.Click += new System.EventHandler(this.buttonSetStopFrequency_Click);
            // 
            // buttonSetStartFrequency
            // 
            this.buttonSetStartFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetStartFrequency.Location = new System.Drawing.Point(526, 180);
            this.buttonSetStartFrequency.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSetStartFrequency.Name = "buttonSetStartFrequency";
            this.buttonSetStartFrequency.Size = new System.Drawing.Size(112, 48);
            this.buttonSetStartFrequency.TabIndex = 49;
            this.buttonSetStartFrequency.Text = "Set";
            this.buttonSetStartFrequency.UseVisualStyleBackColor = true;
            this.buttonSetStartFrequency.Click += new System.EventHandler(this.buttonSetStartFrequency_Click);
            // 
            // ifBandwidth
            // 
            this.ifBandwidth.DecimalPlaces = 3;
            this.ifBandwidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ifBandwidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ifBandwidth.Location = new System.Drawing.Point(315, 284);
            this.ifBandwidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ifBandwidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.ifBandwidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.ifBandwidth.Name = "ifBandwidth";
            this.ifBandwidth.Size = new System.Drawing.Size(205, 39);
            this.ifBandwidth.TabIndex = 47;
            this.ifBandwidth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // sParameter
            // 
            this.sParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sParameter.FormattingEnabled = true;
            this.sParameter.Location = new System.Drawing.Point(320, 73);
            this.sParameter.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.sParameter.Name = "sParameter";
            this.sParameter.Size = new System.Drawing.Size(188, 39);
            this.sParameter.TabIndex = 50;
            this.sParameter.Text = "S21";
            // 
            // buttonSetSParameter
            // 
            this.buttonSetSParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetSParameter.Location = new System.Drawing.Point(526, 68);
            this.buttonSetSParameter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSetSParameter.Name = "buttonSetSParameter";
            this.buttonSetSParameter.Size = new System.Drawing.Size(112, 52);
            this.buttonSetSParameter.TabIndex = 51;
            this.buttonSetSParameter.Text = "Set";
            this.buttonSetSParameter.UseVisualStyleBackColor = true;
            this.buttonSetSParameter.Click += new System.EventHandler(this.buttonSetSParameter_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Size = new System.Drawing.Size(657, 482);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Measurement";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label22, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label21, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonMeasure, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ifBandwidth, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetAveragePoints, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.averagePoints, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.sweepPoints, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetSweepPoints, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetSParameter, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetIfBandwidth, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetSourcePower, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.stopFrequency, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetStopFrequency, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetStartFrequency, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.sParameter, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.sourcePower, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.startFrequency, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.buttonSetAll, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 39);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(641, 436);
            this.tableLayoutPanel2.TabIndex = 48;
            // 
            // buttonSetAll
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.buttonSetAll, 2);
            this.buttonSetAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSetAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetAll.Location = new System.Drawing.Point(500, 7);
            this.buttonSetAll.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonSetAll.Name = "buttonSetAll";
            this.buttonSetAll.Size = new System.Drawing.Size(133, 52);
            this.buttonSetAll.TabIndex = 52;
            this.buttonSetAll.Text = "Set All";
            this.buttonSetAll.UseVisualStyleBackColor = true;
            this.buttonSetAll.Click += new System.EventHandler(this.buttonSetAll_Click);
            // 
            // MeasurementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(658, 537);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MinimumSize = new System.Drawing.Size(690, 625);
            this.Name = "MeasurementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSUATR - Measurement";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sweepPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.averagePoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ifBandwidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuLoad;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.NumericUpDown sweepPoints;
        private System.Windows.Forms.NumericUpDown stopFrequency;
        private System.Windows.Forms.Button buttonSetSourcePower;
        private System.Windows.Forms.NumericUpDown averagePoints;
        private System.Windows.Forms.NumericUpDown startFrequency;
        private System.Windows.Forms.NumericUpDown sourcePower;
        private System.Windows.Forms.Button buttonMeasure;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown ifBandwidth;
        private System.Windows.Forms.Button buttonSetSweepPoints;
        private System.Windows.Forms.Button buttonSetAveragePoints;
        private System.Windows.Forms.Button buttonSetIfBandwidth;
        private System.Windows.Forms.Button buttonSetStopFrequency;
        private System.Windows.Forms.Button buttonSetStartFrequency;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sParameter;
        private System.Windows.Forms.Button buttonSetSParameter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonSetAll;
    }
}