using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace Tracy
{
    public partial class frmPartInfo : Form
    {
        //�e�t�H�[��Form1�փC�x���g������A���i�f���Q�[�g�j
        public delegate void RefreshEventHandler(object sender, EventArgs e);
        public event RefreshEventHandler RefreshEvent;

        // �v�����g�p�e�L�X�g�t�@�C���̕ۑ��p�t�H���_���A��{�ݒ�t�@�C���Őݒ肷��
        string appconfig = System.Environment.CurrentDirectory + "\\info.ini";
        string directory = @"C:\Users\takusuke.fujii\Desktop\Auto Print\\"; 

        //���̑��A�񃍁[�J���ϐ�
        DataTable dtParts;
       // DataTable dtPartsMaster;

        bool formAddMode;
        bool formAdmin;
        bool b_headerComplete;
        bool b_partsComplete;
        bool matchPartsMaster = false;
        bool sound;

        // �R���X�g���N�^
        public frmPartInfo()
        {
            InitializeComponent();
        }

        // ���[�h���̏���
        private void Form3_Load(object sender, EventArgs e)
        {
            // ���t�H�[���̕\���ꏊ���w��
            this.Left = 60;
            this.Top = 35;
            
            // �e�폈���p�̃e�[�u���𐶐�
            //dtOperator = new DataTable();
            dtParts = new DataTable();
            //dtSubMaterial = new DataTable();
            //dtPartsMaster = new DataTable();

            // �e�[�u���̒�`
            defineTables(ref dtParts);

            if (!formAddMode)
            {
                readPartsTable(ref dtParts, ref dgvParts);
            }
            else if (formAddMode)
            {
                insertBlankRecord(ref dtParts, ref dgvParts);
            }

            // �o�b�`�V�K���s���[�h�̏ꍇ�́A�V�K�o�b�`�𔭍s���āA�f�[�^�x�[�X�֏�������
            if (formAddMode)
            {
                txtBatchNo.Text = getNewBatch();
            }

            // �v�����g�p�t�@�C���̕ۑ���t�H���_���A��{�ݒ�t�@�C���Őݒ肷��
            directory = readIni("TARGET DIRECTORY", "DIR", appconfig);
        }

        // �T�u�v���V�[�W���F�e�t�H�[���ŌĂяo���A�e�t�H�[���̏����A�e�L�X�g�{�b�N�X�֊i�[���Ĉ����p��
        public void updateControls(string batchNo, string modelNo, string modelName, 
            DateTime batchDate, string shift, string line, string leader, string leaderName, string input, string output,
            DateTime inputTime, DateTime outputTime, string remark, bool addMode, bool admin)
        {
            txtBatchNo.Text = batchNo;
            cmbModelNo.Text = modelNo;
            txtModelName.Text = modelName;
            //cmbSubAssyNo.Text = subAssyNo;
            //txtSubAssyName.Text = subAssyName;
            dtpBatchDate.Value = batchDate;
            cmbShift.Text = shift;
            cmbLine.Text = line;
            txtLeaderId.Text = leader;
            txtLeaderName.Text = leaderName;
            txtInputQty.Text = input.ToString();
            txtOutputQty.Text = output.ToString();
            dtpInputTime.Value = inputTime;
            dtpOutputTime.Value = outputTime;
            txtRemark.Text = remark;
            formAddMode = addMode;
            formAdmin = admin;

            // �ҏW���[�h�̏ꍇ�́A�o�^�����m�F�͍s��Ȃ��i�����t���O��\�߃I���j
            if (!formAddMode)
            {
                b_headerComplete = true;
                b_partsComplete = true;
            }

            // �Ǘ����[�h�łȂ��ꍇ�i���̃��[�_�[�N�Ẵo�b�`�̏ꍇ�j�A����{�^���ȊO�𖳌��ɂ���
            if (!formAdmin)
            {
                disableControlsExceptTabControlAndCloseButton(this);
            }
        }

        // �T�u�v���V�[�W���F�t�H�[���̖�����
        private void disableControlsExceptTabControlAndCloseButton(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                // ����{�^���ȊO�͖����ɂ���
                if (child.Name != "tabControl1" && child.Name != "btnClose")
                    child.Enabled = false;
            }

            

            foreach (Control child in this.tabParts.Controls) 
                child.Enabled = false;

            
        }

        // �T�u�v���V�[�W���F�c�s�̒�`
        private void defineTables(ref DataTable dt2)
        {
            //dt1.Columns.Add("process", Type.GetType("System.String"));
            //dt1.Columns.Add("operator", Type.GetType("System.String"));
            //dt1.Columns.Add("machine", Type.GetType("System.String"));

            dt2.Columns.Add("parts_no", Type.GetType("System.String"));
            dt2.Columns.Add("parts_name", Type.GetType("System.String"));
            dt2.Columns.Add("parts_supplier", Type.GetType("System.String"));
            dt2.Columns.Add("parts_invoice", Type.GetType("System.String"));
            dt2.Columns.Add("qty", Type.GetType("System.Double"));
            dt2.Columns.Add("note", Type.GetType("System.String"));

            //dt3.Columns.Add("sub_mat_no", Type.GetType("System.String"));
            //dt3.Columns.Add("sub_mat_name", Type.GetType("System.String"));
            //dt3.Columns.Add("sub_mat_supplier", Type.GetType("System.String"));
            //dt3.Columns.Add("sub_mat_invoice", Type.GetType("System.String"));
            //dt3.Columns.Add("validity", Type.GetType("System.DateTime"));

            //dt4.Columns.Add("parts_no", Type.GetType("System.String"));
            //dt4.Columns.Add("parts_name", Type.GetType("System.String"));
            //dt4.Columns.Add("ratio", Type.GetType("System.Double"));
            //dt4.Columns.Add("match", Type.GetType("System.String"));
        }

        // �T�u�v���V�[�W���F�󃌃R�[�h���c�s�֒ǉ����\������
        private void insertBlankRecord(ref DataTable dt, ref DataGridView dgv)
        {
            dt.Clear();
            dt.Rows.Add(dt.NewRow());
            updateDataGridViewsub(dt, ref dgv);
        }

        // �@�I�y���[�^�[
        // �T�u�v���V�[�W���F�I�y���[�^�[�����f�[�^�O���b�h�r���[�ɔ��f����
        private void readOperatorTable(ref DataTable dt, ref DataGridView dgv, bool load)
        {
            string batchNo = txtBatchNo.Text;
            string sql = "select process, operator, machine from t_operator " + "where batch_no='" + batchNo + "'";
            System.Diagnostics.Debug.Print(sql);
            dt.Clear();
            TfSQL tf = new TfSQL();
            tf.sqlDataAdapterFillDatatable(sql, ref dt);
            updateDataGridViewsub(dt, ref dgv);

            //// �O���b�h�r���[�ɃR���{�{�b�N�X��ǉ�����
            //if(load) insertComboBoxToGridView();
        }     

        // �T�u�v���V�[�W���F�O���b�h�r���[�ɃR���{�{�b�N�X��ǉ�����
        private void insertComboBoxToGridView()
        {
            ////dgvOperator.Columns["process"].Visible = false;
            //DataGridViewComboBoxColumn cmbCol= new DataGridViewComboBoxColumn();
            //cmbCol.HeaderText = "select_process";
            //cmbCol.Name = "cmbProcess";

            //string sql = "select process from t_process where " + "sub_assy_no = '" + cmbSubAssyNo.Text + "'";
            //System.Diagnostics.Debug.Print(sql);
            //DataTable dtProcessList = new DataTable();
            //TfSQL tf = new TfSQL();
            //tf.sqlDataAdapterFillDatatable(sql, ref dtProcessList);
            //foreach (DataRow row in dtProcessList.Rows)
            //    cmbCol.Items.Add(row[0].ToString());

            //dgvOperator.Columns.Add(cmbCol);
            //dgvOperator.Columns["cmbProcess"].DisplayIndex = 0;
        }

        // �O���b�h�r���[�R���{�{�b�N�X�̒l���ύX���ꂽ�ۂ̏����i�C�x���g�����j
        private void dgvOperator_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dgvOperator.CurrentCell.ColumnIndex == 3 && e.Control is ComboBox)
            //{
            //    ComboBox comboBox = e.Control as ComboBox;
            //    comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            //}
        }

        // �T�u�v���V�[�W���F�O���b�h�r���[�R���{�{�b�N�X�̒l���ύX���ꂽ�ۂ̏����i�C�x���g���e�j
        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    var currentcell = dgvOperator.CurrentCellAddress;
            //    var sendingCB = sender as DataGridViewComboBoxEditingControl;
            //    DataGridViewTextBoxCell nextcell = (DataGridViewTextBoxCell)dgvOperator.Rows[currentcell.Y].Cells["process"];
            //    nextcell.Value = sendingCB.EditingControlFormattedValue.ToString();
            //    nextcell.Selected = true;
            //    dgvOperator.Columns["cmbProcess"].Width = 50;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        // �A���i
        // �T�u�v���V�[�W���F���i�����f�[�^�O���b�h�r���[�ɔ��f����
        private void readPartsTable(ref DataTable dt, ref DataGridView dgv)
        {
            string batchNo = txtBatchNo.Text;
            string sql = "select parts_no, parts_name, parts_supplier, parts_invoice, qty, note from t_parts_invoice " + "where batch_no='" + batchNo + "'";
            System.Diagnostics.Debug.Print(sql);
            dt.Clear();
            TfSQL tf = new TfSQL();
            tf.sqlDataAdapterFillDatatable(sql, ref dt);
            updateDataGridViewsub(dt, ref dgv);

            // �X�L�����o�^���ł���悤�A�J�����g�Z����ݒ肵�A�c�h�q�s�x�ɂ���
            int r = dt.Rows.Count;
            dt.Rows.Add(dt.NewRow());
            dgv.CurrentCell = dgv[0, r];
            dgv.NotifyCurrentCellDirty(true);
            dgv.NotifyCurrentCellDirty(false);

            // ���i�}�X�^�����擾����
            //readPartsMasterTable(ref dtPartsMaster);
        }

        
        // �B������
        // �T�u�v���V�[�W���F�����ޏ����f�[�^�O���b�h�r���[�ɔ��f����
        //private void readSubMaterialTable(ref DataTable dt, ref DataGridView dgv)
        //{
        //    string batchNo = txtBatchNo.Text;
        //    string sql = "select sub_mat_no, sub_mat_name, sub_mat_supplier, sub_mat_invoice, validity from t_sub_mat_invoice " + "where batch_no='" + batchNo + "'";
        //    System.Diagnostics.Debug.Print(sql);
        //    dt.Clear();
        //    TfSQL tf = new TfSQL();
        //    tf.sqlDataAdapterFillDatatable(sql, ref dt);
        //    updateDataGridViewsub(dt, ref dgv);

        //    // �X�L�����o�^���ł���悤�A�J�����g�Z����ݒ肵�A�c�h�q�s�x�ɂ���
        //    int r = dt.Rows.Count;
        //    dt.Rows.Add(dt.NewRow());
        //    dgv.CurrentCell = dgv[0, r];
        //    dgv.NotifyCurrentCellDirty(true);
        //    dgv.NotifyCurrentCellDirty(false);
        //}

        // �T�u�T�u�v���V�[�W���F�f�[�^�O���b�g�r���[�փf�[�^�e�[�u�����i�[
        private void updateDataGridViewsub(DataTable dt, ref DataGridView dgv)
        {
            //�f�[�^�O���b�g�r���[�փf�[�^�e�[�u�����i�[
            dgv.DataSource = dt;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        // �o�b�`�w�b�_�[���X�V�{�^���������̏���
        private void btnUpdateBatch_Click(object sender, EventArgs e)
        {
            string batchNo = txtBatchNo.Text;
            double inQty;
            double.TryParse(txtInputQty.Text, out inQty);
            double outQty;
            double.TryParse(txtOutputQty.Text, out outQty);
            DateTime inTime = dtpInputTime.Value.Date;
            DateTime outTime = dtpOutputTime.Value.Date;
            string remark = txtRemark.Text;

            bool[] cr = { txtInputQty.Text == string.Empty  ? false : true,
                          txtOutputQty.Text == string.Empty ? false : true,
                                                                      true,
                                                                      true,
                          remark  == string.Empty           ? false : true  };

            string sql1 = "update t_batch_no set " +
                (cr[0] ? "in_qty=" + inQty + "," : "in_qty = null,") +
                (cr[1] ? "out_qty=" + outQty + "," : "out_qty = null,") +
                (cr[2] ? "in_time='" + inTime + "'," : string.Empty) +
                (cr[3] ? "out_time='" + outTime + "'," : string.Empty) +
                (cr[4] ? "remark='" + remark + "'," : "remark = null,");

            string sql2 = " where batch_no='" + batchNo + "'";

            string sql3 = VBStrings.Left(sql1, sql1.Length - 1) + sql2;
            System.Diagnostics.Debug.Print(sql3);
            TfSQL tf = new TfSQL();
            b_headerComplete = tf.sqlExecuteNonQuery(sql3, false);

            if (b_headerComplete)
                MessageBox.Show("Step 1: Batch general info register completed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //�e�t�H�[��Form1�̃f�[�^�O���b�g�r���[���X�V���邽�߁A�f���Q�[�g�C�x���g�𔭐�������
            this.RefreshEvent(this, new EventArgs());
        }

        // ����{�^���������̏���
        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            string batchNo = txtBatchNo.Text;
            string modelNo = cmbModelNo.Text;
            string modelName = txtModelName.Text;
            DateTime batchDate = dtpBatchDate.Value;

            ExcelClass xl = new ExcelClass();

            // �G�N�Z���֏o��
            xl.ExportBatchDetailToExcel(batchNo, modelNo, modelName, batchDate, dtParts);
        }

        // �o�b�`�폜�{�^���������̏����i�w�b�_�[�Ɩ��בS�Ă̍폜�j
        private void btnDeleteBatch_Click(object sender, EventArgs e)
        {
            // �O�̂��߁A�{���ɍ폜����̂��A�Q�x���[�U�[�ɖ₤
            DialogResult result1 = MessageBox.Show("Do you really want to delete the batch data?",
                "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result1 == DialogResult.No) return;

            DialogResult result2 = MessageBox.Show("Again, is it OK to delete the batch?",
                "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result2 == DialogResult.No) return;

            string batchNo = txtBatchNo.Text;
            string sql = "delete from t_batch_no where batch_no='" + batchNo + "'";
            string sql1 = "delete from t_parts_invoice where batch_no='" + batchNo + "'";

            TfSQL tf = new TfSQL();
            tf.sqlExecuteNonQuery(sql, false);
            System.Diagnostics.Debug.Print(sql);
            tf.sqlExecuteNonQuery(sql1, false);
            System.Diagnostics.Debug.Print(sql1);

            //�e�t�H�[��Form1�̃f�[�^�O���b�g�r���[���X�V���邽�߁A�f���Q�[�g�C�x���g�𔭐�������
            this.RefreshEvent(this, new EventArgs());

            // �R���g���[���̖�����
            disableControlsExceptCloseButton(this);

            // �o�^�����t���O�I���i����ĕ��邱�Ƃ�h�~����@�\�A�I�t�j
            b_headerComplete = true;
            b_partsComplete = true;

            // �s�a�h�e�[�u���̃p�[�c�����폜���邽�߁A�Q�Ƃ��ׂ��s�a�h�e�[�u��������肷��
            string model = cmbModelNo.Text;
            DateTime month = dtpBatchDate.Value;
       //     string tbiTable = decideReferenceTable(model, month);

            // �s�a�h�e�[�u���̓��o�b�`�������R�[�h�폜
  //          string sql2 = "delete from " + tbiTable + " where lot = '" + batchNo + "'";
 //           System.Diagnostics.Debug.Print(sql2);
  //          tf.sqlExecuteNonQueryToPqmDb(sql2, false);
        }

        // �t�H�[���N���[�Y�{�^���������̏���
        private void btnClose_Click(object sender, EventArgs e)
        {
            // �X�V���[�h�̏ꍇ�́A�����Ȃ��B
            if (!formAddMode) this.Close(); 

            // �w�b�_�[�E�I�y���[�^�[�E���i�E�����ށA�S�X�e�b�v���������Ă��邩�ۂ��A�m�F
            if (!(b_headerComplete && b_partsComplete))
            {
                string imcompleteList =
                    (b_headerComplete ? string.Empty : "header, ") +
                    (b_partsComplete ? string.Empty : "parts, ") ;

                string message = "Is it ok to close this form?" + System.Environment.NewLine + System.Environment.NewLine +
                    "Please check the followings:" + System.Environment.NewLine +
                    VBStrings.Left(imcompleteList, imcompleteList.Length - 2) + System.Environment.NewLine + System.Environment.NewLine +
                    "Click Yes to close."  + System.Environment.NewLine + 
                    "Click No to check.";

                DialogResult reply = MessageBox.Show(message, "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (reply == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        // �T�u�v���V�[�W��: �R���g���[���̖�����
        private void disableControlsExceptCloseButton(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                // ����{�^���ȊO�͖����ɂ���
                if (child.Name != "btnClose")
                    child.Enabled = false;

                // �e�L�X�g�{�b�N�X�ƃR���{�{�b�N�X�̓N���A
                if (child is TextBox || child is ComboBox)
                    child.Text = string.Empty;
            }

            // �c�`�s�d�s�h�l�d�o�h�b�j�d�q�͓�����������
            dtpBatchDate.Value = DateTime.Today;
            dtpInputTime.Value = DateTime.Today;
            dtpOutputTime.Value = DateTime.Today;

            // �f�[�^�O���b�h�r���[�́A�f�[�^�\�[�X������
            
            dgvParts.DataSource = "";
            
        }


        private void txtParts_KeyDown(object sender, KeyEventArgs e)
        {
            //�G���^�[�L�[�ȊO�A���͕�����Ȃ��A�O���b�h�r���[�I���s�Ȃ��A�͏������Ȃ�
            if (e.KeyCode != Keys.Enter) return;
            
            string partsInfo = txtParts.Text;
            if (partsInfo == string.Empty) return;
            
            int curRow = dgvParts.CurrentCell.RowIndex;
            int curClm = dgvParts.CurrentCell.ColumnIndex;
            if (curRow < 0) return;

            // �Z�~�R�����łp�q�ǂݎ����e�𕪊����A�O���b�g�r���[�ɕ\������
            try
            {
                string[] split = partsInfo.Split(';');
                dtParts.Rows[curRow]["parts_no"] = split[0];
                dtParts.Rows[curRow]["parts_name"] = split[1];
                dtParts.Rows[curRow]["parts_supplier"] = split[2];
                dtParts.Rows[curRow]["parts_invoice"] = split[3];
                // ���i�ԍ������i�}�X�^�̏��ɊY�����邩�m�F���A�t����Ԃ�
                //double r = matchPartsNoAndGetRatio(split[0], dtPartsMaster);
                dtParts.Rows[curRow]["qty"] = split[5]; //split[5]; �o�b�`�S�̂h�m�o�t�s �p�s�x * �t��
                dtParts.Rows[curRow]["note"] = "new";

                // ���i�}�X�^�ɊY�����Ȃ��ꍇ�́A�x���B���[�U�[���o�^���L�����Z������ꍇ�́A����
                if (!matchPartsMaster)
                {
                    DialogResult result = MessageBox.Show(split[0] + " is a new parts master." + System.Environment.NewLine +
                        "Do you want to continue registry ?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.No)
                    {
                        dtParts.Rows[curRow]["parts_no"] = string.Empty;
                        dtParts.Rows[curRow]["parts_name"] = string.Empty;
                        dtParts.Rows[curRow]["parts_supplier"] = string.Empty;
                        dtParts.Rows[curRow]["parts_invoice"] = string.Empty;
                        dtParts.Rows[curRow]["qty"] = string.Empty;
                        dtParts.Rows[curRow]["note"] = string.Empty;

                        // �A�����ăX�L�����ł���悤�A�e�L�X�g����ɂ���
                        txtParts.Text = string.Empty;
                        return;
                        //}
                    }

                    // �A�����ăX�L�����ł���悤�A����̃Z����I������
                    dtParts.Rows.Add(dtParts.NewRow());
                    dgvParts.CurrentCell = dgvParts[curClm, curRow + 1];
                    dgvParts.NotifyCurrentCellDirty(true);
                    dgvParts.NotifyCurrentCellDirty(false);

                    // �A�����ăX�L�����ł���悤�A�e�L�X�g����ɂ���
                    txtParts.Text = string.Empty;
                }
            }
            // �����ł��Ȃ�������̏ꍇ�A�G���[�̕\��
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // �T�u�v���V�[�W���F�X�L�����������i�ԍ������i�}�X�^�̏��ɊY�����邩�m�F���A�t����Ԃ�
        private double matchPartsNoAndGetRatio(string partsNo, DataTable dt)
        {
            if (partsNo == string.Empty) return 1;
            if (dt.Rows.Count == 0) return 1;

            matchPartsMaster = false;
            double ratio = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (partsNo.IndexOf(dt.Rows[i]["parts_no"].ToString()) >= 0)
                {
                    double.TryParse(dt.Rows[i]["ratio"].ToString(), out ratio);
                    dt.Rows[i]["match"] = "1";
                    matchPartsMaster = true;
                }
            }

            return ratio;
        }

        // �A�p�[�c�ҏW�L�����Z���{�^�����������ꂽ���̏���
        private void btnPartCancel_Click(object sender, EventArgs e)
        {
            readPartsTable(ref dtParts, ref dgvParts);
        }

        // �A�p�[�c�ҏW�o�^�{�^�����������ꂽ���̏���
        private void btnPartRegister_Click(object sender, EventArgs e)
        {
            insertBatchNo();

            string batchNo = txtBatchNo.Text;
            TfSqlTracy Tfc = new TfSqlTracy();
            bool res = Tfc.sqlDeleteInsertPartsInfo(batchNo, dtParts);

            // �s�e�r�p�k�s�q�`�b�x���������������ꍇ�̏���
            if (res)
            {
                // �c�a���p�[�c�����f�[�^�O���b�h�r���[�ɕ\������
                readPartsTable(ref dtParts, ref dgvParts);
                b_partsComplete = true;
                MessageBox.Show("Part info register completed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        // �T�u�v���V�[�W��: ���i�}�X�^�[�ɑ��݂��邪�A�X�L�������������̕��i���X�g��\������
        private string showIncompleteScanPartsList(DataTable dtm, DataTable dtp)
        {
            if (dtm.Rows.Count == 0) return string.Empty;
            if (dtp.Rows.Count == 0) return string.Empty;

            // ���i�}�X�^�[�c�`�s�`�s�`�a�k�d�̂l�`�s�b�g�t���O�ɂ��āA�S�X�L�����ϕ��i�ƍď���
            for (int i = 0; i < dtp.Rows.Count; i++)
            {
                string partsNo = dtp.Rows[i]["parts_no"].ToString();
                for (int j = 0; j < dtm.Rows.Count; j++)
                {
                    if (partsNo.IndexOf(dtm.Rows[j]["parts_no"].ToString()) >= 0)
                        dtm.Rows[j]["match"] = "1";
                }
            }

            // ���i�}�X�^�[�c�`�s�`�s�`�a�k�d�̂l�`�s�b�g�t���O�Ŗ��X�L�������i�𒊏o
            DataRow[] dr = dtm.Select("match is null");
            if (dr.Length == 0) return string.Empty;

            string incompleteList = string.Empty;
            for (int i = 0; i < dr.Length; i++)
            {
                incompleteList += (dr[i]["parts_no"].ToString() + " : " + dr[i]["parts_name"].ToString() + System.Environment.NewLine); 
            }
            return incompleteList;
        }
        

        // �T�u�T�u�v���V�[�W���F�R�p�����f���ԍ�����A�q�惂�f���ԍ����擾����
        private string getCustomerModel(string model)
        {
            string custModel = String.Empty;

            if (model == "LA20V-517AB")
                custModel = "517AB";
            else if (model == "LA20V-517AC")
                custModel = "517AC";
            else if (model == "LA20V-517AC1")
                custModel = "517AC1";
            else if (model == "LA20V-517AC2")
                custModel = "517AC2";
            else if (model == "LA20V-517BB")
                custModel = "517BB";
            else if (model == "LA20V-517CB")
                custModel = "517CB";
            else if (model == "LA20V-517DB")
                custModel = "517DB";
            else if (model == "LA20V-517DC")
                custModel = "517DC";
            else
                custModel = "517BC"; // �G���[�΍�

            return custModel;
        }

        // �T�u�v���V�[�W���F�V�K�o�b�`�̔��s
        private string getNewBatch()
        {
            //string subAssyNo = cmbSubAssyNo.Text;
            string modelNo = cmbModelNo.Text;
            string sql;
            TfSQL tf = new TfSQL();

            sql = "select batch_prefix from t_model where model_no = '" + modelNo + "'";
            string batchPrefix = tf.sqlExecuteScalarString(sql);

            sql = "select max(batch_no) from t_batch_no where batch_no like '" + batchPrefix + "%'";
            string batchOld = tf.sqlExecuteScalarString(sql);

            DateTime dateOld = new DateTime(0); 
            long numberOld = 0; 
            string batchNew;

            if (batchOld != string.Empty)  
            {
                dateOld = DateTime.ParseExact(VBStrings.Mid(batchOld, 6, 6), "yyMMdd", CultureInfo.InvariantCulture);
                numberOld = long.Parse(VBStrings.Right(batchOld, 4));
            }

            if (dateOld != DateTime.Today) 
            {
                batchNew = batchPrefix + "#" + DateTime.Today.ToString("yyMMdd") + "#" + "0001"; 
            }
            else
            {                                                                              
                batchNew = batchPrefix + "#" + DateTime.Today.ToString("yyMMdd") + "#" + (numberOld + 1).ToString("0000");
            }

            return batchNew;
        }

        // �T�u�v���V�[�W���F�o�b�`�ԍ��e�[�u���p�A�C���T�[�g�����s
        private void insertBatchNo()
        {
            string batchNo = txtBatchNo.Text;
            string modelNo = cmbModelNo.Text;
            string modelName = txtModelName.Text;
            //string subAssyNo = cmbSubAssyNo.Text;
            //string subAssyName = txtSubAssyName.Text;
            DateTime batchDate = dtpBatchDate.Value;
            string shift = cmbShift.Text;
            string line = cmbLine.Text;
            string leader = txtLeaderId.Text;
            string leaderName = txtLeaderName.Text;
            string inQty = txtInputQty.Text;
            //double.TryParse(txtInputQty.Text, out inQty);
            string outQty = txtOutputQty.Text;
            //double.TryParse(txtOutputQty.Text, out outQty);
            DateTime inTime = dtpInputTime.Value;
            DateTime outTime = dtpOutputTime.Value;
            string remark = txtRemark.Text;

            bool[] cr = { batchNo           == string.Empty ? false : true,
                          modelNo           == string.Empty ? false : true,
                          modelName         == string.Empty ? false : true,
                          //subAssyNo         == string.Empty ? false : true,
                          //subAssyName       == string.Empty ? false : true,
                                                                      true,
                          shift             == string.Empty ? false : true,
                          line              == string.Empty ? false : true,
                          leader            == string.Empty ? false : true, 
                          leaderName        == string.Empty ? false : true,
                          inQty             == string.Empty ? false : true,
                          outQty            == string.Empty ? false : true, 
                                                                      true,
                                                                      true,
                          remark            == string.Empty ? false : true, };

            string sql1 = "insert into t_batch_no(" +
                (cr[0] ? "batch_no," : string.Empty) +
                (cr[1] ? "model_no," : string.Empty) +
                (cr[2] ? "model_name," : string.Empty) +
                //(cr[3] ? "sub_assy_no," : string.Empty) +
                //(cr[4] ? "sub_assy_name," : string.Empty) +
                (cr[3] ? "batch_date," : string.Empty) +
                (cr[4] ? "shift," : string.Empty) +
                (cr[5] ? "line," : string.Empty) +
                (cr[6] ? "leader_id," : string.Empty) +
                (cr[7] ? "leader_name," : string.Empty) +
                (cr[8] ? "in_qty," : string.Empty) +
                (cr[9] ? "out_qty," : string.Empty) +
                (cr[10] ? "in_time," : string.Empty) +
                (cr[11] ? "out_time," : string.Empty) +
                (cr[12] ? "remark," : string.Empty);

            string sql2 = ") VALUES(" +
                (cr[0] ? "'" + batchNo + "'," : string.Empty) +
                (cr[1] ? "'" + modelNo + "'," : string.Empty) +
                (cr[2] ? "'" + modelName + "'," : string.Empty) +
                //(cr[3] ? "'" + subAssyNo + "'," : string.Empty) +
                //(cr[4] ? "'" + subAssyName + "'," : string.Empty) +
                (cr[3] ? "'" + batchDate + "'," : string.Empty) +
                (cr[4] ? "'" + shift + "'," : string.Empty) +
                (cr[5] ? "'" + line + "'," : string.Empty) +
                (cr[6] ? "'" + leader + "'," : string.Empty) +
                (cr[7] ? "'" + leaderName + "'," : string.Empty) +
                (cr[8] ? " " + inQty + " ," : string.Empty) +
                (cr[9] ? " " + outQty + " ," : string.Empty) +
                (cr[10] ? "'" + inTime + "'," : string.Empty) +
                (cr[11] ? "'" + outTime + "'," : string.Empty) +
                (cr[12] ? "'" + remark + "'," : string.Empty);

            string sql3 = VBStrings.Left(sql1, sql1.Length - 1) + VBStrings.Left(sql2, sql2.Length - 1) + ")";
            System.Diagnostics.Debug.Print(sql3);
            TfSQL tf = new TfSQL();
            tf.sqlExecuteNonQuery(sql3, false);

            //�e�t�H�[��Form1�̃f�[�^�O���b�g�r���[���X�V���邽�߁A�f���Q�[�g�C�x���g�𔭐�������
            this.RefreshEvent(this, new EventArgs());
        }

        //MP3�t�@�C���i����͌x�����j���Đ�����
        private string aliasName = "MediaFile";
        private void soundAlarm()
        {
            string currentDir = System.Environment.CurrentDirectory;
            string fileName = currentDir + @"\warning.mp3";
            string cmd;

            if (sound)
            {
                cmd = "stop " + aliasName;
                mciSendString(cmd, null, 0, IntPtr.Zero);
                cmd = "close " + aliasName;
                mciSendString(cmd, null, 0, IntPtr.Zero);
                sound = false;
            }

            cmd = "open \"" + fileName + "\" type mpegvideo alias " + aliasName;
            if (mciSendString(cmd, null, 0, IntPtr.Zero) != 0) return;
            cmd = "play " + aliasName;
            mciSendString(cmd, null, 0, IntPtr.Zero);
            sound = true;
        }
        // Windows API ���C���|�[�g
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern int mciSendString(String command,StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        // �ݒ�e�L�X�g�t�@�C���̓ǂݍ���
        private string readIni(string s, string k, string cfs)
        {
            StringBuilder retVal = new StringBuilder(255);
            string section = s;
            string key = k;
            string def = String.Empty;
            int size = 255;
            //get the value from the key in section
            int strref = GetPrivateProfileString(section, key, def, retVal, size, cfs);
            return retVal.ToString();
        }

        // Windows API ���C���|�[�g
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);

        // ����{�^����V���[�g�J�b�g�ł̏I���������Ȃ�
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x112;
            const long SC_CLOSE = 0xF060L;
            if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt64() & 0xFFF0L) == SC_CLOSE) { return; }
            base.WndProc(ref m);
        }
    }
}