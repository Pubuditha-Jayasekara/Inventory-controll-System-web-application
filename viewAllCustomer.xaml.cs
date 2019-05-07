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
    /// Interaction logic for viewAllCustomer.xaml
    /// </summary>
    public partial class viewAllCustomer : Page
    {
        Service1Client deleteClient = new Service1Client();

        public viewAllCustomer()
        {
            InitializeComponent();
            Loaded += viewAllCustomer_Loaded;
        }

        void viewAllCustomer_Loaded(object sender, RoutedEventArgs e)
        {
            customerList.ItemsSource = deleteClient.viewAllCustomer();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                customerDetailsTB selectedCustomer = (customerDetailsTB)customerList.SelectedItem;
                deleteCustomer newDelete = new deleteCustomer(selectedCustomer.name, selectedCustomer.customerID);
                NavigationService.Navigate(newDelete);

            }

            catch
            {
                MessageBox.Show("Please select record first!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            customerDetailsTB selectedCus = (customerDetailsTB)customerList.SelectedItem;

            //updateCustomerAuto newCustomer = new updateCustomerAuto(selectedCus.name.ToString());

            updateCustomer myCustomer = new updateCustomer(selectedCus.name.ToString());
            this.NavigationService.Navigate(myCustomer);




        }

      
    }
}
