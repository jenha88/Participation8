using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace GOTQuote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<GOT> apiList = new List<GOT>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btbgen_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync("https://got-quotes.herokuapp.com/quotes").Result;
                GOT api = JsonConvert.DeserializeObject<GOT>(jsonData);
                apiList.Add(api);

                txtblock.Text = $"{api.quote}--{api.character}";
                
            }
          
        }

        private void btbexp_Click(object sender, RoutedEventArgs e)
        {

            string jj = JsonConvert.SerializeObject(apiList);
            File.WriteAllText("GOT_Quotes.json", jj);



        }
    }
}
