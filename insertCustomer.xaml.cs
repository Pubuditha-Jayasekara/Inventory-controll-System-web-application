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
    /// Interaction logic for insertCustomer.xaml
    /// </summary>
    public partial class insertCustomer : Page
    {
        Service1Client insertCus = new Service1Client();

        public insertCustomer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           this.NavigationService.Navigate(new Banners());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtAddedDate.Clear();
            txtEmail.Clear();
            txtName.Clear();
            txtTelephone.Clear();
            
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string gend="Male";

            if(rdoFemale.IsChecked==true){
                 gend="Female";
            }

            bool res = insertCus.insertCustomer(txtName.Text.ToString(), Int32.Parse(txtTelephone.Text.ToString()), txtEmail.Text.ToString(), gend.ToString(), txtAddedDate.Text.ToString());

            if (res)
            {
                MessageBox.Show("Successfully Inserted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Successfully Inserted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
      
            }

        }
    }
}
