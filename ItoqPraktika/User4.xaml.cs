using ItoqPraktika.zavodDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ItoqPraktika
{
    /// <summary>
    /// Логика взаимодействия для User4.xaml
    /// </summary>
    public partial class User4 : Page
    {
        body_typeTableAdapter bod = new body_typeTableAdapter();
        public User4()
        {
            InitializeComponent();
            BodyDataGrid.ItemsSource = bod.GetData();
        }
        public object body_id;
        private void BodyDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (BodyDataGrid.SelectedItem != null)
            {
                body_id = (BodyDataGrid.SelectedItem as DataRowView).Row[0];
                name_body.Text = (string)(BodyDataGrid.SelectedItem as DataRowView).Row[1];

            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[а-яА-Я\s]*$";
            if (Regex.IsMatch(name_body.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте кирилиццу.";
            }
            else if (name_body.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                bod.InsertBody(name_body.Text);
                BodyDataGrid.ItemsSource = bod.GetData();
                ErrorText.Text = ""; name_body.Text = "";
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[а-яА-Я\s]*$";
            if (Regex.IsMatch(name_body.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте кирилиццу.";
            }
            else if (name_body.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                bod.UpdateBody(name_body.Text, Convert.ToInt32(body_id));
                BodyDataGrid.ItemsSource = bod.GetData();
                ErrorText.Text = ""; name_body.Text = "";
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            if (name_body.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                bod.DeleteBody(Convert.ToInt32(body_id));
                BodyDataGrid.ItemsSource = bod.GetData();
                ErrorText.Text = ""; name_body.Text = "";
            }


        }
    }
}
