using ControlzEx.Standard;
using ItoqPraktika.zavodDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
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
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace ItoqPraktika
{
    /// <summary>
    /// Логика взаимодействия для Admin1.xaml
    /// </summary>
    public partial class Admin1 : Page
    {
        workersTableAdapter work = new workersTableAdapter();

        roleTableAdapter rol = new roleTableAdapter();
        public Admin1()
        {
            InitializeComponent();
            WorkersDataGrid.ItemsSource = work.GetData();
            RoleBox.ItemsSource = rol.GetData();
            RoleBox.DisplayMemberPath = "name_role";
        }
        public object work_id;
       
        public object depar;
        public object roll;
       

     

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var stringNumber = Salary.Text;
            bool isNumber = int.TryParse(stringNumber, out int numericValue);
            string pattern = @"^[а-яЁёА-Я\s]*$";
            if (Regex.IsMatch(Surname.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте кириллицу.";
            }

            else if (Regex.IsMatch(Name.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте кириллицу.";
            }
            else if (Regex.IsMatch(Middle.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте кириллицу.";
            }
            
            else if ( Surname.Text == "" | Name.Text == ""
                | Middle.Text == "" | Salary.Text == "" | RoleBox.SelectedItem == null)
            {
                ErrorText.Text = "Не все поля заполнены!";
            }
            else if (isNumber != true)
            {
                ErrorText.Text = "В строке с зарплатой только целочисленные значения!";
            }
            else if (isNumber == true && numericValue < 0)
            {
                ErrorText.Text = "Зарплата не может быть отрицательной!";
            }
            else
            {
                work.addWorkers(Surname.Text, Name.Text, Middle.Text, numericValue, Convert.ToInt32(roll));
                WorkersDataGrid.ItemsSource = work.GetData();
                Surname.Text = ""; Name.Text = ""; Middle.Text = ""; Salary.Text = "";  RoleBox.Text = ""; ErrorText.Text = "";
            }
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var stringNumber = Salary.Text;
            bool isNumber = int.TryParse(stringNumber, out int numericValue);
            string pattern = @"^[а-яёЁА-Я\s]*$";
            if (Regex.IsMatch(Surname.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте кириллицу.";
            }
            
            else if (Regex.IsMatch(Name.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте кириллицу.";
            }
            else if (Regex.IsMatch(Middle.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте кириллицу.";
            }
           
            else if (  Surname.Text == "" | Name.Text == ""
                | Middle.Text == "" | Salary.Text == "" | RoleBox.SelectedItem == null)
            {
                ErrorText.Text = "Не все поля заполнены!";
            }
            else if (isNumber != true)
            {
                ErrorText.Text = "В строке с зарплатой только целочисленные значения!";
            }
            else if (isNumber == true && numericValue < 0)
            {
                ErrorText.Text = "Зарплата не может быть отрицательной!";
            }
            else
            {
                work.updateWorkers(Surname.Text, Name.Text, Middle.Text, numericValue, Convert.ToInt32(roll), Convert.ToInt32(work_id));
                WorkersDataGrid.ItemsSource = work.GetData();
                Surname.Text = ""; Name.Text = ""; Middle.Text = ""; Salary.Text = "";  RoleBox.Text = "";  ErrorText.Text = "";
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            work.DeleteWorkers(Convert.ToInt32(work_id));
            WorkersDataGrid.ItemsSource = work.GetData();
            Surname.Text = ""; Name.Text = ""; Middle.Text = ""; Salary.Text = "";  RoleBox.Text = ""; ErrorText.Text = "";

        }

        private void WorkersDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (WorkersDataGrid.SelectedItem != null)
            {
                work_id = (WorkersDataGrid.SelectedItem as DataRowView).Row[0];
                Surname.Text = (string)(WorkersDataGrid.SelectedItem as DataRowView).Row[1];
                Name.Text = (string)(WorkersDataGrid.SelectedItem as DataRowView).Row[2];
                Middle.Text = (string)(WorkersDataGrid.SelectedItem as DataRowView).Row[3];
                Salary.Text = Convert.ToString((WorkersDataGrid.SelectedItem as DataRowView).Row[4]);

                int roleID = Convert.ToInt32((WorkersDataGrid.SelectedItem as DataRowView).Row[5]);
                var allRoles = rol.GetData().Rows;
                for (int i = 0; i < allRoles.Count; i++)
                {
                    if (Convert.ToInt32(allRoles[i][0]) == roleID)
                    {
                        RoleBox.Text = allRoles[i][1].ToString();
                    }
                }

            }
        }

        private void RoleBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (RoleBox.SelectedItem!= null)
            {
                roll = (RoleBox.SelectedItem as DataRowView).Row[0];
            }
            
        }
    }
}

    
