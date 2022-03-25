using Library.Classes;
using System;
using System.Collections.Generic;
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

namespace Library.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageReader.xaml
    /// </summary>
    public partial class PageReader : Page
    {
        public PageReader()
        {
            InitializeComponent();
        }
        public Reader selectedClient { get; set; }
        List<BooksByReader> booksByReaders = new List<BooksByReader>();
        string token { get; set; }
        public PageReader(Reader selectedClient, string token)
        {
            InitializeComponent();
            this.selectedClient = selectedClient;
            this.DataContext = this;
            this.token = token;
          
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (HttpClient httpClient = new HttpClient { BaseAddress = new Uri(Properties.Settings.Default.BaseAddress) })
            {

                var content = new StringContent("", Encoding.UTF8, "application/json");
                
            }
        }
    }
}
