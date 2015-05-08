using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using _1aarsproeve.Model;
using _1aarsproeve.Persistens;
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
            PersistensFacade<Vagter>.GemDB("api/Vagters", new Vagter(VagtplanViewModel.Starttidspunkt, VagtplanViewModel.Sluttidspunkt, VagtplanViewModel.Ugenumre, VagtplanViewModel.Ugedag.UgedagId, VagtplanViewModel.Ansat.Brugernavn));
        }
        /// <summary>
        /// Redigere i eksisterende vagt
        /// </summary>
        public void RedigerVagt()
        {
            PersistensFacade<Vagter>.RedigerDB("api/Vagters", 1, new Vagter());
        }
        /// <summary>
        /// Sletter valgte vagt
        /// </summary>
        public void SletVagt()
        {
            PersistensFacade<Vagter>.SletDB("api/Vagters/",  1);
        }
    }
}
