using ControlzEx.Standard;
using ItoqPraktika.zavodDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItoqPraktika
{
    /// <summary>
    /// Логика взаимодействия для User3.xaml
    /// </summary>
    public partial class User3 : Page
    {
        manufacturerTableAdapter man = new manufacturerTableAdapter();
        public User3()
        {
            InitializeComponent();
            ManufactureDataGrid.ItemsSource = man.GetData();
        }
        public object manu_id;
        private void ManufactureDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ManufactureDataGrid.SelectedItem != null)
            {
                manu_id = (ManufactureDataGrid.SelectedItem as DataRowView).Row[0];
                name_manufacture.Text = (string)(ManufactureDataGrid.SelectedItem as DataRowView).Row[1];




            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[a-zA-Z\s]*$";
            if (Regex.IsMatch(name_manufacture.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте английский.";
            }
            else if (name_manufacture.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                man.InsertManufacture(name_manufacture.Text);
                ManufactureDataGrid.ItemsSource = man.GetData();
                ErrorText.Text = ""; name_manufacture.Text = "";
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[a-zA-Z\s]*$";
            if (Regex.IsMatch(name_manufacture.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте английский.";
            }
            else if (name_manufacture.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                man.UpdateManufacture(name_manufacture.Text, Convert.ToInt32(manu_id));
                ManufactureDataGrid.ItemsSource = man.GetData();
                ErrorText.Text = ""; name_manufacture.Text = "";
            }


        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (name_manufacture.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                man.DeleteManufacture(Convert.ToInt32(manu_id));
                ManufactureDataGrid.ItemsSource = man.GetData();
                ErrorText.Text = ""; name_manufacture.Text = "";
            }
        }
    }
}
