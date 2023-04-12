using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using static ItoqPraktika.zavodDataSet;
using ItoqPraktika.zavodDataSetTableAdapters;
using System.Text.RegularExpressions;

namespace ItoqPraktika
{
    /// <summary>
    /// Логика взаимодействия для User2.xaml
    /// </summary>
    public partial class User2 : Page
    {
        
        modelTableAdapter mod = new modelTableAdapter();
        public User2()
        {
            InitializeComponent();
            ModelDataGrid.ItemsSource = mod.GetData();
        }
        public object model_id;
        private void ModelDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ModelDataGrid.SelectedItem != null)
            {
                model_id = (ModelDataGrid.SelectedItem as DataRowView).Row[0];
                name_model.Text = (string)(ModelDataGrid.SelectedItem as DataRowView).Row[1];

            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9\s]*$";
            if (Regex.IsMatch(name_model.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте английский.";
            }
            else if (name_model.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                mod.InsertModel(name_model.Text);
                ModelDataGrid.ItemsSource = mod.GetData();
                ErrorText.Text = ""; name_model.Text = "";
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9\s]*$";
            if (Regex.IsMatch(name_model.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте английский.";
            }
            else if (name_model.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                mod.UpdateModel(name_model.Text, Convert.ToInt32(model_id));
                ModelDataGrid.ItemsSource = mod.GetData();
                ErrorText.Text = ""; name_model.Text = "";
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (name_model.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                mod.DeleteModel(Convert.ToInt32(model_id));
                ModelDataGrid.ItemsSource = mod.GetData();
                ErrorText.Text = ""; name_model.Text = "";
            }


        }
    }
}
