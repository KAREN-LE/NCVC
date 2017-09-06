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
        //Lam viec voi GIT

        //親フォームForm1へイベント発生を連絡（デレゲート）
        public delegate void RefreshEventHandler(object sender, EventArgs e);
        public event RefreshEventHandler RefreshEvent;

        // プリント用テキストファイルの保存用フォルダを、基本設定ファイルで設定する
        string appconfig = System.Environment.CurrentDirectory + "\\info.ini";
        string directory = @"C:\Users\takusuke.fujii\Desktop\Auto Print\\"; 

        //その他、非ローカル変数
        DataTable dtParts;
       // DataTable dtPartsMaster;

        bool formAddMode;
        bool formAdmin;
        bool b_headerComplete;
        bool b_partsComplete;
        bool matchPartsMaster = false;
        bool sound;

        // コンストラクタ
        public frmPartInfo()
        {
            InitializeComponent();
        }

        // ロード時の処理
        private void Form3_Load(object sender, EventArgs e)
        {
            // 当フォームの表示場所を指定
            this.Left = 60;
            this.Top = 35;
            
            // 各種処理用のテーブルを生成
            //dtOperator = new DataTable();
            dtParts = new DataTable();
            //dtSubMaterial = new DataTable();
            //dtPartsMaster = new DataTable();

            // テーブルの定義
            defineTables(ref dtParts);

            if (!formAddMode)
            {
                readPartsTable(ref dtParts, ref dgvParts);
            }
            else if (formAddMode)
            {
                insertBlankRecord(ref dtParts, ref dgvParts);
            }

            // バッチ新規発行モードの場合は、新規バッチを発行して、データベースへ書き込む
            if (formAddMode)
            {
                txtBatchNo.Text = getNewBatch();
            }

            // プリント用ファイルの保存先フォルダを、基本設定ファイルで設定する
            directory = readIni("TARGET DIRECTORY", "DIR", appconfig);
        }

        // サブプロシージャ：親フォームで呼び出し、親フォームの情報を、テキストボックスへ格納して引き継ぐ
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

            // 編集モードの場合は、登録完了確認は行わない（完了フラグを予めオン）
            if (!formAddMode)
            {
                b_headerComplete = true;
                b_partsComplete = true;
            }

            // 管理モードでない場合（他のリーダー起案のバッチの場合）、閉じるボタン以外を無効にする
            if (!formAdmin)
            {
                disableControlsExceptTabControlAndCloseButton(this);
            }
        }

        // サブプロシージャ：フォームの無効化
        private void disableControlsExceptTabControlAndCloseButton(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                // 閉じるボタン以外は無効にする
                if (child.Name != "tabControl1" && child.Name != "btnClose")
                    child.Enabled = false;
            }

            

            foreach (Control child in this.tabParts.Controls) 
                child.Enabled = false;

            
        }

        // サブプロシージャ：ＤＴの定義
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

        // サブプロシージャ：空レコードをＤＴへ追加し表示する
        private void insertBlankRecord(ref DataTable dt, ref DataGridView dgv)
        {
            dt.Clear();
            dt.Rows.Add(dt.NewRow());
            updateDataGridViewsub(dt, ref dgv);
        }

        // ①オペレーター
        // サブプロシージャ：オペレーター情報をデータグリッドビューに反映する
        private void readOperatorTable(ref DataTable dt, ref DataGridView dgv, bool load)
        {
            string batchNo = txtBatchNo.Text;
            string sql = "select process, operator, machine from t_operator " + "where batch_no='" + batchNo + "'";
            System.Diagnostics.Debug.Print(sql);
            dt.Clear();
            TfSQL tf = new TfSQL();
            tf.sqlDataAdapterFillDatatable(sql, ref dt);
            updateDataGridViewsub(dt, ref dgv);

            //// グリッドビューにコンボボックスを追加する
            //if(load) insertComboBoxToGridView();
        }     

        // サブプロシージャ：グリッドビューにコンボボックスを追加する
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

        // グリッドビューコンボボックスの値が変更された際の処理（イベント発生）
        private void dgvOperator_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dgvOperator.CurrentCell.ColumnIndex == 3 && e.Control is ComboBox)
            //{
            //    ComboBox comboBox = e.Control as ComboBox;
            //    comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            //}
        }

        // サブプロシージャ：グリッドビューコンボボックスの値が変更された際の処理（イベント内容）
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

        // ②部品
        // サブプロシージャ：部品情報をデータグリッドビューに反映する
        private void readPartsTable(ref DataTable dt, ref DataGridView dgv)
        {
            string batchNo = txtBatchNo.Text;
            string sql = "select parts_no, parts_name, parts_supplier, parts_invoice, qty, note from t_parts_invoice " + "where batch_no='" + batchNo + "'";
            System.Diagnostics.Debug.Print(sql);
            dt.Clear();
            TfSQL tf = new TfSQL();
            tf.sqlDataAdapterFillDatatable(sql, ref dt);
            updateDataGridViewsub(dt, ref dgv);

            // スキャン登録ができるよう、カレントセルを設定し、ＤＩＲＴＹにする
            int r = dt.Rows.Count;
            dt.Rows.Add(dt.NewRow());
            dgv.CurrentCell = dgv[0, r];
            dgv.NotifyCurrentCellDirty(true);
            dgv.NotifyCurrentCellDirty(false);

            // 部品マスタ情報を取得する
            //readPartsMasterTable(ref dtPartsMaster);
        }

        
        // ③副資材
        // サブプロシージャ：副資材情報をデータグリッドビューに反映する
        //private void readSubMaterialTable(ref DataTable dt, ref DataGridView dgv)
        //{
        //    string batchNo = txtBatchNo.Text;
        //    string sql = "select sub_mat_no, sub_mat_name, sub_mat_supplier, sub_mat_invoice, validity from t_sub_mat_invoice " + "where batch_no='" + batchNo + "'";
        //    System.Diagnostics.Debug.Print(sql);
        //    dt.Clear();
        //    TfSQL tf = new TfSQL();
        //    tf.sqlDataAdapterFillDatatable(sql, ref dt);
        //    updateDataGridViewsub(dt, ref dgv);

        //    // スキャン登録ができるよう、カレントセルを設定し、ＤＩＲＴＹにする
        //    int r = dt.Rows.Count;
        //    dt.Rows.Add(dt.NewRow());
        //    dgv.CurrentCell = dgv[0, r];
        //    dgv.NotifyCurrentCellDirty(true);
        //    dgv.NotifyCurrentCellDirty(false);
        //}

        // サブサブプロシージャ：データグリットビューへデータテーブルを格納
        private void updateDataGridViewsub(DataTable dt, ref DataGridView dgv)
        {
            //データグリットビューへデータテーブルを格納
            dgv.DataSource = dt;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        // バッチヘッダー情報更新ボタン押下時の処理
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

            //親フォームForm1のデータグリットビューを更新するため、デレゲートイベントを発生させる
            this.RefreshEvent(this, new EventArgs());
        }

        // 印刷ボタン押下時の処理
        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            string batchNo = txtBatchNo.Text;
            string modelNo = cmbModelNo.Text;
            string modelName = txtModelName.Text;
            DateTime batchDate = dtpBatchDate.Value;

            ExcelClass xl = new ExcelClass();

            // エクセルへ出力
            xl.ExportBatchDetailToExcel(batchNo, modelNo, modelName, batchDate, dtParts);
        }

        // バッチ削除ボタン押下時の処理（ヘッダーと明細全ての削除）
        private void btnDeleteBatch_Click(object sender, EventArgs e)
        {
            // 念のため、本当に削除するのか、２度ユーザーに問う
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

            //親フォームForm1のデータグリットビューを更新するため、デレゲートイベントを発生させる
            this.RefreshEvent(this, new EventArgs());

            // コントロールの無効化
            disableControlsExceptCloseButton(this);

            // 登録完了フラグオン（誤って閉じることを防止する機能、オフ）
            b_headerComplete = true;
            b_partsComplete = true;

            // ＴＢＩテーブルのパーツ情報を削除するため、参照すべきＴＢＩテーブル名を特定する
            string model = cmbModelNo.Text;
            DateTime month = dtpBatchDate.Value;
       //     string tbiTable = decideReferenceTable(model, month);

            // ＴＢＩテーブルの同バッチ既存レコード削除
  //          string sql2 = "delete from " + tbiTable + " where lot = '" + batchNo + "'";
 //           System.Diagnostics.Debug.Print(sql2);
  //          tf.sqlExecuteNonQueryToPqmDb(sql2, false);
        }

        // フォームクローズボタン押下時の処理
        private void btnClose_Click(object sender, EventArgs e)
        {
            // 更新モードの場合は、処理なし。
            if (!formAddMode) this.Close(); 

            // ヘッダー・オペレーター・部品・副資材、４ステップが完了しているか否か、確認
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

        // サブプロシージャ: コントロールの無効化
        private void disableControlsExceptCloseButton(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                // 閉じるボタン以外は無効にする
                if (child.Name != "btnClose")
                    child.Enabled = false;

                // テキストボックスとコンボボックスはクリア
                if (child is TextBox || child is ComboBox)
                    child.Text = string.Empty;
            }

            // ＤＡＴＥＴＩＭＥＰＩＣＫＥＲは日時を初期化
            dtpBatchDate.Value = DateTime.Today;
            dtpInputTime.Value = DateTime.Today;
            dtpOutputTime.Value = DateTime.Today;

            // データグリッドビューは、データソースを消去
            
            dgvParts.DataSource = "";
            
        }


        private void txtParts_KeyDown(object sender, KeyEventArgs e)
        {
            //エンターキー以外、入力文字列なし、グリッドビュー選択行なし、は処理しない
            if (e.KeyCode != Keys.Enter) return;
            
            string partsInfo = txtParts.Text;
            if (partsInfo == string.Empty) return;
            
            int curRow = dgvParts.CurrentCell.RowIndex;
            int curClm = dgvParts.CurrentCell.ColumnIndex;
            if (curRow < 0) return;

            // セミコロンでＱＲ読み取り内容を分割し、グリットビューに表示する
            try
            {
                string[] split = partsInfo.Split(';');
                dtParts.Rows[curRow]["parts_no"] = split[0];
                dtParts.Rows[curRow]["parts_name"] = split[1];
                dtParts.Rows[curRow]["parts_supplier"] = split[2];
                dtParts.Rows[curRow]["parts_invoice"] = split[3];
                // 部品番号が部品マスタの情報に該当するか確認し、個付けを返す
                //double r = matchPartsNoAndGetRatio(split[0], dtPartsMaster);
                dtParts.Rows[curRow]["qty"] = split[5]; //split[5]; バッチ全体ＩＮＰＵＴ ＱＴＹ * 個付け
                dtParts.Rows[curRow]["note"] = "new";

                // 部品マスタに該当がない場合は、警告。ユーザーが登録をキャンセルする場合は、消去
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

                        // 連続してスキャンできるよう、テキストを空にする
                        txtParts.Text = string.Empty;
                        return;
                        //}
                    }

                    // 連続してスキャンできるよう、一つ下のセルを選択する
                    dtParts.Rows.Add(dtParts.NewRow());
                    dgvParts.CurrentCell = dgvParts[curClm, curRow + 1];
                    dgvParts.NotifyCurrentCellDirty(true);
                    dgvParts.NotifyCurrentCellDirty(false);

                    // 連続してスキャンできるよう、テキストを空にする
                    txtParts.Text = string.Empty;
                }
            }
            // 分割できない文字列の場合、エラーの表示
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // サブプロシージャ：スキャンした部品番号が部品マスタの情報に該当するか確認し、個付けを返す
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

        // ②パーツ編集キャンセルボタンが押下された時の処理
        private void btnPartCancel_Click(object sender, EventArgs e)
        {
            readPartsTable(ref dtParts, ref dgvParts);
        }

        // ②パーツ編集登録ボタンが押下された時の処理
        private void btnPartRegister_Click(object sender, EventArgs e)
        {
            insertBatchNo();

            string batchNo = txtBatchNo.Text;
            TfSqlTracy Tfc = new TfSqlTracy();
            bool res = Tfc.sqlDeleteInsertPartsInfo(batchNo, dtParts);

            // ＴＦＳＱＬＴＲＡＣＹ処理が成功した場合の処理
            if (res)
            {
                // ＤＢ内パーツ情報をデータグリッドビューに表示する
                readPartsTable(ref dtParts, ref dgvParts);
                b_partsComplete = true;
                MessageBox.Show("Part info register completed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        // サブプロシージャ: 部品マスターに存在するが、スキャンが未完了の部品リストを表示する
        private string showIncompleteScanPartsList(DataTable dtm, DataTable dtp)
        {
            if (dtm.Rows.Count == 0) return string.Empty;
            if (dtp.Rows.Count == 0) return string.Empty;

            // 部品マスターＤＡＴＡＴＡＢＬＥのＭＡＴＣＨフラグについて、全スキャン済部品と再処理
            for (int i = 0; i < dtp.Rows.Count; i++)
            {
                string partsNo = dtp.Rows[i]["parts_no"].ToString();
                for (int j = 0; j < dtm.Rows.Count; j++)
                {
                    if (partsNo.IndexOf(dtm.Rows[j]["parts_no"].ToString()) >= 0)
                        dtm.Rows[j]["match"] = "1";
                }
            }

            // 部品マスターＤＡＴＡＴＡＢＬＥのＭＡＴＣＨフラグで未スキャン部品を抽出
            DataRow[] dr = dtm.Select("match is null");
            if (dr.Length == 0) return string.Empty;

            string incompleteList = string.Empty;
            for (int i = 0; i < dr.Length; i++)
            {
                incompleteList += (dr[i]["parts_no"].ToString() + " : " + dr[i]["parts_name"].ToString() + System.Environment.NewLine); 
            }
            return incompleteList;
        }
        

        // サブサブプロシージャ：コパルモデル番号から、客先モデル番号を取得する
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
                custModel = "517BC"; // エラー対策

            return custModel;
        }

        // サブプロシージャ：新規バッチの発行
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

        // サブプロシージャ：バッチ番号テーブル用、インサート文実行
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

            //親フォームForm1のデータグリットビューを更新するため、デレゲートイベントを発生させる
            this.RefreshEvent(this, new EventArgs());
        }

        //MP3ファイル（今回は警告音）を再生する
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
        // Windows API をインポート
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        private static extern int mciSendString(String command,StringBuilder buffer, int bufferSize, IntPtr hwndCallback);

        // 設定テキストファイルの読み込み
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

        // Windows API をインポート
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);

        // 閉じるボタンやショートカットでの終了を許さない
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