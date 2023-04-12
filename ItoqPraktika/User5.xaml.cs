using ItoqPraktika.zavodDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace ItoqPraktika
{
    /// <summary>
    /// Логика взаимодействия для User5.xaml
    /// </summary>
    public partial class User5 : Page
    {
        brandTableAdapter bra = new brandTableAdapter();
        manufacturerTableAdapter man = new manufacturerTableAdapter();
        modelTableAdapter mod = new modelTableAdapter();
        body_typeTableAdapter bod = new body_typeTableAdapter();
        public User5()
        {
            InitializeComponent();
            BrandDataGrid.ItemsSource = bra.GetData();
            ManufacturerBox.ItemsSource = man.GetData();
            ManufacturerBox.DisplayMemberPath = "name_manufacturer";
            ModelBox.ItemsSource = mod.GetData();
            ModelBox.DisplayMemberPath = "name_model";
            BodyBox.ItemsSource = bod.GetData();
            BodyBox.DisplayMemberPath = "name_body_type";
        }
        public object bran_id;
        private void Brand_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (BrandDataGrid.SelectedItem != null)
            {
                bran_id = (BrandDataGrid.SelectedItem as DataRowView).Row[0];
                int manuID = Convert.ToInt32((BrandDataGrid.SelectedItem as DataRowView).Row[1]);
                var allmanu = man.GetData().Rows;
                for (int i = 0; i < allmanu.Count; i++)
                {
                    if (Convert.ToInt32(allmanu[i][0]) == manuID)
                    {
                        ManufacturerBox.Text = allmanu[i][1].ToString();
                    }
                }

                int modID = Convert.ToInt32((BrandDataGrid.SelectedItem as DataRowView).Row[2]);
                var allmod = mod.GetData().Rows;
                for (int i = 0; i < allmanu.Count; i++)
                {
                    if (Convert.ToInt32(allmod[i][0]) == modID)
                    {
                        ModelBox.Text = allmod[i][1].ToString();
                    }
                }

                int bodID = Convert.ToInt32((BrandDataGrid.SelectedItem as DataRowView).Row[3]);
                var allbod = bod.GetData().Rows;
                for (int i = 0; i < allbod.Count; i++)
                {
                    if (Convert.ToInt32(allbod[i][0]) == bodID)
                    {
                        BodyBox.Text = allbod[i][1].ToString();
                    }
                }

            }
               

        }
        public object manu;
        private void ManufacturerBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ManufacturerBox.SelectedItem != null)
            {
                manu = (ManufacturerBox.SelectedItem as DataRowView).Row[0];
            }

        }
        public object modd;
        private void ModelBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModelBox.SelectedItem != null)
            {
                modd = (ModelBox.SelectedItem as DataRowView).Row[0];
            }

        }
        public object bodd;
        private void BodyBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BodyBox.SelectedItem != null)
            {
                bodd = (BodyBox.SelectedItem as DataRowView).Row[0];
            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ManufacturerBox.SelectedItem == null | ModelBox.SelectedItem == null | BodyBox.SelectedItem == null)
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                bra.InsertBrand(Convert.ToInt32(manu), Convert.ToInt32(modd), Convert.ToInt32(bodd));
                BrandDataGrid.ItemsSource = bra.GetData();
                ErrorText.Text = ""; ManufacturerBox.Text = ""; ModelBox.Text = ""; BodyBox.Text = "";
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ManufacturerBox.SelectedItem == null | ModelBox.SelectedItem == null | BodyBox.SelectedItem == null)
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                bra.UpdateBrand(Convert.ToInt32(manu), Convert.ToInt32(modd), Convert.ToInt32(bodd), Convert.ToInt32(bran_id));
                BrandDataGrid.ItemsSource = bra.GetData();
                ErrorText.Text = ""; ManufacturerBox.Text = ""; ModelBox.Text = ""; BodyBox.Text = "";
            }

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ManufacturerBox.SelectedItem == null | ModelBox.SelectedItem == null | BodyBox.SelectedItem == null)
            {
                ErrorText.Text = "Не все поля заполнены";
            }
            else
            {
                bra.DeleteBrand(Convert.ToInt32(bran_id));
                BrandDataGrid.ItemsSource = bra.GetData();
                ErrorText.Text = ""; ManufacturerBox.Text = ""; ModelBox.Text = ""; BodyBox.Text = "";
            }

        }
    }
}
