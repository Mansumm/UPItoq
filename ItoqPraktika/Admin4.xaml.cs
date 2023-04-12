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
    /// Логика взаимодействия для Admin4.xaml
    /// </summary>
    public partial class Admin4 : Page
    {
        buyerTableAdapter buy = new buyerTableAdapter();
        countryTableAdapter cou = new countryTableAdapter();
        public Admin4()
        {
            InitializeComponent();
            BuyerDataGrid.ItemsSource = buy.GetData();
            CountryBox.ItemsSource = cou.GetData();
            CountryBox.DisplayMemberPath = "name_country";
        }
        public object buyer_id;
        private void CountryBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (CountryBox.SelectedItem != null)
            {
                counn = (CountryBox.SelectedItem as DataRowView).Row[0];
            }

        }
        public object counn;
        private void BuyerDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (BuyerDataGrid.SelectedItem != null)
            {
                buyer_id = (BuyerDataGrid.SelectedItem as DataRowView).Row[0];
                name_komp.Text = (string)(BuyerDataGrid.SelectedItem as DataRowView).Row[1];
                representative.Text = (string)(BuyerDataGrid.SelectedItem as DataRowView).Row[3];
                number.Text = Convert.ToString((BuyerDataGrid.SelectedItem as DataRowView).Row[2]);

                int counID = Convert.ToInt32((BuyerDataGrid.SelectedItem as DataRowView).Row[4]);
                var allcoun = cou.GetData().Rows;
                for (int i = 0; i < allcoun.Count; i++)
                {
                    if (Convert.ToInt32(allcoun[i][0]) == counID)
                    {
                        CountryBox.Text = allcoun[i][1].ToString();
                    }
                }

            }


        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string pattern2 = @"^[а-яА-Я\s]*$";
            string pattern = @"^[a-zA-Z\s]*$";
            string pattern3 = (@"+7-\d{3}-\d{3}-\d{4}");

            if (Regex.IsMatch(number.Text, pattern3, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте правильный формат.";
            }
            else if (Regex.IsMatch(name_komp.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте английский.";
            }
            
            else if (Regex.IsMatch(representative.Text, pattern2, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте кириллицу.";
            }
            else if (name_komp.Text == "" | number.Text == ""
                | representative.Text == "" | CountryBox.SelectedItem == null)
            {
                ErrorText.Text = "Не все поля заполнены!";
            }
            else
            {
                buy.InsertBuyer(name_komp.Text, number.Text, representative.Text, Convert.ToInt32(counn));
                BuyerDataGrid.ItemsSource = buy.GetData();
                name_komp.Text = ""; number.Text = ""; representative.Text = ""; CountryBox.Text = ""; ErrorText.Text = "";
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string pattern2 = @"^[а-яА-Я\s]*$";
            string pattern = @"^[a-zA-Z\s]*$";
            string number1 = @"(\+7|8|\b)(\d{3}-\d{3}-\d{4})";


            if (Regex.IsMatch(number.Text, number1, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте правильный формат.";
            }






            else if (Regex.IsMatch(name_komp.Text, pattern, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте английский.";
            }
            
            else if (Regex.IsMatch(representative.Text, pattern2, RegexOptions.IgnoreCase) != true)
            {
                ErrorText.Text = "Используйте кириллицу.";
            }
            else if (name_komp.Text == "" | number.Text == ""
               | representative.Text == "" | CountryBox.SelectedItem == null)
            {
                ErrorText.Text = "Не все поля заполнены!";
            }
            else
            {
                buy.UpdateBuyer(name_komp.Text, number.Text, representative.Text, Convert.ToInt32(counn), Convert.ToInt32(buyer_id));
                BuyerDataGrid.ItemsSource = buy.GetData();
                name_komp.Text = ""; number.Text = ""; representative.Text = ""; CountryBox.Text = ""; ErrorText.Text = "";
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (name_komp.Text == "" | number.Text == ""
              | representative.Text == "" | CountryBox.SelectedItem == null)
            {
                ErrorText.Text = "Не все поля заполнены!";
            }
            else
            {
                buy.DeleteBuyer( Convert.ToInt32(buyer_id));
                BuyerDataGrid.ItemsSource = buy.GetData();
                name_komp.Text = ""; number.Text = ""; representative.Text = ""; CountryBox.Text = ""; ErrorText.Text = "";
            }



        }
    }
}
