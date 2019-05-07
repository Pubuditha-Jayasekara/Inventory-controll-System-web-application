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

namespace Secrets_Application_2019
{
    /// <summary>
    /// Interaction logic for searchInvoice.xaml
    /// </summary>
    public partial class searchInvoice : Page
    {
        Service1Client cli = new Service1Client();

        public searchInvoice()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                PrintInvoice newInvo = new PrintInvoice(Int32.Parse(txtInoD.Text.ToString()));
                newInvo.Show();
            }
            catch
            {
                MessageBox.Show("Please insert Invoice Number! ","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }
    }
}
