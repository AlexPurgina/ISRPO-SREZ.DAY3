using Library.Classes;
using Library.Views.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для ReadersList.xaml
    /// </summary>
    public partial class ReadersList : Page
    {
        public ReadersList()
        {
            InitializeComponent();
        }
        string token { get; set; }
        List<Reader> readers = new List<Reader>();
        public ReadersList(string token)
        {
            InitializeComponent();
            this.token = token;
            Data();
        }
        public  void Data(string search="")
        {
            try
            {
                using (HttpClient httpClient = new HttpClient { BaseAddress = new Uri(Properties.Settings.Default.BaseAddress) })
                {
                    var reader = httpClient.GetStringAsync($"/GetReaders?token={token}");
                    readers = JsonSerializer.Deserialize<List<Reader>>(reader.Result);

                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        readers = readers.Where(x => x.fullName.ToLower().Contains(search.ToLower())).ToList();

                        if (readers.Count() == 0)
                        {
                            MessageBox.Show("Результаты не найдены");
                        }
                    }
                    LvReader.ItemsSource = readers;
                    ;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("error");
                return;
            }
          
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Data(tbSearch.Text);
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.Current.Shutdown();

        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string file = "";
                file += $"ФИО\n";
                byte[] photos = new byte[readers.Count()];

                foreach (var reader in this.readers)
                {

                    photos = reader.photo;
                    File.WriteAllBytes($@"C:\Users\Пользователь\Desktop\Library\bin\Debug\readerphoto\{reader.lastName} {reader.firstName}.jpg", photos);
                    file += $"{reader.fullName}" + ";" + $@"C:\Users\Пользователь\Desktop\Library\bin\Debug\readerphoto\{reader.lastName} {reader.firstName}.jpg" + "\n";

                }

                File.WriteAllText($@"{Directory.GetCurrentDirectory()}\readers.csv", file, Encoding.Default);


                MessageBox.Show($@"Файл сохранён по пути {Directory.GetCurrentDirectory()}\readers.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
                return;
            }

          

        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var selectedClient = LvReader.SelectedItem as Reader;
            if (selectedClient != null)
            {
                NavigationService.Navigate(new PageReader(selectedClient, token));
            }
        }
    }
}
