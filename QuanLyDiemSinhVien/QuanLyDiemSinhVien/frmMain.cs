using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVien
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataTable thongtinlop;
        private DataTable thongtinsinhvien;
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSVDataSet.SINHVIEN' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'qLDSVDataSet.MONHOC' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'qLDSVDataSet.LOP' table. You can move, or remove it, as needed.

            add_lop();
            load_lop();
            mkhoatbox.Enabled = false;
           
            
           
        }
        //---------------------------------------------Thông tin sinh viên------------------------------------

        private void add_lop()
        {
            thongtinlop = Access.ExecuteQuery("SP_THONGTINLOP");
            cboxLop.Items.Clear();
            foreach (DataRow s in thongtinlop.Rows)
            {
                cboxLop.Items.Add(s[0]);
            }
            cboxLop.SelectedIndex = 0;

        }

        private void cboxLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxLop.Text.Trim() == "")
            {
                MessageBox.Show("MỜI BẠN CHỌN TÊN LỚP");
                return;
            }
            
            string malopsv = cboxLop.Text.ToString();
            string[] name = { "@MALOP" };
            object[] param = { malopsv };
            thongtinsinhvien = Access.ExecuteQuery("SP_LAYSINHVIEN", name, param, 1);
            sP_LAYSINHVIENGridControl.DataSource = thongtinsinhvien;
            sP_LAYSINHVIENGridControl.DataMember = thongtinsinhvien.TableName;

           // gridView2.SetRowCellValue(gridView2.FocusedRowHandle,gridView2.Columns["PHAI"],"dsadsa");
           // string phai = gridView2.GetRowCellValue(gridView2.FocusedRowHandle,"MASV").ToString();
            
            
            

        }

        private void sP_LAYSINHVIENGridControl_Click(object sender, EventArgs e)
        {
            //mlopsvTBOX.DataBindings.Clear();
            msvTBOX.DataBindings.Clear();
            hotensvTBOX.DataBindings.Clear();
            ngaysinhsvTBOX.DataBindings.Clear();
            noisinhsvTBOX.DataBindings.Clear();
            diachisvTBOX.DataBindings.Clear();
            ghichusvTBOX.DataBindings.Clear();

            System.Data.DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            string phai = row[7].ToString();
            string nghihoc = row[8].ToString();



            if (phai == "NAM")
            {
                radio1.Checked = true;
            }
            if (phai == "NỮ")
            {
                radio2.Checked = true;
            }
            if (nghihoc == "ĐANG HỌC")
            {
                nghihocCHECKBOX.Checked = false;
            }
            if (nghihoc == "ĐÃ NGHỈ")
            {
                nghihocCHECKBOX.Checked = true;
            }
            if (nghihoc == "NULL")
            {
                nghihocCHECKBOX.Checked = false;
            }
            //mlopsvTBOX.DataBindings.Add("TEXT", thongtinsinhvien, "MALOP");
            msvTBOX.DataBindings.Add("TEXT", thongtinsinhvien, "MASV");
            hotensvTBOX.DataBindings.Add("TEXT", thongtinsinhvien, "HO TEN");
            ngaysinhsvTBOX.DataBindings.Add("TEXT", thongtinsinhvien, "NGAYSINH");
            noisinhsvTBOX.DataBindings.Add("TEXT", thongtinsinhvien, "NOISINH");
            diachisvTBOX.DataBindings.Add("TEXT", thongtinsinhvien, "DIACHI");
            ghichusvTBOX.DataBindings.Add("TEXT", thongtinsinhvien, "GHICHU");
            //string phai = gridView2.GetRowCellValue(3, "PHAI").ToString();  
            
        }


        private void button1_Click(object sender, EventArgs e) // THEM SINH VIEN
        {
            if (cboxLop.Text.Trim() == "")
            {
                MessageBox.Show("Mời bạn chọn lớp");
                return;
            }
            if (msvTBOX.Text.Trim() == "")
            {
                MessageBox.Show("Mời bạn nhập mã sinh viên");
                return;
            }
            if (hotensvTBOX.Text.Trim() == "")
            {
                MessageBox.Show("nhập họ tên");
                return;
            }
            if (radio1.Checked == false && radio2.Checked == false)
            {
                MessageBox.Show("chọn giới tính");
                return;
            }
            if (ngaysinhsvTBOX.Text.Trim() == "")
            {
                MessageBox.Show("chọn ngày sinh");
                return;
            }
            if (noisinhsvTBOX.Text.Trim() == "")
            {
                MessageBox.Show("nhập nơi sinh");
                return;
            }
            if (diachisvTBOX.Text.Trim() == "")
            {
                MessageBox.Show("nhập địa chỉ");
                return;
            }
            string mlopsv = cboxLop.Text.ToString();
            string msv = msvTBOX.Text.ToString();
            string hoten= hotensvTBOX.Text.ToString();
            string phai = "";
            bool isChecked = radio1.Checked;
            if(isChecked )
            {
              phai=radio1.Text;
            }
            else
            {
              phai=radio2.Text;
            }
            DateTime ngaysinh = DateTime.Parse(ngaysinhsvTBOX.Text.ToString());
            string noisinh=noisinhsvTBOX.Text.ToString();
            string diachi=diachisvTBOX.Text.ToString();
            string nghihoc = "";
            bool checkbox = nghihocCHECKBOX.Checked;
            if (checkbox)
            {
                nghihoc = nghihocCHECKBOX.Text;
            }

            string[] name = { "@MALOP", "@MASV", "@HOTEN", "@PHAI", "@NGAYSINH", "@NOISINH", "@DIACHI","@NGHIHOC"};
            object[] param = { mlopsv, msv, hoten, phai, ngaysinh, noisinh, diachi,nghihoc};
            int x = Access.ExecuteNonQuery("SP_THEMSINHVIEN", name, param, 8);
            if (x == 1)
            {
                MessageBox.Show("không tồn tại mã lớp này");
                return;
            }
            if (x == 2)
            {
                MessageBox.Show("Mã sinh viên này đã tồn tại");
                return;
            }
            if (x == 0)
            {
                MessageBox.Show("Thêm sinh viên" + msv + " thành công");
                Form1_Load(sender, e);
                cboxLop.Text = mlopsv;
                return;
            }
            

        }

        private void button2_Click(object sender, EventArgs e)//xóa sinh viên
        {
            if (MessageBox.Show("Bạn muốn xóa sinh viên :" + " " + msvTBOX.Text.Trim(), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mlopsv = cboxLop.Text.ToString();
                string msv = msvTBOX.Text.ToString();
                string[] name = { "@MASV" };
                object[] param = { msv };
                DataTable xoasinhvien = Access.ExecuteQuery("SP_XOASINHVIEN", name, param, 1);
                MessageBox.Show("Xóa sinh viên thành công");
                Form1_Load(sender, e);
                cboxLop.Text = mlopsv;
            }
        }

        private void button3_Click(object sender, EventArgs e)//Sửa sinh viên
        {
            string mlopsv = cboxLop.Text.ToString();
            string msv = msvTBOX.Text.ToString();
            string hoten = hotensvTBOX.Text.ToString();
            string phai = "";
            bool isChecked = radio1.Checked;
            if (isChecked)
            {
                phai = radio1.Text;
            }
            else
            {
                phai = radio2.Text;
            }
            DateTime ngaysinh = DateTime.Parse(ngaysinhsvTBOX.Text.ToString());
            string noisinh = noisinhsvTBOX.Text.ToString();
            string diachi = diachisvTBOX.Text.ToString();
            string nghihoc = "";
            bool checkbox = nghihocCHECKBOX.Checked;
            if (checkbox)
            {
                nghihoc = nghihocCHECKBOX.Text;
            }
            string[] name = { "@MALOP", "@MASV", "@HOTEN", "@PHAI", "@NGAYSINH", "@NOISINH", "@DIACHI", "@NGHIHOC" };
            object[] param = { mlopsv, msv, hoten, phai, ngaysinh, noisinh, diachi, nghihoc };
            int x = Access.ExecuteNonQuery("SP_SUASINHVIEN", name, param, 8);
            if (x == 1)
            {
                MessageBox.Show("Lớp này không tồn tại");
                return;
            }
            if(x == 2)
            {
                MessageBox.Show("sinh viên này không tồn tại");
                return;
            }
            if (x == 0)
            {
                MessageBox.Show("sửa sinh viên" + " " + msv + "thành công");
                Form1_Load(sender, e);
                cboxLop.Text = mlopsv;
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e) // thống kê sinh viên
        {
            thongkesinhvien thongkesv = new thongkesinhvien();
            thongkesv.Show();
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

       


        //----------------------------------------------------------------------------------------------------------




        //---------------------------------Thông tin Lớp---------------------------------------------------

        private void sP_THONGTINLOPGridControl_Click(object sender, EventArgs e)
        {
            mloptbox.DataBindings.Clear();
            tloptbox.DataBindings.Clear();
            mkhoatbox.DataBindings.Clear();
            mloptbox.DataBindings.Add("TEXT", thongtinlop, "Mã Lớp");
            tloptbox.DataBindings.Add("TEXT", thongtinlop, "Tên Lớp");
            mkhoatbox.DataBindings.Add("TEXT", thongtinlop, "Mã Khoa");
        }
        private void load_lop()
        {
           
            thongtinlop = Access.ExecuteQuery("SP_THONGTINLOP");
            sP_THONGTINLOPGridControl.DataSource = thongtinlop;
            sP_THONGTINLOPGridControl.DataMember = thongtinlop.TableName;
        }

        private void check()
        {
            if (mloptbox.Text.Trim() == "")
            {
                MessageBox.Show("nhập mã lớp");
                return;
            }

            if (tloptbox.Text == "")
            {
                MessageBox.Show("nhập tên lớp");
                return;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mloptbox.Text.Trim() == "")
                {
                    MessageBox.Show("nhập mã lớp");
                    return;
                }

                if (tloptbox.Text == "")
                {
                    MessageBox.Show("nhập tên lớp");
                    return;
                }
                string malop = mloptbox.Text.ToString();
                string tenlop = tloptbox.Text.ToString();
                string[] name = { "@MALOP", "@TENLOP" };
                object[] param = { malop, tenlop };
                int x = Access.ExecuteNonQuery("SP_THEMLOP", name, param, 2);

                if (x == 0)
                {

                    MessageBox.Show("Them lop" + " " + malop + " " + "thanh cong");
                    mloptbox.Text = string.Empty;
                    tloptbox.Text = string.Empty;
                    btnRefresh.PerformClick();
                    return;
                }
                if (x == 1)
                {
                    MessageBox.Show("Ma Lop bi trung");
                    return;
                }
                if (x == 2)
                {
                    MessageBox.Show("ten lop bi trung");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("co loi" + ex);
            }


        }

        private void mALOPTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (mloptbox.Text.Trim() == "")
                {
                    MessageBox.Show("nhập mã lớp");
                    return;
                }

                if (tloptbox.Text == "")
                {
                    MessageBox.Show("nhập tên lớp");
                    return;
                }
                string malop = mloptbox.Text.ToString();
                string tenlop = tloptbox.Text.ToString();
                string[] name = { "@MALOP", "@TENLOP" };
                object[] param = { malop, tenlop };
                int x = Access.ExecuteNonQuery("SP_SUALOP", name, param, 2);
                if (x == 0)
                {
                    MessageBox.Show("Sua Thanh cong ma lop :" + " " + malop);
                    mloptbox.Text = string.Empty;
                    tloptbox.Text = string.Empty;
                    btnRefresh.PerformClick();
                    return;
                }
                if (x == 1)
                {
                    MessageBox.Show("Tên Lớp này đã tồn tại");
                    return;
                }

                if (x == 2)
                {
                    MessageBox.Show("Mã lớp này không tồn tại");
                    return;
                    btnRefresh.PerformClick();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("co loi" + ex);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (mloptbox.Text == "")
                {
                    MessageBox.Show("nhập mã lớp muốn xóa");
                    return;
                }
                string malop = mloptbox.Text.ToString();
                string[] name = { "@MALOP" };
                object[] param = { malop };
                int x = Access.ExecuteNonQuery("SP_XOALOP", name, param, 1);
                if (x == 0)
                {
                    MessageBox.Show(" Đã xóa lớp" + " " + malop.ToUpper() + " " + "thành công");
                    mloptbox.Text = string.Empty;
                    tloptbox.Text = string.Empty;
                    btnRefresh.PerformClick();
                    return;
                }
                if (x != 0)
                {
                    MessageBox.Show("Lớp " + " " + malop + " " + " hien co sinh vien dang hoc khong the xoa");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("loi" + ex);
            }
        }

        private void mAMHTextEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void mloptbox_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.NewValue.ToString().Length > 8)
                    e.Cancel = true;
            }
        }

        private void tloptbox_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.NewValue.ToString().Length > 40)
                    e.Cancel = true;
            }
        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            load_lop();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaoTk taotk = new TaoTk();
            taotk.Show();
        }

        

        

        

       

        



        

        





       
        

     

      

        

       
        

        

       /* private void bnt_GV_Dangnhap_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Tên tài khoản không được để trống");
                textBox2.Focus();
                return;
            }
            Connection cnn = Access.CnnList[cboxKhoa.SelectedIndex];
            Access.dataSource = cnn.DataSource;
            Access.initCatalog = cnn.InitCatalog;
            Access.username = cnn.Username;
            Access.password = cnn.Password;

            if (!Access.Connect())
            {
                MessageBox.Show("Không thể kết nối đến SERVER");
                return;
            }
            string username = textBox2.Text.Trim().ToUpper();
            string password = textBox3.Text.Trim();
            if (password == "")
            {
                Access.username = cnn.SV;
                Access.password = cnn.SVPwd;
                string[] name = { "@masv" };
                object[] param = { username };
                SqlDataReader reader = Access.ExecSqlDataReader("SP_DangNhapSV", name, param, 1);
                reader.Read();
                if(reader.HasRows)
                {
                    Access.hoTen = reader["HO TEN"].ToString();
                    Access.id = username;
                    Access.malop = reader["malop"].ToString();
                    Access.tenlop = reader["tenlop"].ToString();
                    Access.mKhoa = cboxKhoa.Text.Trim();
                }
            }

            
        }
        * */

       


       

        

       

        
    }
}
