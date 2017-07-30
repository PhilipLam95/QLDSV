namespace QuanLyDiemSinhVien
{
    partial class thongkesinhvien
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QLDSVDataSet = new QuanLyDiemSinhVien.QLDSVDataSet();
            this.SP_THONGKESINHVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_THONGKESINHVIENTableAdapter = new QuanLyDiemSinhVien.QLDSVDataSetTableAdapters.SP_THONGKESINHVIENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QLDSVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_THONGKESINHVIENBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(276, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(163, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn lớp";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SP_THONGKESINHVIENBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyDiemSinhVien.thongkesinhvien.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 61);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(723, 316);
            this.reportViewer1.TabIndex = 2;
            // 
            // QLDSVDataSet
            // 
            this.QLDSVDataSet.DataSetName = "QLDSVDataSet";
            this.QLDSVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_THONGKESINHVIENBindingSource
            // 
            this.SP_THONGKESINHVIENBindingSource.DataMember = "SP_THONGKESINHVIEN";
            this.SP_THONGKESINHVIENBindingSource.DataSource = this.QLDSVDataSet;
            // 
            // SP_THONGKESINHVIENTableAdapter
            // 
            this.SP_THONGKESINHVIENTableAdapter.ClearBeforeFill = true;
            // 
            // thongkesinhvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 365);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "thongkesinhvien";
            this.Text = "thongkesinhvien";
            this.Load += new System.EventHandler(this.thongkesinhvien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QLDSVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_THONGKESINHVIENBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_THONGKESINHVIENBindingSource;
        private QLDSVDataSet QLDSVDataSet;
        private QLDSVDataSetTableAdapters.SP_THONGKESINHVIENTableAdapter SP_THONGKESINHVIENTableAdapter;
    }
}