using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Security.Cryptography.Core;
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
    /// DataContext klasse til Views: Login, OpretBruger, Profil
    /// </summary>
    public class BrugerViewModel
    {
        private static GeneriskSingleton<Ansatte> _ansatteSingleton = GeneriskSingleton<Ansatte>.Instance();
        private string _brugernavn;
        private string _password;
        private static HttpClient _client;
        private ICommand _opretBrugerCommand;
        private ICommand _redigerBrugerCommand;

        public Ansatte Ansat { get; set; }
        public BrugerHandler BrugerHandler { get; set; }
        /// <summary>
        /// Gør det muligt at gemme værdier i local storage
        /// </summary>
        public ApplicationDataContainer Setting { get; set; }

        /// <summary>
        /// Brugernavn property
        /// </summary>
        public string Brugernavn
        {
            get { return _brugernavn; }
            set { _brugernavn = value; }
        }
        /// <summary>
        /// Get til klienten til forbindelsen til databasen
        /// </summary
        public static HttpClient Client
        {
            get { return _client; }
        }

        /// <summary>
        /// Password property
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }

        }
        /// <summary>
        /// AnsatteCollection property
        /// </summary>
        public static ObservableCollection<Ansatte> AnsatteCollection
        {
            get { return _ansatteSingleton.Collection; }
            set { _ansatteSingleton.Collection = value; }
        }
        /// <summary>
        /// Liste med stillinger
        /// </summary>
        public List<Stillinger> StillingerListe { get; set; }
        /// <summary>
        /// Logger brugeren ind
        /// </summary>
        public ICommand LogIndCommand { get; set; }
        /// <summary>
        /// Logger brugeren ud
        /// </summary>
        public ICommand LogUdCommand { get; set; }
        /// <summary>
        /// Opretter bruger
        /// </summary>
        public ICommand OpretBrugerCommand
        {
            get
            {
                if (_opretBrugerCommand == null)
                    _opretBrugerCommand = new RelayCommand(BrugerHandler.OpretBruger);
                return _opretBrugerCommand;
            }
            set { _opretBrugerCommand = value; }
        }
        /// <summary>
        /// Rediger bruger command
        /// </summary>
        public ICommand RedigerBrugerCommand
        {
            get
            {
                if (_redigerBrugerCommand == null)
                    _redigerBrugerCommand = new RelayCommand(BrugerHandler.RedigerBruger);
                return _redigerBrugerCommand;
            }
            set { _redigerBrugerCommand = value; }
        }
        /// <summary>
        /// Konstruktør for BrugerViewModel
        /// </summary>
        public BrugerViewModel()
        {
            AabenForbindelse();
            Setting = ApplicationData.Current.LocalSettings;
            Brugernavn = (string)Setting.Values["Brugernavn"];
            StillingerListe = new List<Stillinger>();
            StillingerListe.Add(new Stillinger(100, "loolllerland"));
            var a = PersistensFacade<Stillinger>.LoadDB("api/Stillingers").Result;
            //foreach (var item in a)
            //{
            //    StillingerListe.Add(item);
            //}

            BrugerHandler = new BrugerHandler(this);
            LogIndCommand = new RelayCommand(LogInd);
            LogUdCommand = new RelayCommand(LogUd);
            OpretBrugerCommand = new RelayCommand(BrugerHandler.OpretBruger);
            RedigerBrugerCommand = new RelayCommand(BrugerHandler.RedigerBruger);
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
        /// Logger brugeren ind
        /// </summary>
        public void LogInd()
        {
            /*try
            {
                AnsatteCollection.Clear();
                var responce = PersistensFacade<Ansatte>.LoadDB("api/Ansattes");

                var query = from q in responce.Result
                            where q.Brugernavn == Brugernavn && q.Password == Password
                            select q;
                foreach (var item in query)
                {
                    AnsatteCollection.Add(item);
                }
                if (AnsatteCollection.Count() == 1)
                {
                    Setting.Values["Brugernavn"] = AnsatteCollection[0].Brugernavn;
                    Setting.Values["StillingId"] = AnsatteCollection[0].StillingId;
                    var rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(Hovedmenu));
                }
                else
                {

                    MessageDialog fail = new MessageDialog("Forkert brugernavn/password");
                    fail.ShowAsync();
                }

            }
            catch (ArgumentException ex)
            {
                if (AnsatteCollection.Count != 0)
                {
                    AnsatteCollection.Clear();
                }
                MessageDialog exception = new MessageDialog("Forkert brugernavn/password!", "Fejl!");
                exception.ShowAsync();
            }*/
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Hovedmenu));
        }

        /// <summary>
        /// Logger brugeren ud
        /// </summary>
        public void LogUd()
        {
            //AnsatteCollection.Clear();
            Setting.Values.Remove("Brugernavn");
            Setting.Values.Remove("StillingId");

            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Login));

        }
    }
}
