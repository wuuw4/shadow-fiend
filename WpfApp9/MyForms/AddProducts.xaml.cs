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
    /// Логика взаимодействия для AddProducts.xaml
    /// </summary>
    public partial class AddProducts : Window
    {
        public AddProducts()
        {
            InitializeComponent();

        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBase.MyContext myContext = new DataBase.MyContext();
                DataBase.Product newProduct = new DataBase.Product()

                {
                    Articul = tbArticul.Text,
                    Category = tbCategory.Text,
                    NameProduct = tbNameProduct.Text,
                    Price = Convert.ToDouble(tbPrice.Text),
                    Sale = Convert.ToDouble(tbSale.Text)
                };
                try
                {
                    myContext.products.Add(newProduct);
                    myContext.SaveChanges();
                    MessageBox.Show("Продукт был добавлен");
                }
                catch
                {
                    MessageBox.Show("Продукт не был добавлен");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "уауауауауауауауауауауауауауауау");

            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MyForms.AdminWindow adminWindow = new MyForms.AdminWindow();
            adminWindow.Show();
            Close();
        }
    }
}
