namespace CSUATRv2
{
    partial class PlottingForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.idSelect = new System.Windows.Forms.DomainUpDown();
            this.sparamSelect = new System.Windows.Forms.ComboBox();
            this.buttonAutoScale = new System.Windows.Forms.Button();
            this.powerSelect = new System.Windows.Forms.DomainUpDown();
            this.frequencySelect = new System.Windows.Forms.DomainUpDown();
            this.elevationSelect = new System.Windows.Forms.DomainUpDown();
            this.horizontalSelect = new System.Windows.Forms.DomainUpDown();
            this.depthSelect = new System.Windows.Forms.DomainUpDown();
            this.azimuthSelect = new System.Windows.Forms.DomainUpDown();
            this.verticalSelect = new System.Windows.Forms.DomainUpDown();
            this.polarSelect = new System.Windows.Forms.DomainUpDown();
            this.variable = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.continuous = new System.Windows.Forms.CheckBox();
            this.plotType = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelVariable = new System.Windows.Forms.Label();
            this.valueType = new System.Windows.Forms.ComboBox();
            this.labelValueType = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.statusDataPoints = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusStrip1.Location = new System.Drawing.Point(0, 714);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(3, 0, 37, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1368, 48);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // idSelect
            // 
            this.idSelect.Items.Add("A");
            this.idSelect.Items.Add("B");
            this.idSelect.Items.Add("C");
            this.idSelect.Items.Add("D");
            this.idSelect.Items.Add("E");
            this.idSelect.Location = new System.Drawing.Point(269, 205);
            this.idSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.idSelect.Name = "idSelect";
            this.idSelect.Size = new System.Drawing.Size(205, 38);
            this.idSelect.TabIndex = 124;
            this.idSelect.Text = "NULL";
            this.idSelect.SelectedItemChanged += new System.EventHandler(this.idSelect_SelectedItemChanged);
            // 
            // sparamSelect
            // 
            this.sparamSelect.FormattingEnabled = true;
            this.sparamSelect.Items.AddRange(new object[] {
            "S11",
            "S12",
            "S21",
            "S22"});
            this.sparamSelect.Location = new System.Drawing.Point(269, 297);
            this.sparamSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sparamSelect.Name = "sparamSelect";
            this.sparamSelect.Size = new System.Drawing.Size(199, 39);
            this.sparamSelect.TabIndex = 123;
            this.sparamSelect.Text = "S21";
            this.sparamSelect.SelectedIndexChanged += new System.EventHandler(this.sparamSelect_SelectedIndexChanged);
            // 
            // buttonAutoScale
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonAutoScale, 2);
            this.buttonAutoScale.Location = new System.Drawing.Point(3, 4);
            this.buttonAutoScale.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAutoScale.Name = "buttonAutoScale";
            this.buttonAutoScale.Size = new System.Drawing.Size(203, 52);
            this.buttonAutoScale.TabIndex = 121;
            this.buttonAutoScale.Text = "Auto-Scale";
            this.buttonAutoScale.UseVisualStyleBackColor = true;
            this.buttonAutoScale.Click += new System.EventHandler(this.buttonAutoScale_Click);
            // 
            // powerSelect
            // 
            this.powerSelect.Items.Add("A");
            this.powerSelect.Items.Add("B");
            this.powerSelect.Items.Add("C");
            this.powerSelect.Items.Add("D");
            this.powerSelect.Items.Add("E");
            this.powerSelect.Location = new System.Drawing.Point(269, 344);
            this.powerSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.powerSelect.Name = "powerSelect";
            this.powerSelect.Size = new System.Drawing.Size(205, 38);
            this.powerSelect.TabIndex = 119;
            this.powerSelect.Text = "NULL";
            this.powerSelect.SelectedItemChanged += new System.EventHandler(this.powerSelect_SelectedItemChanged);
            // 
            // frequencySelect
            // 
            this.frequencySelect.Items.Add("A");
            this.frequencySelect.Items.Add("B");
            this.frequencySelect.Items.Add("C");
            this.frequencySelect.Items.Add("D");
            this.frequencySelect.Items.Add("E");
            this.frequencySelect.Location = new System.Drawing.Point(269, 251);
            this.frequencySelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.frequencySelect.Name = "frequencySelect";
            this.frequencySelect.Size = new System.Drawing.Size(205, 38);
            this.frequencySelect.TabIndex = 117;
            this.frequencySelect.Text = "NULL";
            this.frequencySelect.SelectedItemChanged += new System.EventHandler(this.frequencySelect_SelectedItemChanged);
            // 
            // elevationSelect
            // 
            this.elevationSelect.Items.Add("A");
            this.elevationSelect.Items.Add("B");
            this.elevationSelect.Items.Add("C");
            this.elevationSelect.Items.Add("D");
            this.elevationSelect.Items.Add("E");
            this.elevationSelect.Location = new System.Drawing.Point(269, 574);
            this.elevationSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.elevationSelect.Name = "elevationSelect";
            this.elevationSelect.Size = new System.Drawing.Size(205, 38);
            this.elevationSelect.TabIndex = 115;
            this.elevationSelect.Text = "NULL";
            this.elevationSelect.SelectedItemChanged += new System.EventHandler(this.elevationSelect_SelectedItemChanged);
            // 
            // horizontalSelect
            // 
            this.horizontalSelect.Items.Add("A");
            this.horizontalSelect.Items.Add("B");
            this.horizontalSelect.Items.Add("C");
            this.horizontalSelect.Items.Add("D");
            this.horizontalSelect.Items.Add("E");
            this.horizontalSelect.Location = new System.Drawing.Point(269, 390);
            this.horizontalSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.horizontalSelect.Name = "horizontalSelect";
            this.horizontalSelect.Size = new System.Drawing.Size(205, 38);
            this.horizontalSelect.TabIndex = 114;
            this.horizontalSelect.Text = "NULL";
            this.horizontalSelect.SelectedItemChanged += new System.EventHandler(this.horizontalSelect_SelectedItemChanged);
            // 
            // depthSelect
            // 
            this.depthSelect.Items.Add("A");
            this.depthSelect.Items.Add("B");
            this.depthSelect.Items.Add("C");
            this.depthSelect.Items.Add("D");
            this.depthSelect.Items.Add("E");
            this.depthSelect.Location = new System.Drawing.Point(269, 482);
            this.depthSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.depthSelect.Name = "depthSelect";
            this.depthSelect.Size = new System.Drawing.Size(205, 38);
            this.depthSelect.TabIndex = 113;
            this.depthSelect.Text = "NULL";
            this.depthSelect.SelectedItemChanged += new System.EventHandler(this.depthSelect_SelectedItemChanged);
            // 
            // azimuthSelect
            // 
            this.azimuthSelect.Items.Add("A");
            this.azimuthSelect.Items.Add("B");
            this.azimuthSelect.Items.Add("C");
            this.azimuthSelect.Items.Add("D");
            this.azimuthSelect.Items.Add("E");
            this.azimuthSelect.Location = new System.Drawing.Point(269, 528);
            this.azimuthSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.azimuthSelect.Name = "azimuthSelect";
            this.azimuthSelect.Size = new System.Drawing.Size(205, 38);
            this.azimuthSelect.TabIndex = 112;
            this.azimuthSelect.Text = "NULL";
            this.azimuthSelect.SelectedItemChanged += new System.EventHandler(this.azimuthSelect_SelectedItemChanged);
            // 
            // verticalSelect
            // 
            this.verticalSelect.Items.Add("A");
            this.verticalSelect.Items.Add("B");
            this.verticalSelect.Items.Add("C");
            this.verticalSelect.Items.Add("D");
            this.verticalSelect.Items.Add("E");
            this.verticalSelect.Location = new System.Drawing.Point(269, 436);
            this.verticalSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.verticalSelect.Name = "verticalSelect";
            this.verticalSelect.Size = new System.Drawing.Size(205, 38);
            this.verticalSelect.TabIndex = 111;
            this.verticalSelect.Text = "NULL";
            this.verticalSelect.SelectedItemChanged += new System.EventHandler(this.verticalSelect_SelectedItemChanged);
            // 
            // polarSelect
            // 
            this.polarSelect.Items.Add("A");
            this.polarSelect.Items.Add("B");
            this.polarSelect.Items.Add("C");
            this.polarSelect.Items.Add("D");
            this.polarSelect.Items.Add("E");
            this.polarSelect.Location = new System.Drawing.Point(269, 620);
            this.polarSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.polarSelect.Name = "polarSelect";
            this.polarSelect.Size = new System.Drawing.Size(205, 38);
            this.polarSelect.TabIndex = 110;
            this.polarSelect.Text = "NULL";
            this.polarSelect.SelectedItemChanged += new System.EventHandler(this.polarSelect_SelectedItemChanged);
            // 
            // variable
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.variable, 2);
            this.variable.FormattingEnabled = true;
            this.variable.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.variable.Location = new System.Drawing.Point(152, 158);
            this.variable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.variable.Name = "variable";
            this.variable.Size = new System.Drawing.Size(319, 39);
            this.variable.TabIndex = 103;
            this.variable.Text = "Frequency";
            this.variable.SelectedIndexChanged += new System.EventHandler(this.variable_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.continuous, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.plotType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label22, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label19, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label20, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.label21, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.idSelect, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.frequencySelect, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.horizontalSelect, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.verticalSelect, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.depthSelect, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.azimuthSelect, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.elevationSelect, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.polarSelect, 2, 13);
            this.tableLayoutPanel1.Controls.Add(this.buttonAutoScale, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.variable, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelVariable, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.valueType, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelValueType, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.powerSelect, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.sparamSelect, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.statusDataPoints, 2, 14);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 7);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(477, 700);
            this.tableLayoutPanel1.TabIndex = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 2);
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 662);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label4.Size = new System.Drawing.Size(193, 42);
            this.label4.TabIndex = 130;
            this.label4.Text = "# Data Points:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // continuous
            // 
            this.continuous.AutoSize = true;
            this.continuous.Dock = System.Windows.Forms.DockStyle.Left;
            this.continuous.Location = new System.Drawing.Point(269, 2);
            this.continuous.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.continuous.Name = "continuous";
            this.continuous.Size = new System.Drawing.Size(198, 56);
            this.continuous.TabIndex = 126;
            this.continuous.Text = "Continuous";
            this.continuous.UseVisualStyleBackColor = true;
            // 
            // plotType
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.plotType, 2);
            this.plotType.FormattingEnabled = true;
            this.plotType.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.plotType.Location = new System.Drawing.Point(152, 64);
            this.plotType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.plotType.Name = "plotType";
            this.plotType.Size = new System.Drawing.Size(319, 39);
            this.plotType.TabIndex = 126;
            this.plotType.SelectedIndexChanged += new System.EventHandler(this.plotType_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label22, 2);
            this.label22.Dock = System.Windows.Forms.DockStyle.Left;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(3, 616);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(247, 46);
            this.label22.TabIndex = 24;
            this.label22.Text = "Polarization (deg):";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label13, 2);
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 201);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(123, 46);
            this.label13.TabIndex = 15;
            this.label13.Text = "Point ID:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label14, 2);
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 247);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(239, 46);
            this.label14.TabIndex = 16;
            this.label14.Text = "Frequency (MHz):";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label17, 2);
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(3, 386);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(214, 46);
            this.label17.TabIndex = 19;
            this.label17.Text = "Horizontal (cm):";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label18, 2);
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(3, 432);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(181, 46);
            this.label18.TabIndex = 20;
            this.label18.Text = "Vertical (cm):";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label19, 2);
            this.label19.Dock = System.Windows.Forms.DockStyle.Left;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(3, 478);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(161, 46);
            this.label19.TabIndex = 21;
            this.label19.Text = "Depth (cm):";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label20, 2);
            this.label20.Dock = System.Windows.Forms.DockStyle.Left;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(3, 524);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(199, 46);
            this.label20.TabIndex = 22;
            this.label20.Text = "Azimuth (deg):";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label21, 2);
            this.label21.Dock = System.Windows.Forms.DockStyle.Left;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(3, 570);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(215, 46);
            this.label21.TabIndex = 23;
            this.label21.Text = "Elevation (deg):";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 47);
            this.label3.TabIndex = 127;
            this.label3.Text = "Plot Type:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVariable
            // 
            this.labelVariable.AutoSize = true;
            this.labelVariable.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVariable.Location = new System.Drawing.Point(3, 154);
            this.labelVariable.Name = "labelVariable";
            this.labelVariable.Size = new System.Drawing.Size(103, 47);
            this.labelVariable.TabIndex = 126;
            this.labelVariable.Text = "X Axis:";
            this.labelVariable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // valueType
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.valueType, 2);
            this.valueType.FormattingEnabled = true;
            this.valueType.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.valueType.Location = new System.Drawing.Point(152, 111);
            this.valueType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.valueType.Name = "valueType";
            this.valueType.Size = new System.Drawing.Size(319, 39);
            this.valueType.TabIndex = 128;
            this.valueType.SelectedIndexChanged += new System.EventHandler(this.valueType_SelectedIndexChanged);
            // 
            // labelValueType
            // 
            this.labelValueType.AutoSize = true;
            this.labelValueType.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelValueType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValueType.Location = new System.Drawing.Point(3, 107);
            this.labelValueType.Name = "labelValueType";
            this.labelValueType.Size = new System.Drawing.Size(103, 47);
            this.labelValueType.TabIndex = 129;
            this.labelValueType.Text = "Y Axis:";
            this.labelValueType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label15, 2);
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(3, 340);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(260, 46);
            this.label15.TabIndex = 17;
            this.label15.Text = "Source Power (dB):";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label16, 2);
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 293);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(181, 47);
            this.label16.TabIndex = 18;
            this.label16.Text = "S Parameter:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusDataPoints
            // 
            this.statusDataPoints.AutoSize = true;
            this.statusDataPoints.Dock = System.Windows.Forms.DockStyle.Left;
            this.statusDataPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusDataPoints.Location = new System.Drawing.Point(269, 662);
            this.statusDataPoints.Name = "statusDataPoints";
            this.statusDataPoints.Size = new System.Drawing.Size(31, 42);
            this.statusDataPoints.TabIndex = 131;
            this.statusDataPoints.Text = "0";
            this.statusDataPoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1368, 714);
            this.tableLayoutPanel2.TabIndex = 126;
            // 
            // PlottingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1368, 762);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MinimumSize = new System.Drawing.Size(1400, 850);
            this.Name = "PlottingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSUATR - Plotter";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.DomainUpDown idSelect;
        public System.Windows.Forms.ComboBox sparamSelect;
        private System.Windows.Forms.Button buttonAutoScale;
        public System.Windows.Forms.DomainUpDown powerSelect;
        public System.Windows.Forms.DomainUpDown frequencySelect;
        public System.Windows.Forms.DomainUpDown elevationSelect;
        public System.Windows.Forms.DomainUpDown horizontalSelect;
        public System.Windows.Forms.DomainUpDown depthSelect;
        public System.Windows.Forms.DomainUpDown azimuthSelect;
        public System.Windows.Forms.DomainUpDown verticalSelect;
        public System.Windows.Forms.DomainUpDown polarSelect;
        public System.Windows.Forms.ComboBox variable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label labelVariable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.ComboBox plotType;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox continuous;
        public System.Windows.Forms.ComboBox valueType;
        private System.Windows.Forms.Label labelValueType;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label statusDataPoints;
    }
}