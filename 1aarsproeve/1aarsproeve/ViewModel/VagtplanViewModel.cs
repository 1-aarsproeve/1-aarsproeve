using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using _1aarsproeve.Annotations;
using _1aarsproeve.Common;
using _1aarsproeve.Model;
using _1aarsproeve.Strategy;
using _1aarsproeve.View;
using _1aarsproeve.Persistens;

namespace _1aarsproeve.ViewModel
{
    /// <summary>
    /// DataContext klasse til Views: OpretVagt, RedigerVagt, Vagtplan
    /// </summary>
    class VagtplanViewModel : INotifyPropertyChanged
    {
        private GeneriskSingleton<ObservableCollection<VagtplanView>> _vagtCollection = GeneriskSingleton<ObservableCollection<VagtplanView>>.Instance();
        private IVagtSort _vagtsort;
        /// <summary>
        /// Gør det muligt at gemme værdier i local storage
        /// </summary>
        public ApplicationDataContainer Setting { get; set; }
        /// <summary>
        /// Brugernavn property
        /// </summary>
        public string Brugernavn { get; set; }
        /// <summary>
        /// Sætter mandag til bestemt farve
        /// </summary>
        public Brush MandagFarve { get; set; }
        /// <summary>
        /// Sætter tirsdag til bestemt farve
        /// </summary>
        public Brush TirsdagFarve { get; set; }
        /// <summary>
        /// Sætter onsdag til bestemt farve
        /// </summary>
        public Brush OnsdagFarve { get; set; }
        /// <summary>
        /// Sætter torsdag til bestemt farve
        /// </summary>
        public Brush TorsdagFarve { get; set; }
        /// <summary>
        /// Sætter fredag til bestemt farve
        /// </summary>
        public Brush FredagFarve { get; set; }
        /// <summary>
        /// Sætter lørdag til bestemt farve
        /// </summary>
        public Brush LoerdagFarve { get; set; }
        /// <summary>
        /// Sætter søndag til bestemt farve
        /// </summary>
        public Brush SoendagFarve { get; set; }
        private int _ugenummer;
        private string _mandag;
        private string _tirsdag;
        private string _onsdag;
        private string _torsdag;
        private string _fredag;
        private string _loerdag;
        private string _soendag;
        /// <summary>
        /// Alle mandagsvagter
        /// </summary>
        public ObservableCollection<VagtplanView> MandagVagter;
        /// <summary>
        /// Alle tirsdagsvagter
        /// </summary>
        public ObservableCollection<VagtplanView> TirsdagVagter;
        /// <summary>
        /// Alle onsdagsvagter
        /// </summary>
        public ObservableCollection<VagtplanView> OnsdagVagter;
        /// <summary>
        /// Alle torsdagssvagter
        /// </summary>
        public ObservableCollection<VagtplanView> TorsdagVagter;
        /// <summary>
        /// Alle fredagsvagter
        /// </summary>
        public ObservableCollection<VagtplanView> FredagVagter;
        /// <summary>
        /// Alle lørdagsvagter
        /// </summary>
        public ObservableCollection<VagtplanView> LoerdagVagter;
        /// <summary>
        /// Alle søndagsvagter
        /// </summary>
        public ObservableCollection<VagtplanView> SoendagVagter;
        /// <summary>
        /// ForrigeUgeCommand property
        /// </summary>
        public ICommand ForrigeUgeCommand { get; set; }
        /// <summary>
        /// NaesteUgeCommand property
        /// </summary>
        public ICommand NaesteUgeCommand { get; set; }
        /// <summary>
        /// AlleVagterCommand property
        /// </summary>
        public ICommand AlleVagterCommand { get; set; }
        /// <summary>
        /// FrieVagterCommand property
        /// </summary>
        public ICommand FrieVagterCommand { get; set; }
        /// <summary>
        /// MineVagterCommand property
        /// </summary>
        public ICommand MineVagterCommand { get; set; }
        /// <summary>
        /// EksporterAlleCommand property
        /// </summary>
        public ICommand EksporterAlleCommand { get; set; }
        /// <summary>
        /// EksporterMineCommand property
        /// </summary>
        public ICommand EksporterMineCommand { get; set; }
        /// <summary>
        /// LogUdCommand property
        /// </summary>
        public ICommand LogUdCommand { get; set; }
        /// <summary>
        /// Constructor for VagtplanViewModel
        /// </summary>
        public VagtplanViewModel()
        {
            Setting = ApplicationData.Current.LocalSettings;
            Brugernavn = (string) Setting.Values["Brugernavn"];

            NuvaerendeUgedag(new SolidColorBrush(Color.FromArgb(255, 169, 169, 169)), new SolidColorBrush(Color.FromArgb(255, 184, 19, 35)));

            FindUgenummer("da-DK");
            Ugedage();

            MandagVagter = new ObservableCollection<VagtplanView>();
            TirsdagVagter = new ObservableCollection<VagtplanView>();
            OnsdagVagter = new ObservableCollection<VagtplanView>();
            TorsdagVagter = new ObservableCollection<VagtplanView>();
            FredagVagter = new ObservableCollection<VagtplanView>();
            LoerdagVagter = new ObservableCollection<VagtplanView>();
            SoendagVagter = new ObservableCollection<VagtplanView>();

            VagtCollection.Add(MandagVagter);
            VagtCollection.Add(TirsdagVagter);
            VagtCollection.Add(OnsdagVagter);
            VagtCollection.Add(TorsdagVagter);
            VagtCollection.Add(FredagVagter);
            VagtCollection.Add(LoerdagVagter);
            VagtCollection.Add(SoendagVagter);

            InitialiserVagter();

            ForrigeUgeCommand = new RelayCommand(ForrigeUge);
            NaesteUgeCommand = new RelayCommand(NaesteUge);

            AlleVagterCommand = new RelayCommand(AlleVagter);
            FrieVagterCommand = new RelayCommand(FrieVagter);
            MineVagterCommand = new RelayCommand(MineVagter);
            EksporterAlleCommand = new RelayCommand(EksporterAlleVagter);
            EksporterMineCommand = new RelayCommand(EksporterMineVagter);
            LogUdCommand = new RelayCommand(LogUd);

        }
        /// <summary>
        /// Eksporter alle vagter
        /// </summary>
        public async void EksporterAlleVagter()
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.Desktop;
            savePicker.FileTypeChoices.Add("Filformat", new List<string>() { ".ics", ".csv" });
            savePicker.SuggestedFileName = "vagtplan-alle-uge-" + Ugenummer;

