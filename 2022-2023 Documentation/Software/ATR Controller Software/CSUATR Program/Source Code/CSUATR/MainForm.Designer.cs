namespace CSUATR
{
    partial class MainForm
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
            this.groupBoxConna = new System.Windows.Forms.GroupBox();
            this.mode = new System.Windows.Forms.ComboBox();
            this.labelMode = new System.Windows.Forms.Label();
            this.buttonNAConnect = new System.Windows.Forms.Button();
            this.groupBoxPos = new System.Windows.Forms.GroupBox();
            this.moveByElevation = new System.Windows.Forms.NumericUpDown();
            this.moveByHorizontal = new System.Windows.Forms.NumericUpDown();
            this.moveByDepth = new System.Windows.Forms.NumericUpDown();
            this.moveByAzimuth = new System.Windows.Forms.NumericUpDown();
            this.moveByVertical = new System.Windows.Forms.NumericUpDown();
            this.moveByPolar = new System.Windows.Forms.NumericUpDown();
            this.moveToElevation = new System.Windows.Forms.NumericUpDown();
            this.moveToVertical = new System.Windows.Forms.NumericUpDown();
            this.statusPositionElevation = new System.Windows.Forms.Label();
            this.statusPositionAzimuth = new System.Windows.Forms.Label();
            this.statusPositionDepth = new System.Windows.Forms.Label();
            this.statusPositionHorizontal = new System.Windows.Forms.Label();
            this.statusPositionVertical = new System.Windows.Forms.Label();
            this.moveToAzimuth = new System.Windows.Forms.NumericUpDown();
            this.moveToDepth = new System.Windows.Forms.NumericUpDown();
            this.moveToHorizontal = new System.Windows.Forms.NumericUpDown();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonEngageElevation = new System.Windows.Forms.Button();
            this.labelPosEleva = new System.Windows.Forms.Label();
            this.buttonEngageAzimuth = new System.Windows.Forms.Button();
            this.labelPosAzimu = new System.Windows.Forms.Label();
            this.buttonEngageDepth = new System.Windows.Forms.Button();
            this.labelPosDepth = new System.Windows.Forms.Label();
            this.buttonEngageHorizontal = new System.Windows.Forms.Button();
            this.labelPosHoriz = new System.Windows.Forms.Label();
            this.buttonEngageVertical = new System.Windows.Forms.Button();
            this.labelPosVerti = new System.Windows.Forms.Label();
            this.buttonMoveBy = new System.Windows.Forms.Button();
            this.buttonMoveTo = new System.Windows.Forms.Button();
            this.moveToPolar = new System.Windows.Forms.NumericUpDown();
            this.statusPositionPolar = new System.Windows.Forms.Label();
            this.buttonEngagePolar = new System.Windows.Forms.Button();
            this.labelPosPolar = new System.Windows.Forms.Label();
            this.buttonMoveStop = new System.Windows.Forms.Button();
            this.buttonMoveReSet = new System.Windows.Forms.Button();
            this.groupBoxScan = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.progressPercent = new System.Windows.Forms.Label();
            this.scanEstimatedTime = new System.Windows.Forms.Label();
            this.scanAvgPoints = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.scanSourcePower = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.upperLimitFrequency = new System.Windows.Forms.NumericUpDown();
            this.lowerLimitFrequency = new System.Windows.Forms.NumericUpDown();
            this.scanSweepPoints = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.resolutionElevation = new System.Windows.Forms.NumericUpDown();
            this.resolutionHorizontal = new System.Windows.Forms.NumericUpDown();
            this.resolutionDepth = new System.Windows.Forms.NumericUpDown();
            this.resolutionAzimuth = new System.Windows.Forms.NumericUpDown();
            this.resolutionVertical = new System.Windows.Forms.NumericUpDown();
            this.resolutionPolar = new System.Windows.Forms.NumericUpDown();
            this.upperLimitElevation = new System.Windows.Forms.NumericUpDown();
            this.upperLimitHorizontal = new System.Windows.Forms.NumericUpDown();
            this.upperLimitDepth = new System.Windows.Forms.NumericUpDown();
            this.upperLimitAzimuth = new System.Windows.Forms.NumericUpDown();
            this.upperLimitVertical = new System.Windows.Forms.NumericUpDown();
            this.upperLimitPolar = new System.Windows.Forms.NumericUpDown();
            this.lowerLimitElevation = new System.Windows.Forms.NumericUpDown();
            this.lowerLimitVertical = new System.Windows.Forms.NumericUpDown();
            this.lowerLimitAzimuth = new System.Windows.Forms.NumericUpDown();
            this.lowerLimitDepth = new System.Windows.Forms.NumericUpDown();
            this.lowerLimitHorizontal = new System.Windows.Forms.NumericUpDown();
            this.lowerLimitPolar = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelScanEstim = new System.Windows.Forms.Label();
            this.scanType = new System.Windows.Forms.ComboBox();
            this.labelScanType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonScanStart = new System.Windows.Forms.Button();
            this.buttonLockElevation = new System.Windows.Forms.Button();
            this.buttonLockAzimuth = new System.Windows.Forms.Button();
            this.buttonLockDepth = new System.Windows.Forms.Button();
            this.buttonLockHorizontal = new System.Windows.Forms.Button();
            this.buttonLockVertical = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonLockPolar = new System.Windows.Forms.Button();
            this.buttonScanCancel = new System.Windows.Forms.Button();
            this.buttonScanReSet = new System.Windows.Forms.Button();
            this.groupBoxConard = new System.Windows.Forms.GroupBox();
            this.port = new System.Windows.Forms.ComboBox();
            this.labelConardPort = new System.Windows.Forms.Label();
            this.buttonArduinoConnect = new System.Windows.Forms.Button();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.listBoxOutput = new System.Windows.Forms.ListBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemChangeSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLoadData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRescanPorts = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRemoveLastPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClearDataset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxMeasurement = new System.Windows.Forms.GroupBox();
            this.setToSweepPoints = new System.Windows.Forms.NumericUpDown();
            this.statusSweepPoints = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.setToStopFrequency = new System.Windows.Forms.NumericUpDown();
            this.statusStopFrequency = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSetTo = new System.Windows.Forms.Button();
            this.setToAvgPoints = new System.Windows.Forms.NumericUpDown();
            this.setToStartFrequency = new System.Windows.Forms.NumericUpDown();
            this.setToSourcePower = new System.Windows.Forms.NumericUpDown();
            this.statusStartFrequency = new System.Windows.Forms.Label();
            this.statusAvgPoints = new System.Windows.Forms.Label();
            this.statusSourcePower = new System.Windows.Forms.Label();
            this.buttonMeasure = new System.Windows.Forms.Button();
            this.labelMeasPower = new System.Windows.Forms.Label();
            this.labelMeasPoints = new System.Windows.Forms.Label();
            this.labelMeasFreqBand = new System.Windows.Forms.Label();
            this.buttonMeasureReSet = new System.Windows.Forms.Button();
            this.groupBoxVisual = new System.Windows.Forms.GroupBox();
            this.indexSelect = new System.Windows.Forms.DomainUpDown();
            this.modeSelect = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonAutoScale = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.powerSelect = new System.Windows.Forms.DomainUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.frequencySelect = new System.Windows.Forms.DomainUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.elevationSelect = new System.Windows.Forms.DomainUpDown();
            this.horizontalSelect = new System.Windows.Forms.DomainUpDown();
            this.depthSelect = new System.Windows.Forms.DomainUpDown();
            this.azimuthSelect = new System.Windows.Forms.DomainUpDown();
            this.verticalSelect = new System.Windows.Forms.DomainUpDown();
            this.polarSelect = new System.Windows.Forms.DomainUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.indepVariable = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.checkScatMP = new System.Windows.Forms.CheckBox();
            this.checkScatRI = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkPhase = new System.Windows.Forms.CheckBox();
            this.checkMag = new System.Windows.Forms.CheckBox();
            this.checkImag = new System.Windows.Forms.CheckBox();
            this.checkReal = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkContinuous = new System.Windows.Forms.CheckBox();
            this.groupBoxPlot = new System.Windows.Forms.GroupBox();
            this.groupBoxConna.SuspendLayout();
            this.groupBoxPos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moveByElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByAzimuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByPolar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToAzimuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToPolar)).BeginInit();
            this.groupBoxScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scanAvgPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scanSourcePower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scanSweepPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionAzimuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionPolar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitAzimuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitPolar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitAzimuth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitHorizontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitPolar)).BeginInit();
            this.groupBoxConard.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.groupBoxMeasurement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setToSweepPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setToStopFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setToAvgPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setToStartFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setToSourcePower)).BeginInit();
            this.groupBoxVisual.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxConna
            // 
            this.groupBoxConna.Controls.Add(this.mode);
            this.groupBoxConna.Controls.Add(this.labelMode);
            this.groupBoxConna.Controls.Add(this.buttonNAConnect);
            this.groupBoxConna.Location = new System.Drawing.Point(5, 26);
            this.groupBoxConna.Margin = new System.Windows.Forms.Padding(1);
            this.groupBoxConna.Name = "groupBoxConna";
            this.groupBoxConna.Padding = new System.Windows.Forms.Padding(1);
            this.groupBoxConna.Size = new System.Drawing.Size(204, 44);
            this.groupBoxConna.TabIndex = 0;
            this.groupBoxConna.TabStop = false;
            this.groupBoxConna.Text = "Network Analyzer Connection";
            // 
            // mode
            // 
            this.mode.FormattingEnabled = true;
            this.mode.Items.AddRange(new object[] {
            "S11",
            "S12",
            "S21",
            "S22"});
            this.mode.Location = new System.Drawing.Point(144, 16);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(53, 21);
            this.mode.TabIndex = 22;
            this.mode.Text = "S21";
            this.mode.TextChanged += new System.EventHandler(this.mode_TextChanged);
            // 
            // labelMode
            // 
            this.labelMode.AutoSize = true;
            this.labelMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMode.Location = new System.Drawing.Point(102, 19);
            this.labelMode.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(38, 13);
            this.labelMode.TabIndex = 21;
            this.labelMode.Text = "Mode";
            // 
            // buttonNAConnect
            // 
            this.buttonNAConnect.Location = new System.Drawing.Point(5, 14);
            this.buttonNAConnect.Margin = new System.Windows.Forms.Padding(1);
            this.buttonNAConnect.Name = "buttonNAConnect";
            this.buttonNAConnect.Size = new System.Drawing.Size(74, 22);
            this.buttonNAConnect.TabIndex = 1;
            this.buttonNAConnect.Text = "Connect";
            this.buttonNAConnect.UseVisualStyleBackColor = true;
            this.buttonNAConnect.Click += new System.EventHandler(this.buttonNAConnect_Click);
            // 
            // groupBoxPos
            // 
            this.groupBoxPos.Controls.Add(this.moveByElevation);
            this.groupBoxPos.Controls.Add(this.moveByHorizontal);
            this.groupBoxPos.Controls.Add(this.moveByDepth);
            this.groupBoxPos.Controls.Add(this.moveByAzimuth);
            this.groupBoxPos.Controls.Add(this.moveByVertical);
            this.groupBoxPos.Controls.Add(this.moveByPolar);
            this.groupBoxPos.Controls.Add(this.moveToElevation);
            this.groupBoxPos.Controls.Add(this.moveToVertical);
            this.groupBoxPos.Controls.Add(this.statusPositionElevation);
            this.groupBoxPos.Controls.Add(this.statusPositionAzimuth);
            this.groupBoxPos.Controls.Add(this.statusPositionDepth);
            this.groupBoxPos.Controls.Add(this.statusPositionHorizontal);
            this.groupBoxPos.Controls.Add(this.statusPositionVertical);
            this.groupBoxPos.Controls.Add(this.moveToAzimuth);
            this.groupBoxPos.Controls.Add(this.moveToDepth);
            this.groupBoxPos.Controls.Add(this.moveToHorizontal);
            this.groupBoxPos.Controls.Add(this.buttonHome);
            this.groupBoxPos.Controls.Add(this.buttonEngageElevation);
            this.groupBoxPos.Controls.Add(this.labelPosEleva);
            this.groupBoxPos.Controls.Add(this.buttonEngageAzimuth);
            this.groupBoxPos.Controls.Add(this.labelPosAzimu);
            this.groupBoxPos.Controls.Add(this.buttonEngageDepth);
            this.groupBoxPos.Controls.Add(this.labelPosDepth);
            this.groupBoxPos.Controls.Add(this.buttonEngageHorizontal);
            this.groupBoxPos.Controls.Add(this.labelPosHoriz);
            this.groupBoxPos.Controls.Add(this.buttonEngageVertical);
            this.groupBoxPos.Controls.Add(this.labelPosVerti);
            this.groupBoxPos.Controls.Add(this.buttonMoveBy);
            this.groupBoxPos.Controls.Add(this.buttonMoveTo);
            this.groupBoxPos.Controls.Add(this.moveToPolar);
            this.groupBoxPos.Controls.Add(this.statusPositionPolar);
            this.groupBoxPos.Controls.Add(this.buttonEngagePolar);
            this.groupBoxPos.Controls.Add(this.labelPosPolar);
            this.groupBoxPos.Controls.Add(this.buttonMoveStop);
            this.groupBoxPos.Controls.Add(this.buttonMoveReSet);
            this.groupBoxPos.Location = new System.Drawing.Point(5, 70);
            this.groupBoxPos.Margin = new System.Windows.Forms.Padding(1);
            this.groupBoxPos.Name = "groupBoxPos";
            this.groupBoxPos.Padding = new System.Windows.Forms.Padding(1);
            this.groupBoxPos.Size = new System.Drawing.Size(415, 186);
            this.groupBoxPos.TabIndex = 1;
            this.groupBoxPos.TabStop = false;
            this.groupBoxPos.Text = "Positioning";
            // 
            // moveByElevation
            // 
            this.moveByElevation.DecimalPlaces = 2;
            this.moveByElevation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveByElevation.Location = new System.Drawing.Point(342, 158);
            this.moveByElevation.Margin = new System.Windows.Forms.Padding(1);
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
            this.moveByElevation.Size = new System.Drawing.Size(67, 20);
            this.moveByElevation.TabIndex = 52;
            // 
            // moveByHorizontal
            // 
            this.moveByHorizontal.DecimalPlaces = 2;
            this.moveByHorizontal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveByHorizontal.Location = new System.Drawing.Point(342, 87);
            this.moveByHorizontal.Margin = new System.Windows.Forms.Padding(1);
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
            this.moveByHorizontal.Size = new System.Drawing.Size(67, 20);
            this.moveByHorizontal.TabIndex = 51;
            // 
            // moveByDepth
            // 
            this.moveByDepth.DecimalPlaces = 2;
            this.moveByDepth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveByDepth.Location = new System.Drawing.Point(342, 111);
            this.moveByDepth.Margin = new System.Windows.Forms.Padding(1);
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
            this.moveByDepth.Size = new System.Drawing.Size(67, 20);
            this.moveByDepth.TabIndex = 50;
            // 
            // moveByAzimuth
            // 
            this.moveByAzimuth.DecimalPlaces = 2;
            this.moveByAzimuth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveByAzimuth.Location = new System.Drawing.Point(342, 134);
            this.moveByAzimuth.Margin = new System.Windows.Forms.Padding(1);
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
            this.moveByAzimuth.Size = new System.Drawing.Size(67, 20);
            this.moveByAzimuth.TabIndex = 49;
            // 
            // moveByVertical
            // 
            this.moveByVertical.DecimalPlaces = 2;
            this.moveByVertical.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveByVertical.Location = new System.Drawing.Point(342, 63);
            this.moveByVertical.Margin = new System.Windows.Forms.Padding(1);
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
            this.moveByVertical.Size = new System.Drawing.Size(67, 20);
            this.moveByVertical.TabIndex = 48;
            // 
            // moveByPolar
            // 
            this.moveByPolar.DecimalPlaces = 2;
            this.moveByPolar.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveByPolar.Location = new System.Drawing.Point(342, 39);
            this.moveByPolar.Margin = new System.Windows.Forms.Padding(1);
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
            this.moveByPolar.Size = new System.Drawing.Size(67, 20);
            this.moveByPolar.TabIndex = 47;
            // 
            // moveToElevation
            // 
            this.moveToElevation.DecimalPlaces = 2;
            this.moveToElevation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveToElevation.Location = new System.Drawing.Point(273, 158);
            this.moveToElevation.Margin = new System.Windows.Forms.Padding(1);
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
            this.moveToElevation.Size = new System.Drawing.Size(67, 20);
            this.moveToElevation.TabIndex = 46;
            // 
            // moveToVertical
            // 
            this.moveToVertical.DecimalPlaces = 2;
            this.moveToVertical.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveToVertical.Location = new System.Drawing.Point(273, 63);
            this.moveToVertical.Margin = new System.Windows.Forms.Padding(1);
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
            this.moveToVertical.Size = new System.Drawing.Size(67, 20);
            this.moveToVertical.TabIndex = 45;
            // 
            // statusPositionElevation
            // 
            this.statusPositionElevation.AutoSize = true;
            this.statusPositionElevation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusPositionElevation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusPositionElevation.Location = new System.Drawing.Point(120, 158);
            this.statusPositionElevation.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.statusPositionElevation.MaximumSize = new System.Drawing.Size(71, 19);
            this.statusPositionElevation.MinimumSize = new System.Drawing.Size(71, 19);
            this.statusPositionElevation.Name = "statusPositionElevation";
            this.statusPositionElevation.Size = new System.Drawing.Size(71, 19);
            this.statusPositionElevation.TabIndex = 44;
            this.statusPositionElevation.Text = "NULL";
            // 
            // statusPositionAzimuth
            // 
            this.statusPositionAzimuth.AutoSize = true;
            this.statusPositionAzimuth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusPositionAzimuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusPositionAzimuth.Location = new System.Drawing.Point(120, 134);
            this.statusPositionAzimuth.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.statusPositionAzimuth.MaximumSize = new System.Drawing.Size(71, 19);
            this.statusPositionAzimuth.MinimumSize = new System.Drawing.Size(71, 19);
            this.statusPositionAzimuth.Name = "statusPositionAzimuth";
            this.statusPositionAzimuth.Size = new System.Drawing.Size(71, 19);
            this.statusPositionAzimuth.TabIndex = 43;
            this.statusPositionAzimuth.Text = "NULL";
            // 
            // statusPositionDepth
            // 
            this.statusPositionDepth.AutoSize = true;
            this.statusPositionDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusPositionDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusPositionDepth.Location = new System.Drawing.Point(120, 111);
            this.statusPositionDepth.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.statusPositionDepth.MaximumSize = new System.Drawing.Size(71, 19);
            this.statusPositionDepth.MinimumSize = new System.Drawing.Size(71, 19);
            this.statusPositionDepth.Name = "statusPositionDepth";
            this.statusPositionDepth.Size = new System.Drawing.Size(71, 19);
            this.statusPositionDepth.TabIndex = 42;
            this.statusPositionDepth.Text = "NULL";
            // 
            // statusPositionHorizontal
            // 
            this.statusPositionHorizontal.AutoSize = true;
            this.statusPositionHorizontal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusPositionHorizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusPositionHorizontal.Location = new System.Drawing.Point(120, 87);
            this.statusPositionHorizontal.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.statusPositionHorizontal.MaximumSize = new System.Drawing.Size(71, 19);
            this.statusPositionHorizontal.MinimumSize = new System.Drawing.Size(71, 19);
            this.statusPositionHorizontal.Name = "statusPositionHorizontal";
            this.statusPositionHorizontal.Size = new System.Drawing.Size(71, 19);
            this.statusPositionHorizontal.TabIndex = 41;
            this.statusPositionHorizontal.Text = "NULL";
            // 
            // statusPositionVertical
            // 
            this.statusPositionVertical.AutoSize = true;
            this.statusPositionVertical.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusPositionVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusPositionVertical.Location = new System.Drawing.Point(120, 63);
            this.statusPositionVertical.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.statusPositionVertical.MaximumSize = new System.Drawing.Size(71, 19);
            this.statusPositionVertical.MinimumSize = new System.Drawing.Size(71, 19);
            this.statusPositionVertical.Name = "statusPositionVertical";
            this.statusPositionVertical.Size = new System.Drawing.Size(71, 19);
            this.statusPositionVertical.TabIndex = 40;
            this.statusPositionVertical.Text = "NULL";
            // 
            // moveToAzimuth
            // 
            this.moveToAzimuth.DecimalPlaces = 2;
            this.moveToAzimuth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveToAzimuth.Location = new System.Drawing.Point(273, 134);
            this.moveToAzimuth.Margin = new System.Windows.Forms.Padding(1);
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
            this.moveToAzimuth.Size = new System.Drawing.Size(67, 20);
            this.moveToAzimuth.TabIndex = 39;
            // 
            // moveToDepth
            // 
            this.moveToDepth.DecimalPlaces = 2;
            this.moveToDepth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveToDepth.Location = new System.Drawing.Point(273, 111);
            this.moveToDepth.Margin = new System.Windows.Forms.Padding(1);
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
            this.moveToDepth.Size = new System.Drawing.Size(67, 20);
            this.moveToDepth.TabIndex = 38;
            // 
            // moveToHorizontal
            // 
            this.moveToHorizontal.DecimalPlaces = 2;
            this.moveToHorizontal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveToHorizontal.Location = new System.Drawing.Point(273, 87);
            this.moveToHorizontal.Margin = new System.Windows.Forms.Padding(1);
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
            this.moveToHorizontal.Size = new System.Drawing.Size(67, 20);
            this.moveToHorizontal.TabIndex = 37;
            // 
            // buttonHome
            // 
            this.buttonHome.Location = new System.Drawing.Point(145, 14);
            this.buttonHome.Margin = new System.Windows.Forms.Padding(1);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(46, 22);
            this.buttonHome.TabIndex = 36;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonEngageElevation
            // 
            this.buttonEngageElevation.Location = new System.Drawing.Point(193, 157);
            this.buttonEngageElevation.Margin = new System.Windows.Forms.Padding(1);
            this.buttonEngageElevation.Name = "buttonEngageElevation";
            this.buttonEngageElevation.Size = new System.Drawing.Size(78, 22);
            this.buttonEngageElevation.TabIndex = 32;
            this.buttonEngageElevation.Text = "Unengaged";
            this.buttonEngageElevation.UseVisualStyleBackColor = true;
            this.buttonEngageElevation.Click += new System.EventHandler(this.buttonEngageElevation_Click);
            // 
            // labelPosEleva
            // 
            this.labelPosEleva.AutoSize = true;
            this.labelPosEleva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosEleva.Location = new System.Drawing.Point(18, 162);
            this.labelPosEleva.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelPosEleva.Name = "labelPosEleva";
            this.labelPosEleva.Size = new System.Drawing.Size(93, 13);
            this.labelPosEleva.TabIndex = 31;
            this.labelPosEleva.Text = "Elevation (deg)";
            // 
            // buttonEngageAzimuth
            // 
            this.buttonEngageAzimuth.Location = new System.Drawing.Point(193, 134);
            this.buttonEngageAzimuth.Margin = new System.Windows.Forms.Padding(1);
            this.buttonEngageAzimuth.Name = "buttonEngageAzimuth";
            this.buttonEngageAzimuth.Size = new System.Drawing.Size(78, 22);
            this.buttonEngageAzimuth.TabIndex = 27;
            this.buttonEngageAzimuth.Text = "Unengaged";
            this.buttonEngageAzimuth.UseVisualStyleBackColor = true;
            this.buttonEngageAzimuth.Click += new System.EventHandler(this.buttonEngageAzimuth_Click);
            // 
            // labelPosAzimu
            // 
            this.labelPosAzimu.AutoSize = true;
            this.labelPosAzimu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosAzimu.Location = new System.Drawing.Point(28, 138);
            this.labelPosAzimu.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelPosAzimu.Name = "labelPosAzimu";
            this.labelPosAzimu.Size = new System.Drawing.Size(84, 13);
            this.labelPosAzimu.TabIndex = 26;
            this.labelPosAzimu.Text = "Azimuth (deg)";
            // 
            // buttonEngageDepth
            // 
            this.buttonEngageDepth.Location = new System.Drawing.Point(193, 110);
            this.buttonEngageDepth.Margin = new System.Windows.Forms.Padding(1);
            this.buttonEngageDepth.Name = "buttonEngageDepth";
            this.buttonEngageDepth.Size = new System.Drawing.Size(78, 22);
            this.buttonEngageDepth.TabIndex = 22;
            this.buttonEngageDepth.Text = "Unengaged";
            this.buttonEngageDepth.UseVisualStyleBackColor = true;
            this.buttonEngageDepth.Click += new System.EventHandler(this.buttonEngageDepth_Click);
            // 
            // labelPosDepth
            // 
            this.labelPosDepth.AutoSize = true;
            this.labelPosDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosDepth.Location = new System.Drawing.Point(44, 114);
            this.labelPosDepth.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelPosDepth.Name = "labelPosDepth";
            this.labelPosDepth.Size = new System.Drawing.Size(69, 13);
            this.labelPosDepth.TabIndex = 21;
            this.labelPosDepth.Text = "Depth (cm)";
            // 
            // buttonEngageHorizontal
            // 
            this.buttonEngageHorizontal.Location = new System.Drawing.Point(193, 86);
            this.buttonEngageHorizontal.Margin = new System.Windows.Forms.Padding(1);
            this.buttonEngageHorizontal.Name = "buttonEngageHorizontal";
            this.buttonEngageHorizontal.Size = new System.Drawing.Size(78, 22);
            this.buttonEngageHorizontal.TabIndex = 17;
            this.buttonEngageHorizontal.Text = "Unengaged";
            this.buttonEngageHorizontal.UseVisualStyleBackColor = true;
            this.buttonEngageHorizontal.Click += new System.EventHandler(this.buttonEngageHorizontal_Click);
            // 
            // labelPosHoriz
            // 
            this.labelPosHoriz.AutoSize = true;
            this.labelPosHoriz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosHoriz.Location = new System.Drawing.Point(12, 91);
            this.labelPosHoriz.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelPosHoriz.Name = "labelPosHoriz";
            this.labelPosHoriz.Size = new System.Drawing.Size(99, 13);
            this.labelPosHoriz.TabIndex = 16;
            this.labelPosHoriz.Text = "Horizonatal (cm)";
            // 
            // buttonEngageVertical
            // 
            this.buttonEngageVertical.Location = new System.Drawing.Point(193, 62);
            this.buttonEngageVertical.Margin = new System.Windows.Forms.Padding(1);
            this.buttonEngageVertical.Name = "buttonEngageVertical";
            this.buttonEngageVertical.Size = new System.Drawing.Size(78, 22);
            this.buttonEngageVertical.TabIndex = 12;
            this.buttonEngageVertical.Text = "Unengaged";
            this.buttonEngageVertical.UseVisualStyleBackColor = true;
            this.buttonEngageVertical.Click += new System.EventHandler(this.buttonEngageVertical_Click);
            // 
            // labelPosVerti
            // 
            this.labelPosVerti.AutoSize = true;
            this.labelPosVerti.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosVerti.Location = new System.Drawing.Point(34, 67);
            this.labelPosVerti.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelPosVerti.Name = "labelPosVerti";
            this.labelPosVerti.Size = new System.Drawing.Size(78, 13);
            this.labelPosVerti.TabIndex = 11;
            this.labelPosVerti.Text = "Vertical (cm)";
            // 
            // buttonMoveBy
            // 
            this.buttonMoveBy.Location = new System.Drawing.Point(342, 14);
            this.buttonMoveBy.Margin = new System.Windows.Forms.Padding(1);
            this.buttonMoveBy.Name = "buttonMoveBy";
            this.buttonMoveBy.Size = new System.Drawing.Size(67, 22);
            this.buttonMoveBy.TabIndex = 10;
            this.buttonMoveBy.Text = "Move-By\r\n";
            this.buttonMoveBy.UseVisualStyleBackColor = true;
            this.buttonMoveBy.Click += new System.EventHandler(this.buttonMoveBy_Click);
            // 
            // buttonMoveTo
            // 
            this.buttonMoveTo.Location = new System.Drawing.Point(273, 14);
            this.buttonMoveTo.Margin = new System.Windows.Forms.Padding(1);
            this.buttonMoveTo.Name = "buttonMoveTo";
            this.buttonMoveTo.Size = new System.Drawing.Size(67, 22);
            this.buttonMoveTo.TabIndex = 9;
            this.buttonMoveTo.Text = "Move-To\r\n";
            this.buttonMoveTo.UseVisualStyleBackColor = true;
            this.buttonMoveTo.Click += new System.EventHandler(this.buttonMoveTo_Click);
            // 
            // moveToPolar
            // 
            this.moveToPolar.DecimalPlaces = 2;
            this.moveToPolar.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.moveToPolar.Location = new System.Drawing.Point(273, 39);
            this.moveToPolar.Margin = new System.Windows.Forms.Padding(1);
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
            this.moveToPolar.Size = new System.Drawing.Size(67, 20);
            this.moveToPolar.TabIndex = 6;
            // 
            // statusPositionPolar
            // 
            this.statusPositionPolar.AutoSize = true;
            this.statusPositionPolar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusPositionPolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusPositionPolar.Location = new System.Drawing.Point(120, 39);
            this.statusPositionPolar.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.statusPositionPolar.MaximumSize = new System.Drawing.Size(71, 19);
            this.statusPositionPolar.MinimumSize = new System.Drawing.Size(71, 19);
            this.statusPositionPolar.Name = "statusPositionPolar";
            this.statusPositionPolar.Size = new System.Drawing.Size(71, 19);
            this.statusPositionPolar.TabIndex = 5;
            this.statusPositionPolar.Text = "NULL";
            // 
            // buttonEngagePolar
            // 
            this.buttonEngagePolar.Location = new System.Drawing.Point(193, 38);
            this.buttonEngagePolar.Margin = new System.Windows.Forms.Padding(1);
            this.buttonEngagePolar.Name = "buttonEngagePolar";
            this.buttonEngagePolar.Size = new System.Drawing.Size(78, 22);
            this.buttonEngagePolar.TabIndex = 4;
            this.buttonEngagePolar.Text = "Unengaged";
            this.buttonEngagePolar.UseVisualStyleBackColor = true;
            this.buttonEngagePolar.Click += new System.EventHandler(this.buttonEngagePolar_Click);
            // 
            // labelPosPolar
            // 
            this.labelPosPolar.AutoSize = true;
            this.labelPosPolar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosPolar.Location = new System.Drawing.Point(4, 43);
            this.labelPosPolar.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelPosPolar.Name = "labelPosPolar";
            this.labelPosPolar.Size = new System.Drawing.Size(106, 13);
            this.labelPosPolar.TabIndex = 3;
            this.labelPosPolar.Text = "Polarization (deg)";
            // 
            // buttonMoveStop
            // 
            this.buttonMoveStop.Location = new System.Drawing.Point(102, 14);
            this.buttonMoveStop.Margin = new System.Windows.Forms.Padding(1);
            this.buttonMoveStop.Name = "buttonMoveStop";
            this.buttonMoveStop.Size = new System.Drawing.Size(40, 22);
            this.buttonMoveStop.TabIndex = 2;
            this.buttonMoveStop.Text = "Stop";
            this.buttonMoveStop.UseVisualStyleBackColor = true;
            this.buttonMoveStop.Click += new System.EventHandler(this.buttonMoveStop_Click);
            // 
            // buttonMoveReSet
            // 
            this.buttonMoveReSet.Location = new System.Drawing.Point(4, 14);
            this.buttonMoveReSet.Margin = new System.Windows.Forms.Padding(1);
            this.buttonMoveReSet.Name = "buttonMoveReSet";
            this.buttonMoveReSet.Size = new System.Drawing.Size(96, 22);
            this.buttonMoveReSet.TabIndex = 1;
            this.buttonMoveReSet.Text = "Reload Settings";
            this.buttonMoveReSet.UseVisualStyleBackColor = true;
            this.buttonMoveReSet.Click += new System.EventHandler(this.buttonMoveReSet_Click);
            // 
            // groupBoxScan
            // 
            this.groupBoxScan.Controls.Add(this.label2);
            this.groupBoxScan.Controls.Add(this.label24);
            this.groupBoxScan.Controls.Add(this.progressPercent);
            this.groupBoxScan.Controls.Add(this.scanEstimatedTime);
            this.groupBoxScan.Controls.Add(this.scanAvgPoints);
            this.groupBoxScan.Controls.Add(this.label21);
            this.groupBoxScan.Controls.Add(this.scanSourcePower);
            this.groupBoxScan.Controls.Add(this.label20);
            this.groupBoxScan.Controls.Add(this.upperLimitFrequency);
            this.groupBoxScan.Controls.Add(this.lowerLimitFrequency);
            this.groupBoxScan.Controls.Add(this.scanSweepPoints);
            this.groupBoxScan.Controls.Add(this.label19);
            this.groupBoxScan.Controls.Add(this.resolutionElevation);
            this.groupBoxScan.Controls.Add(this.resolutionHorizontal);
            this.groupBoxScan.Controls.Add(this.resolutionDepth);
            this.groupBoxScan.Controls.Add(this.resolutionAzimuth);
            this.groupBoxScan.Controls.Add(this.resolutionVertical);
            this.groupBoxScan.Controls.Add(this.resolutionPolar);
            this.groupBoxScan.Controls.Add(this.upperLimitElevation);
            this.groupBoxScan.Controls.Add(this.upperLimitHorizontal);
            this.groupBoxScan.Controls.Add(this.upperLimitDepth);
            this.groupBoxScan.Controls.Add(this.upperLimitAzimuth);
            this.groupBoxScan.Controls.Add(this.upperLimitVertical);
            this.groupBoxScan.Controls.Add(this.upperLimitPolar);
            this.groupBoxScan.Controls.Add(this.lowerLimitElevation);
            this.groupBoxScan.Controls.Add(this.lowerLimitVertical);
            this.groupBoxScan.Controls.Add(this.lowerLimitAzimuth);
            this.groupBoxScan.Controls.Add(this.lowerLimitDepth);
            this.groupBoxScan.Controls.Add(this.lowerLimitHorizontal);
            this.groupBoxScan.Controls.Add(this.lowerLimitPolar);
            this.groupBoxScan.Controls.Add(this.label13);
            this.groupBoxScan.Controls.Add(this.label14);
            this.groupBoxScan.Controls.Add(this.label15);
            this.groupBoxScan.Controls.Add(this.label16);
            this.groupBoxScan.Controls.Add(this.label17);
            this.groupBoxScan.Controls.Add(this.label18);
            this.groupBoxScan.Controls.Add(this.progressBar);
            this.groupBoxScan.Controls.Add(this.labelScanEstim);
            this.groupBoxScan.Controls.Add(this.scanType);
            this.groupBoxScan.Controls.Add(this.labelScanType);
            this.groupBoxScan.Controls.Add(this.label3);
            this.groupBoxScan.Controls.Add(this.label1);
            this.groupBoxScan.Controls.Add(this.buttonScanStart);
            this.groupBoxScan.Controls.Add(this.buttonLockElevation);
            this.groupBoxScan.Controls.Add(this.buttonLockAzimuth);
            this.groupBoxScan.Controls.Add(this.buttonLockDepth);
            this.groupBoxScan.Controls.Add(this.buttonLockHorizontal);
            this.groupBoxScan.Controls.Add(this.buttonLockVertical);
            this.groupBoxScan.Controls.Add(this.label11);
            this.groupBoxScan.Controls.Add(this.buttonLockPolar);
            this.groupBoxScan.Controls.Add(this.buttonScanCancel);
            this.groupBoxScan.Controls.Add(this.buttonScanReSet);
            this.groupBoxScan.Location = new System.Drawing.Point(5, 416);
            this.groupBoxScan.Margin = new System.Windows.Forms.Padding(1);
            this.groupBoxScan.Name = "groupBoxScan";
            this.groupBoxScan.Padding = new System.Windows.Forms.Padding(1);
            this.groupBoxScan.Size = new System.Drawing.Size(415, 305);
            this.groupBoxScan.TabIndex = 2;
            this.groupBoxScan.TabStop = false;
            this.groupBoxScan.Text = "Scan Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 208);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "# Sweep Points";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(5, 278);
            this.label24.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label24.MaximumSize = new System.Drawing.Size(69, 19);
            this.label24.MinimumSize = new System.Drawing.Size(69, 19);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(69, 19);
            this.label24.TabIndex = 86;
            this.label24.Text = "Progress";
            // 
            // progressPercent
            // 
            this.progressPercent.AutoSize = true;
            this.progressPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressPercent.Location = new System.Drawing.Point(352, 278);
            this.progressPercent.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.progressPercent.MaximumSize = new System.Drawing.Size(50, 19);
            this.progressPercent.MinimumSize = new System.Drawing.Size(50, 19);
            this.progressPercent.Name = "progressPercent";
            this.progressPercent.Size = new System.Drawing.Size(50, 19);
            this.progressPercent.TabIndex = 85;
            this.progressPercent.Text = "100%";
            // 
            // scanEstimatedTime
            // 
            this.scanEstimatedTime.AutoSize = true;
            this.scanEstimatedTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scanEstimatedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanEstimatedTime.Location = new System.Drawing.Point(349, 253);
            this.scanEstimatedTime.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.scanEstimatedTime.MaximumSize = new System.Drawing.Size(53, 19);
            this.scanEstimatedTime.MinimumSize = new System.Drawing.Size(53, 19);
            this.scanEstimatedTime.Name = "scanEstimatedTime";
            this.scanEstimatedTime.Size = new System.Drawing.Size(53, 19);
            this.scanEstimatedTime.TabIndex = 84;
            this.scanEstimatedTime.Text = "NULL";
            // 
            // scanAvgPoints
            // 
            this.scanAvgPoints.Location = new System.Drawing.Point(349, 230);
            this.scanAvgPoints.Margin = new System.Windows.Forms.Padding(1);
            this.scanAvgPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scanAvgPoints.Name = "scanAvgPoints";
            this.scanAvgPoints.Size = new System.Drawing.Size(53, 20);
            this.scanAvgPoints.TabIndex = 83;
            this.scanAvgPoints.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(224, 232);
            this.label21.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(115, 13);
            this.label21.TabIndex = 82;
            this.label21.Text = "# Averaging Points";
            // 
            // scanSourcePower
            // 
            this.scanSourcePower.DecimalPlaces = 3;
            this.scanSourcePower.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.scanSourcePower.Location = new System.Drawing.Point(131, 230);
            this.scanSourcePower.Margin = new System.Windows.Forms.Padding(1);
            this.scanSourcePower.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.scanSourcePower.Minimum = new decimal(new int[] {
            47,
            0,
            0,
            -2147483648});
            this.scanSourcePower.Name = "scanSourcePower";
            this.scanSourcePower.Size = new System.Drawing.Size(77, 20);
            this.scanSourcePower.TabIndex = 81;
            this.scanSourcePower.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 234);
            this.label20.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(113, 13);
            this.label20.TabIndex = 80;
            this.label20.Text = "Source Power (dB)";
            // 
            // upperLimitFrequency
            // 
            this.upperLimitFrequency.DecimalPlaces = 3;
            this.upperLimitFrequency.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.upperLimitFrequency.Location = new System.Drawing.Point(264, 182);
            this.upperLimitFrequency.Margin = new System.Windows.Forms.Padding(1);
            this.upperLimitFrequency.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.upperLimitFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperLimitFrequency.Name = "upperLimitFrequency";
            this.upperLimitFrequency.Size = new System.Drawing.Size(77, 20);
            this.upperLimitFrequency.TabIndex = 79;
            this.upperLimitFrequency.Value = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            // 
            // lowerLimitFrequency
            // 
            this.lowerLimitFrequency.DecimalPlaces = 3;
            this.lowerLimitFrequency.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.lowerLimitFrequency.Location = new System.Drawing.Point(184, 182);
            this.lowerLimitFrequency.Margin = new System.Windows.Forms.Padding(1);
            this.lowerLimitFrequency.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.lowerLimitFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerLimitFrequency.Name = "lowerLimitFrequency";
            this.lowerLimitFrequency.Size = new System.Drawing.Size(77, 20);
            this.lowerLimitFrequency.TabIndex = 78;
            this.lowerLimitFrequency.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // scanSweepPoints
            // 
            this.scanSweepPoints.Location = new System.Drawing.Point(184, 206);
            this.scanSweepPoints.Margin = new System.Windows.Forms.Padding(1);
            this.scanSweepPoints.Maximum = new decimal(new int[] {
            10001,
            0,
            0,
            0});
            this.scanSweepPoints.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.scanSweepPoints.Name = "scanSweepPoints";
            this.scanSweepPoints.Size = new System.Drawing.Size(77, 20);
            this.scanSweepPoints.TabIndex = 77;
            this.scanSweepPoints.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(72, 185);
            this.label19.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 13);
            this.label19.TabIndex = 76;
            this.label19.Text = "Frequency (MHz)";
            // 
            // resolutionElevation
            // 
            this.resolutionElevation.DecimalPlaces = 2;
            this.resolutionElevation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.resolutionElevation.Location = new System.Drawing.Point(335, 158);
            this.resolutionElevation.Margin = new System.Windows.Forms.Padding(1);
            this.resolutionElevation.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.resolutionElevation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.resolutionElevation.Name = "resolutionElevation";
            this.resolutionElevation.Size = new System.Drawing.Size(67, 20);
            this.resolutionElevation.TabIndex = 75;
            this.resolutionElevation.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // resolutionHorizontal
            // 
            this.resolutionHorizontal.DecimalPlaces = 2;
            this.resolutionHorizontal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.resolutionHorizontal.Location = new System.Drawing.Point(335, 87);
            this.resolutionHorizontal.Margin = new System.Windows.Forms.Padding(1);
            this.resolutionHorizontal.Maximum = new decimal(new int[] {
            210,
            0,
            0,
            0});
            this.resolutionHorizontal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.resolutionHorizontal.Name = "resolutionHorizontal";
            this.resolutionHorizontal.Size = new System.Drawing.Size(67, 20);
            this.resolutionHorizontal.TabIndex = 74;
            this.resolutionHorizontal.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // resolutionDepth
            // 
            this.resolutionDepth.DecimalPlaces = 2;
            this.resolutionDepth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.resolutionDepth.Location = new System.Drawing.Point(335, 111);
            this.resolutionDepth.Margin = new System.Windows.Forms.Padding(1);
            this.resolutionDepth.Maximum = new decimal(new int[] {
            280,
            0,
            0,
            0});
            this.resolutionDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.resolutionDepth.Name = "resolutionDepth";
            this.resolutionDepth.Size = new System.Drawing.Size(67, 20);
            this.resolutionDepth.TabIndex = 73;
            this.resolutionDepth.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // resolutionAzimuth
            // 
            this.resolutionAzimuth.DecimalPlaces = 2;
            this.resolutionAzimuth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.resolutionAzimuth.Location = new System.Drawing.Point(335, 134);
            this.resolutionAzimuth.Margin = new System.Windows.Forms.Padding(1);
            this.resolutionAzimuth.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.resolutionAzimuth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.resolutionAzimuth.Name = "resolutionAzimuth";
            this.resolutionAzimuth.Size = new System.Drawing.Size(67, 20);
            this.resolutionAzimuth.TabIndex = 72;
            this.resolutionAzimuth.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // resolutionVertical
            // 
            this.resolutionVertical.DecimalPlaces = 2;
            this.resolutionVertical.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.resolutionVertical.Location = new System.Drawing.Point(335, 63);
            this.resolutionVertical.Margin = new System.Windows.Forms.Padding(1);
            this.resolutionVertical.Maximum = new decimal(new int[] {
            210,
            0,
            0,
            0});
            this.resolutionVertical.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.resolutionVertical.Name = "resolutionVertical";
            this.resolutionVertical.Size = new System.Drawing.Size(67, 20);
            this.resolutionVertical.TabIndex = 71;
            this.resolutionVertical.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // resolutionPolar
            // 
            this.resolutionPolar.DecimalPlaces = 2;
            this.resolutionPolar.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.resolutionPolar.Location = new System.Drawing.Point(335, 39);
            this.resolutionPolar.Margin = new System.Windows.Forms.Padding(1);
            this.resolutionPolar.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.resolutionPolar.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.resolutionPolar.Name = "resolutionPolar";
            this.resolutionPolar.Size = new System.Drawing.Size(67, 20);
            this.resolutionPolar.TabIndex = 70;
            this.resolutionPolar.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // upperLimitElevation
            // 
            this.upperLimitElevation.DecimalPlaces = 2;
            this.upperLimitElevation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperLimitElevation.Location = new System.Drawing.Point(264, 158);
            this.upperLimitElevation.Margin = new System.Windows.Forms.Padding(1);
            this.upperLimitElevation.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.upperLimitElevation.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.upperLimitElevation.Name = "upperLimitElevation";
            this.upperLimitElevation.Size = new System.Drawing.Size(67, 20);
            this.upperLimitElevation.TabIndex = 69;
            this.upperLimitElevation.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            // 
            // upperLimitHorizontal
            // 
            this.upperLimitHorizontal.DecimalPlaces = 2;
            this.upperLimitHorizontal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperLimitHorizontal.Location = new System.Drawing.Point(264, 87);
            this.upperLimitHorizontal.Margin = new System.Windows.Forms.Padding(1);
            this.upperLimitHorizontal.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.upperLimitHorizontal.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.upperLimitHorizontal.Name = "upperLimitHorizontal";
            this.upperLimitHorizontal.Size = new System.Drawing.Size(67, 20);
            this.upperLimitHorizontal.TabIndex = 68;
            this.upperLimitHorizontal.Value = new decimal(new int[] {
            105,
            0,
            0,
            0});
            // 
            // upperLimitDepth
            // 
            this.upperLimitDepth.DecimalPlaces = 2;
            this.upperLimitDepth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperLimitDepth.Location = new System.Drawing.Point(264, 111);
            this.upperLimitDepth.Margin = new System.Windows.Forms.Padding(1);
            this.upperLimitDepth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.upperLimitDepth.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.upperLimitDepth.Name = "upperLimitDepth";
            this.upperLimitDepth.Size = new System.Drawing.Size(67, 20);
            this.upperLimitDepth.TabIndex = 67;
            this.upperLimitDepth.Value = new decimal(new int[] {
            140,
            0,
            0,
            0});
            // 
            // upperLimitAzimuth
            // 
            this.upperLimitAzimuth.DecimalPlaces = 2;
            this.upperLimitAzimuth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperLimitAzimuth.Location = new System.Drawing.Point(264, 134);
            this.upperLimitAzimuth.Margin = new System.Windows.Forms.Padding(1);
            this.upperLimitAzimuth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.upperLimitAzimuth.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.upperLimitAzimuth.Name = "upperLimitAzimuth";
            this.upperLimitAzimuth.Size = new System.Drawing.Size(67, 20);
            this.upperLimitAzimuth.TabIndex = 66;
            this.upperLimitAzimuth.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            // 
            // upperLimitVertical
            // 
            this.upperLimitVertical.DecimalPlaces = 2;
            this.upperLimitVertical.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperLimitVertical.Location = new System.Drawing.Point(264, 63);
            this.upperLimitVertical.Margin = new System.Windows.Forms.Padding(1);
            this.upperLimitVertical.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.upperLimitVertical.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.upperLimitVertical.Name = "upperLimitVertical";
            this.upperLimitVertical.Size = new System.Drawing.Size(67, 20);
            this.upperLimitVertical.TabIndex = 65;
            this.upperLimitVertical.Value = new decimal(new int[] {
            105,
            0,
            0,
            0});
            // 
            // upperLimitPolar
            // 
            this.upperLimitPolar.DecimalPlaces = 2;
            this.upperLimitPolar.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.upperLimitPolar.Location = new System.Drawing.Point(264, 39);
            this.upperLimitPolar.Margin = new System.Windows.Forms.Padding(1);
            this.upperLimitPolar.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.upperLimitPolar.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.upperLimitPolar.Name = "upperLimitPolar";
            this.upperLimitPolar.Size = new System.Drawing.Size(67, 20);
            this.upperLimitPolar.TabIndex = 64;
            this.upperLimitPolar.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            // 
            // lowerLimitElevation
            // 
            this.lowerLimitElevation.DecimalPlaces = 2;
            this.lowerLimitElevation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerLimitElevation.Location = new System.Drawing.Point(194, 158);
            this.lowerLimitElevation.Margin = new System.Windows.Forms.Padding(1);
            this.lowerLimitElevation.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.lowerLimitElevation.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.lowerLimitElevation.Name = "lowerLimitElevation";
            this.lowerLimitElevation.Size = new System.Drawing.Size(67, 20);
            this.lowerLimitElevation.TabIndex = 63;
            this.lowerLimitElevation.Value = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            // 
            // lowerLimitVertical
            // 
            this.lowerLimitVertical.DecimalPlaces = 2;
            this.lowerLimitVertical.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerLimitVertical.Location = new System.Drawing.Point(194, 63);
            this.lowerLimitVertical.Margin = new System.Windows.Forms.Padding(1);
            this.lowerLimitVertical.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.lowerLimitVertical.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.lowerLimitVertical.Name = "lowerLimitVertical";
            this.lowerLimitVertical.Size = new System.Drawing.Size(67, 20);
            this.lowerLimitVertical.TabIndex = 62;
            this.lowerLimitVertical.Value = new decimal(new int[] {
            105,
            0,
            0,
            -2147483648});
            // 
            // lowerLimitAzimuth
            // 
            this.lowerLimitAzimuth.DecimalPlaces = 2;
            this.lowerLimitAzimuth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerLimitAzimuth.Location = new System.Drawing.Point(194, 134);
            this.lowerLimitAzimuth.Margin = new System.Windows.Forms.Padding(1);
            this.lowerLimitAzimuth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.lowerLimitAzimuth.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.lowerLimitAzimuth.Name = "lowerLimitAzimuth";
            this.lowerLimitAzimuth.Size = new System.Drawing.Size(67, 20);
            this.lowerLimitAzimuth.TabIndex = 61;
            // 
            // lowerLimitDepth
            // 
            this.lowerLimitDepth.DecimalPlaces = 2;
            this.lowerLimitDepth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerLimitDepth.Location = new System.Drawing.Point(194, 111);
            this.lowerLimitDepth.Margin = new System.Windows.Forms.Padding(1);
            this.lowerLimitDepth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.lowerLimitDepth.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.lowerLimitDepth.Name = "lowerLimitDepth";
            this.lowerLimitDepth.Size = new System.Drawing.Size(67, 20);
            this.lowerLimitDepth.TabIndex = 60;
            this.lowerLimitDepth.Value = new decimal(new int[] {
            140,
            0,
            0,
            -2147483648});
            // 
            // lowerLimitHorizontal
            // 
            this.lowerLimitHorizontal.DecimalPlaces = 2;
            this.lowerLimitHorizontal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerLimitHorizontal.Location = new System.Drawing.Point(194, 87);
            this.lowerLimitHorizontal.Margin = new System.Windows.Forms.Padding(1);
            this.lowerLimitHorizontal.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.lowerLimitHorizontal.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.lowerLimitHorizontal.Name = "lowerLimitHorizontal";
            this.lowerLimitHorizontal.Size = new System.Drawing.Size(67, 20);
            this.lowerLimitHorizontal.TabIndex = 59;
            this.lowerLimitHorizontal.Value = new decimal(new int[] {
            105,
            0,
            0,
            -2147483648});
            // 
            // lowerLimitPolar
            // 
            this.lowerLimitPolar.DecimalPlaces = 2;
            this.lowerLimitPolar.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.lowerLimitPolar.Location = new System.Drawing.Point(194, 39);
            this.lowerLimitPolar.Margin = new System.Windows.Forms.Padding(1);
            this.lowerLimitPolar.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.lowerLimitPolar.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.lowerLimitPolar.Name = "lowerLimitPolar";
            this.lowerLimitPolar.Size = new System.Drawing.Size(67, 20);
            this.lowerLimitPolar.TabIndex = 58;
            this.lowerLimitPolar.Value = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(18, 162);
            this.label13.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 13);
            this.label13.TabIndex = 57;
            this.label13.Text = "Elevation (deg)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(28, 138);
            this.label14.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 13);
            this.label14.TabIndex = 56;
            this.label14.Text = "Azimuth (deg)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(44, 114);
            this.label15.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 55;
            this.label15.Text = "Depth (cm)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 91);
            this.label16.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 13);
            this.label16.TabIndex = 54;
            this.label16.Text = "Horizonatal (cm)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(34, 67);
            this.label17.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 13);
            this.label17.TabIndex = 53;
            this.label17.Text = "Vertical (cm)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(4, 43);
            this.label18.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 13);
            this.label18.TabIndex = 52;
            this.label18.Text = "Polarization (deg)";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(75, 278);
            this.progressBar.Margin = new System.Windows.Forms.Padding(1);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(277, 19);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 49;
            // 
            // labelScanEstim
            // 
            this.labelScanEstim.AutoSize = true;
            this.labelScanEstim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScanEstim.Location = new System.Drawing.Point(213, 256);
            this.labelScanEstim.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelScanEstim.Name = "labelScanEstim";
            this.labelScanEstim.Size = new System.Drawing.Size(125, 13);
            this.labelScanEstim.TabIndex = 47;
            this.labelScanEstim.Text = "Estimated Time (sec)";
            // 
            // scanType
            // 
            this.scanType.FormattingEnabled = true;
            this.scanType.Location = new System.Drawing.Point(78, 253);
            this.scanType.Name = "scanType";
            this.scanType.Size = new System.Drawing.Size(129, 21);
            this.scanType.TabIndex = 46;
            this.scanType.Text = "Single";
            // 
            // labelScanType
            // 
            this.labelScanType.AutoSize = true;
            this.labelScanType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScanType.Location = new System.Drawing.Point(4, 256);
            this.labelScanType.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelScanType.Name = "labelScanType";
            this.labelScanType.Size = new System.Drawing.Size(68, 13);
            this.labelScanType.TabIndex = 45;
            this.labelScanType.Text = "Scan Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(330, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Resolution\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(280, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 26);
            this.label1.TabIndex = 43;
            this.label1.Text = "Upper\r\nLimit\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonScanStart
            // 
            this.buttonScanStart.Location = new System.Drawing.Point(104, 14);
            this.buttonScanStart.Margin = new System.Windows.Forms.Padding(1);
            this.buttonScanStart.Name = "buttonScanStart";
            this.buttonScanStart.Size = new System.Drawing.Size(58, 22);
            this.buttonScanStart.TabIndex = 36;
            this.buttonScanStart.Text = "Start";
            this.buttonScanStart.UseVisualStyleBackColor = true;
            this.buttonScanStart.Click += new System.EventHandler(this.buttonScanStart_Click);
            // 
            // buttonLockElevation
            // 
            this.buttonLockElevation.Location = new System.Drawing.Point(120, 157);
            this.buttonLockElevation.Margin = new System.Windows.Forms.Padding(1);
            this.buttonLockElevation.Name = "buttonLockElevation";
            this.buttonLockElevation.Size = new System.Drawing.Size(72, 22);
            this.buttonLockElevation.TabIndex = 32;
            this.buttonLockElevation.Text = "Locked";
            this.buttonLockElevation.UseVisualStyleBackColor = true;
            this.buttonLockElevation.Click += new System.EventHandler(this.buttonLockElevation_Click);
            // 
            // buttonLockAzimuth
            // 
            this.buttonLockAzimuth.Location = new System.Drawing.Point(120, 134);
            this.buttonLockAzimuth.Margin = new System.Windows.Forms.Padding(1);
            this.buttonLockAzimuth.Name = "buttonLockAzimuth";
            this.buttonLockAzimuth.Size = new System.Drawing.Size(72, 22);
            this.buttonLockAzimuth.TabIndex = 27;
            this.buttonLockAzimuth.Text = "Locked";
            this.buttonLockAzimuth.UseVisualStyleBackColor = true;
            this.buttonLockAzimuth.Click += new System.EventHandler(this.buttonLockAzimuth_Click);
            // 
            // buttonLockDepth
            // 
            this.buttonLockDepth.Location = new System.Drawing.Point(120, 110);
            this.buttonLockDepth.Margin = new System.Windows.Forms.Padding(1);
            this.buttonLockDepth.Name = "buttonLockDepth";
            this.buttonLockDepth.Size = new System.Drawing.Size(72, 22);
            this.buttonLockDepth.TabIndex = 22;
            this.buttonLockDepth.Text = "Locked";
            this.buttonLockDepth.UseVisualStyleBackColor = true;
            this.buttonLockDepth.Click += new System.EventHandler(this.buttonLockDepth_Click);
            // 
            // buttonLockHorizontal
            // 
            this.buttonLockHorizontal.Location = new System.Drawing.Point(120, 86);
            this.buttonLockHorizontal.Margin = new System.Windows.Forms.Padding(1);
            this.buttonLockHorizontal.Name = "buttonLockHorizontal";
            this.buttonLockHorizontal.Size = new System.Drawing.Size(72, 22);
            this.buttonLockHorizontal.TabIndex = 17;
            this.buttonLockHorizontal.Text = "Locked";
            this.buttonLockHorizontal.UseVisualStyleBackColor = true;
            this.buttonLockHorizontal.Click += new System.EventHandler(this.buttonLockHorizontal_Click);
            // 
            // buttonLockVertical
            // 
            this.buttonLockVertical.Location = new System.Drawing.Point(120, 62);
            this.buttonLockVertical.Margin = new System.Windows.Forms.Padding(1);
            this.buttonLockVertical.Name = "buttonLockVertical";
            this.buttonLockVertical.Size = new System.Drawing.Size(72, 22);
            this.buttonLockVertical.TabIndex = 12;
            this.buttonLockVertical.Text = "Locked";
            this.buttonLockVertical.UseVisualStyleBackColor = true;
            this.buttonLockVertical.Click += new System.EventHandler(this.buttonLockVertical_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(216, 13);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 26);
            this.label11.TabIndex = 8;
            this.label11.Text = "Lower\r\nLimit";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonLockPolar
            // 
            this.buttonLockPolar.Location = new System.Drawing.Point(120, 38);
            this.buttonLockPolar.Margin = new System.Windows.Forms.Padding(1);
            this.buttonLockPolar.Name = "buttonLockPolar";
            this.buttonLockPolar.Size = new System.Drawing.Size(72, 22);
            this.buttonLockPolar.TabIndex = 4;
            this.buttonLockPolar.Text = "Locked";
            this.buttonLockPolar.UseVisualStyleBackColor = true;
            this.buttonLockPolar.Click += new System.EventHandler(this.buttonLockPolar_Click);
            // 
            // buttonScanCancel
            // 
            this.buttonScanCancel.Location = new System.Drawing.Point(163, 14);
            this.buttonScanCancel.Margin = new System.Windows.Forms.Padding(1);
            this.buttonScanCancel.Name = "buttonScanCancel";
            this.buttonScanCancel.Size = new System.Drawing.Size(51, 22);
            this.buttonScanCancel.TabIndex = 2;
            this.buttonScanCancel.Text = "Cancel";
            this.buttonScanCancel.UseVisualStyleBackColor = true;
            this.buttonScanCancel.Click += new System.EventHandler(this.buttonScanCancel_Click);
            // 
            // buttonScanReSet
            // 
            this.buttonScanReSet.Location = new System.Drawing.Point(5, 14);
            this.buttonScanReSet.Margin = new System.Windows.Forms.Padding(1);
            this.buttonScanReSet.Name = "buttonScanReSet";
            this.buttonScanReSet.Size = new System.Drawing.Size(96, 22);
            this.buttonScanReSet.TabIndex = 1;
            this.buttonScanReSet.Text = "Reload Settings";
            this.buttonScanReSet.UseVisualStyleBackColor = true;
            this.buttonScanReSet.Click += new System.EventHandler(this.buttonScanReSet_Click);
            // 
            // groupBoxConard
            // 
            this.groupBoxConard.Controls.Add(this.port);
            this.groupBoxConard.Controls.Add(this.labelConardPort);
            this.groupBoxConard.Controls.Add(this.buttonArduinoConnect);
            this.groupBoxConard.Location = new System.Drawing.Point(216, 26);
            this.groupBoxConard.Name = "groupBoxConard";
            this.groupBoxConard.Size = new System.Drawing.Size(204, 44);
            this.groupBoxConard.TabIndex = 3;
            this.groupBoxConard.TabStop = false;
            this.groupBoxConard.Text = "Arduino Connection";
            // 
            // port
            // 
            this.port.FormattingEnabled = true;
            this.port.Location = new System.Drawing.Point(121, 16);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(76, 21);
            this.port.TabIndex = 6;
            this.port.Text = "COM#";
            // 
            // labelConardPort
            // 
            this.labelConardPort.AutoSize = true;
            this.labelConardPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConardPort.Location = new System.Drawing.Point(89, 19);
            this.labelConardPort.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelConardPort.Name = "labelConardPort";
            this.labelConardPort.Size = new System.Drawing.Size(30, 13);
            this.labelConardPort.TabIndex = 5;
            this.labelConardPort.Text = "Port";
            // 
            // buttonArduinoConnect
            // 
            this.buttonArduinoConnect.Location = new System.Drawing.Point(5, 14);
            this.buttonArduinoConnect.Margin = new System.Windows.Forms.Padding(1);
            this.buttonArduinoConnect.Name = "buttonArduinoConnect";
            this.buttonArduinoConnect.Size = new System.Drawing.Size(74, 22);
            this.buttonArduinoConnect.TabIndex = 2;
            this.buttonArduinoConnect.Text = "Connect";
            this.buttonArduinoConnect.UseVisualStyleBackColor = true;
            this.buttonArduinoConnect.Click += new System.EventHandler(this.buttonArduinoConnect_Click);
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.listBoxOutput);
            this.groupBoxOutput.Location = new System.Drawing.Point(779, 461);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(393, 260);
            this.groupBoxOutput.TabIndex = 4;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output";
            // 
            // listBoxOutput
            // 
            this.listBoxOutput.FormattingEnabled = true;
            this.listBoxOutput.Location = new System.Drawing.Point(6, 16);
            this.listBoxOutput.Name = "listBoxOutput";
            this.listBoxOutput.Size = new System.Drawing.Size(381, 225);
            this.listBoxOutput.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.dataToolStripMenuItem,
            this.menuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1177, 24);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemChangeSettings,
            this.menuItemSaveSettings,
            this.menuItemSaveData,
            this.menuItemLoadData,
            this.menuItemRescanPorts,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "File";
            // 
            // menuItemChangeSettings
            // 
            this.menuItemChangeSettings.Name = "menuItemChangeSettings";
            this.menuItemChangeSettings.Size = new System.Drawing.Size(209, 22);
            this.menuItemChangeSettings.Text = "Change Settings Location";
            this.menuItemChangeSettings.Click += new System.EventHandler(this.menuItemChangeSettingsLocation_Click);
            // 
            // menuItemSaveSettings
            // 
            this.menuItemSaveSettings.Name = "menuItemSaveSettings";
            this.menuItemSaveSettings.Size = new System.Drawing.Size(209, 22);
            this.menuItemSaveSettings.Text = "Save Settings";
            this.menuItemSaveSettings.Click += new System.EventHandler(this.menuItemSaveSettings_Click);
            // 
            // menuItemSaveData
            // 
            this.menuItemSaveData.Name = "menuItemSaveData";
            this.menuItemSaveData.Size = new System.Drawing.Size(209, 22);
            this.menuItemSaveData.Text = "Save Data";
            this.menuItemSaveData.Click += new System.EventHandler(this.menuItemSaveData_Click);
            // 
            // menuItemLoadData
            // 
            this.menuItemLoadData.Name = "menuItemLoadData";
            this.menuItemLoadData.Size = new System.Drawing.Size(209, 22);
            this.menuItemLoadData.Text = "Load Data";
            this.menuItemLoadData.Click += new System.EventHandler(this.menuItemLoadData_Click);
            // 
            // menuItemRescanPorts
            // 
            this.menuItemRescanPorts.Name = "menuItemRescanPorts";
            this.menuItemRescanPorts.Size = new System.Drawing.Size(209, 22);
            this.menuItemRescanPorts.Text = "Rescan Ports";
            this.menuItemRescanPorts.Click += new System.EventHandler(this.menuItemRescanPorts_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(209, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRemoveLastPoint,
            this.menuItemClearDataset});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // menuItemRemoveLastPoint
            // 
            this.menuItemRemoveLastPoint.Name = "menuItemRemoveLastPoint";
            this.menuItemRemoveLastPoint.Size = new System.Drawing.Size(172, 22);
            this.menuItemRemoveLastPoint.Text = "Remove Last Point";
            this.menuItemRemoveLastPoint.Click += new System.EventHandler(this.menuItemRemoveLastPoint_Click);
            // 
            // menuItemClearDataset
            // 
            this.menuItemClearDataset.Name = "menuItemClearDataset";
            this.menuItemClearDataset.Size = new System.Drawing.Size(172, 22);
            this.menuItemClearDataset.Text = "Clear Dataset";
            this.menuItemClearDataset.Click += new System.EventHandler(this.menuItemClearDataset_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.menuItemHelp.Text = "Help";
            this.menuItemHelp.Click += new System.EventHandler(this.menuItemHelp_Click);
            // 
            // groupBoxMeasurement
            // 
            this.groupBoxMeasurement.Controls.Add(this.setToSweepPoints);
            this.groupBoxMeasurement.Controls.Add(this.statusSweepPoints);
            this.groupBoxMeasurement.Controls.Add(this.label8);
            this.groupBoxMeasurement.Controls.Add(this.setToStopFrequency);
            this.groupBoxMeasurement.Controls.Add(this.statusStopFrequency);
            this.groupBoxMeasurement.Controls.Add(this.label5);
            this.groupBoxMeasurement.Controls.Add(this.buttonSetTo);
            this.groupBoxMeasurement.Controls.Add(this.setToAvgPoints);
            this.groupBoxMeasurement.Controls.Add(this.setToStartFrequency);
            this.groupBoxMeasurement.Controls.Add(this.setToSourcePower);
            this.groupBoxMeasurement.Controls.Add(this.statusStartFrequency);
            this.groupBoxMeasurement.Controls.Add(this.statusAvgPoints);
            this.groupBoxMeasurement.Controls.Add(this.statusSourcePower);
            this.groupBoxMeasurement.Controls.Add(this.buttonMeasure);
            this.groupBoxMeasurement.Controls.Add(this.labelMeasPower);
            this.groupBoxMeasurement.Controls.Add(this.labelMeasPoints);
            this.groupBoxMeasurement.Controls.Add(this.labelMeasFreqBand);
            this.groupBoxMeasurement.Controls.Add(this.buttonMeasureReSet);
            this.groupBoxMeasurement.Location = new System.Drawing.Point(5, 256);
            this.groupBoxMeasurement.Margin = new System.Windows.Forms.Padding(1);
            this.groupBoxMeasurement.Name = "groupBoxMeasurement";
            this.groupBoxMeasurement.Padding = new System.Windows.Forms.Padding(1);
            this.groupBoxMeasurement.Size = new System.Drawing.Size(415, 160);
            this.groupBoxMeasurement.TabIndex = 0;
            this.groupBoxMeasurement.TabStop = false;
            this.groupBoxMeasurement.Text = "Measurement";
            // 
            // setToSweepPoints
            // 
            this.setToSweepPoints.Location = new System.Drawing.Point(235, 111);
            this.setToSweepPoints.Margin = new System.Windows.Forms.Padding(1);
            this.setToSweepPoints.Maximum = new decimal(new int[] {
            10001,
            0,
            0,
            0});
            this.setToSweepPoints.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.setToSweepPoints.Name = "setToSweepPoints";
            this.setToSweepPoints.Size = new System.Drawing.Size(77, 20);
            this.setToSweepPoints.TabIndex = 37;
            this.setToSweepPoints.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // statusSweepPoints
            // 
            this.statusSweepPoints.AutoSize = true;
            this.statusSweepPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusSweepPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusSweepPoints.Location = new System.Drawing.Point(149, 111);
            this.statusSweepPoints.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.statusSweepPoints.MaximumSize = new System.Drawing.Size(83, 19);
            this.statusSweepPoints.MinimumSize = new System.Drawing.Size(83, 19);
            this.statusSweepPoints.Name = "statusSweepPoints";
            this.statusSweepPoints.Size = new System.Drawing.Size(83, 19);
            this.statusSweepPoints.TabIndex = 36;
            this.statusSweepPoints.Text = "NULL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(45, 114);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "# Sweep Points";
            // 
            // setToStopFrequency
            // 
            this.setToStopFrequency.DecimalPlaces = 3;
            this.setToStopFrequency.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.setToStopFrequency.Location = new System.Drawing.Point(235, 87);
            this.setToStopFrequency.Margin = new System.Windows.Forms.Padding(1);
            this.setToStopFrequency.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.setToStopFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.setToStopFrequency.Name = "setToStopFrequency";
            this.setToStopFrequency.Size = new System.Drawing.Size(77, 20);
            this.setToStopFrequency.TabIndex = 34;
            this.setToStopFrequency.Value = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            // 
            // statusStopFrequency
            // 
            this.statusStopFrequency.AutoSize = true;
            this.statusStopFrequency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusStopFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStopFrequency.Location = new System.Drawing.Point(149, 87);
            this.statusStopFrequency.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.statusStopFrequency.MaximumSize = new System.Drawing.Size(83, 19);
            this.statusStopFrequency.MinimumSize = new System.Drawing.Size(83, 19);
            this.statusStopFrequency.Name = "statusStopFrequency";
            this.statusStopFrequency.Size = new System.Drawing.Size(83, 19);
            this.statusStopFrequency.TabIndex = 33;
            this.statusStopFrequency.Text = "NULL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Stop Frequency (MHz)";
            // 
            // buttonSetTo
            // 
            this.buttonSetTo.Location = new System.Drawing.Point(235, 14);
            this.buttonSetTo.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSetTo.Name = "buttonSetTo";
            this.buttonSetTo.Size = new System.Drawing.Size(77, 22);
            this.buttonSetTo.TabIndex = 31;
            this.buttonSetTo.Text = "Set-To";
            this.buttonSetTo.UseVisualStyleBackColor = true;
            this.buttonSetTo.Click += new System.EventHandler(this.buttonSetTo_Click);
            // 
            // setToAvgPoints
            // 
            this.setToAvgPoints.Location = new System.Drawing.Point(235, 134);
            this.setToAvgPoints.Margin = new System.Windows.Forms.Padding(1);
            this.setToAvgPoints.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.setToAvgPoints.Name = "setToAvgPoints";
            this.setToAvgPoints.Size = new System.Drawing.Size(77, 20);
            this.setToAvgPoints.TabIndex = 30;
            this.setToAvgPoints.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // setToStartFrequency
            // 
            this.setToStartFrequency.DecimalPlaces = 3;
            this.setToStartFrequency.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.setToStartFrequency.Location = new System.Drawing.Point(235, 63);
            this.setToStartFrequency.Margin = new System.Windows.Forms.Padding(1);
            this.setToStartFrequency.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.setToStartFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.setToStartFrequency.Name = "setToStartFrequency";
            this.setToStartFrequency.Size = new System.Drawing.Size(77, 20);
            this.setToStartFrequency.TabIndex = 29;
            this.setToStartFrequency.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // setToSourcePower
            // 
            this.setToSourcePower.DecimalPlaces = 3;
            this.setToSourcePower.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.setToSourcePower.Location = new System.Drawing.Point(235, 39);
            this.setToSourcePower.Margin = new System.Windows.Forms.Padding(1);
            this.setToSourcePower.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.setToSourcePower.Minimum = new decimal(new int[] {
            47,
            0,
            0,
            -2147483648});
            this.setToSourcePower.Name = "setToSourcePower";
            this.setToSourcePower.Size = new System.Drawing.Size(77, 20);
            this.setToSourcePower.TabIndex = 28;
            this.setToSourcePower.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // statusStartFrequency
            // 
            this.statusStartFrequency.AutoSize = true;
            this.statusStartFrequency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusStartFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStartFrequency.Location = new System.Drawing.Point(149, 63);
            this.statusStartFrequency.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.statusStartFrequency.MaximumSize = new System.Drawing.Size(83, 19);
            this.statusStartFrequency.MinimumSize = new System.Drawing.Size(83, 19);
            this.statusStartFrequency.Name = "statusStartFrequency";
            this.statusStartFrequency.Size = new System.Drawing.Size(83, 19);
            this.statusStartFrequency.TabIndex = 27;
            this.statusStartFrequency.Text = "NULL";
            // 
            // statusAvgPoints
            // 
            this.statusAvgPoints.AutoSize = true;
            this.statusAvgPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusAvgPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusAvgPoints.Location = new System.Drawing.Point(149, 134);
            this.statusAvgPoints.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.statusAvgPoints.MaximumSize = new System.Drawing.Size(83, 19);
            this.statusAvgPoints.MinimumSize = new System.Drawing.Size(83, 19);
            this.statusAvgPoints.Name = "statusAvgPoints";
            this.statusAvgPoints.Size = new System.Drawing.Size(83, 19);
            this.statusAvgPoints.TabIndex = 26;
            this.statusAvgPoints.Text = "NULL";
            // 
            // statusSourcePower
            // 
            this.statusSourcePower.AutoSize = true;
            this.statusSourcePower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusSourcePower.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusSourcePower.Location = new System.Drawing.Point(149, 39);
            this.statusSourcePower.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.statusSourcePower.MaximumSize = new System.Drawing.Size(83, 19);
            this.statusSourcePower.MinimumSize = new System.Drawing.Size(83, 19);
            this.statusSourcePower.Name = "statusSourcePower";
            this.statusSourcePower.Size = new System.Drawing.Size(83, 19);
            this.statusSourcePower.TabIndex = 25;
            this.statusSourcePower.Text = "NULL";
            // 
            // buttonMeasure
            // 
            this.buttonMeasure.Location = new System.Drawing.Point(104, 14);
            this.buttonMeasure.Margin = new System.Windows.Forms.Padding(1);
            this.buttonMeasure.Name = "buttonMeasure";
            this.buttonMeasure.Size = new System.Drawing.Size(60, 22);
            this.buttonMeasure.TabIndex = 22;
            this.buttonMeasure.Text = "Measure";
            this.buttonMeasure.UseVisualStyleBackColor = true;
            this.buttonMeasure.Click += new System.EventHandler(this.buttonMeasure_Click);
            // 
            // labelMeasPower
            // 
            this.labelMeasPower.AutoSize = true;
            this.labelMeasPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMeasPower.Location = new System.Drawing.Point(27, 43);
            this.labelMeasPower.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelMeasPower.Name = "labelMeasPower";
            this.labelMeasPower.Size = new System.Drawing.Size(113, 13);
            this.labelMeasPower.TabIndex = 17;
            this.labelMeasPower.Text = "Source Power (dB)";
            // 
            // labelMeasPoints
            // 
            this.labelMeasPoints.AutoSize = true;
            this.labelMeasPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMeasPoints.Location = new System.Drawing.Point(24, 138);
            this.labelMeasPoints.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelMeasPoints.Name = "labelMeasPoints";
            this.labelMeasPoints.Size = new System.Drawing.Size(115, 13);
            this.labelMeasPoints.TabIndex = 16;
            this.labelMeasPoints.Text = "# Averaging Points";
            // 
            // labelMeasFreqBand
            // 
            this.labelMeasFreqBand.AutoSize = true;
            this.labelMeasFreqBand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMeasFreqBand.Location = new System.Drawing.Point(4, 67);
            this.labelMeasFreqBand.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelMeasFreqBand.Name = "labelMeasFreqBand";
            this.labelMeasFreqBand.Size = new System.Drawing.Size(134, 13);
            this.labelMeasFreqBand.TabIndex = 14;
            this.labelMeasFreqBand.Text = "Start Frequency (MHz)";
            // 
            // buttonMeasureReSet
            // 
            this.buttonMeasureReSet.Location = new System.Drawing.Point(5, 14);
            this.buttonMeasureReSet.Margin = new System.Windows.Forms.Padding(1);
            this.buttonMeasureReSet.Name = "buttonMeasureReSet";
            this.buttonMeasureReSet.Size = new System.Drawing.Size(96, 22);
            this.buttonMeasureReSet.TabIndex = 1;
            this.buttonMeasureReSet.Text = "Reload Settings";
            this.buttonMeasureReSet.UseVisualStyleBackColor = true;
            this.buttonMeasureReSet.Click += new System.EventHandler(this.buttonMeasureReSet_Click);
            // 
            // groupBoxVisual
            // 
            this.groupBoxVisual.Controls.Add(this.indexSelect);
            this.groupBoxVisual.Controls.Add(this.modeSelect);
            this.groupBoxVisual.Controls.Add(this.label7);
            this.groupBoxVisual.Controls.Add(this.buttonAutoScale);
            this.groupBoxVisual.Controls.Add(this.label10);
            this.groupBoxVisual.Controls.Add(this.powerSelect);
            this.groupBoxVisual.Controls.Add(this.label31);
            this.groupBoxVisual.Controls.Add(this.frequencySelect);
            this.groupBoxVisual.Controls.Add(this.label30);
            this.groupBoxVisual.Controls.Add(this.elevationSelect);
            this.groupBoxVisual.Controls.Add(this.horizontalSelect);
            this.groupBoxVisual.Controls.Add(this.depthSelect);
            this.groupBoxVisual.Controls.Add(this.azimuthSelect);
            this.groupBoxVisual.Controls.Add(this.verticalSelect);
            this.groupBoxVisual.Controls.Add(this.polarSelect);
            this.groupBoxVisual.Controls.Add(this.label23);
            this.groupBoxVisual.Controls.Add(this.label25);
            this.groupBoxVisual.Controls.Add(this.label26);
            this.groupBoxVisual.Controls.Add(this.label27);
            this.groupBoxVisual.Controls.Add(this.label28);
            this.groupBoxVisual.Controls.Add(this.label29);
            this.groupBoxVisual.Controls.Add(this.indepVariable);
            this.groupBoxVisual.Controls.Add(this.label12);
            this.groupBoxVisual.Controls.Add(this.checkScatMP);
            this.groupBoxVisual.Controls.Add(this.checkScatRI);
            this.groupBoxVisual.Controls.Add(this.label9);
            this.groupBoxVisual.Controls.Add(this.label4);
            this.groupBoxVisual.Controls.Add(this.checkPhase);
            this.groupBoxVisual.Controls.Add(this.checkMag);
            this.groupBoxVisual.Controls.Add(this.checkImag);
            this.groupBoxVisual.Controls.Add(this.checkReal);
            this.groupBoxVisual.Controls.Add(this.label6);
            this.groupBoxVisual.Controls.Add(this.checkContinuous);
            this.groupBoxVisual.Location = new System.Drawing.Point(426, 461);
            this.groupBoxVisual.Name = "groupBoxVisual";
            this.groupBoxVisual.Size = new System.Drawing.Size(347, 260);
            this.groupBoxVisual.TabIndex = 8;
            this.groupBoxVisual.TabStop = false;
            this.groupBoxVisual.Text = "Visual";
            // 
            // indexSelect
            // 
            this.indexSelect.Items.Add("A");
            this.indexSelect.Items.Add("B");
            this.indexSelect.Items.Add("C");
            this.indexSelect.Items.Add("D");
            this.indexSelect.Items.Add("E");
            this.indexSelect.Location = new System.Drawing.Point(263, 41);
            this.indexSelect.Name = "indexSelect";
            this.indexSelect.Size = new System.Drawing.Size(77, 20);
            this.indexSelect.TabIndex = 91;
            this.indexSelect.Text = "NULL";
            this.indexSelect.TextChanged += new System.EventHandler(this.indexSelect_TextChanged);
            // 
            // modeSelect
            // 
            this.modeSelect.FormattingEnabled = true;
            this.modeSelect.Items.AddRange(new object[] {
            "S11",
            "S12",
            "S21",
            "S22"});
            this.modeSelect.Location = new System.Drawing.Point(46, 14);
            this.modeSelect.Name = "modeSelect";
            this.modeSelect.Size = new System.Drawing.Size(53, 21);
            this.modeSelect.TabIndex = 90;
            this.modeSelect.Text = "S21";
            this.modeSelect.TextChanged += new System.EventHandler(this.modeSelect_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 17);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 89;
            this.label7.Text = "Mode";
            // 
            // buttonAutoScale
            // 
            this.buttonAutoScale.Location = new System.Drawing.Point(4, 40);
            this.buttonAutoScale.Margin = new System.Windows.Forms.Padding(1);
            this.buttonAutoScale.Name = "buttonAutoScale";
            this.buttonAutoScale.Size = new System.Drawing.Size(76, 22);
            this.buttonAutoScale.TabIndex = 88;
            this.buttonAutoScale.Text = "Auto-Scale";
            this.buttonAutoScale.UseVisualStyleBackColor = true;
            this.buttonAutoScale.Click += new System.EventHandler(this.buttonAutoScale_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(188, 43);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 87;
            this.label10.Text = "Point Index";
            // 
            // powerSelect
            // 
            this.powerSelect.Items.Add("A");
            this.powerSelect.Items.Add("B");
            this.powerSelect.Items.Add("C");
            this.powerSelect.Items.Add("D");
            this.powerSelect.Items.Add("E");
            this.powerSelect.Location = new System.Drawing.Point(263, 209);
            this.powerSelect.Name = "powerSelect";
            this.powerSelect.Size = new System.Drawing.Size(77, 20);
            this.powerSelect.TabIndex = 85;
            this.powerSelect.Text = "NULL";
            this.powerSelect.TextChanged += new System.EventHandler(this.powerSelect_TextChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(146, 211);
            this.label31.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(113, 13);
            this.label31.TabIndex = 84;
            this.label31.Text = "Source Power (dB)";
            // 
            // frequencySelect
            // 
            this.frequencySelect.Items.Add("A");
            this.frequencySelect.Items.Add("B");
            this.frequencySelect.Items.Add("C");
            this.frequencySelect.Items.Add("D");
            this.frequencySelect.Items.Add("E");
            this.frequencySelect.Location = new System.Drawing.Point(263, 233);
            this.frequencySelect.Name = "frequencySelect";
            this.frequencySelect.Size = new System.Drawing.Size(77, 20);
            this.frequencySelect.TabIndex = 83;
            this.frequencySelect.Text = "NULL";
            this.frequencySelect.TextChanged += new System.EventHandler(this.frequencySelect_TextChanged);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(156, 235);
            this.label30.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(103, 13);
            this.label30.TabIndex = 82;
            this.label30.Text = "Frequency (MHz)";
            // 
            // elevationSelect
            // 
            this.elevationSelect.Items.Add("A");
            this.elevationSelect.Items.Add("B");
            this.elevationSelect.Items.Add("C");
            this.elevationSelect.Items.Add("D");
            this.elevationSelect.Items.Add("E");
            this.elevationSelect.Location = new System.Drawing.Point(263, 185);
            this.elevationSelect.Name = "elevationSelect";
            this.elevationSelect.Size = new System.Drawing.Size(77, 20);
            this.elevationSelect.TabIndex = 81;
            this.elevationSelect.Text = "NULL";
            this.elevationSelect.TextChanged += new System.EventHandler(this.elevationSelect_TextChanged);
            // 
            // horizontalSelect
            // 
            this.horizontalSelect.Items.Add("A");
            this.horizontalSelect.Items.Add("B");
            this.horizontalSelect.Items.Add("C");
            this.horizontalSelect.Items.Add("D");
            this.horizontalSelect.Items.Add("E");
            this.horizontalSelect.Location = new System.Drawing.Point(263, 113);
            this.horizontalSelect.Name = "horizontalSelect";
            this.horizontalSelect.Size = new System.Drawing.Size(77, 20);
            this.horizontalSelect.TabIndex = 80;
            this.horizontalSelect.Text = "NULL";
            this.horizontalSelect.TextChanged += new System.EventHandler(this.horizontalSelect_TextChanged);
            // 
            // depthSelect
            // 
            this.depthSelect.Items.Add("A");
            this.depthSelect.Items.Add("B");
            this.depthSelect.Items.Add("C");
            this.depthSelect.Items.Add("D");
            this.depthSelect.Items.Add("E");
            this.depthSelect.Location = new System.Drawing.Point(263, 137);
            this.depthSelect.Name = "depthSelect";
            this.depthSelect.Size = new System.Drawing.Size(77, 20);
            this.depthSelect.TabIndex = 79;
            this.depthSelect.Text = "NULL";
            this.depthSelect.TextChanged += new System.EventHandler(this.depthSelect_TextChanged);
            // 
            // azimuthSelect
            // 
            this.azimuthSelect.Items.Add("A");
            this.azimuthSelect.Items.Add("B");
            this.azimuthSelect.Items.Add("C");
            this.azimuthSelect.Items.Add("D");
            this.azimuthSelect.Items.Add("E");
            this.azimuthSelect.Location = new System.Drawing.Point(263, 161);
            this.azimuthSelect.Name = "azimuthSelect";
            this.azimuthSelect.Size = new System.Drawing.Size(77, 20);
            this.azimuthSelect.TabIndex = 78;
            this.azimuthSelect.Text = "NULL";
            this.azimuthSelect.TextChanged += new System.EventHandler(this.azimuthSelect_TextChanged);
            // 
            // verticalSelect
            // 
            this.verticalSelect.Items.Add("A");
            this.verticalSelect.Items.Add("B");
            this.verticalSelect.Items.Add("C");
            this.verticalSelect.Items.Add("D");
            this.verticalSelect.Items.Add("E");
            this.verticalSelect.Location = new System.Drawing.Point(263, 89);
            this.verticalSelect.Name = "verticalSelect";
            this.verticalSelect.Size = new System.Drawing.Size(77, 20);
            this.verticalSelect.TabIndex = 77;
            this.verticalSelect.Text = "NULL";
            this.verticalSelect.TextChanged += new System.EventHandler(this.verticalSelect_TextChanged);
            // 
            // polarSelect
            // 
            this.polarSelect.Items.Add("A");
            this.polarSelect.Items.Add("B");
            this.polarSelect.Items.Add("C");
            this.polarSelect.Items.Add("D");
            this.polarSelect.Items.Add("E");
            this.polarSelect.Location = new System.Drawing.Point(263, 65);
            this.polarSelect.Name = "polarSelect";
            this.polarSelect.Size = new System.Drawing.Size(77, 20);
            this.polarSelect.TabIndex = 76;
            this.polarSelect.Text = "NULL";
            this.polarSelect.TextChanged += new System.EventHandler(this.polarSelect_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(167, 187);
            this.label23.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(93, 13);
            this.label23.TabIndex = 75;
            this.label23.Text = "Elevation (deg)";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(177, 163);
            this.label25.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(84, 13);
            this.label25.TabIndex = 74;
            this.label25.Text = "Azimuth (deg)";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(193, 139);
            this.label26.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(69, 13);
            this.label26.TabIndex = 73;
            this.label26.Text = "Depth (cm)";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(161, 115);
            this.label27.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(99, 13);
            this.label27.TabIndex = 72;
            this.label27.Text = "Horizonatal (cm)";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(183, 91);
            this.label28.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(78, 13);
            this.label28.TabIndex = 71;
            this.label28.Text = "Vertical (cm)";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(153, 67);
            this.label29.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(106, 13);
            this.label29.TabIndex = 70;
            this.label29.Text = "Polarization (deg)";
            // 
            // indepVariable
            // 
            this.indepVariable.FormattingEnabled = true;
            this.indepVariable.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.indepVariable.Location = new System.Drawing.Point(219, 14);
            this.indepVariable.Name = "indepVariable";
            this.indepVariable.Size = new System.Drawing.Size(121, 21);
            this.indepVariable.TabIndex = 68;
            this.indepVariable.Text = "Frequency";
            this.indepVariable.TextChanged += new System.EventHandler(this.indepVariable_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(162, 17);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 67;
            this.label12.Text = "Variable";
            // 
            // checkScatMP
            // 
            this.checkScatMP.AutoSize = true;
            this.checkScatMP.Location = new System.Drawing.Point(6, 234);
            this.checkScatMP.Name = "checkScatMP";
            this.checkScatMP.Size = new System.Drawing.Size(130, 17);
            this.checkScatMP.TabIndex = 66;
            this.checkScatMP.Text = "Magnitude and Phase";
            this.checkScatMP.UseVisualStyleBackColor = true;
            this.checkScatMP.Click += new System.EventHandler(this.checkScatMP_Click);
            // 
            // checkScatRI
            // 
            this.checkScatRI.AutoSize = true;
            this.checkScatRI.Location = new System.Drawing.Point(6, 217);
            this.checkScatRI.Name = "checkScatRI";
            this.checkScatRI.Size = new System.Drawing.Size(117, 17);
            this.checkScatRI.TabIndex = 65;
            this.checkScatRI.Text = "Real and Imaginary";
            this.checkScatRI.UseVisualStyleBackColor = true;
            this.checkScatRI.Click += new System.EventHandler(this.checkScatRI_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 201);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 60;
            this.label9.Text = "Scatter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Line";
            // 
            // checkPhase
            // 
            this.checkPhase.AutoSize = true;
            this.checkPhase.Location = new System.Drawing.Point(7, 178);
            this.checkPhase.Name = "checkPhase";
            this.checkPhase.Size = new System.Drawing.Size(56, 17);
            this.checkPhase.TabIndex = 57;
            this.checkPhase.Text = "Phase";
            this.checkPhase.UseVisualStyleBackColor = true;
            this.checkPhase.Click += new System.EventHandler(this.checkPhase_Click);
            // 
            // checkMag
            // 
            this.checkMag.AutoSize = true;
            this.checkMag.Location = new System.Drawing.Point(7, 161);
            this.checkMag.Name = "checkMag";
            this.checkMag.Size = new System.Drawing.Size(76, 17);
            this.checkMag.TabIndex = 56;
            this.checkMag.Text = "Magnitude";
            this.checkMag.UseVisualStyleBackColor = true;
            this.checkMag.Click += new System.EventHandler(this.checkMag_Click);
            // 
            // checkImag
            // 
            this.checkImag.AutoSize = true;
            this.checkImag.Location = new System.Drawing.Point(7, 144);
            this.checkImag.Name = "checkImag";
            this.checkImag.Size = new System.Drawing.Size(71, 17);
            this.checkImag.TabIndex = 55;
            this.checkImag.Text = "Imaginary";
            this.checkImag.UseVisualStyleBackColor = true;
            this.checkImag.Click += new System.EventHandler(this.checkImag_Click);
            // 
            // checkReal
            // 
            this.checkReal.AutoSize = true;
            this.checkReal.Location = new System.Drawing.Point(7, 127);
            this.checkReal.Name = "checkReal";
            this.checkReal.Size = new System.Drawing.Size(48, 17);
            this.checkReal.TabIndex = 54;
            this.checkReal.Text = "Real";
            this.checkReal.UseVisualStyleBackColor = true;
            this.checkReal.Click += new System.EventHandler(this.checkReal_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Functionality";
            // 
            // checkContinuous
            // 
            this.checkContinuous.AutoSize = true;
            this.checkContinuous.Location = new System.Drawing.Point(7, 87);
            this.checkContinuous.Name = "checkContinuous";
            this.checkContinuous.Size = new System.Drawing.Size(79, 17);
            this.checkContinuous.TabIndex = 0;
            this.checkContinuous.Text = "Continuous";
            this.checkContinuous.UseVisualStyleBackColor = true;
            // 
            // groupBoxPlot
            // 
            this.groupBoxPlot.Location = new System.Drawing.Point(426, 26);
            this.groupBoxPlot.Name = "groupBoxPlot";
            this.groupBoxPlot.Size = new System.Drawing.Size(746, 429);
            this.groupBoxPlot.TabIndex = 9;
            this.groupBoxPlot.TabStop = false;
            this.groupBoxPlot.Text = "Plot";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1177, 724);
            this.Controls.Add(this.groupBoxPlot);
            this.Controls.Add(this.groupBoxVisual);
            this.Controls.Add(this.groupBoxMeasurement);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.groupBoxConard);
            this.Controls.Add(this.groupBoxScan);
            this.Controls.Add(this.groupBoxPos);
            this.Controls.Add(this.groupBoxConna);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximumSize = new System.Drawing.Size(1193, 763);
            this.MinimumSize = new System.Drawing.Size(1193, 763);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSUATR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBoxConna.ResumeLayout(false);
            this.groupBoxConna.PerformLayout();
            this.groupBoxPos.ResumeLayout(false);
            this.groupBoxPos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moveByElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByAzimuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveByPolar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToAzimuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveToPolar)).EndInit();
            this.groupBoxScan.ResumeLayout(false);
            this.groupBoxScan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scanAvgPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scanSourcePower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scanSweepPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionAzimuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionPolar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitAzimuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitPolar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitAzimuth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitHorizontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerLimitPolar)).EndInit();
            this.groupBoxConard.ResumeLayout(false);
            this.groupBoxConard.PerformLayout();
            this.groupBoxOutput.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBoxMeasurement.ResumeLayout(false);
            this.groupBoxMeasurement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setToSweepPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setToStopFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setToAvgPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setToStartFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setToSourcePower)).EndInit();
            this.groupBoxVisual.ResumeLayout(false);
            this.groupBoxVisual.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxConna;
        private System.Windows.Forms.GroupBox groupBoxPos;
        private System.Windows.Forms.Button buttonMoveStop;
        private System.Windows.Forms.Button buttonMoveReSet;
        private System.Windows.Forms.Label labelPosPolar;
        private System.Windows.Forms.Button buttonNAConnect;
        private System.Windows.Forms.Button buttonEngagePolar;
        private System.Windows.Forms.Label statusPositionPolar;
        private System.Windows.Forms.NumericUpDown moveToPolar;
        private System.Windows.Forms.Button buttonMoveTo;
        private System.Windows.Forms.Button buttonMoveBy;
        private System.Windows.Forms.Button buttonEngageElevation;
        private System.Windows.Forms.Label labelPosEleva;
        private System.Windows.Forms.Button buttonEngageAzimuth;
        private System.Windows.Forms.Label labelPosAzimu;
        private System.Windows.Forms.Button buttonEngageDepth;
        private System.Windows.Forms.Label labelPosDepth;
        private System.Windows.Forms.Button buttonEngageHorizontal;
        private System.Windows.Forms.Label labelPosHoriz;
        private System.Windows.Forms.Button buttonEngageVertical;
        private System.Windows.Forms.Label labelPosVerti;
        private System.Windows.Forms.GroupBox groupBoxScan;
        private System.Windows.Forms.Button buttonScanStart;
        private System.Windows.Forms.Button buttonLockElevation;
        private System.Windows.Forms.Button buttonLockAzimuth;
        private System.Windows.Forms.Button buttonLockDepth;
        private System.Windows.Forms.Button buttonLockHorizontal;
        private System.Windows.Forms.Button buttonLockVertical;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonLockPolar;
        private System.Windows.Forms.Button buttonScanCancel;
        private System.Windows.Forms.Button buttonScanReSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelScanEstim;
        private System.Windows.Forms.Label labelScanType;
        private System.Windows.Forms.GroupBox groupBoxConard;
        private System.Windows.Forms.Button buttonArduinoConnect;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.ListBox listBoxOutput;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ToolStripMenuItem menuItemChangeSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveData;
        private System.Windows.Forms.Label labelConardPort;
        private System.Windows.Forms.ComboBox port;
        private System.Windows.Forms.GroupBox groupBoxMeasurement;
        private System.Windows.Forms.Label labelMeasPower;
        private System.Windows.Forms.Label labelMeasPoints;
        private System.Windows.Forms.Label labelMeasFreqBand;
        private System.Windows.Forms.Button buttonMeasureReSet;
        private System.Windows.Forms.Button buttonMeasure;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.ComboBox mode;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.NumericUpDown moveByElevation;
        private System.Windows.Forms.NumericUpDown moveByHorizontal;
        private System.Windows.Forms.NumericUpDown moveByDepth;
        private System.Windows.Forms.NumericUpDown moveByAzimuth;
        private System.Windows.Forms.NumericUpDown moveByVertical;
        private System.Windows.Forms.NumericUpDown moveByPolar;
        private System.Windows.Forms.NumericUpDown moveToElevation;
        private System.Windows.Forms.NumericUpDown moveToVertical;
        private System.Windows.Forms.Label statusPositionElevation;
        private System.Windows.Forms.Label statusPositionAzimuth;
        private System.Windows.Forms.Label statusPositionDepth;
        private System.Windows.Forms.Label statusPositionHorizontal;
        private System.Windows.Forms.Label statusPositionVertical;
        private System.Windows.Forms.NumericUpDown moveToAzimuth;
        private System.Windows.Forms.NumericUpDown moveToDepth;
        private System.Windows.Forms.NumericUpDown moveToHorizontal;
        private System.Windows.Forms.Label statusStartFrequency;
        private System.Windows.Forms.Label statusAvgPoints;
        private System.Windows.Forms.Label statusSourcePower;
        private System.Windows.Forms.NumericUpDown setToSourcePower;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label progressPercent;
        private System.Windows.Forms.Label scanEstimatedTime;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button buttonSetTo;
        private System.Windows.Forms.NumericUpDown setToAvgPoints;
        private System.Windows.Forms.NumericUpDown setToStartFrequency;
        private System.Windows.Forms.GroupBox groupBoxVisual;
        private System.Windows.Forms.ToolStripMenuItem menuItemRescanPorts;
        private System.Windows.Forms.NumericUpDown setToSweepPoints;
        private System.Windows.Forms.Label statusSweepPoints;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown setToStopFrequency;
        private System.Windows.Forms.Label statusStopFrequency;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxPlot;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonAutoScale;
        public System.Windows.Forms.CheckBox checkContinuous;
        public System.Windows.Forms.CheckBox checkPhase;
        public System.Windows.Forms.CheckBox checkMag;
        public System.Windows.Forms.CheckBox checkImag;
        public System.Windows.Forms.CheckBox checkReal;
        public System.Windows.Forms.CheckBox checkScatMP;
        public System.Windows.Forms.CheckBox checkScatRI;
        public System.Windows.Forms.DomainUpDown polarSelect;
        public System.Windows.Forms.ComboBox indepVariable;
        public System.Windows.Forms.DomainUpDown elevationSelect;
        public System.Windows.Forms.DomainUpDown horizontalSelect;
        public System.Windows.Forms.DomainUpDown depthSelect;
        public System.Windows.Forms.DomainUpDown azimuthSelect;
        public System.Windows.Forms.DomainUpDown verticalSelect;
        public System.Windows.Forms.DomainUpDown frequencySelect;
        public System.Windows.Forms.DomainUpDown powerSelect;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DomainUpDown indexSelect;
        public System.Windows.Forms.ComboBox modeSelect;
        public System.Windows.Forms.NumericUpDown scanAvgPoints;
        public System.Windows.Forms.NumericUpDown scanSourcePower;
        public System.Windows.Forms.NumericUpDown upperLimitFrequency;
        public System.Windows.Forms.NumericUpDown lowerLimitFrequency;
        public System.Windows.Forms.NumericUpDown scanSweepPoints;
        public System.Windows.Forms.NumericUpDown resolutionElevation;
        public System.Windows.Forms.NumericUpDown resolutionHorizontal;
        public System.Windows.Forms.NumericUpDown resolutionDepth;
        public System.Windows.Forms.NumericUpDown resolutionAzimuth;
        public System.Windows.Forms.NumericUpDown resolutionVertical;
        public System.Windows.Forms.NumericUpDown resolutionPolar;
        public System.Windows.Forms.NumericUpDown upperLimitElevation;
        public System.Windows.Forms.NumericUpDown upperLimitHorizontal;
        public System.Windows.Forms.NumericUpDown upperLimitDepth;
        public System.Windows.Forms.NumericUpDown upperLimitAzimuth;
        public System.Windows.Forms.NumericUpDown upperLimitVertical;
        public System.Windows.Forms.NumericUpDown upperLimitPolar;
        public System.Windows.Forms.NumericUpDown lowerLimitElevation;
        public System.Windows.Forms.NumericUpDown lowerLimitVertical;
        public System.Windows.Forms.NumericUpDown lowerLimitAzimuth;
        public System.Windows.Forms.NumericUpDown lowerLimitDepth;
        public System.Windows.Forms.NumericUpDown lowerLimitHorizontal;
        public System.Windows.Forms.NumericUpDown lowerLimitPolar;
        public System.Windows.Forms.ComboBox scanType;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemRemoveLastPoint;
        private System.Windows.Forms.ToolStripMenuItem menuItemClearDataset;
    }
}