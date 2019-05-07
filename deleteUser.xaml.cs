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
    /// Interaction logic for deleteUser.xaml
    /// </summary>
    public partial class deleteUser : Page
    {
        Service1Client client = new Service1Client();

        private string userNam = null;
        private string currentUSER = null;
        public deleteUser(string userName, string user)
        {
            currentUSER = user;
            InitializeComponent();
            userNam = userName;
            Loaded += deleteUser_Loaded;
        }

        void deleteUser_Loaded(object sender, RoutedEventArgs e)
        {
            deleteUserList.ItemsSource = client.searchUser(userNam);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new viewAllUsers(currentUSER));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool dateSet = client.DeleteUser(userNam);

            if (dateSet == true)
            {
                bool output = client.DeleteLogin(userNam);

                if (output)
                {

                    MessageBox.Show("Successfully Deleted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new viewAllUsers(currentUSER));
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

            if (currentUSER == userNam)
            {
                MainWindow mn = new MainWindow();
                mn.Show();
                System.Windows.Application.Current.Shutdown();
                

                // here i need to re direct to the login page ,But in my case entire program is shutting down dueu to shutdown()functhion. neet to solve...
            }

        }
    }
}
