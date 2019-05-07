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
    public partial class out_of_stock : Form
    {
        public out_of_stock()
        {
            InitializeComponent();
        }

        private void out_of_stock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'OutOfStockDataSet.itemDetailsTB' table. You can move, or remove it, as needed.
            this.itemDetailsTBTableAdapter.Fill(this.OutOfStockDataSet.itemDetailsTB);

            this.reportViewer1.RefreshReport();
        }
    }
}