            StorageFile fil = await savePicker.PickSaveFileAsync();
            if (fil != null)
            {
                CachedFileManager.DeferUpdates(fil);
                string vagter = "";
                const string emne = "Fakta - vagt";
                const string sted = "Jyderup";
                if (fil.FileType.Equals(".ics"))
                {
                    vagter +=
                     "BEGIN:VCALENDAR\n" +
                     "VERSION:2.0\n\n";
                    for (int i = 0; i < VagtCollection.Count; i++)
                    {
                        var query1 =
                            from q in VagtCollection[i]
                            where q.UgedagId == i + 1 && q.Ugenummer == Ugenummer
                            select new { q.Starttidspunkt, q.Sluttidspunkt };
                        foreach (var item in query1)
                        {
                            vagter +=
                                "BEGIN:VEVENT\n" +
                                "DTSTART:" + FoersteDagPaaUge(Ugenummer).AddDays(i).ToString("yyyyMMdd") + "T" + item.Starttidspunkt.ToString("hhmmss") + "\n" +
                                "DTEND:" + FoersteDagPaaUge(Ugenummer).AddDays(i).ToString("yyyyMMdd") + "T" + item.Sluttidspunkt.ToString("hhmmss") + "\n" +
                                "SUMMARY:" + emne + "\n" +
                                "LOCATION:" + sted + "\n" +
                                "END:VEVENT\n\n";
                        }
                    }
                    vagter += "END:VCALENDAR";
                }
                else
                {
                    vagter +=
                        "Subject, Start Date, Start Time, End Date, End Time, Location\n";
                    for (int i = 0; i < VagtCollection.Count; i++)
                    {
                        var query1 =
                            from q in VagtCollection[i]
                            where q.UgedagId == i + 1 && q.Ugenummer == Ugenummer && q.Brugernavn == Brugernavn
                            select new { q.Starttidspunkt, q.Sluttidspunkt };
                        foreach (var item in query1)
                        {
                            vagter +=
                                emne +
                                ", " + FoersteDagPaaUge(Ugenummer).AddDays(i).ToString("d") +
                                ", " + item.Starttidspunkt +
                                ", " + FoersteDagPaaUge(Ugenummer).AddDays(i).ToString("d") +
                                ", " + item.Sluttidspunkt +
                                ", " + sted + "\n";
                        }
                    }
                }
                await FileIO.WriteTextAsync(fil, vagter);
                FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(fil);
                if (status == FileUpdateStatus.Complete)
                {
                    MessageDialog m = new MessageDialog("Vagtplanen blev eksporteret som " + fil.FileType + "-fil", "Succes!");
                    m.ShowAsync();
                }
                else
                {
                    MessageDialog m = new MessageDialog("Der skete en fejl under eksporteringen - prøv igen", "Fejl!");
                    m.ShowAsync();
                }
            }
        }
        /// <summary>
        /// Eksporterer alle mine vagter
        /// </summary>
        public async void EksporterMineVagter()
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedStartLocation = PickerLocationId.Desktop;
            savePicker.FileTypeChoices.Add("Filformat", new List<string>() { ".ics", ".csv" });
            savePicker.SuggestedFileName = "vagtplan-mine-uge-" + Ugenummer;

