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
    /// Interaction logic for deleteCustomer.xaml
    /// </summary>
    public partial class deleteCustomer : Page
    {
        Service1Client cust = new Service1Client();

        private string custName;
        private int custId;

        public deleteCustomer(string name,int id)
        {

            custId = id;
            custName = name;

            Loaded += deleteCustomer_Loaded;

            InitializeComponent();
        }

        void deleteCustomer_Loaded(object sender, RoutedEventArgs e)
        {
            deletingcustomerList.ItemsSource = cust.searchCustomer(custName);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new viewAllCustomer());

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool dateSet = cust.DeleteCustomer(custId);

            if (dateSet == true)
            {
               MessageBox.Show("Successfully Deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
               NavigationService.Navigate(new viewAllCustomer());
            }
            else
            {
                MessageBox.Show("Can not delete!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        }
    
}
