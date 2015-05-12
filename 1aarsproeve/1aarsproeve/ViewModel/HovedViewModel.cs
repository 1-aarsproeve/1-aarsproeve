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
        private ICommand _skrivBeskedCommand;
        private GeneriskSingleton<HovedmenuView> _beskedCollection = GeneriskSingleton<HovedmenuView>.Instance();
        /// <summary>
        /// Singleton vagtcollection
        /// </summary>
        public ObservableCollection<HovedmenuView> BeskedCollection
        {
            get { return _beskedCollection.Collection; }
            set { _beskedCollection.Collection = value; }
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
        /// Hovedhandler property
        /// </summary>
        public HovedHandler HovedHandler { get; set; }
        /// <summary>
        /// HovedmenuView property
        /// </summary>
        public HovedmenuView HovedmenuView { get; set; }
        /// <summary>
        /// StillingId property
        /// </summary>
        public int StillingsId { get; set; }
        /// <summary>
        /// Constructor for HovedViewModel
        /// </summary>
        public HovedViewModel()
        {
            Setting = ApplicationData.Current.LocalSettings;
            Brugernavn = (string)Setting.Values["Brugernavn"];
            StillingsId = (int)Setting.Values["StillingId"];

            BeskedCollection.Clear();
            var query = PersistensFacade<HovedmenuView>.LoadDB("api/HovedmenuViews").Result;
            foreach (var item in query)
            {
                BeskedCollection.Add(item);
            }
            
            SkjulKnap = new Visibility();

            Stilling();

            LogUdCommand = new RelayCommand(LogUd);
            HovedmenuView = new HovedmenuView();
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
            if (StillingsId != 1)
            {
                SkjulKnap = Visibility.Collapsed;
            }
        }
    }
}