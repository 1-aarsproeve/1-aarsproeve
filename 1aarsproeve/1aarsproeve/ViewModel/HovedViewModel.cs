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
using _1aarsproeve.Handler;
using _1aarsproeve.Model;
using _1aarsproeve.Persistens;
using _1aarsproeve.View;

namespace _1aarsproeve.ViewModel
{
    /// <summary>
    /// DataContext klasse til Views: Hovedmenu, SkrivBesked
    /// </summary>
    public class HovedViewModel
    {
        private GeneriskSingleton<ObservableCollection<HovedmenuView>> _beskedCollection = GeneriskSingleton<ObservableCollection<HovedmenuView>>.Instance();
        /// <summary>
        /// ObservableCollection med Beskeder
        /// </summary>
        public ObservableCollection<HovedmenuView> BeskederC { get; set; }
        private static HttpClient _client;
        /// <summary>
        /// Singleton vagtcollection
        /// </summary>
        public ObservableCollection<ObservableCollection<HovedmenuView>> BeskedCollection
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
        private ICommand _skrivBeskedCommand;
        /// <summary>
        /// Hovedhandler property
        /// </summary>
        public HovedHandler HovedHandler { get; set; }
        /// <summary>
        /// Besked property
        /// </summary>
        public Beskeder Besked { get; set; }
        /// <summary>
        /// Constructor for HovedViewModel
        /// </summary>
        public int StillingsId { get; set; }
        public HovedViewModel()
        {
            AabenForbindelse();
            Setting = ApplicationData.Current.LocalSettings;
            Brugernavn = (string)Setting.Values["Brugernavn"];
            StillingsId = (int)Setting.Values["StillingId"];

            BeskederC = new ObservableCollection<HovedmenuView>();
            BeskedCollection.Add(BeskederC);

            BeskedCollection[0].Clear();
            var query = PersistensFacade<HovedmenuView>.LoadDB("api/HovedmenuViews").Result;
            foreach (var item in query)
            {
                BeskedCollection[0].Add(item);
            }
            
            SkjulKnap = new Visibility();

            Stilling();

            LogUdCommand = new RelayCommand(LogUd);
            Besked = new Beskeder();
            HovedHandler = new HovedHandler(this);
        }
        /// <summary>
        /// SkrivBesked command
        /// </summary>
        public ICommand SkrivBeskedCommand
        {
            get
            {
                if (_skrivBeskedCommand == null)
                    _skrivBeskedCommand = new RelayCommand(HovedHandler.SkrivBesked);
                return _skrivBeskedCommand;
            }
            set { _skrivBeskedCommand = value; }
        }
        /// <summary>
        /// Åbner forbindelsen til database
        /// </summary>
        private void AabenForbindelse()
        {
            try
            {
                const string serverUrl = "http://localhost:9999/";
                HttpClientHandler handler = new HttpClientHandler();
                handler.UseDefaultCredentials = true;
                _client = new HttpClient(handler);
                _client.BaseAddress = new Uri(serverUrl);
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            }
            catch (Exception)
            {
                MessageDialog m = new MessageDialog("Der kunne ikke oprettes forbindelse til databasen", "Fejl!");
                m.ShowAsync();
            }
        }
        /// <summary>
        /// Logger brugeren ud
        /// </summary>
        public void LogUd()
        {
            Setting.Values.Remove("Brugernavn");
            Setting.Values.Remove("StillingId");

            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Login));
        }
        /// <summary>
        /// Collapser knapper alt efter stilling
        /// </summary>
        public void Stilling()
        {
            if (StillingsId != 2)
            {
                SkjulKnap = Visibility.Collapsed;
            }
        }
    }
}