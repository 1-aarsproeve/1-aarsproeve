using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public ObservableCollection<ObservableCollection<Beskeder>> BeskedCollection
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
        /// Constructor for HovedViewModel
        /// </summary>

        public Visibility SkjulKnap { get; set; }
        public HovedViewModel()
        {
            Setting = ApplicationData.Current.LocalSettings;
            Brugernavn = (string)Setting.Values["Brugernavn"];
            _beskeder = new ObservableCollection<Beskeder>();
            BeskedCollection.Add(_beskeder);

            _beskeder.Add(new Beskeder(1, "MUS", new DateTime(), "hgfjjg", new DateTime(), "Daniel"));
            SkjulKnap = new Visibility();

            Stilling();

            LogUdCommand = new RelayCommand(LogUd);
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

        public void Stilling()
        {
            if (Brugernavn != "Daniel")
            {    
                SkjulKnap = Visibility.Collapsed;
            }
        }
    }
}