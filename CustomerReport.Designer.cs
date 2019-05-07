namespace Secrets_Application_2019
{
    partial class CustomerReport
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
            this.CustomerDataSet = new Secrets_Application_2019.CustomerDataSet();
            this.customerDetailsTBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerDetailsTBTableAdapter = new Secrets_Application_2019.CustomerDataSetTableAdapters.customerDetailsTBTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDetailsTBBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.customerDetailsTBBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Secrets_Application_2019.Report5.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(599, 284);
            this.reportViewer1.TabIndex = 0;
            // 
            // CustomerDataSet
            // 
            this.CustomerDataSet.DataSetName = "CustomerDataSet";
            this.CustomerDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customerDetailsTBBindingSource
            // 
            this.customerDetailsTBBindingSource.DataMember = "customerDetailsTB";
            this.customerDetailsTBBindingSource.DataSource = this.CustomerDataSet;
            // 
            // customerDetailsTBTableAdapter
            // 
            this.customerDetailsTBTableAdapter.ClearBeforeFill = true;
            // 
            // CustomerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 284);
            this.Controls.Add(this.reportViewer1);
            this.Name = "CustomerReport";
            this.Text = "CustomerReport";
            this.Load += new System.EventHandler(this.CustomerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomerDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customerDetailsTBBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource customerDetailsTBBindingSource;
        private CustomerDataSet CustomerDataSet;
        private CustomerDataSetTableAdapters.customerDetailsTBTableAdapter customerDetailsTBTableAdapter;
    }
}