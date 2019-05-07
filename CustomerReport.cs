using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Secrets_Application_2019
{
    public partial class CustomerReport : Form
    {
        public CustomerReport()
        {
            InitializeComponent();
        }

        private void CustomerReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'CustomerDataSet.customerDetailsTB' table. You can move, or remove it, as needed.
            this.customerDetailsTBTableAdapter.Fill(this.CustomerDataSet.customerDetailsTB);

            this.reportViewer1.RefreshReport();
        }
    }
}
