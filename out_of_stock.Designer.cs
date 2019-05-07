namespace Secrets_Application_2019
{
    partial class out_of_stock
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
            this.OutOfStockDataSet = new Secrets_Application_2019.OutOfStockDataSet();
            this.itemDetailsTBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemDetailsTBTableAdapter = new Secrets_Application_2019.OutOfStockDataSetTableAdapters.itemDetailsTBTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.OutOfStockDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemDetailsTBBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.itemDetailsTBBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Secrets_Application_2019.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(695, 411);
            this.reportViewer1.TabIndex = 0;
            // 
            // OutOfStockDataSet
            // 
            this.OutOfStockDataSet.DataSetName = "OutOfStockDataSet";
            this.OutOfStockDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemDetailsTBBindingSource
            // 
            this.itemDetailsTBBindingSource.DataMember = "itemDetailsTB";
            this.itemDetailsTBBindingSource.DataSource = this.OutOfStockDataSet;
            // 
            // itemDetailsTBTableAdapter
            // 
            this.itemDetailsTBTableAdapter.ClearBeforeFill = true;
            // 
            // out_of_stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 411);
            this.Controls.Add(this.reportViewer1);
            this.Name = "out_of_stock";
            this.Text = "out_of_stock";
            this.Load += new System.EventHandler(this.out_of_stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OutOfStockDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemDetailsTBBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource itemDetailsTBBindingSource;
        private OutOfStockDataSet OutOfStockDataSet;
        private OutOfStockDataSetTableAdapters.itemDetailsTBTableAdapter itemDetailsTBTableAdapter;
    }
}