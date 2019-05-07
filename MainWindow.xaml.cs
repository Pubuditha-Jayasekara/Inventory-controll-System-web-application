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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Service1Client loginClient = new Service1Client();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtUserName.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Home newHome = new Home(txtUserName.Text.ToString());
            newHome.Show();
            this.Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {


            bool result = loginClient.checkUser(txtUserName.Text.ToString(), txtPassword.Password.ToString());

            if (result == true)
            {
                this.Hide();
                Home homeWindow = new Home(txtUserName.Text.ToString());
                homeWindow.Show();
                this.Close();  
            }
            else
            {
                MessageBox.Show("Incorrect Username and Password !", "Invaid", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUserName.Clear();
                txtPassword.Clear();
                txtUserName.Focus();
            }
        }


    }
}
