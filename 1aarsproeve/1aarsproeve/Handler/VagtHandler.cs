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
    public class VagtHandler
    {
        /// <summary>
        /// VagtId Property
        /// </summary>
        public int VagtId { get; set; }
        /// <summary>
        /// Starttidspunkt Property
        /// </summary>
        public TimeSpan Starttidspunkt { get; set; }
        /// <summary>
        /// Sluttidspunkt Property
        /// </summary>
        public TimeSpan Sluttidspunkt { get; set; }
        /// <summary>
        /// Ugenummer Property
        /// </summary>
        public int UgenumreListe { get; set; }
        /// <summary>
        /// UgedagId Property
        /// </summary>
        public int UgedagId { get; set; }
        /// <summary>
        /// Brugernavn Property
        /// </summary>
        public string Brugernavn { get; set; }

        public VagtplanViewModel VagtplanViewModel { get; set; }


        public VagtHandler(VagtplanViewModel vagtplanViewModel)
        {
            VagtplanViewModel = vagtplanViewModel;
        }

        public void OpretVagt()
        {
            PersistensFacade<Vagter>.GemDB("api/Vagters", new Vagter(VagtplanViewModel.Starttidspunkt, VagtplanViewModel.Sluttidspunkt, VagtplanViewModel.U, VagtplanViewModel.U1.UgedagId, VagtplanViewModel.A));
        }

        public void RedigerVagt(string brugernavn, TimeSpan starttidspunkt, TimeSpan sluttidspunkt, int ugedagId,
            int ugenummer, int vagtId)
        {
            
        }

        public void
        SletVagt(Vagter vagt)
        {
            PersistensFacade<Vagter>.SletDB("api/Vagters/",  1);
        }
    }
}
