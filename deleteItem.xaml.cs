﻿using System;
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
    /// Interaction logic for deleteItem.xaml
    /// </summary>
    public partial class deleteItem : Page
    {
        Service1Client deleteclient = new Service1Client();

        private string itemName = null;
        private int itemID = 0;

        public deleteItem(string name,int itID)
        {

            itemName = name;
            itemID = itID;
            Loaded += deleteItem_Loaded;
            InitializeComponent();
        }

        void deleteItem_Loaded(object sender, RoutedEventArgs e)
        {
            deletingItemList.ItemsSource = deleteclient.searchItem(itemName);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new viewAllItem());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool dateSet = deleteclient.DeleteItem(itemID);

            if (dateSet == true)
            {
                MessageBox.Show("Successfully Deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new viewAllItem());
            }
            else
            {
                MessageBox.Show("Can not delete!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
