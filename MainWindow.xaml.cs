using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
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


namespace WpfApp_binance
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        const string FGetUrl = "https://api.binance.com/api/v3/depth?symbol=BNBBTC";

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var FHttpWebRequest = (HttpWebRequest)WebRequest.Create(FGetUrl);

            FHttpWebRequest.ContentType = "application/json";//"text/json";
            FHttpWebRequest.Method = "GET"; 
            var FHttpResponse = (HttpWebResponse)FHttpWebRequest.GetResponse();
            using (var FStreamReader = new StreamReader(FHttpResponse.GetResponseStream()))
            {
                var FResult = FStreamReader.ReadToEnd();
                tbxText.Text = FResult.ToString();
            }

        }

        const string FWebSocketUrl = "wss://stream.binance.com:9443";

        private void btnWebSocket_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
