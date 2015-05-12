using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
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
        /// Opretter ny vagt
        /// </summary>
        public void OpretVagt()
        {
            PersistensFacade<VagtplanView>.GemDB("api/Vagters", new VagtplanView(VagtplanViewModel.VagtplanView.Starttidspunkt, VagtplanViewModel.VagtplanView.Sluttidspunkt, VagtplanViewModel.VagtplanView.Ugenummer, VagtplanViewModel.Ugedag.UgedagId, VagtplanViewModel.Ansat.Brugernavn));

            MessageDialog m = new MessageDialog("Vagten blev tilføjet", "Succes!");
            m.ShowAsync();
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
        /// Redigere i eksisterende vagt
        /// </summary>
        public void RedigerVagt()
        {
            PersistensFacade<VagtplanView>.RedigerDB("api/Vagters", new VagtplanView(VagtplanViewModel.SelectedVagter.VagtId, VagtplanViewModel.VagtplanView.Starttidspunkt, VagtplanViewModel.VagtplanView.Sluttidspunkt, VagtplanViewModel.VagtplanView.Ugenummer, VagtplanViewModel.Ugedag.UgedagId, VagtplanViewModel.Ansat.Brugernavn), id: VagtplanViewModel.SelectedVagter.VagtId);

            MessageDialog m = new MessageDialog("Vagten blev redigeret", "Succes!");
            m.ShowAsync();
        }
        /// <summary>
        /// Sletter valgte vagt
        /// </summary>
        public async void SletVagt()
        {
            PersistensFacade<VagtplanView>.SletDB("api/Vagters", VagtplanViewModel.SelectedVagter.VagtId);
            
            VagtplanViewModel.ClearVagterCollections();
            VagtplanViewModel.InitialiserVagter();
        }
    }
}
