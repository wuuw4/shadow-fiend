using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp9.MyForms
{
    /// <summary>
    /// Логика взаимодействия для ChangeProductWindow.xaml
    /// </summary>
    public partial class ChangeProductWindow : Window
    {
        public string[] category = new string[]
            {
                "First category", "Second category"
            };
        public string[] images = new string[]
            {
                "image1.png", "imahe2.png"
            };
        public ChangeProductWindow()
        {
            InitializeComponent();
            cbCategory.ItemsSource = category;
            cbImage.ItemsSource = images;
        }

        private void btnFoubtArtikul_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                var pr = myContext.products.SingleOrDefault(x => x.Artikul == tbArtikul.Text);
                if (pr != null)
                {
                    tbProductName.Text = pr.ProductName.ToString();
                    tbDescription.Text = pr.Description.ToString();
                    tbManufacture.Text = pr.Manufacture.ToString();
                    tbPrice.Text = pr.Price.ToString();
                    tbSale.Text = pr.Sale.ToString();
                    tbcategory.Text = pr.Category.ToString();
                    tbImage.Text = pr.ImagePath.ToString();
                    var unitOnStorage = myContext.storages.Where(x => x.ProductId == pr.ProductID);
                    int count = 0;
                    if (unitOnStorage.Count() > 0)
                    {
                        tbUnitOnStorage.Text = unitOnStorage.Sum(x => x.Count).ToString(); ;
                    }
                    else { MessageBox.Show("Product wasnt deliver on storage"); }
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        private void btnAddNewCount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                var pr = myContext.products.SingleOrDefault(x => x.Artikul == tbArtikul.Text);
                if (pr != null)
                {
                    var delivery = new DB.Storage();
                    delivery.ProductId = pr.ProductID;
                    delivery.Count = Convert.ToInt32(tbNewCount.Text);
                    myContext.storages.Add(delivery);
                    myContext.SaveChanges();
                    MessageBox.Show("product add to storage");
                }
                else { MessageBox.Show("product want add to starage"); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void btnSaveChanged_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                var pr = myContext.products.SingleOrDefault(x => x.Artikul == tbArtikul.Text);
                if (pr != null)
                {
                    if (Convert.ToDouble(tbSale.Text) > 0.5) //pr.maxSale from table
                    {
                        MessageBox.Show("Sale cant be more 0.5");
                        return;
                    }
                    pr.ProductName = tbProductName.Text;
                    pr.Manufacture = tbManufacture.Text;
                    pr.Description = tbDescription.Text;
                    pr.Price = Convert.ToDouble(tbPrice.Text);
                    pr.Sale = Convert.ToDouble(tbSale.Text);

                    if (tbImage.Text != null)
                    {
                        pr.Category = cbCategory.ItemsSource.ToString();

                    }
                    if (tbImage.Text != null)
                    {
                        pr.ImagePath = cbImage.ItemsSource.ToString();
                    }
                    myContext.products.Update(pr);
                    myContext.SaveChanges();
                    MessageBox.Show("Product was update");
                }
                else
                { MessageBox.Show("not found"); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.MyContext myContext = new DB.MyContext();
                var pr = myContext.products.SingleOrDefault(x => x.Artikul == tbArtikul.Text);
                if (pr != null)
                {
                    myContext.products.Remove(pr);
                    myContext.SaveChanges();
                    MessageBox.Show("product was deleted");
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

            private void btnExit_Click(object sender, RoutedEventArgs e)
            {

                 try
                 {
                    DB.MyContext myContext = new DB.MyContext();
                    var pr = myContext.products.SingleOrDefault(x => x.Artikul == tbArtikul.Text);
                    if (pr != null)
                    {
                    myContext.products.Remove(pr);
                    myContext.SaveChanges();
                    }
                 }
                 catch (Exception ex)
                 {
                MessageBox.Show(ex.Message);
                 }
            }
        
    }
}
