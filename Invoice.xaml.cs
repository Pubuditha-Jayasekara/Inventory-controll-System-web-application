using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Secrets_Application_2019.secretsWebServiceReference;
using System.Threading;

namespace Secrets_Application_2019
{
    /// <summary>
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Page
    {
        Service1Client mycli = new Service1Client();
        string cashier;
        string branch;
        int billNO;

        int totalBill;
        DateTime dt; // Or whatever
        string s;
        


        public Invoice(string c, string b, int bN)
        {
            cashier = c;
            branch = b;
            billNO = bN+1;
            totalBill = 0;
            dt = DateTime.Now;
        //  s = dt.ToString("yyyy/MM/dd");
            s = dt.ToString("dd/MM/yyyy");
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                txtItemID.Clear();
                txtItemQty.Clear();
                lblID.Content = null;
                lblDate.Content = null;
                lblName.Content = null;
                lblPrice.Content = null;
                lblQty.Content = null;
                lblTotal.Content = null;
            }

            catch
            {
                MessageBox.Show("Error in invoice!");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                 
                 mycli.insertSalse(billNO, totalBill, s);

                PrintInvoice newInvo = new PrintInvoice(billNO);
                newInvo.Show();
            }

            catch
            {
                MessageBox.Show("please at least one item to generate report!");
            }
        }

        private void add(object sender, RoutedEventArgs e)
        {
            
            try
            {
                

                //teTime today=new DateTime();
                var dataSet = mycli.searchItemByID(Int32.Parse(txtItemID.Text.ToString()));

                //MessageBox.Show(billNO.ToString());

                //bool res = mycli.insertInvoice(billNO+1, Int32.Parse(dataSet[0].ItemID.ToString()), dataSet[0].Name, Int32.Parse(txtItemQty.Text.ToString()), Int16.Parse(dataSet[0].sellingPrice.ToString()), (Int16.Parse(dataSet[0].sellingPrice.ToString()) * Int32.Parse(txtItemQty.Text.ToString())), cashier, branch, today.ToString());
                bool rest = mycli.insertInvoice(billNO, Int32.Parse(dataSet[0].ItemID.ToString()), dataSet[0].Name.ToString(), Int32.Parse(txtItemQty.Text.ToString()), Int16.Parse(dataSet[0].sellingPrice.ToString()), (Int16.Parse(dataSet[0].sellingPrice.ToString()) * Int32.Parse(txtItemQty.Text.ToString())), cashier.ToString(), branch.ToString(), s);

                lblDate.Content = s;
                lblID.Content = dataSet[0].ItemID;
                lblName.Content = dataSet[0].Name;
                lblPrice.Content = dataSet[0].sellingPrice;
                lblQty.Content = txtItemQty.Text.ToString();
                lblTotal.Content = Int32.Parse(txtItemQty.Text.ToString()) * Int32.Parse(dataSet[0].sellingPrice.ToString());
               
                totalBill += Int32.Parse(txtItemQty.Text.ToString()) * Int32.Parse(dataSet[0].sellingPrice.ToString());

               bool res= mycli.reduceQty(dataSet[0].ItemID, Int32.Parse(txtItemQty.Text.ToString()));

               var itm = mycli.searchItemByID(dataSet[0].ItemID).ToList();

                if(int.Parse(itm[0].qty.ToString())<=0){

                    bool upda = mycli.updateItemavailability(dataSet[0].ItemID);
                         
                }
            }
            catch
            {
                MessageBox.Show("Invoice Error!");
            }
        }
    }
}