            StorageFile fil = await savePicker.PickSaveFileAsync();
            if (fil != null)
            {
                CachedFileManager.DeferUpdates(fil);
                string vagter = "";
                const string emne = "Fakta - vagt";
                const string sted = "Jyderup";
                if (fil.FileType.Equals(".ics"))
                {
                    vagter +=
                     "BEGIN:VCALENDAR\n" +
                     "VERSION:2.0\n\n";
                    for (int i = 0; i < VagtCollection.Count; i++)
                    {
                        var query1 =
                            from q in VagtCollection[i]
                            where q.UgedagId == i + 1 && q.Ugenummer == Ugenummer && q.Brugernavn == Brugernavn
                            select new { q.Starttidspunkt, q.Sluttidspunkt };
                        foreach (var item in query1)
                        {
                            vagter +=
                                "BEGIN:VEVENT\n" +
                                "DTSTART:" + FoersteDagPaaUge(Ugenummer).AddDays(i).ToString("yyyyMMdd") + "T" + item.Starttidspunkt.ToString("hhmmss") + "\n" +
                                "DTEND:" + FoersteDagPaaUge(Ugenummer).AddDays(i).ToString("yyyyMMdd") + "T" + item.Sluttidspunkt.ToString("hhmmss") + "\n" +
                                "SUMMARY:" + emne + "\n" +
                                "LOCATION:" + sted + "\n" +
                                "END:VEVENT\n\n";
                        }
                    }
                    vagter += "END:VCALENDAR";
                }
                else
                {
                    vagter +=
                        "Subject, Start Date, Start Time, End Date, End Time, Location\n";
                    for (int i = 0; i < VagtCollection.Count; i++)
                    {
                        var query1 =
                            from q in VagtCollection[i]
                            where q.UgedagId == i + 1 && q.Ugenummer == Ugenummer && q.Brugernavn == Brugernavn
                            select new { q.Starttidspunkt, q.Sluttidspunkt };
                        foreach (var item in query1)
                        {
                            vagter +=
                                emne +
                                ", " + FoersteDagPaaUge(Ugenummer).AddDays(i).ToString("d") +
                                ", " + item.Starttidspunkt +
                                ", " + FoersteDagPaaUge(Ugenummer).AddDays(i).ToString("d") +
                                ", " + item.Sluttidspunkt +
                                ", " + sted + "\n";
                        }
                    }
                }
                await FileIO.WriteTextAsync(fil, vagter);
                FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(fil);
                if (status == FileUpdateStatus.Complete)
                {
                    MessageDialog m = new MessageDialog("Vagtplanen blev eksporteret som " + fil.FileType + "-fil", "Succes!");
                    m.ShowAsync();
                }
                else
                {
                    MessageDialog m = new MessageDialog("Der skete en fejl under eksporteringen - prøv igen", "Fejl!");
                    m.ShowAsync();
                }
            }
        }
        /// <summary>
        /// Clear alle collections
        /// </summary>
        public void ClearVagterCollections()
        {
            for (int i = 0; i < VagtCollection.Count; i++)
            {
                VagtCollection[i].Clear();
            }
        }
        /// <summary>
        /// Henter vagter for forrige uge
        /// </summary>
        public void ForrigeUge()
        {
            Ugenummer = Ugenummer - 1;

            if (Ugenummer < 1)
            {
                Ugenummer = 52;
            }
            Ugedage();
            ClearVagterCollections();
            InitialiserVagter();
        }
        /// <summary>
        /// Henter vagter for næste uge
        /// </summary
        public void NaesteUge()
        {
            Ugenummer = Ugenummer + 1;

            if (Ugenummer > 52)
            {
                Ugenummer = 1;
            }
            Ugedage();
            ClearVagterCollections();
            InitialiserVagter();
        }
        /// <summary>
        /// Sætter datoerne for hver ugedag
        /// </summary>
        public void Ugedage()
        {
            Mandag = FoersteDagPaaUge(Ugenummer).ToString("d. MMMM", new CultureInfo("da-DK"));
            Tirsdag = FoersteDagPaaUge(Ugenummer).AddDays(1).ToString("d. MMMM", new CultureInfo("da-DK"));
            Onsdag = FoersteDagPaaUge(Ugenummer).AddDays(2).ToString("d. MMMM", new CultureInfo("da-DK"));
            Torsdag = FoersteDagPaaUge(Ugenummer).AddDays(3).ToString("d. MMMM", new CultureInfo("da-DK"));
            Fredag = FoersteDagPaaUge(Ugenummer).AddDays(4).ToString("d. MMMM", new CultureInfo("da-DK"));
            Loerdag = FoersteDagPaaUge(Ugenummer).AddDays(5).ToString("d. MMMM", new CultureInfo("da-DK"));
            Soendag = FoersteDagPaaUge(Ugenummer).AddDays(6).ToString("d. MMMM", new CultureInfo("da-DK"));
        }

        /// <summary>
        /// Angiver farve på nuværende ugedag
        /// </summary>
        /// <param name="brush">Angiver farven som bliver vist på i dags ugedag</param>
        /// <param name="brushOriginal">Angiver farven som bliver vist på de ugedage som ikke er i dag</param>
        public void NuvaerendeUgedag(SolidColorBrush brush, SolidColorBrush brushOriginal)
        {
            if (MandagFarve == null || TirsdagFarve == null || OnsdagFarve == null || TorsdagFarve == null || FredagFarve == null || LoerdagFarve == null || SoendagFarve == null)
            {
                MandagFarve = brushOriginal;
                TirsdagFarve = brushOriginal;
                OnsdagFarve = brushOriginal;
                TorsdagFarve = brushOriginal;
                FredagFarve = brushOriginal;
                LoerdagFarve = brushOriginal;
                SoendagFarve = brushOriginal;
            }
            switch (DateTime.Now.ToString("dddd"))
            {
                case "Monday":
                    MandagFarve = brush;
                    break;
                case "Tuesday":
                    TirsdagFarve = brush;
                    break;
                case "Wednesday":
                    OnsdagFarve = brush;
                    break;
                case "Thursday":
                    TorsdagFarve = brush;
                    break;
                case "Friday":
                    FredagFarve = brush;
                    break;
                case "Saturday":
                    LoerdagFarve = brush;
                    break;
                case "Sunday":
                    SoendagFarve = brush;
                    break;
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
        /// <summary>
        /// Finder første dag på ugen
        /// </summary>
        /// <param name="ugePaaAaret">Angiver ugenummer</param>
        /// <returns></returns>
        public DateTime FoersteDagPaaUge(int ugePaaAaret)
        {
            DateTime jan1 = new DateTime(DateTime.Today.Year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime foersteTorsdag = jan1.AddDays(daysOffset);
            int firstWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(foersteTorsdag, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var ugenummer = ugePaaAaret;
            if (firstWeek <= 1)
            {
                ugenummer -= 1;
            }
            var resultat = foersteTorsdag.AddDays(ugenummer * 7);
            return resultat.AddDays(-3);
        }
        #region InitialiserVagter
        /// <summary>
        /// Initialisere vagter
        /// </summary>
        public async void InitialiserVagter()
        {
            ClearVagterCollections();

            var vagter = await PersistensFacade<VagtplanView>.LoadDB("api/VagtplanViews");
            for (int i = 0; i < VagtCollection.Count; i++)
            {
                var query =
                    from q in vagter
                    where q.UgedagId == i + 1 && q.Ugenummer == Ugenummer
                    orderby q.Starttidspunkt ascending
                    select q;
                foreach (var item in query)
                {
                    VagtCollection[i].Add(item);
                }
            }
        }
        #endregion
        /// <summary>
        /// Viser allevagter
        /// </summary>
        public void AlleVagter()
        {
            Vagter v = new Vagter() {VagtId = 17, Starttidspunkt = new TimeSpan(21, 00, 00), Sluttidspunkt = new TimeSpan(22, 00, 00), Ugenummer = 20, UgedagId = 3, Brugernavn = "Daniel"};
            PersistensFacade<Vagter>.RedigerDB("api/Vagters/", 17, v);

            ClearVagterCollections();

            _vagtsort = new AlleVagter();
            _vagtsort.Sort(VagtCollection, Ugenummer);
        }
        /// <summary>
        /// Viser frie vagter
        /// </summary>
        public void FrieVagter()
        {
            ClearVagterCollections();

            _vagtsort = new FrieVagter();
            _vagtsort.Sort(VagtCollection, Ugenummer);
        }
        /// <summary>
        /// Viser mine vagter
        /// </summary>
        public void MineVagter()
        {
            ClearVagterCollections();

            _vagtsort = new MineVagter();
            _vagtsort.Sort(VagtCollection, Ugenummer);
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
        /// Singleton vagtcollection
        /// </summary>
        public ObservableCollection<ObservableCollection<VagtplanView>> VagtCollection
        {
            get { return _vagtCollection.Collection; }
            set { _vagtCollection.Collection = value; }
        }
        /// <summary>
        /// Mandag property
        /// </summary>
        public string Mandag
        {
            get { return _mandag; }
            set
            {
                _mandag = value;
                OnPropertyChanged("Mandag");
            }
        }
        /// <summary>
        /// Tirsdag property
        /// </summary>
        public string Tirsdag
        {
            get { return _tirsdag; }
            set
            {
                _tirsdag = value;
                OnPropertyChanged("Tirsdag");
            }
        }
        /// <summary>
        /// Onsdag property
        /// </summary>
        public string Onsdag
        {
            get { return _onsdag; }
            set
            {
                _onsdag = value;
                OnPropertyChanged("Onsdag");
            }
        }
        /// <summary>
        /// Torsdag property
        /// </summary>
        public string Torsdag
        {
            get { return _torsdag; }
            set
            {
                _torsdag = value;
                OnPropertyChanged("Torsdag");
            }
        }
        /// <summary>
        /// Fredag property
        /// </summary>
        public string Fredag
        {
            get { return _fredag; }
            set
            {
                _fredag = value;
                OnPropertyChanged("Fredag");
            }
        }
        /// <summary>
        /// Lørdag property
        /// </summary>
        public string Loerdag
        {
            get { return _loerdag; }
            set
            {
                _loerdag = value;
                OnPropertyChanged("Loerdag");
            }
        }
        /// <summary>
        /// Søndag property
        /// </summary>
        public string Soendag
        {
            get { return _soendag; }
            set
            {
                _soendag = value;
                OnPropertyChanged("Soendag");
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
        /// Implementerer INotifyPropertyChanged interfacet
        /// </summary>
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