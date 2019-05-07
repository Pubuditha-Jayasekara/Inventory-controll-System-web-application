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
    /// Interaction logic for searchItem.xaml
    /// </summary>
    public partial class searchItem : Page
    {
        Service1Client deleteCli = new Service1Client();

        public searchItem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //deleteCli.DeleteItem();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var res = deleteCli.searchItem(txtSerch.Text);

            if (res != null)
            {

                searchItemList.ItemsSource = deleteCli.searchUser(txtSerch.Text);
            }

            else
            {
                MessageBox.Show("NO Item called " + txtSerch.Text + " !", "Massage", MessageBoxButton.OK, MessageBoxImage.Information);
                txtSerch.Clear();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var res = deleteCli.searchItem(txtSerch.Text.ToString());
            if (res != null)
            {

                searchItemList.ItemsSource = res;
            }

            else
            {
                MessageBox.Show("Item not found!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Banners());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var resItem = deleteCli.searchItem(txtSerch.Text);

            if (resItem != null)
            {
                // DialogResult result=MessageBox.Show("Are you sure to delete?", "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
              
                var mssage=MessageBox.Show("Are you sure to delete?", "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
                //MessageBox.Show(mssage.ToString());
                //MessageBox.Show(mssage.ToString());

                if (mssage.ToString()=="Yes")
                {

                   // MessageBox.Show("Stop here it works!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    bool result = deleteCli.DeleteItem(resItem[0].ItemID);

                    if (result)
                    {
                        MessageBox.Show("Successfully deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        searchItemList.ItemsSource = null;
                    }
                    else
                    {
                        MessageBox.Show("Can Not deleted!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("NO item to delete!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //itemDetailsTB selectedItem = (itemDetailsTB)deleteList.SelectedItem;
            var res = deleteCli.searchItem(txtSerch.Text).ToList();

            updateItem newUpdate = new updateItem(res[0].Name);
            this.NavigationService.Navigate(newUpdate);
        }
    }
}
