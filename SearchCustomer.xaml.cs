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
    /// Interaction logic for SearchCustomer.xaml
    /// </summary>
    public partial class SearchCustomer : Page
    {
        Service1Client mycli = new Service1Client();

        public SearchCustomer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var res = mycli.searchCustomer(txtSerch.Text);

                if (res != null)
                {
                    searchCustomerList.ItemsSource = res;
                }

                else
                {
                    MessageBox.Show("Customer not found!", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            catch
            {
                MessageBox.Show("Customer not found!", "Warning", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Banners());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var res = mycli.searchCustomer(txtSerch.Text);

            var resss=MessageBox.Show("Are you sure to delete?", "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);

            if (resss.ToString() == "Yes")
            {

                var del = mycli.DeleteCustomer(res[0].customerID);

                if (del)
                {
                    MessageBox.Show("Successfully deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                {
                    MessageBox.Show("Can not delete!", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string passingVal=txtSerch.Text;

            updateCustomer newUpdate = new updateCustomer(passingVal);
            this.NavigationService.Navigate(newUpdate );
         
        }
    }
}
