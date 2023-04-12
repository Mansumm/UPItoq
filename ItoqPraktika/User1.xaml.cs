using ItoqPraktika.zavodDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
    /// Логика взаимодействия для User1.xaml
    /// </summary>
    public partial class User1 : Page
    {
        sparesTableAdapter spa = new sparesTableAdapter();
        brandTableAdapter br = new brandTableAdapter();
        public User1()
        {
            InitializeComponent();
            SparesDataGrid.ItemsSource = spa.GetData();
            BrandBox.ItemsSource = br.GetData();
            BrandBox.DisplayMemberPath = "brand_id";
        }

        public object bran;
        private void BrandBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (BrandBox.SelectedItem != null)
            {
                bran = (BrandBox.SelectedItem as DataRowView).Row[0];
            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var stringNumber = quantity.Text;
            bool isNumber = int.TryParse(stringNumber, out int numericValue);
            var stringNumber1 = price.Text;
            bool isNumber1 = int.TryParse(stringNumber1, out int numericValue1);
            string pattern = @"^[а-яЁёА-Я\s]*$";
            if (Regex.IsMatch(name_spares.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте кириллицу.";
            }
            else if (isNumber1 != true)
            {
                ErrorText.Text = "В строке с зарплатой только целочисленные значения!";
            }
            else if (isNumber1 == true && numericValue1 <= 0)
            {
                ErrorText.Text = "Цена не может быть отрицательной и 0!";
            }
            else if (isNumber != true)
            {
                ErrorText.Text = "В строке с количесвтом только целочисленные значения!";
            }
            else if (isNumber == true && numericValue < 0)
            {
                ErrorText.Text = "Количество не может быть отрицательной!";
            }
            else if (name_spares.Text == "" | quantity.Text == "" | price.Text == "" | BrandBox.SelectedItem == null)
            {
                ErrorText.Text = "Не все поля заполнены";
            }

            else
            {
                spa.InsertSpares(name_spares.Text, Convert.ToInt32(bran), Convert.ToInt32(quantity.Text), Convert.ToInt32(price.Text));
                SparesDataGrid.ItemsSource = spa.GetData();
                ErrorText.Text = ""; name_spares.Text = ""; quantity.Text = ""; price.Text = "";
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var stringNumber = quantity.Text;
            bool isNumber = int.TryParse(stringNumber, out int numericValue);
            var stringNumber1 = price.Text;
            bool isNumber1 = int.TryParse(stringNumber1, out int numericValue1);
            string pattern = @"^[а-яЁёА-Я\s]*$";
            if (Regex.IsMatch(name_spares.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте кириллицу.";
            }
            else if (isNumber1 != true)
            {
                ErrorText.Text = "В строке с зарплатой только целочисленные значения!";
            }
            else if (isNumber1 == true && numericValue1 <= 0)
            {
                ErrorText.Text = "Зарплата не может быть отрицательной!";
            }
            else if (isNumber != true)
            {
                ErrorText.Text = "В строке с количесвтом только целочисленные значения!";
            }
            else if (isNumber == true && numericValue < 0)
            {
                ErrorText.Text = "Количество не может быть отрицательной!";
            }
            else if (name_spares.Text == "" | quantity.Text == "" | price.Text == "" | BrandBox.SelectedItem == null)
            {
                ErrorText.Text = "Не все поля заполнены";
            }

            else
            {
                spa.UpdateSpares(name_spares.Text, Convert.ToInt32(bran), Convert.ToInt32(quantity.Text), Convert.ToInt32(price.Text), Convert.ToInt32(bran));
                SparesDataGrid.ItemsSource = spa.GetData();
                ErrorText.Text = ""; name_spares.Text = ""; quantity.Text = ""; price.Text = "";
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (name_spares.Text == "" | quantity.Text == "" | price.Text == "" | BrandBox.SelectedItem == null)
            {
                ErrorText.Text = "Не все поля заполнены";
            }

            else
            {
                spa.DeleteSpares(Convert.ToInt32(spar_id));
                SparesDataGrid.ItemsSource = spa.GetData();
                ErrorText.Text = ""; name_spares.Text = ""; quantity.Text = ""; price.Text = "";
            }

        }
        public object spar_id;

        private void SparesDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
            if (SparesDataGrid.SelectedItem != null)
            {
                spar_id = (SparesDataGrid.SelectedItem as DataRowView).Row[0];
                name_spares.Text = (string)(SparesDataGrid.SelectedItem as DataRowView).Row[1];
                quantity.Text = Convert.ToString((SparesDataGrid.SelectedItem as DataRowView).Row[3]);
                price.Text = Convert.ToString((SparesDataGrid.SelectedItem as DataRowView).Row[4]);


                int brandID = Convert.ToInt32((SparesDataGrid.SelectedItem as DataRowView).Row[2]);
                var allbrand = br.GetData().Rows;
                for (int i = 0; i < allbrand.Count; i++)
                {
                    if (Convert.ToInt32(allbrand[i][0]) == brandID)
                    {
                        BrandBox.Text = allbrand[i][1].ToString();
                    }
                }

            }
        }
    }
}
