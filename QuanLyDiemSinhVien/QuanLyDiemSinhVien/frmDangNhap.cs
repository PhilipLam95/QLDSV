using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyDiemSinhVien
{
    public partial class frmDangNhap : Form
    {
        private DataTable tenKhoa;
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void add_khoa()
        {
            tenKhoa = Access.ExecuteQuery("SP_LayKhoa");
            cboxKhoa.Items.Clear();
            foreach (DataRow s in tenKhoa.Rows)
            {
                cboxKhoa.Items.Add(s[1]);
            }
            cboxKhoa.SelectedIndex = 0;

        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            add_khoa();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Tên tài khoản không được để trống");
                textBox1.Focus();
                return;
            }

            Access.tenKhoa = cboxKhoa.Text;
            if (cboxKhoa.Text == "CONG NGHE THONG TIN")
            {
                Access.dataSource = @"DELL-PC\SERVER_TWO";
                return;
                
            }
            if (cboxKhoa.Text == "VIEN THONG")
            {
                Access.dataSource = @"DELL-PC\SERVER_THREE";
                return;

            }
            if ((cboxKhoa.Text != "CONG NGHE THONG TIN") && (cboxKhoa.Text != "VIEN THONG"))
            {
                MessageBox.Show("SERVER NAY KHONG TON TAI");
                return;
            }
            frmMain fmain = new frmMain();
            fmain.Show();

            
            /*
            MessageBox
            Access.initCatalog = cnn.InitCatalog;
            Access.username = cnn.Username;
            Access.password = cnn.Password;
            if (!Access.Connect())
            {
                MessageBox.Show("Không thể kết nối đến máy chủ");
                return;
            }*/
            string username = textBox1.Text.Trim().ToUpper();
            string password = textBox2.Text.Trim();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            groupBox2.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Show();
        }

        private void cboxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
