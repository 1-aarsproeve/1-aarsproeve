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
        private ICommand _logUdCommand;
        private GeneriskSingleton<HovedmenuView> _beskedCollection = GeneriskSingleton<HovedmenuView>.Instance();

        #region Get Set properties

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
        /// Hovedhandler property
        /// </summary>
        public HovedHandler HovedHandler { get; set; }
        /// <summary>
        /// SkjulKnap property
        /// </summary>
        public Visibility SkjulKnap { get; set; }
        #endregion

        /// <summary>
        /// Constructor for HovedViewModel
        /// </summary>
        public HovedViewModel()
        {
            Setting = ApplicationData.Current.LocalSettings;

            Brugernavn = (string)Setting.Values["Brugernavn"];
            SkjulKnap = HjaelpeKlasse.Stilling((int)Setting.Values["StillingId"]);
            
            BeskedCollection.Clear();
            var query = PersistensFacade<HovedmenuView>.LoadDB("api/HovedmenuViews").Result;
            var query1 =
                from q in query
                orderby q.Dato descending 
                select q;
            foreach (var item in query1)
            {
                BeskedCollection.Add(item);
            }

            HovedHandler = new HovedHandler(this);
        }

        #region Commands

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
        public ICommand LogUdCommand
        {
            get
            {
                if (_logUdCommand == null)
                    _logUdCommand = new RelayCommand(HjaelpeKlasse.LogUd);
                return _logUdCommand;
            }
            set { _logUdCommand = value; }
        }
       
        #endregion
    }
}