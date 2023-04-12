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
    /// Логика взаимодействия для Admin5.xaml
    /// </summary>
    public partial class Admin5 : Page
    {
        countryTableAdapter cou = new countryTableAdapter();
        public Admin5()
        {
            InitializeComponent();
            CountryDataGrid.ItemsSource = cou.GetData();
        }
        public object country_id; 
        private void CountryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CountryDataGrid.SelectedItem != null)
            {
                country_id = (CountryDataGrid.SelectedItem as DataRowView).Row[0];
                Country.Text = (string)(CountryDataGrid.SelectedItem as DataRowView).Row[1];




            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[а-яА-Я\s]*$";
            if (Regex.IsMatch(Country.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте кириллицу.";
            }
            else if (Country.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                cou.InsertCountry(Country.Text);
                CountryDataGrid.ItemsSource = cou.GetData();
                ErrorText.Text = ""; Country.Text = "";
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[а-яА-Я\s]*$";
            if (Regex.IsMatch(Country.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте кириллицу.";
            }
            else if (Country.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                cou.UpdateCountry(Country.Text, Convert.ToInt32(country_id));
                CountryDataGrid.ItemsSource = cou.GetData();
                ErrorText.Text = ""; Country.Text = "";
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Country.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                cou.DeleteCountry(Convert.ToInt32(country_id));
                CountryDataGrid.ItemsSource = cou.GetData();
                ErrorText.Text = ""; Country.Text = "";
            }

        }
    }
}
