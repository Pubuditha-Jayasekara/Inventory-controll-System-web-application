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
    public partial class DailySalse : Form
    {
        public DailySalse()
        {
            InitializeComponent();
        }

        private void DailySalse_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dailySalseDataSet.DailySalseTB' table. You can move, or remove it, as needed.
           
        }

        private void submit_Click(object sender, EventArgs e)
        {
            string[] date = datePick.Value.ToString().Split(' ');
           //essageBox.Show(date[0].ToString());


            this.DailySalseTBTableAdapter.Fill(this.dailySalseDataSet.DailySalseTB, date[0]);

            this.reportViewer1.RefreshReport();
        }
    }
}
