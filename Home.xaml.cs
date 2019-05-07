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
using System.Windows.Shapes;
using Secrets_Application_2019.secretsWebServiceReference;

namespace Secrets_Application_2019
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        Service1Client client = new Service1Client();

       private string us = null;

        public Home(string username)
        {

            us = username;
            InitializeComponent();
            Loaded += Home_Loaded;
                 
        }

        void Home_Loaded(object sender, RoutedEventArgs e)
        {
            var userData=client.searchUser(us);

            employee.Text = userData[0].employeeName;
            userName.Text = userData[0].userName;
            id.Text = userData[0].userID.ToString();
            branch.Text = userData[0].branch;

            //userImage.Source = userData[0].image;
            if (userData[0].image!=null)
            {
               //userImage.Source = new BitmapImage(new Uri(userData[0].image.ToString(), UriKind.Relative));
               // userImage.Resources = new BitmapImage(new Uri(userData[0].image.ToString(), UriKind.Relative));
               // imageList.ItemsSource = userData[0].image;

                var myImage = new BitmapImage(new Uri(userData[0].image.ToString()));
                var imageControl = new Image();
                imageControl.Source = myImage;
                contenetRoot.Children.Add(imageControl);

              // MessageBox.Show(userData[0].image.ToString());
               
            }

            homeFrame.Content = new Banners();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           viewAllUsers user= new viewAllUsers(us);
           homeFrame.Content = user;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                // Do not close the window  
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            viewAllItem item = new viewAllItem();
            homeFrame.Content = item;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            viewAllCustomer cust = new viewAllCustomer();
            homeFrame.Content = cust;

        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {

            searchUser user = new searchUser(us);
            homeFrame.Content = user;

        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            insertUser newUser = new insertUser();
            homeFrame.Content = newUser;
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            searchUser user = new searchUser(us);
            homeFrame.Content = user;
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            insertItem item = new insertItem();
            homeFrame.Content = item;
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            searchItem serItem = new searchItem();
            homeFrame.Content = serItem;
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            searchItem serItem = new searchItem();
            homeFrame.Content = serItem;
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            insertCustomer newCustomer = new insertCustomer();
            homeFrame.Content = newCustomer;

        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            SearchCustomer newCustomer =new SearchCustomer();
            homeFrame.Content = newCustomer;
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            SearchCustomer newCustomer = new SearchCustomer();
            homeFrame.Content = newCustomer;
        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            updateCustomer newUpdate = new updateCustomer(null);
            homeFrame.Content = newUpdate;
        }

        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {
            updateUser newUpdate = new updateUser(null, us);
            homeFrame.Content = newUpdate;
        }

        private void MenuItem_Click_15(object sender, RoutedEventArgs e)
        {
            helpBanner newHelp = new helpBanner();
            homeFrame.Content = newHelp;
        }

        private void MenuItem_Click_16(object sender, RoutedEventArgs e)
        {
            updateItem newUpdateItem = new updateItem(null);
            homeFrame.Content = newUpdateItem;
        }

        private void MenuItem_Click_17(object sender, RoutedEventArgs e)
        {
            out_of_stock newout = new out_of_stock();
            newout.Show();
        }

        private void MenuItem_Click_18(object sender, RoutedEventArgs e)
        {
            var userData=client.searchUser(us);

            var invo=client.findLastBill();

           // MessageBox.Show(invo.ToString());

            Invoice newInvoice = new Invoice(userData[0].employeeName, userData[0].branch, invo);
            homeFrame.Content = newInvoice;
          
        }

        private void MenuItem_Click_19(object sender, RoutedEventArgs e)
        {
            searchInvoice ewinv = new searchInvoice();
            homeFrame.Content =  ewinv;
        }

        private void MenuItem_Click_20(object sender, RoutedEventArgs e)
        {
            DailySalse sale = new DailySalse();
            //meFrame.Content = sale;
            sale.Show();
        }

        private void MenuItem_Click_21(object sender, RoutedEventArgs e)
        {
            InStockReport newrep = new InStockReport();
            newrep.Show();
        }

        private void MenuItem_Click_22(object sender, RoutedEventArgs e)
        {
            CustomerReport newcus = new CustomerReport();
            newcus.Show();
        }

    }
}
