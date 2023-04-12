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
    /// Логика взаимодействия для Admin2.xaml
    /// </summary>
    public partial class Admin2 : Page
    {
        

        roleTableAdapter rol = new roleTableAdapter();
        public Admin2()
        {
            InitializeComponent();
            InitializeComponent();
            RolesDataGrid.ItemsSource = rol.GetData();

        }



        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[a-zA-Z\s]*$";
            if (Regex.IsMatch(Role.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте английский.";
            }
            else if (Role.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                rol.InsertRole(Role.Text);
                RolesDataGrid.ItemsSource = rol.GetData();
                ErrorText.Text = ""; Role.Text = "";
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[a-zA-Z\s]*$";
            if (Regex.IsMatch(Role.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте английский.";
            }
            else if (Role.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                rol.UpdateRole(Role.Text, Convert.ToInt32(role_id));
                RolesDataGrid.ItemsSource = rol.GetData();
                ErrorText.Text = ""; Role.Text = "";
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Role.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                rol.DeleteRole(Convert.ToInt32(role_id));
                RolesDataGrid.ItemsSource = rol.GetData();
                ErrorText.Text = ""; Role.Text = "";
            }

        }
        public object role_id;

        private void RolesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RolesDataGrid.SelectedItem != null) {
                role_id = (RolesDataGrid.SelectedItem as DataRowView).Row[0];
                Role.Text = (string)(RolesDataGrid.SelectedItem as DataRowView).Row[1   ];




            }

        }
    }
}
