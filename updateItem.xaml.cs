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

namespace Secrets_Application_2019
{
    /// <summary>
    /// Interaction logic for updateItem.xaml
    /// </summary>
    public partial class updateItem : Page
    {
        Service1Client myCLI = new Service1Client();

        String itemName = null;
        public updateItem(string iN)
        {
            itemName = iN;
            Loaded += updateItem_Loaded;
            InitializeComponent();
        }

        void updateItem_Loaded(object sender, RoutedEventArgs e)
        {
            if (itemName != null)
            {
                txtName.Focus();//auto
                var res=myCLI.searchItem(itemName).ToList();
                autoLoad(res[0].Name);
            }
            else
            {
                txtSerch.Focus();//manual
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
            txtSerch.Clear();
            txtSize.Clear();
            txtName.Focus();
            lblImgPath.Content = null;
           // ItemImage.Source = new BitmapImage(new Uri(null, UriKind.Relative));
           // ItemImage.Source = (new ImageSourceConverter()).ConvertFromString(null) as ImageSource;
            //lblImage.Content = null;
            //ItemImage.Source = (new ImageSourceConverter()).ConvertFromString(lblImage.Content.ToString()) as ImageSource;
            ItemImage.Source = null;
        }

        private void autoLoad(string Itname)
        {
            var res2 = myCLI.searchItem(itemName).ToList();

           // lblImgPath.Visibility = false;

            txtAddedDate.Text = res2[0].addedDate;
            txtCategory.Text = res2[0].Category;
            txtDescription.Text = res2[0].description;
            txtName.Text = res2[0].Name;
            txtPurchesdPrice.Text = res2[0].purchesdPrice.ToString();
            txtQty.Text = res2[0].qty.ToString();
            txtSellingPrice.Text = res2[0].sellingPrice.ToString();
            txtSerch.IsEnabled = false;
            btnSerch.IsEnabled = false;
            txtSize.Text = res2[0].size;
            //ItemImage.Source=new BitmapImage(new Uri(res2[0].image.ToString(),UriKind.Relative));

            if (res2[0].image.Length>1)
            {
               // MessageBox.Show(res2[0].image.Length.ToString());
                lblImgPath.Content = res2[0].image.ToString();

                ItemImage.Source = (new ImageSourceConverter()).ConvertFromString(lblImgPath.Content.ToString()) as ImageSource;
            }

            if (res2[0].availability==true)
            {
                availability.SelectedIndex = 0;
            }
            else
            {
                availability.SelectedIndex = 1;
            }

            txtName.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //image picker

            var ofd = new OpenFileDialog();
            ofd.Filter = "Image jpeg(*.jpg)|*.jpg|Image png(*.png)|*.png";
            ofd.DefaultExt = ".jpeg";

            // Process open file dialog box results 
            if (ofd.ShowDialog() == true)
            {
                ItemImage.Source = new BitmapImage(new Uri(ofd.FileName));

                //MessageBox.Show(" " + ofd.FileName);

                lblImage.Content = ofd.FileName;

            }
        }

        private void goHome_Click(object sender, RoutedEventArgs e)
        {
            if (itemName != null)
            {
                this.NavigationService.Navigate(new viewAllItem());
            }
            else
            {
                this.NavigationService.Navigate(new Banners());
            }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (availability.SelectedValue != null)
                {
                    string[] ava = availability.SelectedValue.ToString().Split(':');
                    //MessageBox.Show(availability.SelectedValue.ToString());

                    var res3 = myCLI.searchItem(itemName).ToList();
                    bool stAvala = false;

                    if (ava[1].ToString() == " Available")
                    {
                        stAvala = true;
                    }

                    bool res = myCLI.updateItem(res3[0].ItemID, txtName.Text, txtCategory.Text, Int32.Parse(txtPurchesdPrice.Text), Int32.Parse(txtSellingPrice.Text), lblImgPath.Content.ToString(), stAvala, txtAddedDate.Text, txtDescription.Text, txtSize.Text, Int32.Parse(txtQty.Text));

                    if (res)
                    {
                        MessageBox.Show("Item Updated Successfuly!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error in Update!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Check Availability!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Select Item first!","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }
    }
}
