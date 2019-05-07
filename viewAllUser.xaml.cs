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
    /// Interaction logic for viewAllUsers.xaml
    /// </summary>
    public partial class viewAllUsers : Page
    {
        Service1Client client = new Service1Client();
        private string currentUS;
        public viewAllUsers(string currentUser)
        {
            currentUS = currentUser;
            InitializeComponent();
            Loaded += viewAllUsers_Loaded;
        }

        void viewAllUsers_Loaded(object sender, RoutedEventArgs e)
        {
            userList.ItemsSource = client.viewAllUser();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                userDetailsTB selectedUser = (userDetailsTB)userList.SelectedItem;
                deleteUser deleteUser = new deleteUser(selectedUser.userName,currentUS);

                this.NavigationService.Navigate(deleteUser);
            }
            catch
            {
                MessageBox.Show("Please select record first!","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
            userDetailsTB selectedUser = (userDetailsTB)userList.SelectedItem;
            updateUser newUserUpdate = new updateUser(selectedUser.userName,currentUS);
            this.NavigationService.Navigate(newUserUpdate);

        }
         catch
            {
                MessageBox.Show("Please select record first!","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }
    }
}
