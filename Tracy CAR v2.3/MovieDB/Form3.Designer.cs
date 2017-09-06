namespace Tracy
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.btnUpdateBatch = new System.Windows.Forms.Button();
            this.txtLeaderId = new System.Windows.Forms.TextBox();
            this.dgvOperator = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpInputTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeleteBatch = new System.Windows.Forms.Button();
            this.txtParts = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbModelNo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLine = new System.Windows.Forms.ComboBox();
            this.txtInputQty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOutputQty = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpOutputTime = new System.Windows.Forms.DateTimePicker();
            this.txtLeaderName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbSubAssyNo = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpBatchDate = new System.Windows.Forms.DateTimePicker();
            this.dgvSubMaterial = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSubAssyName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPrintBatch = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabOperator = new System.Windows.Forms.TabPage();
            this.btnResetOperator = new System.Windows.Forms.Button();
            this.btnOperatorCancel = new System.Windows.Forms.Button();
            this.btnOperatorRegister = new System.Windows.Forms.Button();
            this.txtOperator = new System.Windows.Forms.TextBox();
            this.tabParts = new System.Windows.Forms.TabPage();
            this.btnPartCancel = new System.Windows.Forms.Button();
            this.btnPartRegister = new System.Windows.Forms.Button();
            this.tabSubMaterial = new System.Windows.Forms.TabPage();
            this.btnSubMaterialCancel = new System.Windows.Forms.Button();
            this.btnSubMaterialRegister = new System.Windows.Forms.Button();
            this.txtSubMaterial = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubMaterial)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabOperator.SuspendLayout();
            this.tabParts.SuspendLayout();
            this.tabSubMaterial.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdateBatch
            // 
            this.btnUpdateBatch.Location = new System.Drawing.Point(655, 10);
            this.btnUpdateBatch.Name = "btnUpdateBatch";
            this.btnUpdateBatch.Size = new System.Drawing.Size(100, 22);
            this.btnUpdateBatch.TabIndex = 6;
            this.btnUpdateBatch.Text = "Update Header";
            this.btnUpdateBatch.UseVisualStyleBackColor = true;
            this.btnUpdateBatch.Click += new System.EventHandler(this.btnUpdateBatch_Click);
            // 
            // txtLeaderId
            // 
            this.txtLeaderId.Enabled = false;
            this.txtLeaderId.Location = new System.Drawing.Point(417, 101);
            this.txtLeaderId.Name = "txtLeaderId";
            this.txtLeaderId.Size = new System.Drawing.Size(188, 19);
            this.txtLeaderId.TabIndex = 50;
            this.txtLeaderId.TabStop = false;
            // 
            // dgvOperator
            // 
            this.dgvOperator.AllowUserToOrderColumns = true;
            this.dgvOperator.BackgroundColor = System.Drawing.Color.Pink;
            this.dgvOperator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperator.Location = new System.Drawing.Point(33, 56);
            this.dgvOperator.MultiSelect = false;
            this.dgvOperator.Name = "dgvOperator";
            this.dgvOperator.RowTemplate.Height = 21;
            this.dgvOperator.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOperator.Size = new System.Drawing.Size(1059, 312);
            this.dgvOperator.TabIndex = 7;
            this.dgvOperator.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvOperator_EditingControlShowing);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(636, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 50;
            this.label1.Text = "Inpute Time: ";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Enabled = false;
            this.txtBatchNo.Location = new System.Drawing.Point(125, 12);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(188, 19);
            this.txtBatchNo.TabIndex = 50;
            this.txtBatchNo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 50;
            this.label2.Text = "Batch No:";
            // 
            // dtpInputTime
            // 
            this.dtpInputTime.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dtpInputTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInputTime.Location = new System.Drawing.Point(731, 99);
            this.dtpInputTime.Name = "dtpInputTime";
            this.dtpInputTime.ShowUpDown = true;
            this.dtpInputTime.Size = new System.Drawing.Size(188, 19);
            this.dtpInputTime.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "Operator Info: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(331, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 50;
            this.label10.Text = "Shift: ";
            // 
            // cmbShift
            // 
            this.cmbShift.Enabled = false;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(417, 47);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(188, 20);
            this.cmbShift.TabIndex = 50;
            this.cmbShift.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1072, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 22);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteBatch
            // 
            this.btnDeleteBatch.Location = new System.Drawing.Point(943, 10);
            this.btnDeleteBatch.Name = "btnDeleteBatch";
            this.btnDeleteBatch.Size = new System.Drawing.Size(100, 22);
            this.btnDeleteBatch.TabIndex = 19;
            this.btnDeleteBatch.Text = "Delete Batch";
            this.btnDeleteBatch.UseVisualStyleBackColor = true;
            this.btnDeleteBatch.Click += new System.EventHandler(this.btnDeleteBatch_Click);
            // 
            // txtParts
            // 
            this.txtParts.Location = new System.Drawing.Point(141, 25);
            this.txtParts.Name = "txtParts";
            this.txtParts.Size = new System.Drawing.Size(357, 19);
            this.txtParts.TabIndex = 10;
            this.txtParts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtParts_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 12);
            this.label5.TabIndex = 50;
            this.label5.Text = "Parts Info:";
            // 
            // dgvParts
            // 
            this.dgvParts.AllowUserToAddRows = false;
            this.dgvParts.AllowUserToOrderColumns = true;
            this.dgvParts.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParts.Location = new System.Drawing.Point(33, 56);
            this.dgvParts.MultiSelect = false;
            this.dgvParts.Name = "dgvParts";
            this.dgvParts.RowTemplate.Height = 21;
            this.dgvParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvParts.Size = new System.Drawing.Size(1059, 312);
            this.dgvParts.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 50;
            this.label6.Text = "Model No: ";
            // 
            // cmbModelNo
            // 
            this.cmbModelNo.Enabled = false;
            this.cmbModelNo.FormattingEnabled = true;
            this.cmbModelNo.Location = new System.Drawing.Point(125, 47);
            this.cmbModelNo.Name = "cmbModelNo";
            this.cmbModelNo.Size = new System.Drawing.Size(188, 20);
            this.cmbModelNo.TabIndex = 50;
            this.cmbModelNo.TabStop = false;
            this.cmbModelNo.SelectedIndexChanged += new System.EventHandler(this.cmbModelNo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(331, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 12);
            this.label7.TabIndex = 50;
            this.label7.Text = "Leader Id: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(331, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 12);
            this.label8.TabIndex = 50;
            this.label8.Text = "Line: ";
            // 
            // cmbLine
            // 
            this.cmbLine.Enabled = false;
            this.cmbLine.FormattingEnabled = true;
            this.cmbLine.Location = new System.Drawing.Point(417, 73);
            this.cmbLine.Name = "cmbLine";
            this.cmbLine.Size = new System.Drawing.Size(188, 20);
            this.cmbLine.TabIndex = 50;
            this.cmbLine.TabStop = false;
            // 
            // txtInputQty
            // 
            this.txtInputQty.Location = new System.Drawing.Point(731, 47);
            this.txtInputQty.Name = "txtInputQty";
            this.txtInputQty.Size = new System.Drawing.Size(188, 19);
            this.txtInputQty.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(636, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 12);
            this.label11.TabIndex = 50;
            this.label11.Text = "Input Qty: ";
            // 
            // txtOutputQty
            // 
            this.txtOutputQty.Location = new System.Drawing.Point(731, 73);
            this.txtOutputQty.Name = "txtOutputQty";
            this.txtOutputQty.Size = new System.Drawing.Size(188, 19);
            this.txtOutputQty.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(636, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 12);
            this.label13.TabIndex = 50;
            this.label13.Text = "Output Qty: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(636, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 12);
            this.label12.TabIndex = 50;
            this.label12.Text = "Output Time: ";
            // 
            // dtpOutputTime
            // 
            this.dtpOutputTime.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dtpOutputTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOutputTime.Location = new System.Drawing.Point(731, 124);
            this.dtpOutputTime.Name = "dtpOutputTime";
            this.dtpOutputTime.ShowUpDown = true;
            this.dtpOutputTime.Size = new System.Drawing.Size(188, 19);
            this.dtpOutputTime.TabIndex = 4;
            // 
            // txtLeaderName
            // 
            this.txtLeaderName.Enabled = false;
            this.txtLeaderName.Location = new System.Drawing.Point(417, 126);
            this.txtLeaderName.Name = "txtLeaderName";
            this.txtLeaderName.Size = new System.Drawing.Size(188, 19);
            this.txtLeaderName.TabIndex = 50;
            this.txtLeaderName.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 12);
            this.label4.TabIndex = 50;
            this.label4.Text = "Leader Name: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 101);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 12);
            this.label14.TabIndex = 50;
            this.label14.Text = "Sub Assy No: ";
            // 
            // cmbSubAssyNo
            // 
            this.cmbSubAssyNo.Enabled = false;
            this.cmbSubAssyNo.FormattingEnabled = true;
            this.cmbSubAssyNo.Location = new System.Drawing.Point(125, 98);
            this.cmbSubAssyNo.Name = "cmbSubAssyNo";
            this.cmbSubAssyNo.Size = new System.Drawing.Size(188, 20);
            this.cmbSubAssyNo.TabIndex = 50;
            this.cmbSubAssyNo.TabStop = false;
            this.cmbSubAssyNo.SelectedIndexChanged += new System.EventHandler(this.cmbSubAssyNo_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(331, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 12);
            this.label15.TabIndex = 50;
            this.label15.Text = "Batch Date: ";
            // 
            // dtpBatchDate
            // 
            this.dtpBatchDate.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtpBatchDate.Enabled = false;
            this.dtpBatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBatchDate.Location = new System.Drawing.Point(417, 12);
            this.dtpBatchDate.Name = "dtpBatchDate";
            this.dtpBatchDate.ShowUpDown = true;
            this.dtpBatchDate.Size = new System.Drawing.Size(188, 19);
            this.dtpBatchDate.TabIndex = 50;
            this.dtpBatchDate.TabStop = false;
            // 
            // dgvSubMaterial
            // 
            this.dgvSubMaterial.AllowUserToAddRows = false;
            this.dgvSubMaterial.AllowUserToOrderColumns = true;
            this.dgvSubMaterial.BackgroundColor = System.Drawing.Color.NavajoWhite;
            this.dgvSubMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubMaterial.Location = new System.Drawing.Point(33, 56);
            this.dgvSubMaterial.MultiSelect = false;
            this.dgvSubMaterial.Name = "dgvSubMaterial";
            this.dgvSubMaterial.RowTemplate.Height = 21;
            this.dgvSubMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSubMaterial.Size = new System.Drawing.Size(1059, 312);
            this.dgvSubMaterial.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(41, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 12);
            this.label16.TabIndex = 50;
            this.label16.Text = "Sub Material Info: ";
            // 
            // txtSubAssyName
            // 
            this.txtSubAssyName.Enabled = false;
            this.txtSubAssyName.Location = new System.Drawing.Point(125, 124);
            this.txtSubAssyName.Name = "txtSubAssyName";
            this.txtSubAssyName.Size = new System.Drawing.Size(188, 19);
            this.txtSubAssyName.TabIndex = 50;
            this.txtSubAssyName.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(30, 124);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 12);
            this.label17.TabIndex = 50;
            this.label17.Text = "Sub Assy Name: ";
            // 
            // txtModelName
            // 
            this.txtModelName.Enabled = false;
            this.txtModelName.Location = new System.Drawing.Point(125, 73);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(188, 19);
            this.txtModelName.TabIndex = 50;
            this.txtModelName.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 12);
            this.label9.TabIndex = 50;
            this.label9.Text = "Model Name: ";
            // 
            // btnPrintBatch
            // 
            this.btnPrintBatch.Location = new System.Drawing.Point(808, 10);
            this.btnPrintBatch.Name = "btnPrintBatch";
            this.btnPrintBatch.Size = new System.Drawing.Size(100, 22);
            this.btnPrintBatch.TabIndex = 16;
            this.btnPrintBatch.Text = "Print Batch";
            this.btnPrintBatch.UseVisualStyleBackColor = true;
            this.btnPrintBatch.Click += new System.EventHandler(this.btnPrintBatch_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(957, 73);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(188, 72);
            this.txtRemark.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(955, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 12);
            this.label18.TabIndex = 50;
            this.label18.Text = "Remark: ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabOperator);
            this.tabControl1.Controls.Add(this.tabParts);
            this.tabControl1.Controls.Add(this.tabSubMaterial);
            this.tabControl1.Location = new System.Drawing.Point(32, 151);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1140, 407);
            this.tabControl1.TabIndex = 6;
            // 
            // tabOperator
            // 
            this.tabOperator.Controls.Add(this.btnResetOperator);
            this.tabOperator.Controls.Add(this.btnOperatorCancel);
            this.tabOperator.Controls.Add(this.btnOperatorRegister);
            this.tabOperator.Controls.Add(this.txtOperator);
            this.tabOperator.Controls.Add(this.dgvOperator);
            this.tabOperator.Controls.Add(this.label3);
            this.tabOperator.Location = new System.Drawing.Point(4, 22);
            this.tabOperator.Name = "tabOperator";
            this.tabOperator.Padding = new System.Windows.Forms.Padding(3);
            this.tabOperator.Size = new System.Drawing.Size(1132, 381);
            this.tabOperator.TabIndex = 0;
            this.tabOperator.Text = "Operator Info";
            this.tabOperator.UseVisualStyleBackColor = true;
            // 
            // btnResetOperator
            // 
            this.btnResetOperator.Location = new System.Drawing.Point(833, 23);
            this.btnResetOperator.Name = "btnResetOperator";
            this.btnResetOperator.Size = new System.Drawing.Size(110, 22);
            this.btnResetOperator.TabIndex = 15;
            this.btnResetOperator.Text = "Reset Operator";
            this.btnResetOperator.UseVisualStyleBackColor = true;
            this.btnResetOperator.Click += new System.EventHandler(this.btnResetOperator_Click);
            // 
            // btnOperatorCancel
            // 
            this.btnOperatorCancel.Location = new System.Drawing.Point(688, 23);
            this.btnOperatorCancel.Name = "btnOperatorCancel";
            this.btnOperatorCancel.Size = new System.Drawing.Size(110, 22);
            this.btnOperatorCancel.TabIndex = 9;
            this.btnOperatorCancel.Text = "Cancel Edit";
            this.btnOperatorCancel.UseVisualStyleBackColor = true;
            this.btnOperatorCancel.Click += new System.EventHandler(this.btnOperatorCancel_Click);
            // 
            // btnOperatorRegister
            // 
            this.btnOperatorRegister.Location = new System.Drawing.Point(553, 23);
            this.btnOperatorRegister.Name = "btnOperatorRegister";
            this.btnOperatorRegister.Size = new System.Drawing.Size(110, 22);
            this.btnOperatorRegister.TabIndex = 8;
            this.btnOperatorRegister.Text = "Register Operator";
            this.btnOperatorRegister.UseVisualStyleBackColor = true;
            this.btnOperatorRegister.Click += new System.EventHandler(this.btnOperatorRegister_Click);
            // 
            // txtOperator
            // 
            this.txtOperator.Location = new System.Drawing.Point(141, 25);
            this.txtOperator.Name = "txtOperator";
            this.txtOperator.Size = new System.Drawing.Size(357, 19);
            this.txtOperator.TabIndex = 14;
            this.txtOperator.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOperator_KeyDown);
            // 
            // tabParts
            // 
            this.tabParts.Controls.Add(this.btnPartCancel);
            this.tabParts.Controls.Add(this.btnPartRegister);
            this.tabParts.Controls.Add(this.dgvParts);
            this.tabParts.Controls.Add(this.txtParts);
            this.tabParts.Controls.Add(this.label5);
            this.tabParts.Location = new System.Drawing.Point(4, 22);
            this.tabParts.Name = "tabParts";
            this.tabParts.Padding = new System.Windows.Forms.Padding(3);
            this.tabParts.Size = new System.Drawing.Size(1132, 381);
            this.tabParts.TabIndex = 1;
            this.tabParts.Text = "Parts Info";
            this.tabParts.UseVisualStyleBackColor = true;
            // 
            // btnPartCancel
            // 
            this.btnPartCancel.Location = new System.Drawing.Point(688, 23);
            this.btnPartCancel.Name = "btnPartCancel";
            this.btnPartCancel.Size = new System.Drawing.Size(110, 22);
            this.btnPartCancel.TabIndex = 12;
            this.btnPartCancel.Text = "Cancel Edit";
            this.btnPartCancel.UseVisualStyleBackColor = true;
            this.btnPartCancel.Click += new System.EventHandler(this.btnPartCancel_Click);
            // 
            // btnPartRegister
            // 
            this.btnPartRegister.Location = new System.Drawing.Point(553, 23);
            this.btnPartRegister.Name = "btnPartRegister";
            this.btnPartRegister.Size = new System.Drawing.Size(110, 22);
            this.btnPartRegister.TabIndex = 11;
            this.btnPartRegister.Text = "Register Parts";
            this.btnPartRegister.UseVisualStyleBackColor = true;
            this.btnPartRegister.Click += new System.EventHandler(this.btnPartRegister_Click);
            // 
            // tabSubMaterial
            // 
            this.tabSubMaterial.Controls.Add(this.btnSubMaterialCancel);
            this.tabSubMaterial.Controls.Add(this.btnSubMaterialRegister);
            this.tabSubMaterial.Controls.Add(this.txtSubMaterial);
            this.tabSubMaterial.Controls.Add(this.dgvSubMaterial);
            this.tabSubMaterial.Controls.Add(this.label16);
            this.tabSubMaterial.Location = new System.Drawing.Point(4, 22);
            this.tabSubMaterial.Name = "tabSubMaterial";
            this.tabSubMaterial.Size = new System.Drawing.Size(1132, 381);
            this.tabSubMaterial.TabIndex = 2;
            this.tabSubMaterial.Text = "Sub Material Info";
            this.tabSubMaterial.UseVisualStyleBackColor = true;
            // 
            // btnSubMaterialCancel
            // 
            this.btnSubMaterialCancel.Location = new System.Drawing.Point(688, 23);
            this.btnSubMaterialCancel.Name = "btnSubMaterialCancel";
            this.btnSubMaterialCancel.Size = new System.Drawing.Size(110, 22);
            this.btnSubMaterialCancel.TabIndex = 15;
            this.btnSubMaterialCancel.Text = "Cancel Edit";
            this.btnSubMaterialCancel.UseVisualStyleBackColor = true;
            this.btnSubMaterialCancel.Click += new System.EventHandler(this.btnSubMaterialCancel_Click);
            // 
            // btnSubMaterialRegister
            // 
            this.btnSubMaterialRegister.Location = new System.Drawing.Point(553, 23);
            this.btnSubMaterialRegister.Name = "btnSubMaterialRegister";
            this.btnSubMaterialRegister.Size = new System.Drawing.Size(110, 22);
            this.btnSubMaterialRegister.TabIndex = 14;
            this.btnSubMaterialRegister.Text = "Register Sub Mat";
            this.btnSubMaterialRegister.UseVisualStyleBackColor = true;
            this.btnSubMaterialRegister.Click += new System.EventHandler(this.btnSubMaterialRegister_Click);
            // 
            // txtSubMaterial
            // 
            this.txtSubMaterial.Location = new System.Drawing.Point(141, 25);
            this.txtSubMaterial.Name = "txtSubMaterial";
            this.txtSubMaterial.Size = new System.Drawing.Size(357, 19);
            this.txtSubMaterial.TabIndex = 13;
            this.txtSubMaterial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubMaterial_KeyDown);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1196, 567);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDeleteBatch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbLine);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.cmbSubAssyNo);
            this.Controls.Add(this.cmbModelNo);
            this.Controls.Add(this.dtpOutputTime);
            this.Controls.Add(this.dtpBatchDate);
            this.Controls.Add(this.dtpInputTime);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtOutputQty);
            this.Controls.Add(this.txtInputQty);
            this.Controls.Add(this.txtBatchNo);
            this.Controls.Add(this.txtModelName);
            this.Controls.Add(this.txtSubAssyName);
            this.Controls.Add(this.txtLeaderName);
            this.Controls.Add(this.txtLeaderId);
            this.Controls.Add(this.btnPrintBatch);
            this.Controls.Add(this.btnUpdateBatch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operator / Parts / Sub Materials";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubMaterial)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabOperator.ResumeLayout(false);
            this.tabOperator.PerformLayout();
            this.tabParts.ResumeLayout(false);
            this.tabParts.PerformLayout();
            this.tabSubMaterial.ResumeLayout(false);
            this.tabSubMaterial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLeaderId;
        private System.Windows.Forms.Button btnUpdateBatch;
        private System.Windows.Forms.DataGridView dgvOperator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpInputTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDeleteBatch;
        private System.Windows.Forms.TextBox txtParts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvParts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbModelNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbLine;
        private System.Windows.Forms.TextBox txtInputQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOutputQty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpOutputTime;
        private System.Windows.Forms.TextBox txtLeaderName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbSubAssyNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpBatchDate;
        private System.Windows.Forms.DataGridView dgvSubMaterial;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSubAssyName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPrintBatch;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabOperator;
        private System.Windows.Forms.TabPage tabParts;
        private System.Windows.Forms.TabPage tabSubMaterial;
        private System.Windows.Forms.Button btnPartCancel;
        private System.Windows.Forms.Button btnPartRegister;
        private System.Windows.Forms.Button btnOperatorCancel;
        private System.Windows.Forms.Button btnOperatorRegister;
        private System.Windows.Forms.TextBox txtOperator;
        private System.Windows.Forms.Button btnSubMaterialCancel;
        private System.Windows.Forms.Button btnSubMaterialRegister;
        private System.Windows.Forms.TextBox txtSubMaterial;
        private System.Windows.Forms.Button btnResetOperator;
    }
}

