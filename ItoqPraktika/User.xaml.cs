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

namespace ItoqPraktika
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
            PageFrame.Content = new User1();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new User1();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new User2();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new User3();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new User4();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new User5();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new User6();

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new User7();
        }
    }
}
