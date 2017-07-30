using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QuanLyDiemSinhVien
{
    public partial class thongkesinhvien : Form
    {
        private DataTable dslop;
        public thongkesinhvien()
        {
            InitializeComponent();
        }

        private void loadlop()
        {
            dslop = Access.ExecuteQuery("SP_THONGTINLOP");

            comboBox1.Items.Clear();
            foreach (DataRow s in dslop.Rows)
            {
                comboBox1.Items.Add(s[0]);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void thongkesinhvien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLDSVDataSet.SP_THONGKESINHVIEN' table. You can move, or remove it, as needed.

            loadlop();
            this.reportViewer1.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lop = comboBox1.Text.ToString();
            string[] name = { "@MALOP" };
            object[] param = { lop };
            DataTable thongtinsinhvien = Access.ExecuteQuery("SP_THONGKESINHVIEN", name, param, 1);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "thongkesinhvien.rdlc";
            if (thongtinsinhvien.Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = thongtinsinhvien;

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
        }

       
    }
}
