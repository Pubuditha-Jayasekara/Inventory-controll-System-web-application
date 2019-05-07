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
using Microsoft.Win32;
using Secrets_Application_2019.secretsWebServiceReference;

namespace Secrets_Application_2019
{
    /// <summary>
    /// Interaction logic for insertUser.xaml
    /// </summary>
    public partial class insertUser : Page
    {
        Service1Client cl = new Service1Client();

        public insertUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtBranch.Clear();
            txtconfirmpassword.Clear();
            txtEmployeeName.Clear();
            txtId.Clear();
            txtImage.Clear();
            txtName.Clear();
            txtpassword.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Banners());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            bool res=cl.insertUser(txtName.Text,txtEmployeeName.Text,txtBranch.Text,txtImage.Text);

            var res2 = cl.searchUser(txtName.Text);

            if (res2.Any())
            {
                string paasingValName = res2[0].userName;
                int paasingValId = res2[0].userID;

                if (txtpassword.Password == txtconfirmpassword.Password)
                {
                    bool res3 = cl.insertLogin(paasingValId, paasingValName, txtpassword.Password.ToString());

                    if (res == true && res3 == true)
                    {
                        MessageBox.Show("Added user Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        Button_Click_1(sender,e);
                    }
                }
                else
                {
                    MessageBox.Show("Passsword does not match!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtconfirmpassword.Clear();
                    txtpassword.Clear();
                }
               
            }

            else {

                MessageBox.Show("Error in Login Table!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            

           
        }
    }
}
