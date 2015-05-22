using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Channels;
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
    /// Handler-klasser der håndterer vagtplanens operationer
    /// </summary>
    public class VagtHandler
    {
        /// <summary>
        /// Starttidspunkt property
        /// </summary>
        public TimeSpan Starttidspunkt { get; set; }
        /// <summary>
        /// Sluttidspunkt property
        /// </summary>
        public TimeSpan Sluttidspunkt { get; set; }
        /// <summary>
        /// Ugenummer property
        /// </summary>
        public int Ugenummer { get; set; }
        /// <summary>
        /// Ugedag property
        /// </summary>
        public Ugedage Ugedag { get; set; }
        /// <summary>
        /// Ansat property
        /// </summary>
        public Ansatte Ansat { get; set; }
        /// <summary>
        /// VagtplanViewModel property
        /// </summary>
        public VagtplanViewModel VagtplanViewModel { get; set; }
        /// <summary>
        /// VagtHandler konstruktør
        /// </summary>
        /// <param name="vagtplanViewModel">VagtplanViewModel objekt parameter</param>
        public VagtHandler(VagtplanViewModel vagtplanViewModel)
        {
            VagtplanViewModel = vagtplanViewModel;
        }
        /// <summary>
        /// Set valgte vagt
        /// </summary>
        /// <param name="v">Tager VagtplanView som objekt</param>
        public void SetSelectedVagt(VagtplanView v)
        {
            VagtplanViewModel.SelectedVagter = v;
        }
        /// <summary>
        /// Opretter ny vagt
        /// </summary>
        public void OpretVagt()
        {
            MessageDialog m = Hjaelpeklasse.SuccesMeddelelse("");
            if (Ansat == null)
            {
                m.Content += "Vælg en ansat\n";
            }
            if (Ugenummer == 0)
            {
                m.Content += "Vælg ugenummer\n";
            }
            if (Ugedag == null)
            {
                m.Content += "Vælg en ugedag\n";
            }
            if (m.Content != "")
            {
                m.ShowAsync();
            }
            else
            {
                PersistensFacade<VagtplanView>.GemDB("api/Vagters", new VagtplanView(Starttidspunkt, Sluttidspunkt, Ugenummer, Ugedag, Ansat));
                VagtplanView vagt = new VagtplanView(Starttidspunkt, Sluttidspunkt, Ugedag.UgedagId, Ugenummer, Ansat.Brugernavn, Ansat.Navn);

                VagtplanViewModel.VagtCollection.VagtCollectionsArray[Ugedag.UgedagId - 1].Add(vagt);
                
                MessageDialog m1 = Hjaelpeklasse.SuccesMeddelelse("Vagten blev tilføjet");
                m1.ShowAsync();
            }

        }
        /// <summary>
        /// Navigerer til RedigerVagt view
        /// </summary>
        public void NavigerRedigerVagt()
        {
            if (VagtplanViewModel.SelectedVagter == null)
            {
                MessageDialog m = Hjaelpeklasse.FejlMeddelelse("Vælg en vagt der skal redigeres");
                m.ShowAsync();
            }
            else
            {
                var rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(RedigerVagt));
            }
        }
        /// <summary>
        /// Redigere i eksisterende vagt
        /// </summary>
        public void RedigerVagt()
        {
            var m = Hjaelpeklasse.FejlMeddelelse("");
            if (Ansat == null)
            {
                m.Content += "Vælg en ansat\n";
            }
            if (VagtplanViewModel.SelectedVagter.Ugenummer == 0)
            {
                m.Content += "Vælg ugenummer\n";
            }
            if (Ugedag == null)
            {
                m.Content += "Vælg en ugedag\n";
            }
            if (m.Content != "")
            {
                m.ShowAsync();
            }
            else
            {
                PersistensFacade<VagtplanView>.RedigerDB("api/Vagters", new VagtplanView(VagtplanViewModel.SelectedVagter.VagtId, VagtplanViewModel.SelectedVagter.Starttidspunkt, VagtplanViewModel.SelectedVagter.Sluttidspunkt, VagtplanViewModel.SelectedVagter.Ugenummer, Ugedag.UgedagId, Ansat.Brugernavn), id: VagtplanViewModel.SelectedVagter.VagtId);
                VagtplanViewModel.VagtCollection.VagtCollectionsArray[VagtplanViewModel.SelectedVagter.UgedagId - 1].Remove(VagtplanViewModel.SelectedVagter);

                if (VagtplanViewModel.SelectedVagter.Ugenummer == VagtplanViewModel.VagtCollection.Ugenummer)
                {
                    VagtplanViewModel.VagtCollection.VagtCollectionsArray[Ugedag.UgedagId - 1].Add(new VagtplanView(VagtplanViewModel.SelectedVagter.Starttidspunkt, VagtplanViewModel.SelectedVagter.Sluttidspunkt, VagtplanViewModel.SelectedVagter.Ugenummer, Ugedag.UgedagId, Ansat.Brugernavn, Ansat.Navn));
                }
                
                var rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(Vagtplan));
            }
        }
        /// <summary>
        /// Sletter valgte vagt
        /// </summary>
        public void SletVagt()
        {
            if (VagtplanViewModel.SelectedVagter == null)
            {
                MessageDialog m = Hjaelpeklasse.FejlMeddelelse("Vælg en vagt der skal slettes");
                m.ShowAsync();
            }
            else
            {
                PersistensFacade<VagtplanView>.SletDB("api/Vagters", VagtplanViewModel.SelectedVagter.VagtId);
                switch (VagtplanViewModel.SelectedVagter.UgedagId)
                {
                    case 1:
                        VagtplanViewModel.VagtCollection.MandagCollection.Remove(VagtplanViewModel.SelectedVagter);
                        break;
                    case 2:
                        VagtplanViewModel.VagtCollection.TirsdagCollection.Remove(VagtplanViewModel.SelectedVagter);
                        break;
                    case 3:
                        VagtplanViewModel.VagtCollection.OnsdagCollection.Remove(VagtplanViewModel.SelectedVagter);
                        break;
                    case 4:
                        VagtplanViewModel.VagtCollection.TorsdagCollection.Remove(VagtplanViewModel.SelectedVagter);
                        break;
                    case 5:
                        VagtplanViewModel.VagtCollection.FredagCollection.Remove(VagtplanViewModel.SelectedVagter);
                        break;
                    case 6:
                        VagtplanViewModel.VagtCollection.LoerdagCollection.Remove(VagtplanViewModel.SelectedVagter);
                        break;
                    case 7:
                        VagtplanViewModel.VagtCollection.SoendagCollection.Remove(VagtplanViewModel.SelectedVagter);
                        break;
                }
            }
        }
        /// <summary>
        /// Anmoder om valgte vagt
        /// </summary>
        public void AnmodVagt()
        {
            if (VagtplanViewModel.SelectedVagter == null)
            {
                MessageDialog m = Hjaelpeklasse.FejlMeddelelse("Vælg en vagt du vil anmode om");
                m.ShowAsync();
            }
            else if (VagtplanViewModel.SelectedVagter.Brugernavn == VagtplanViewModel.Brugernavn)
            {
                MessageDialog m = Hjaelpeklasse.FejlMeddelelse("Du kan ikke anmode vagtskift med dig selv");
                m.ShowAsync();
            }
            else
            {
                PersistensFacade<AnmodningerView>.GemDB("api/Anmodningers", new AnmodningerView(VagtplanViewModel.SelectedVagter.VagtId, VagtplanViewModel.Brugernavn));
                
                MessageDialog m1 = Hjaelpeklasse.SuccesMeddelelse("Du har anmodet " + VagtplanViewModel.SelectedVagter.Navn + " om denne vagt");
                m1.ShowAsync();
            }
        }
    }
}
