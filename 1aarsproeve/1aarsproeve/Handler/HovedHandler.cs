

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using _1aarsproeve.Model;
using _1aarsproeve.Persistens;
using _1aarsproeve.View;
using _1aarsproeve.ViewModel;

namespace _1aarsproeve.Handler
{
    /// <summary>
    /// Handler-klasser der håndterer operationer for HovedmenuView
    /// </summary>
    public class HovedHandler
    {
        /// <summary>
        /// Overskrift property
        /// </summary>
        public string Overskrift { get; set; }
        /// <summary>
        /// Beskrivelse property
        /// </summary>
        public string Beskrivelse { get; set; }
        /// <summary>
        /// HovedViewModel property
        /// </summary>
        public HovedViewModel HovedViewModel { get; set; }
        /// <summary>
        /// HovedViewModel konstruktør
        /// </summary>
        /// <param name="hovedViewModel">HovedViewModel objekt parameter</param>
        public HovedHandler(HovedViewModel hovedViewModel)
        {
            HovedViewModel = hovedViewModel;
        }
        /// <summary>
        /// Set valgte anmodning
        /// </summary>
        /// <param name="a">Tager AnmodningerView som objekt</param>
        public void SetSelectedAnmodning(AnmodningerView a)
        {
            HovedViewModel.SelectedAnmodninger = a;
        }
        /// <summary>
        /// Skriver ny besked
        /// </summary>
        public void SkrivBesked()
        {
            MessageDialog m = new MessageDialog("", "Fejl!");
            try
            {
                HovedmenuView.CheckOverskrift(Overskrift);
            }
            catch (Exception)
            {
                m.Content += "Overskrift er forkert!\n";
            }
            try
            {
                HovedmenuView.CheckBeskrivelse(Beskrivelse);
            }
            catch (Exception)
            {
                m.Content += "Beskrivelse er forkert!\n";
            }
            if (m.Content != "")
            {
                m.ShowAsync();
            }
            else
            {
                PersistensFacade<HovedmenuView>.GemDB("api/Beskeders", new HovedmenuView(Overskrift, new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day), Beskrivelse, new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, DateTime.Today.Day), HovedViewModel.Brugernavn));

                var rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(Hovedmenu));
            }

        }
        /// <summary>
        /// Accepterer vagtanmodning
        /// </summary>
        public void AccepterAnmodning()
        {
            PersistensFacade<VagtplanView>.RedigerDB("api/Vagters", new VagtplanView(HovedViewModel.SelectedAnmodninger.VagtId, HovedViewModel.SelectedAnmodninger.Starttidspunkt, HovedViewModel.SelectedAnmodninger.Sluttidspunkt, HovedViewModel.SelectedAnmodninger.Ugenummer, HovedViewModel.SelectedAnmodninger.UgedagId, HovedViewModel.SelectedAnmodninger.AnmodningBrugernavn), id: HovedViewModel.SelectedAnmodninger.VagtId);
            PersistensFacade<AnmodningerView>.SletDB("api/Anmodningers", id: HovedViewModel.SelectedAnmodninger.AnmodningId);

            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof (Anmodninger));
        }
        /// <summary>
        /// Annullerer vagtanmodning
        /// </summary>
        public void AnnullerAnmodning()
        {
            PersistensFacade<AnmodningerView>.SletDB("api/Anmodningers", id: HovedViewModel.SelectedAnmodninger.AnmodningId);
            
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Anmodninger));
        }
    }
}