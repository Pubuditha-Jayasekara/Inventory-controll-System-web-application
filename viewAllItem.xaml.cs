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
    /// Interaction logic for viewAllItem.xaml
    /// </summary>
    public partial class viewAllItem : Page
    {

        Service1Client deleteClient = new Service1Client();
       
        public viewAllItem()
        {
            InitializeComponent();
            Loaded += viewAllItem_Loaded;
        }

        void viewAllItem_Loaded(object sender, RoutedEventArgs e)
        {
            deleteList.ItemsSource = deleteClient.viewAllItem();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                itemDetailsTB selectedItem = (itemDetailsTB)deleteList.SelectedItem;
                deleteItem deleteItem = new deleteItem(selectedItem.Name, selectedItem.ItemID);
                this.NavigationService.Navigate(deleteItem);

               // MessageBox.Show(selectedItem.ItemID.ToString());
            }
            catch
            {
                MessageBox.Show("Please select record first!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                itemDetailsTB selectedItem = (itemDetailsTB)deleteList.SelectedItem;
                updateItem newUpdate = new updateItem(selectedItem.Name);
                this.NavigationService.Navigate(newUpdate);
            }
            catch
            {
                MessageBox.Show("Please select record first!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
