using ItoqPraktika.zavodDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для User6.xaml
    /// </summary>
    public partial class User6 : Page
    {
        buyTableAdapter bu = new buyTableAdapter();
        buyerTableAdapter buy = new buyerTableAdapter();
        sparesTableAdapter spa = new sparesTableAdapter();


        public User6()
        {
            InitializeComponent();
            BuyDataGrid.ItemsSource = bu.GetData();
            BuyerBox.ItemsSource = buy.GetData();
            BuyerBox.DisplayMemberPath = "name_komp";
            SparesBox.ItemsSource = spa.GetData();
            SparesBox.DisplayMemberPath = "name_spares";
        }
        public object buy_id;
        private void BuyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BuyDataGrid.SelectedItem != null)
            {
                buy_id = (BuyDataGrid.SelectedItem as DataRowView).Row[0];
                int buyerID = Convert.ToInt32((BuyDataGrid.SelectedItem as DataRowView).Row[1]);
                var allbuyer = buy.GetData().Rows;
                for (int i = 0; i < allbuyer.Count; i++)
                {
                    if (Convert.ToInt32(allbuyer[i][0]) == buyerID)
                    {
                        BuyerBox.Text = allbuyer[i][1].ToString();
                    }
                }

                int spaID = Convert.ToInt32((BuyDataGrid.SelectedItem as DataRowView).Row[2]);
                var allspa = spa.GetData().Rows;
                for (int i = 0; i < allspa.Count; i++)
                {
                    if (Convert.ToInt32(allspa[i][0]) == spaID)
                    {
                        SparesBox.Text = allspa[i][1].ToString();
                    }
                }

            }
        }
        public object spaa;
        private void SparesBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SparesBox.SelectedItem != null)
            {
                spaa = (SparesBox.SelectedItem as DataRowView).Row[0];
            }

        }
        public object buyy;
        private void BuyerBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BuyerBox.SelectedItem != null)
            {
                buyy = (BuyerBox.SelectedItem as DataRowView).Row[0];
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (BuyerBox.SelectedItem == null | SparesBox.SelectedItem == null )
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                bu.InsertBuy(Convert.ToInt32(buyy), Convert.ToInt32(spaa));
                BuyDataGrid.ItemsSource = bu.GetData();
                ErrorText.Text = ""; BuyerBox.Text = ""; SparesBox.Text = ""; 
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (BuyerBox.SelectedItem == null | SparesBox.SelectedItem == null)
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                bu.UpdateBuy(Convert.ToInt32(buyy), Convert.ToInt32(spaa), Convert.ToInt32(buy_id));
                BuyDataGrid.ItemsSource = bu.GetData();
                ErrorText.Text = ""; BuyerBox.Text = ""; SparesBox.Text = "";
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (BuyerBox.SelectedItem == null | SparesBox.SelectedItem == null)
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                bu.DeleteBuy( Convert.ToInt32(buy_id));
                BuyDataGrid.ItemsSource = bu.GetData();
                ErrorText.Text = ""; BuyerBox.Text = ""; SparesBox.Text = "";
            }

        }
    }
}
