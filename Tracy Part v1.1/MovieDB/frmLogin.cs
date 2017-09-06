using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb; 
using System.Security.Permissions;

namespace Tracy
{
    public partial class frmLogin : Form
    {
        // �R���X�g���N�^
        public frmLogin()
        {
            InitializeComponent();
        }

        // ���[�h���̏����i�R���{�{�b�N�X�ɁA�I�[�g�R���v���[�g�@�\�̒ǉ��j
        private void Form5_Load(object sender, EventArgs e)
        {
            string sql = "select leader_id FROM t_leader_id ORDER BY leader_id";
            System.Diagnostics.Debug.Print(sql);
            TfSQL tf = new TfSQL();
            tf.getComboBoxData(sql, ref cmbLeaderId);
        }

        // �R���{�{�b�N�X�I�����A���[�_�[����\������
        private void cmbLeaderId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select leader_name FROM t_leader_id where leader_id ='" + cmbLeaderId.Text + "'";
            System.Diagnostics.Debug.Print(sql);
            TfSQL tf = new TfSQL();
            string name = tf.sqlExecuteScalarString(sql);
            txtLeaderName.Text = name;
        }

        // ���[�U�[���O�C��
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string leaderId = cmbLeaderId.Text;
            string leaderName = txtLeaderName.Text;

            leaderId = cmbLeaderId.Text;

            if (leaderId != null) 
            {
                TfSQL tf = new TfSQL();

                string sql1 = "select pass FROM t_leader_id WHERE leader_id='" + leaderId + "'";
                string pass = tf.sqlExecuteScalarString(sql1);

                if (pass == txtPassword.Text)
                {
                    // �q�t�H�[��Form1��\�����A�f���Q�[�g�C�x���g��ǉ��F 

                    frmMain f1 = new frmMain();
                    f1.RefreshEvent += delegate(object sndr, EventArgs excp)
                    {
                        // �q�t�H�[��Form1�����ہA���t�H�[����\������
                        txtPassword.Text = string.Empty;
                        this.Visible = true;
                    };

                    string sql2 = "select adminflag FROM t_leader_id WHERE leader_id='" + leaderId + "'";
                    bool adminUser = tf.sqlExecuteScalarBool(sql2);

                    f1.updateControls(leaderId, leaderName, adminUser);
                    f1.Show();
                    this.Visible = false;
                }
                else if(pass != txtPassword.Text)
                {
                    MessageBox.Show("Password does not match", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // ���[�U�[���O�C��
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string pass = txtPassword.Text;
                if (pass != String.Empty)
                {
                    btnLogIn_Click(sender, e);
                }
            }
        }
    }
}



