using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using _1aarsproeve.Common;
using _1aarsproeve.Model;
using _1aarsproeve.View;

namespace _1aarsproeve.ViewModel
{
    /// <summary>
    /// DataContext klasse til Views: Hovedmenu, SkrivBesked
    /// </summary>
    class HovedViewModel
    {
        private GeneriskSingleton<ObservableCollection<Beskeder>> _beskedCollection = GeneriskSingleton<ObservableCollection<Beskeder>>.Instance();
        private ObservableCollection<Beskeder> _beskeder;
        private static HttpClient _client;
        /// <summary>
        /// Singleton vagtcollection
        /// </summary>
        public ObservableCollection<ObservableCollection<Beskeder>> BeskedCollection
        {
            get { return _beskedCollection.Collection; }
            set { _beskedCollection.Collection = value; }
        }
        /// <summary>
        /// Get til klienten til forbindelsen til databasen
        /// </summary
        public static HttpClient Client
        {
            get { return _client; }
        }
        /// <summary>
        /// Gør det muligt at gemme værdier i local storage
        /// </summary>
        public ApplicationDataContainer Setting { get; set; }
        /// <summary>
        /// Brugernavn property
        /// </summary>
        public string Brugernavn { get; set; }
        /// <summary>
        /// Logger brugeren ud
        /// </summary>
        public ICommand LogUdCommand { get; set; }
        /// <summary>
        /// Property til at skjule knapper
        /// </summary>
        public Visibility SkjulKnap { get; set; }
        /// <summary>
        /// Constructor for HovedViewModel
        /// </summary>
        public HovedViewModel()
        {
            AabenForbindelse();
            Setting = ApplicationData.Current.LocalSettings;
            Brugernavn = (string)Setting.Values["Brugernavn"];
            _beskeder = new ObservableCollection<Beskeder>();
            BeskedCollection.Add(_beskeder);

            _beskeder.Add(new Beskeder(1, "MUS-samtale", new DateTime(), "Så er der fyringsrunde!!", new DateTime(), "Daniel"));
            SkjulKnap = new Visibility();

            Stilling();

            LogUdCommand = new RelayCommand(LogUd);
            
        }
        /// <summary>
        /// Åbner forbindelsen til database
        /// </summary>
        public void AabenForbindelse()
        {
            const string serverUrl = "http://localhost:9999/";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            _client = new HttpClient(handler);
            _client.BaseAddress = new Uri(serverUrl);
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        /// <summary>
        /// Logger brugeren ud
        /// </summary>
        public void LogUd()
        {
            Setting.Values.Remove("Brugernavn");

            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Login));
        }
        /// <summary>
        /// Collapser knapper alt efter stilling
        /// </summary>
        public void Stilling()
        {
            if (Brugernavn != "Daniel")
            {    
                SkjulKnap = Visibility.Collapsed;
            }
        }
    }
}