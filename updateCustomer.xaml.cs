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
using System.Windows.Controls.Primitives;

namespace Secrets_Application_2019
{
    /// <summary>
    /// Interaction logic for updateCustomer.xaml
    /// </summary>
    public partial class updateCustomer : Page
    {
        Service1Client updateCli = new Service1Client();

        string name = null;
        
        public updateCustomer(string na)
        {
            name = na;
            Loaded += updateCustomer_Loaded;
            InitializeComponent();
        }

        void updateCustomer_Loaded(object sender, RoutedEventArgs e)
        {
            if (name != null)
            {
                autoUpdate(name);
            }
                       
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            txtSearch.IsEnabled = true;
            btnSearch.IsEnabled = true;

            var dataSet = updateCli.searchCustomer(txtSearch.Text).ToList();

            txtName.Text = dataSet[0].name;
            txtEmail.Text = dataSet[0].email;
            txtTelephone.Text = dataSet[0].telephone.ToString();
            txtAddedDate.Text = dataSet[0].addedDate;

            if (dataSet[0].gender == "Male")
            {
                rdoMale.IsChecked = true;
                rdoFemale.IsChecked = false;
            }
            else
            {
                rdoMale.IsChecked = false;
                rdoFemale.IsChecked = true;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (name != null)
            {
                this.NavigationService.Navigate(new viewAllCustomer());
            }

            else
            {
                this.NavigationService.Navigate(new Banners());
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            txtTelephone.Clear();
            txtSearch.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtAddedDate.Clear();

            rdoFemale.IsChecked = false;
            rdoMale.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string gend="Male";

            if (name != null)
            {
                var selected = updateCli.searchCustomer(name).ToList();

                if (rdoFemale.IsChecked == true)
                {
                    gend = "Female";
                }

                var updateResult = updateCli.updateCustomer(selected[0].customerID, txtName.Text, Int32.Parse(txtTelephone.Text), gend, txtEmail.Text, txtAddedDate.Text);

                if (updateResult)
                {
                    MessageBox.Show("Updated succcessfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error in Update!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else
            {
                var selected = updateCli.searchCustomer(txtSearch.Text).ToList();

                if (rdoFemale.IsChecked == true)
                {
                    gend = "Female";
                }

                var updateResult = updateCli.updateCustomer(selected[0].customerID, txtName.Text, Int32.Parse(txtTelephone.Text), gend, txtEmail.Text, txtAddedDate.Text);

                if (updateResult)
                {
                    MessageBox.Show("Updated succcessfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error in Update!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void autoUpdate(string name)
        {
            txtSearch.IsEnabled = false;
            btnSearch.IsEnabled = false;

            var dataSet = updateCli.searchCustomer(name).ToList();

            txtName.Text= dataSet[0].name;
            txtEmail.Text = dataSet[0].email;
            txtTelephone.Text = dataSet[0].telephone.ToString();
            txtAddedDate.Text = dataSet[0].addedDate;

            if (dataSet[0].gender == "Male")
            {
                rdoMale.IsChecked = true;
                rdoFemale.IsChecked = false;
            }
            else
            {
                rdoMale.IsChecked = false;
                rdoFemale.IsChecked = true;
            }
        }

    }
}
