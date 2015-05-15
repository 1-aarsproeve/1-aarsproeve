using System;
using System.Collections.Generic;
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
            MessageDialog m = new MessageDialog("", "Fejl!");
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
                PersistensFacade<VagtplanView>.GemDB("api/Vagters", new VagtplanView(Starttidspunkt, Sluttidspunkt, Ugenummer, Ugedag.UgedagId, Ansat.Brugernavn));

                MessageDialog me = new MessageDialog("Vagten blev tilføjet", "Succes!");
                me.ShowAsync();
            }

        }
        /// <summary>
        /// Navigerer til RedigerVagt view
        /// </summary>
        public void NavigerRedigerVagt()
        {
            if (VagtplanViewModel.SelectedVagter == null)
            {
                MessageDialog m = new MessageDialog("Vælg en vagt der skal redigeres", "Fejl!");
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
            MessageDialog m = new MessageDialog("", "Fejl!");
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
                PersistensFacade<VagtplanView>.RedigerDB("api/Vagters", new VagtplanView(VagtplanViewModel.SelectedVagter.VagtId, Starttidspunkt, Sluttidspunkt, Ugenummer, Ugedag.UgedagId, Ansat.Brugernavn), id: VagtplanViewModel.SelectedVagter.VagtId);

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
                MessageDialog m = new MessageDialog("Vælg en vagt der skal slettes", "Fejl!");
                m.ShowAsync();
            }
            else
            {
                PersistensFacade<VagtplanView>.SletDB("api/Vagters", VagtplanViewModel.SelectedVagter.VagtId);

                var rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(Vagtplan));
            }
        }
        /// <summary>
        /// Anmoder om valgte vagt
        /// </summary>
        public void AnmodVagt()
        {
            if (VagtplanViewModel.SelectedVagter == null)
            {
                MessageDialog m = new MessageDialog("Vælg en vagt der skal slettes", "Fejl!");
                m.ShowAsync();
            }
            else if (VagtplanViewModel.SelectedVagter.Brugernavn == VagtplanViewModel.Brugernavn)
            {
                MessageDialog m = new MessageDialog("Du kan ikke anmode vagtskift med dig selv", "Fejl!");
                m.ShowAsync();
            }
            else
            {
                PersistensFacade<AnmodningerView>.GemDB("api/Anmodningers", new AnmodningerView(VagtplanViewModel.SelectedVagter.VagtId, VagtplanViewModel.Brugernavn));
                MessageDialog me = new MessageDialog("Du har anmodet om denne vagt", "Succes!");
                me.ShowAsync();
            }
        }
    }
}
