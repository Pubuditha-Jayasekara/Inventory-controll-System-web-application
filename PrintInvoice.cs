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
    public partial class PrintInvoice : Form
    {
        int billNOEKAYAKO;
        public PrintInvoice(int bill)
        {
            billNOEKAYAKO = bill;
            InitializeComponent();
        }

        private void PrintInvoice_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'InvoiceDataSet.invoiceTB' table. You can move, or remove it, as needed.
            this.invoiceTBTableAdapter.Fill(this.InvoiceDataSet.invoiceTB,billNOEKAYAKO);

            this.reportViewer1.RefreshReport();
        }
    }
}
