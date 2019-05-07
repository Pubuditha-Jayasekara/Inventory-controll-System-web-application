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
    /// Interaction logic for insertItem.xaml
    /// </summary>
    public partial class insertItem : Page
    {
        Service1Client itemCli = new Service1Client();

        public insertItem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image jpeg(*.jpg)|*.jpg|Image png(*.png)|*.png";
            ofd.DefaultExt = ".jpeg";

            // Process open file dialog box results 
            if (ofd.ShowDialog() == true)
            {
                ItemImage.Source = new BitmapImage(new Uri(ofd.FileName));

               // MessageBox.Show(" " + ofd.FileName);

               lblImage.Content = ofd.FileName;

            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtAddedDate.Clear();
            txtCategory.Clear();
            txtDescription.Clear();
            txtName.Clear();
            txtPurchesdPrice.Clear();
            txtQty.Clear();
            txtSellingPrice.Clear();
            txtSize.Clear();
            lblImage.Content = "";
            availability.Items.Clear();

            ItemImage.Source = null;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            bool available = false;

            if (availability.SelectedIndex>-1)
            {
               // MessageBox.Show(availability.SelectedItem.ToString());

                string[] seperatorResult = availability.SelectedItem.ToString().Split(':');

                MessageBox.Show(seperatorResult[1].ToString());

                if (seperatorResult[1].ToString() == " Available")//this condiiton is not working
                {
                     available = true;
                    // MessageBox.Show(available.ToString());
                }
                else
                {
                    available = false;
                }

                bool output = itemCli.insertItem(txtName.Text, txtCategory.Text, Int32.Parse(txtPurchesdPrice.Text.ToString()), Int32.Parse(txtSellingPrice.Text.ToString()), lblImage.Content.ToString(), available, txtAddedDate.Text.ToString(), txtDescription.Text.ToString(), txtSize.Text.ToString(), Int32.Parse(txtQty.Text.ToString()));

               // MessageBox.Show(available.ToString());

                if (output)
                {
                    MessageBox.Show("Item Added Successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Item can not add", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        
        else{

            MessageBox.Show("Please select Availability", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
         }            
    }
}
}

    

