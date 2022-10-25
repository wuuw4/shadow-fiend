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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnVvod_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == "ya krutoy" && tbPassword.Password == "123")
            {
                MyForms.AdminWindow adminWindow = new MyForms.AdminWindow();
                adminWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("иди нахуй просто написал");

            }
        }

        private void btnVvodGuest_Click(object sender, RoutedEventArgs e)
        {
            MyForms.GuestWindow guestWindow = new MyForms.GuestWindow();
            guestWindow.Show();
            Close();
        }

    }
}
