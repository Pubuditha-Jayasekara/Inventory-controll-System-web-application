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
using Microsoft.Win32;
using System.Windows.Resources;

namespace Secrets_Application_2019
{
    /// <summary>
    /// Interaction logic for updateUser.xaml
    /// </summary>
    public partial class updateUser : Page
    {
        Service1Client mycli=new Service1Client();
        string passingVal = null;
        string currentUser = null;

        public updateUser(string ps,string cu)
        {
            passingVal = ps;
            currentUser = cu;
            Loaded += updateUser_Loaded;
            InitializeComponent();
        }

        void updateUser_Loaded(object sender, RoutedEventArgs e)
        {
            if (passingVal != null)
            {
                txtSearch.IsEnabled = false;
                btnSearch.IsEnabled = false;

                autoLoad(passingVal);
            }
            else
            {
                txtSearch.IsEnabled = true;
                btnSearch.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtBranch.Clear();
            txtconfirmpassword.Clear();
            txtEmployeeName.Clear();
            txtId.Clear();
            txtImage.Clear();
            txtName.Clear();
            txtpassword.Clear();
            userIMage.Source = null;

           txtName.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                var res = mycli.updateUser(Int32.Parse(txtId.Text), txtName.Text, txtEmployeeName.Text, txtBranch.Text, txtImage.Text, txtpassword.Password);

                if (res)
                {
                    MessageBox.Show("Successfully updated!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                {
                    MessageBox.Show("Error in update!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }

            catch
            {
                MessageBox.Show("No user selected!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }


        private void autoLoad(string nameUS)
        {
            var searched = mycli.searchUser(nameUS).ToList();

            txtBranch.Text = searched[0].branch;
            txtEmployeeName.Text = searched[0].employeeName;
            txtId.Text = searched[0].userID.ToString();
            txtImage.Text = searched[0].image;
            txtName.Text = searched[0].userName;

            var searchedLOgin = mycli.searchLogin(Int32.Parse(txtId.Text));

            txtpassword.Password = searchedLOgin[0].password;
            txtconfirmpassword.Password= searchedLOgin[0].password;

           // userIMage.Source = new BitmapImage(new Uri(searched[0].image.ToString(), UriKind.Relative));

            //Image image = new Image();
            userIMage.Source = (new ImageSourceConverter()).ConvertFromString(searched[0].image.ToString()) as ImageSource;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (passingVal != null)
            {
                this.NavigationService.Navigate(new viewAllUsers(currentUser));
            }
            else
            {
                this.NavigationService.Navigate(new Banners());
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //image picker

            var ofd = new OpenFileDialog();
            ofd.Filter = "Image jpeg(*.jpg)|*.jpg|Image png(*.png)|*.png";
            ofd.DefaultExt = ".jpeg";

            // Process open file dialog box results 
            if (ofd.ShowDialog() == true)
            {
                userIMage.Source = new BitmapImage(new Uri(ofd.FileName));

                //MessageBox.Show(" " + ofd.FileName);

                txtImage.Text = ofd.FileName;

            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searched = mycli.searchUser(txtSearch.Text).ToList();

            txtBranch.Text = searched[0].branch;
            txtEmployeeName.Text = searched[0].employeeName;
            txtId.Text = searched[0].userID.ToString();
            txtImage.Text = searched[0].image;
            txtName.Text = searched[0].userName;

            var searchedLOgin = mycli.searchLogin(Int32.Parse(txtId.Text));

            txtpassword.Password = searchedLOgin[0].password;
            txtconfirmpassword.Password = searchedLOgin[0].password;

           // userIMage.Source = new BitmapImage(new Uri(searched[0].image.ToString(), UriKind.Relative));

            //Image image = new Image();
            userIMage.Source = (new ImageSourceConverter()).ConvertFromString(searched[0].image.ToString()) as ImageSource;
        }
    }
}
