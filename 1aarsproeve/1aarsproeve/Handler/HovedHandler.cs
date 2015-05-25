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
    /// Handler-klasser der håndterer operationer for BeskedModel
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
        /// <param name="a">Tager AnmodningModel som objekt</param>
        public void SetSelectedAnmodning(AnmodningModel a)
        {
            HovedViewModel.SelectedAnmodning = a;
        }
        /// <summary>
        /// Skriver ny besked
        /// </summary>
        public void SkrivBesked()
        {
            MessageDialog m = Hjaelpeklasse.FejlMeddelelse("");
            try
            {
                BeskedModel.CheckOverskrift(Overskrift);
            }
            catch (Exception)
            {
                m.Content += "Overskrift er forkert!\n";
            }
            try
            {
                BeskedModel.CheckBeskrivelse(Beskrivelse);
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

                PersistensFacade<BeskedModel>.GemDB("api/Beskeders", new BeskedModel(Overskrift, new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day), Beskrivelse, new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, DateTime.Today.Day), HovedViewModel.Brugernavn));
                HovedViewModel.BeskedCollection.Add(new BeskedModel(Overskrift, new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day), Beskrivelse, new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, DateTime.Today.Day), HovedViewModel.Brugernavn, BrugerViewModel.AnsatteCollection[0]));
                
                var rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(Hovedmenu));
            }

        }
        /// <summary>
        /// Accepterer vagtanmodning
        /// </summary>
        public void AccepterAnmodning()
        {
            PersistensFacade<VagtModel>.RedigerDB("api/Vagters", new VagtModel(HovedViewModel.SelectedAnmodning.VagtId, HovedViewModel.SelectedAnmodning.Starttidspunkt, HovedViewModel.SelectedAnmodning.Sluttidspunkt, HovedViewModel.SelectedAnmodning.Ugenummer, HovedViewModel.SelectedAnmodning.UgedagId, HovedViewModel.SelectedAnmodning.AnmodningBrugernavn), id: HovedViewModel.SelectedAnmodning.VagtId);
            PersistensFacade<AnmodningModel>.SletDB("api/Anmodningers", id: HovedViewModel.SelectedAnmodning.AnmodningId);

            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof (Anmodninger));
        }
        /// <summary>
        /// Annullerer vagtanmodning
        /// </summary>
        public void AnnullerAnmodning()
        {
            PersistensFacade<AnmodningModel>.SletDB("api/Anmodningers", id: HovedViewModel.SelectedAnmodning.AnmodningId);
            
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Anmodninger));
        }
    }
}