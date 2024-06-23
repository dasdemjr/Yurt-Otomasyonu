namespace _211116065_YusufDasdemir
{
    partial class frmOgrRapor
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.YurtKayitDataSet7 = new _211116065_YusufDasdemir.YurtKayitDataSet7();
            this.OgrenciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OgrenciTableAdapter = new _211116065_YusufDasdemir.YurtKayitDataSet7TableAdapters.OgrenciTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.YurtKayitDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OgrenciBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.OgrenciBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "_211116065_YusufDasdemir.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1320, 458);
            this.reportViewer1.TabIndex = 0;
            // 
            // YurtKayitDataSet7
            // 
            this.YurtKayitDataSet7.DataSetName = "YurtKayitDataSet7";
            this.YurtKayitDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // OgrenciBindingSource
            // 
            this.OgrenciBindingSource.DataMember = "Ogrenci";
            this.OgrenciBindingSource.DataSource = this.YurtKayitDataSet7;
            // 
            // OgrenciTableAdapter
            // 
            this.OgrenciTableAdapter.ClearBeforeFill = true;
            // 
            // frmOgrRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1320, 458);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOgrRapor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Öğrennci Rapor";
            this.Load += new System.EventHandler(this.frmOgrRapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.YurtKayitDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OgrenciBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource OgrenciBindingSource;
        private YurtKayitDataSet7 YurtKayitDataSet7;
        private YurtKayitDataSet7TableAdapters.OgrenciTableAdapter OgrenciTableAdapter;
    }
}