namespace Secrets_Application_2019
{
    partial class InStockReport
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
            this.InStockDataSet = new Secrets_Application_2019.InStockDataSet();
            this.itemDetailsTBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemDetailsTBTableAdapter = new Secrets_Application_2019.InStockDataSetTableAdapters.itemDetailsTBTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.InStockDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemDetailsTBBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.itemDetailsTBBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Secrets_Application_2019.Report4.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(726, 475);
            this.reportViewer1.TabIndex = 0;
            // 
            // InStockDataSet
            // 
            this.InStockDataSet.DataSetName = "InStockDataSet";
            this.InStockDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemDetailsTBBindingSource
            // 
            this.itemDetailsTBBindingSource.DataMember = "itemDetailsTB";
            this.itemDetailsTBBindingSource.DataSource = this.InStockDataSet;
            // 
            // itemDetailsTBTableAdapter
            // 
            this.itemDetailsTBTableAdapter.ClearBeforeFill = true;
            // 
            // InStockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 475);
            this.Controls.Add(this.reportViewer1);
            this.Name = "InStockReport";
            this.Text = "InStockReport";
            this.Load += new System.EventHandler(this.InStockReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InStockDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemDetailsTBBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource itemDetailsTBBindingSource;
        private InStockDataSet InStockDataSet;
        private InStockDataSetTableAdapters.itemDetailsTBTableAdapter itemDetailsTBTableAdapter;
    }
}