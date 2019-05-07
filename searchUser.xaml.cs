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
    /// Interaction logic for searchUser.xaml
    /// </summary>
    public partial class searchUser : Page
    {
        Service1Client searchCl = new Service1Client();
       // private string usName = null;
        private string currentUser = null;

        public searchUser(string cus)
        {

           // usName = mainuser;
            currentUser = cus;
            InitializeComponent();
            Loaded += searchUser_Loaded;
        }

        void searchUser_Loaded(object sender, RoutedEventArgs e)
        {
            txtSerch.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Banners());

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                var res = searchCl.searchUser(txtSerch.Text);

                if (res!=null)
                {
                    searchUserList.ItemsSource = searchCl.searchUser(txtSerch.Text);
                }

                else
                {
                    MessageBox.Show("NO user called " + txtSerch.Text + " !", "Massage", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtSerch.Clear();
                }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var result = searchCl.searchUser(txtSerch.Text);

            bool dateSet = searchCl.DeleteUser(result[0].userName);

            if (dateSet == true)
            {
                bool output = searchCl.DeleteLogin(result[0].userName);

                if (output)
                {

                    MessageBox.Show("Successfully Deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    //NavigationService.Navigate(new viewAllUsers(currentUSER));
                    txtSerch.Clear();
                    txtSerch.Focus();

                    searchUserList.ItemsSource = null;
                   

                    if (currentUser == result[0].userName)
                    {
                        MainWindow mn = new MainWindow();
                        mn.Show();
                        System.Windows.Application.Current.Shutdown();

                        // here i need to re direct to the login page ,But in my case entire program is shutting down dueu to shutdown()functhion. neet to solve...
                    }
                }
                else
                {
                    MessageBox.Show("Successfully Deleted from user TB! error in Login!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Can not delete!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

           
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var res = searchCl.searchUser(txtSerch.Text).ToList();

            updateUser newUpdate = new updateUser(res[0].userName,currentUser);
            this.NavigationService.Navigate(newUpdate);
        }


    }
}
