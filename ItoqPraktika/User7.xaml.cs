using ItoqPraktika.zavodDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using static ItoqPraktika.zavodDataSet;

namespace ItoqPraktika
{
    /// <summary>
    /// Логика взаимодействия для User7.xaml
    /// </summary>
    public partial class User7 : Page
    {
        buy_historyTableAdapter his = new buy_historyTableAdapter();
        buyTableAdapter bu = new buyTableAdapter();
        public User7()
        {
            InitializeComponent();
            HistoryDataGrid.ItemsSource = his.GetData();
            BuyBox.ItemsSource = bu.GetData();
            BuyBox.DisplayMemberPath = "buy_id";
        }
        public object his_id;
        private void HistoryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HistoryDataGrid.SelectedItem != null)
            {
                his_id = (HistoryDataGrid.SelectedItem as DataRowView).Row[0];
                Data.Text = Convert.ToString((HistoryDataGrid.SelectedItem as DataRowView).Row[2]);
                int buyID = Convert.ToInt32((HistoryDataGrid.SelectedItem as DataRowView).Row[1]);
                var allbuy = bu.GetData().Rows;
                for (int i = 0; i < allbuy.Count; i++)
                {
                    if (Convert.ToInt32(allbuy[i][0]) == buyID)
                    {
                        BuyBox.Text = allbuy[i][1].ToString();
                    }
                }

            }

        }
        public object buyy;
        private void HistoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BuyBox.SelectedItem != null)
            {
                buyy = (BuyBox.SelectedItem as DataRowView).Row[0];
            }


        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
          
            if (BuyBox.SelectedItem == null | Data.Text == "") 
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                his.InsertHistory(Convert.ToInt32(buyy), Data.Text);
                HistoryDataGrid.ItemsSource = his.GetData();
                ErrorText.Text = ""; BuyBox.Text = ""; Data.Text = "";
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (BuyBox.SelectedItem == null | Data.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                his.UpdateHistory(Convert.ToInt32(buyy), Data.Text, Convert.ToInt32(his_id));
                HistoryDataGrid.ItemsSource = his.GetData();
                ErrorText.Text = ""; BuyBox.Text = ""; Data.Text = "";
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (BuyBox.SelectedItem == null | Data.Text == "")
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                his.DeleteHistory(Convert.ToInt32(his_id));
                HistoryDataGrid.ItemsSource = his.GetData();
                ErrorText.Text = ""; BuyBox.Text = ""; Data.Text = "";
            }

        }
    }
}
