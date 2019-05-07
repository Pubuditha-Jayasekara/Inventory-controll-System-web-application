namespace Secrets_Application_2019
{
    partial class DailySalse
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
            this.DailySalseTBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dailySalseDataSet = new Secrets_Application_2019.dailySalseDataSet();
            this.datePick = new System.Windows.Forms.DateTimePicker();
            this.submit = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DailySalseTBTableAdapter = new Secrets_Application_2019.dailySalseDataSetTableAdapters.DailySalseTBTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DailySalseTBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dailySalseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // DailySalseTBBindingSource
            // 
            this.DailySalseTBBindingSource.DataMember = "DailySalseTB";
            this.DailySalseTBBindingSource.DataSource = this.dailySalseDataSet;
            // 
            // dailySalseDataSet
            // 
            this.dailySalseDataSet.DataSetName = "dailySalseDataSet";
            this.dailySalseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // datePick
            // 
            this.datePick.Location = new System.Drawing.Point(12, 12);
            this.datePick.Name = "datePick";
            this.datePick.Size = new System.Drawing.Size(134, 20);
            this.datePick.TabIndex = 0;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(170, 12);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 1;
            this.submit.Text = "View Report";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DailySalseTBBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Secrets_Application_2019.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 51);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(778, 367);
            this.reportViewer1.TabIndex = 2;
            // 
            // DailySalseTBTableAdapter
            // 
            this.DailySalseTBTableAdapter.ClearBeforeFill = true;
            // 
            // DailySalse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 418);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.datePick);
            this.Name = "DailySalse";
            this.Text = "DailySalse";
            this.Load += new System.EventHandler(this.DailySalse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DailySalseTBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dailySalseDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePick;
        private System.Windows.Forms.Button submit;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DailySalseTBBindingSource;
        private dailySalseDataSet dailySalseDataSet;
        private dailySalseDataSetTableAdapters.DailySalseTBTableAdapter DailySalseTBTableAdapter;
    }
}