namespace Tracy
{
    partial class frmPartInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartInfo));
            this.txtLeaderId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpInputTime = new System.Windows.Forms.DateTimePicker();
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
            this.label15 = new System.Windows.Forms.Label();
            this.dtpBatchDate = new System.Windows.Forms.DateTimePicker();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabParts = new System.Windows.Forms.TabPage();
            this.btnPartCancel = new System.Windows.Forms.Button();
            this.btnPartRegister = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabParts.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLeaderId
            // 
            this.txtLeaderId.Enabled = false;
            this.txtLeaderId.Location = new System.Drawing.Point(415, 79);
            this.txtLeaderId.Name = "txtLeaderId";
            this.txtLeaderId.Size = new System.Drawing.Size(188, 20);
            this.txtLeaderId.TabIndex = 50;
            this.txtLeaderId.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Inpute Time: ";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Enabled = false;
            this.txtBatchNo.Location = new System.Drawing.Point(125, 13);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(188, 20);
            this.txtBatchNo.TabIndex = 50;
            this.txtBatchNo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Batch No:";
            // 
            // dtpInputTime
            // 
            this.dtpInputTime.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dtpInputTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInputTime.Location = new System.Drawing.Point(724, 82);
            this.dtpInputTime.Name = "dtpInputTime";
            this.dtpInputTime.ShowUpDown = true;
            this.dtpInputTime.Size = new System.Drawing.Size(188, 20);
            this.dtpInputTime.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(329, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "Shift: ";
            // 
            // cmbShift
            // 
            this.cmbShift.Enabled = false;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(415, 13);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(188, 21);
            this.cmbShift.TabIndex = 50;
            this.cmbShift.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1020, 146);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 24);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteBatch
            // 
            this.btnDeleteBatch.Location = new System.Drawing.Point(891, 146);
            this.btnDeleteBatch.Name = "btnDeleteBatch";
            this.btnDeleteBatch.Size = new System.Drawing.Size(100, 24);
            this.btnDeleteBatch.TabIndex = 19;
            this.btnDeleteBatch.Text = "Delete Batch";
            this.btnDeleteBatch.UseVisualStyleBackColor = true;
            this.btnDeleteBatch.Click += new System.EventHandler(this.btnDeleteBatch_Click);
            // 
            // txtParts
            // 
            this.txtParts.Location = new System.Drawing.Point(109, 28);
            this.txtParts.Name = "txtParts";
            this.txtParts.Size = new System.Drawing.Size(423, 20);
            this.txtParts.TabIndex = 10;
            this.txtParts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtParts_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Parts Info:";
            // 
            // dgvParts
            // 
            this.dgvParts.AllowUserToAddRows = false;
            this.dgvParts.AllowUserToOrderColumns = true;
            this.dgvParts.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParts.Location = new System.Drawing.Point(6, 61);
            this.dgvParts.MultiSelect = false;
            this.dgvParts.Name = "dgvParts";
            this.dgvParts.RowTemplate.Height = 21;
            this.dgvParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvParts.Size = new System.Drawing.Size(1161, 338);
            this.dgvParts.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Model No: ";
            // 
            // cmbModelNo
            // 
            this.cmbModelNo.Enabled = false;
            this.cmbModelNo.FormattingEnabled = true;
            this.cmbModelNo.Location = new System.Drawing.Point(125, 46);
            this.cmbModelNo.Name = "cmbModelNo";
            this.cmbModelNo.Size = new System.Drawing.Size(188, 21);
            this.cmbModelNo.TabIndex = 50;
            this.cmbModelNo.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(329, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Leader Id: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(330, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Line: ";
            // 
            // cmbLine
            // 
            this.cmbLine.Enabled = false;
            this.cmbLine.FormattingEnabled = true;
            this.cmbLine.Location = new System.Drawing.Point(415, 46);
            this.cmbLine.Name = "cmbLine";
            this.cmbLine.Size = new System.Drawing.Size(188, 21);
            this.cmbLine.TabIndex = 50;
            this.cmbLine.TabStop = false;
            // 
            // txtInputQty
            // 
            this.txtInputQty.Location = new System.Drawing.Point(724, 15);
            this.txtInputQty.Name = "txtInputQty";
            this.txtInputQty.Size = new System.Drawing.Size(188, 20);
            this.txtInputQty.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(629, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Input Qty: ";
            // 
            // txtOutputQty
            // 
            this.txtOutputQty.Location = new System.Drawing.Point(724, 49);
            this.txtOutputQty.Name = "txtOutputQty";
            this.txtOutputQty.Size = new System.Drawing.Size(188, 20);
            this.txtOutputQty.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(629, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 50;
            this.label13.Text = "Output Qty: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(630, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = "Output Time: ";
            // 
            // dtpOutputTime
            // 
            this.dtpOutputTime.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dtpOutputTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOutputTime.Location = new System.Drawing.Point(724, 109);
            this.dtpOutputTime.Name = "dtpOutputTime";
            this.dtpOutputTime.ShowUpDown = true;
            this.dtpOutputTime.Size = new System.Drawing.Size(188, 20);
            this.dtpOutputTime.TabIndex = 4;
            // 
            // txtLeaderName
            // 
            this.txtLeaderName.Enabled = false;
            this.txtLeaderName.Location = new System.Drawing.Point(415, 110);
            this.txtLeaderName.Name = "txtLeaderName";
            this.txtLeaderName.Size = new System.Drawing.Size(188, 20);
            this.txtLeaderName.TabIndex = 50;
            this.txtLeaderName.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Leader Name: ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(30, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 13);
            this.label15.TabIndex = 50;
            this.label15.Text = "Batch Date: ";
            // 
            // dtpBatchDate
            // 
            this.dtpBatchDate.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dtpBatchDate.Enabled = false;
            this.dtpBatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBatchDate.Location = new System.Drawing.Point(125, 111);
            this.dtpBatchDate.Name = "dtpBatchDate";
            this.dtpBatchDate.ShowUpDown = true;
            this.dtpBatchDate.Size = new System.Drawing.Size(188, 20);
            this.dtpBatchDate.TabIndex = 50;
            this.dtpBatchDate.TabStop = false;
            // 
            // txtModelName
            // 
            this.txtModelName.Enabled = false;
            this.txtModelName.Location = new System.Drawing.Point(125, 79);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(188, 20);
            this.txtModelName.TabIndex = 50;
            this.txtModelName.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 50;
            this.label9.Text = "Model Name: ";
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Location = new System.Drawing.Point(756, 146);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(100, 24);
            this.btnExcelExport.TabIndex = 16;
            this.btnExcelExport.Text = "Excel Export";
            this.btnExcelExport.UseVisualStyleBackColor = true;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(950, 32);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(188, 78);
            this.txtRemark.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(947, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(50, 13);
            this.label18.TabIndex = 50;
            this.label18.Text = "Remark: ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabParts);
            this.tabControl1.Location = new System.Drawing.Point(12, 176);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1181, 429);
            this.tabControl1.TabIndex = 6;
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
            this.tabParts.Size = new System.Drawing.Size(1173, 403);
            this.tabParts.TabIndex = 1;
            this.tabParts.Text = "Parts Info";
            this.tabParts.UseVisualStyleBackColor = true;
            // 
            // btnPartCancel
            // 
            this.btnPartCancel.Location = new System.Drawing.Point(688, 25);
            this.btnPartCancel.Name = "btnPartCancel";
            this.btnPartCancel.Size = new System.Drawing.Size(110, 24);
            this.btnPartCancel.TabIndex = 12;
            this.btnPartCancel.Text = "Cancel Edit";
            this.btnPartCancel.UseVisualStyleBackColor = true;
            this.btnPartCancel.Click += new System.EventHandler(this.btnPartCancel_Click);
            // 
            // btnPartRegister
            // 
            this.btnPartRegister.Location = new System.Drawing.Point(553, 25);
            this.btnPartRegister.Name = "btnPartRegister";
            this.btnPartRegister.Size = new System.Drawing.Size(110, 24);
            this.btnPartRegister.TabIndex = 11;
            this.btnPartRegister.Text = "Register Parts";
            this.btnPartRegister.UseVisualStyleBackColor = true;
            this.btnPartRegister.Click += new System.EventHandler(this.btnPartRegister_Click);
            // 
            // frmPartInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1196, 614);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDeleteBatch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbLine);
            this.Controls.Add(this.cmbShift);
            this.Controls.Add(this.cmbModelNo);
            this.Controls.Add(this.dtpOutputTime);
            this.Controls.Add(this.dtpBatchDate);
            this.Controls.Add(this.dtpInputTime);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtOutputQty);
            this.Controls.Add(this.txtInputQty);
            this.Controls.Add(this.txtBatchNo);
            this.Controls.Add(this.txtModelName);
            this.Controls.Add(this.txtLeaderName);
            this.Controls.Add(this.txtLeaderId);
            this.Controls.Add(this.btnExcelExport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPartInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parts Info";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabParts.ResumeLayout(false);
            this.tabParts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLeaderId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpInputTime;
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
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpBatchDate;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabParts;
        private System.Windows.Forms.Button btnPartCancel;
        private System.Windows.Forms.Button btnPartRegister;
    }
}

