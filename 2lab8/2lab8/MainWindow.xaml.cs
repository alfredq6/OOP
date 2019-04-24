using _2lab8.oopLab8DataSet1TableAdapters;
using _2lab8.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2lab8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlDataReader reader;
        private List<Product> products;
        private List<Producer> producers;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void SetProductData()
        {
            var productTable = new ТоварыTableAdapter();
            var productData = productTable.GetData();

            products = new List<Product>();

            var rows = productData.Rows;
            foreach (DataRow row in rows)
            {
                var product = new Product();
                var values = row.ItemArray;
                product.Name = values[0].ToString();
                product.InventoryNumber = (long?)values[1];
                product.Weight = values[2] is int ? (int?)values[2] : null;
                product.Type = values[3].ToString();
                product.Price = values[4] is decimal ? (decimal?)values[4] : null;
                product.Producer = values[5].ToString();
                product.Image = (Byte[])values[6];
                product.ImagePath = values[7].ToString();
                products.Add(product);
            }
        }

        private void SetProducerData()
        {
            var producerTable = new ПроизводителиTableAdapter();
            var producerData = producerTable.GetData();

            producers = new List<Producer>();

            var rows = producerData.Rows;
            foreach (DataRow row in rows)
            {
                var producer = new Producer();
                var values = row.ItemArray;
                producer.OrganisationName = values[0].ToString();
                producer.Country = values[1].ToString();
                producer.Adress = values[2].ToString();
                producer.TelephoneNumber = values[3] is long ? (long?)values[3] : null;

                producers.Add(producer);
            }
        }

        private void UpdateTables()
        {
            Properties.Settings connectionString = new Properties.Settings();

            using (SqlConnection connection = new SqlConnection(connectionString.oopLab8ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "delete Товары";
                    command.ExecuteNonQuery();
                    command.CommandText = "delete Производители";
                    command.ExecuteNonQuery();
                    foreach (var producer in producers)
                    {
                        command.CommandText = $@"insert into Производители ([Организация], [Страна], [Адрес], [Телефон])
                                            values ('{(producer.OrganisationName == null ? "NULL" : producer.OrganisationName)}',
                                                    '{(producer.Country == null ? "NULL" : producer.Country)}',
                                                    '{(producer.Adress == null ? "NULL" : producer.Adress)}',
                                                    {(producer.TelephoneNumber == null ? "NULL" : producer.TelephoneNumber.ToString())})";
                        command.ExecuteNonQuery();
                    }

                    foreach (var product in products)
                    {
                        command.CommandText = $@"insert into Товары ([Название], [Инвентарный номер], [Тип], [Вес], [Цена], [Производитель], [Путь к изображению], [Изображение])
                            Select '{(product.Name == null ? "NULL" : product.Name)}',
                            {(product.InventoryNumber == null ? "NULL" : product.InventoryNumber.ToString())},
                            '{(product.Type == null ? "NULL" : product.Type)}',
                            {(product.Weight == null ? "NULL" : product.Weight.ToString())},
                            {(product.Price == null ? "NULL" : product.Price.ToString())},
                            '{(product.Producer == null ? "NULL" : product.Producer)}',
                            '{(product.ImagePath == null ? @"D:\oop\images\SAMSUNG_Galaxy_S9_Blue.png" : product.ImagePath)}', BulkColumn
                            from Openrowset(Bulk '{(product.ImagePath == null ? @"D:\oop\images\SAMSUNG_Galaxy_S9_Blue.png" : product.ImagePath)}', Single_Blob) as col{products.IndexOf(product).ToString()}";
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void GetImages()
        {
            Properties.Settings connectionString = new Properties.Settings();

            listBox.Items.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString.oopLab8ConnectionString))
            {
                connection.Open();
                var sqlExpr = "getimages";
                SqlCommand command = new SqlCommand(sqlExpr, connection);
                command.CommandType = CommandType.StoredProcedure;

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ImageSourceConverter converter = new ImageSourceConverter();
                    var image = new Image();
                    image.Source = (ImageSource)converter.ConvertFrom(reader.GetValue(0));
                    image.Height = 200;
                    listBox.Items.Add(image);
                }
                
                reader.Close();
                command.Connection.Close();
            }
        }

        private void ShowBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetProductData();
                SetProducerData();

                DG1.DataContext = products;
                DG2.DataContext = producers;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + "будет создана новая база данных oopLab8");
                CreateDataBase();
            }
        }

        private void CreateDataBase()
        {
            var connectionString = @"Data Source=MACHINE\SQL2017;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "create database oopLab8";
                command.ExecuteNonQuery();
                command.CommandText = @"use oopLab8
                                    create table Производители(
                    [Организация] nvarchar(50) primary key,
                    [Страна] nvarchar(20),
                    [Адрес] nvarchar(100),
		            [Телефон] bigint)

                                    create table Товары(
                    [Название] nvarchar(50),
		            [Инвентарный номер] bigint primary key,
		            [Вес] int,
		            [Тип] nvarchar(50) check([Тип] = 'Потребительский' or[Тип] = 'Промышленный'),
		            [Цена] bigint,
		            [Производитель] nvarchar(50) foreign key references Производители([Организация]),
		            [Изображение] image,
		            [Путь к изображению] nvarchar(200))";
                command.ExecuteNonQuery();
                //command.CommandText = @"
                //go
                //create proc getimages as
                //begin
                //select Изображение from Товары
                //end";
                //command.ExecuteNonQuery();
                command.Connection.Close();
            }
        }

        private void GetImageBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetImages();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + "будет создана новая база данных oopLab8");
                CreateDataBase();
            }
        }

        private void SaveBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateTables();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + "\nБудет создана новая база данных oopLab8");
                CreateDataBase();
            }
        }

        private void NextBut_Click(object sender, RoutedEventArgs e)
        {
            DG1.Visibility = Visibility.Hidden;
            DG2.Visibility = Visibility.Visible;
        }

        private void PrevBut_Click(object sender, RoutedEventArgs e)
        {
            DG1.Visibility = Visibility.Visible;
            DG2.Visibility = Visibility.Hidden;
        }
    }
}
