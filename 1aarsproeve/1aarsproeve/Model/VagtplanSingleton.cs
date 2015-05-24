using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Windows.UI.Popups;
using _1aarsproeve.Annotations;
using _1aarsproeve.Persistens;
using _1aarsproeve.ViewModel;

namespace _1aarsproeve.Model
{
    /// <summary>
    /// Vagtplan Singleton klasse
    /// </summary>
    public class VagtplanSingleton : INotifyPropertyChanged
    {
        private static VagtplanSingleton _instance;
        private List<VagtplanView> _vagterListe; 
        private ObservableCollection<VagtplanView>[] _vagtCollectionsArray;
        private ObservableCollection<VagtplanView> _mandagCollection;
        private ObservableCollection<VagtplanView> _tirsdagCollection;
        private ObservableCollection<VagtplanView> _onsdagCollection;
        private ObservableCollection<VagtplanView> _torsdagCollection;
        private ObservableCollection<VagtplanView> _fredagCollection;
        private ObservableCollection<VagtplanView> _loerdagCollection;
        private ObservableCollection<VagtplanView> _soendagCollection;
        private int _ugenummer;
        /// <summary>
        /// Mandag-collection property
        /// </summary>
        public ObservableCollection<VagtplanView> MandagCollection
        {
            get { return _mandagCollection; }
            set { _mandagCollection = value; }
        }
        /// <summary>
        /// Tirsdag-collection property
        /// </summary>
        public ObservableCollection<VagtplanView> TirsdagCollection
        {
            get { return _tirsdagCollection; }
            set { _tirsdagCollection = value; }
        }
        /// <summary>
        /// Onsdag-collection property
        /// </summary>
        public ObservableCollection<VagtplanView> OnsdagCollection
        {
            get { return _onsdagCollection; }
            set { _onsdagCollection = value; }
        }
        /// <summary>
        /// Torsdag-collection property
        /// </summary>
        public ObservableCollection<VagtplanView> TorsdagCollection
        {
            get { return _torsdagCollection; }
            set { _torsdagCollection = value; }
        }
        /// <summary>
        /// Fredag-collection property
        /// </summary>
        public ObservableCollection<VagtplanView> FredagCollection
        {
            get { return _fredagCollection; }
            set { _fredagCollection = value; }
        }
        /// <summary>
        /// Lørdag-collection property
        /// </summary>
        public ObservableCollection<VagtplanView> LoerdagCollection
        {
            get { return _loerdagCollection; }
            set { _loerdagCollection = value; }
        }
        /// <summary>
        /// Søndag-collection property
        /// </summary>
        public ObservableCollection<VagtplanView> SoendagCollection
        {
            get { return _soendagCollection; }
            set { _soendagCollection = value; }
        }
        /// <summary>
        /// Samlet array af ugedage-collections
        /// </summary>
        public ObservableCollection<VagtplanView>[] VagtCollectionsArray
        {
            get { return _vagtCollectionsArray; }
            set { _vagtCollectionsArray = value; }
        }

        private VagtplanSingleton()
        {
            _vagterListe = new List<VagtplanView>();
            _mandagCollection = new ObservableCollection<VagtplanView>();
            _tirsdagCollection = new ObservableCollection<VagtplanView>();
            _onsdagCollection = new ObservableCollection<VagtplanView>();
            _torsdagCollection = new ObservableCollection<VagtplanView>();
            _fredagCollection = new ObservableCollection<VagtplanView>();
            _loerdagCollection = new ObservableCollection<VagtplanView>();
            _soendagCollection = new ObservableCollection<VagtplanView>();

            _vagtCollectionsArray = new ObservableCollection<VagtplanView>[7];
            _vagtCollectionsArray[0] = _mandagCollection;
            _vagtCollectionsArray[1] = _tirsdagCollection;
            _vagtCollectionsArray[2] = _onsdagCollection;
            _vagtCollectionsArray[3] = _torsdagCollection;
            _vagtCollectionsArray[4] = _fredagCollection;
            _vagtCollectionsArray[5] = _loerdagCollection;
            _vagtCollectionsArray[6] = _soendagCollection;

            FindUgenummer("da-DK");
            LoadVagter();
        }
        /// <summary>
        /// Instance metoden der definere singleton
        /// </summary>
        /// <returns>
        /// _instance som er et objekt af VagtplanSingleton
        /// </returns>
        public static VagtplanSingleton Instance()
        {
            if (_instance == null)
            {
                _instance = new VagtplanSingleton();
            }
            return _instance;
        }
        /// <summary>
        /// Liste property
        /// </summary>
        public List<VagtplanView> VagterListe
        {
            get { return _vagterListe; }
            set { _vagterListe = value; }
        }
        /// <summary>
        /// Loader vagter fra database
        /// </summary>
        public async void LoadVagter()
        {
            try
            {
                VagterListe.Clear();
                var vagter = await PersistensFacade<VagtplanView>.LoadDB("api/VagtplanViews");
                foreach (var item in vagter)
                {
                    VagterListe.Add(item);
                }
                for (int i = 0; i < _vagtCollectionsArray.Length; i++)
                {
                    var query =
                        from q in vagter
                        where q.UgedagId == i + 1 && q.Ugenummer == Ugenummer
                        orderby q.Starttidspunkt ascending, q.Sluttidspunkt
                        select q;
                    foreach (var item in query)
                    {
                        _vagtCollectionsArray[i].Add(item);
                    }
                }
            }
            catch (Exception)
            {
                MessageDialog m = Hjaelpeklasse.FejlMeddelelse("Der kunne udtrækkes fra databasen");
                m.ShowAsync();
            }
        }
        /// <summary>
        /// Ugenummer property
        /// </summary>
        public int Ugenummer
        {
            get { return _ugenummer; }
            set
            {
                _ugenummer = value;
                OnPropertyChanged("Ugenummer");
            }
        }
        /// <summary>
        /// Finder nuværende ugenummer
        /// </summary>
        /// <param name="kulturInfo">Angiver hvilket land</param>
        public void FindUgenummer(string kulturInfo)
        {
            var kultur = CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(kulturInfo);
            Ugenummer = kultur.Calendar.GetWeekOfYear(DateTime.Today, DateTimeFormatInfo.GetInstance(kultur).CalendarWeekRule, DateTimeFormatInfo.GetInstance(kultur).FirstDayOfWeek);
        }

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
