using ItoqPraktika.zavodDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using static ItoqPraktika.zavodDataSet;

namespace ItoqPraktika
{
    /// <summary>
    /// Логика взаимодействия для Admin3.xaml
    /// </summary>
    public partial class Admin3 : Page
    {
        workersTableAdapter work = new workersTableAdapter();
        authTableAdapter aut = new authTableAdapter();
        public Admin3()
        {
            InitializeComponent();
            AuthDataGrid.ItemsSource = aut.GetData();
            AuthBox.ItemsSource = work.GetData();
            AuthBox.DisplayMemberPath = "surname";
        }
        public object workk;

        private void AuthBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AuthBox.SelectedItem != null)
            {
                workk = (AuthBox.SelectedItem as DataRowView).Row[0];
            }


        }
        public object auth_id;
        private void AuthDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (AuthDataGrid.SelectedItem != null)
            {
                auth_id = (AuthDataGrid.SelectedItem as DataRowView).Row[0];
                Login.Text = (string)(AuthDataGrid.SelectedItem as DataRowView).Row[1];
                Password.Password = (string)(AuthDataGrid.SelectedItem as DataRowView).Row[2];


                int workID = Convert.ToInt32((AuthDataGrid.SelectedItem as DataRowView).Row[3]);
                var allworke = work.GetData().Rows;
                for (int i = 0; i < allworke.Count; i++)
                {
                    if (Convert.ToInt32(allworke[i][0]) == workID)
                    {
                        AuthBox.Text = allworke[i][1].ToString();
                    }
                }

            }


        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9]*$";
            string pattern2 = @"^[a-zA-Z0-9\D]*$";
            if (Regex.IsMatch(Login.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте английский.";
            }
            else if (Regex.IsMatch(Login.Text, pattern2, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте английский и специальные знаки.";
            }

            
            else if (Login.Text == "" | Password.Password == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            
            else
            {
                aut.InsertAuth(Login.Text, Password.Password, Convert.ToInt32(workk));
                AuthDataGrid.ItemsSource = aut.GetData();
                ErrorText.Text = ""; Login.Text = ""; Password.Password = "";
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9]*$";
            string pattern2 = @"^[a-zA-Z0-9\D]*$";
            if (Regex.IsMatch(Login.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте английский.";
            }
            else if (Regex.IsMatch(Login.Text, pattern2, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте английский и специальные знаки.";
            }


            else if (Login.Text == "" | Password.Password == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }

            else
            {
                aut.UpdateAuth(Login.Text, Password.Password, Convert.ToInt32(workk), Convert.ToInt32(auth_id));
                AuthDataGrid.ItemsSource = aut.GetData();
                ErrorText.Text = ""; Login.Text = ""; Password.Password = "";
            }


        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text == "" | Password.Password == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }

            else
            {
                aut.DeleteAuth(Convert.ToInt32(auth_id));
                AuthDataGrid.ItemsSource = aut.GetData();
                ErrorText.Text = ""; Login.Text = ""; Password.Password = "";
            }

        }

      
    }
}
