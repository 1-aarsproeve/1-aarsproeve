
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
        #region Backing fields

        private GeneriskSingleton<Ansatte> _ansatteSingleton;
        private string _brugernavn;
        private string _password;
        private List<Stillinger> _stillingerListe;
        private ICommand _opretBrugerCommand;
        private ICommand _redigerBrugerCommand;
        private ICommand _logindCommand;
        private ICommand _logudCommand;

        #endregion

        #region Get Set properties
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
        /// Bruger
        /// </summary>
        public BrugerHandler BrugerHandler { get; set; }


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
        public ObservableCollection<Ansatte> AnsatteCollection
        {
            get { return _ansatteSingleton.Collection; }
            set { _ansatteSingleton.Collection = value; }
        }

        /// <summary>
        /// Liste med stillinger
        /// </summary>
        public List<Stillinger> StillingerListe
        {
            get { return _stillingerListe; }
            set { _stillingerListe = value; }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Logger brugeren ind
        /// </summary>
        public ICommand LogIndCommand
        {
            get
            {
                if (_logindCommand == null)
                {
                    _logindCommand = new RelayCommand(LogInd);
                }
                return _logindCommand;
            }
            set { _logindCommand = value; }
        }

        /// <summary>
        /// Logger brugeren ud
        /// </summary>
        public ICommand LogUdCommand
        {
            get
            {
                if (_logudCommand == null)
                {
                    _logudCommand = new RelayCommand(Hjaelpeklasse.LogUd);
                }
                return _logudCommand;
            }
            set { _logudCommand = value; }
        }

        /// <summary>
        /// Opretter bruger
        /// </summary>
        public ICommand OpretBrugerCommand
        {
            get
            {
                if (_opretBrugerCommand == null)
                {
                    _opretBrugerCommand = new RelayCommand(BrugerHandler.OpretBruger);
                }
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
                {
                    _redigerBrugerCommand = new RelayCommand(BrugerHandler.RedigerBruger);
                }
                return _redigerBrugerCommand;
            }
            set { _redigerBrugerCommand = value; }
        }

        #endregion

        /// <summary>
        /// Konstruktør for BrugerViewModel
        /// </summary>
        public BrugerViewModel()
        {
            Hjaelpeklasse.AabenForbindelse();
            _ansatteSingleton = GeneriskSingleton<Ansatte>.Instance();
            Setting = ApplicationData.Current.LocalSettings;
            Brugernavn = (string)Setting.Values["Brugernavn"];
            StillingerListe = new List<Stillinger>();

            Brugernavn = "Daniel";
            Password = "123456";

            var responce = PersistensFacade<Stillinger>.LoadDB("api/Stillingers");
            var query = from q in responce.Result
                        select q;
            foreach (var itemStillinger in query)
            {
                StillingerListe.Add(itemStillinger);
            }
            BrugerHandler = new BrugerHandler(this);
        }
        /// <summary>
        /// Logger brugeren ind
        /// </summary>
        public void LogInd()
        {
            try
            {
                AnsatteCollection.Clear();
                var responce = PersistensFacade<Ansatte>.LoadDB("api/Ansattes");

                var query = from q in responce.Result
                    where q.Brugernavn == Brugernavn && q.Password == Hjaelpeklasse.KrypterStreng(Password)
                    select q;
                foreach (var item in query)
                {
                    AnsatteCollection.Add(item);
                }
                if (AnsatteCollection.Any())
                {
                    Setting.Values["Brugernavn"] = AnsatteCollection[0].Brugernavn;
                    Setting.Values["StillingId"] = AnsatteCollection[0].StillingId;
                    var rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(Hovedmenu));
                }
                else
                {

                MessageDialog m = Hjaelpeklasse.FejlMeddelelse("Forkert brugernavn/password");
                m.ShowAsync();
                }

            }
            catch (ArgumentException ex)
            {
                if (AnsatteCollection.Any() == false)
                {
                    AnsatteCollection.Clear();
                }
                MessageDialog m = Hjaelpeklasse.FejlMeddelelse("Der kunne ikke udtrækkes fra databasen");
                m.ShowAsync();
            }
        }
    }
}
