using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using _1aarsproeve.Model;
using _1aarsproeve.Persistens;
using _1aarsproeve.ViewModel;

namespace _1aarsproeve.Strategy
{
    /// <summary>
    /// Strategy klasse der implmenterer IVagtSort interfacet
    /// </summary>
    public class FrieVagter : IVagtSort
    {
        /// <summary>
        /// Sorterer vagterne udfra Mine vagter
        /// </summary>
        /// <param name="vagtCollection">Angiver hvilken collection der skal sorteres</param>
        /// <param name="ugenummer">Angiver for hvilken uge vagterne skal vises i</param>
        public async void Sort(ObservableCollection<ObservableCollection<VagtplanView>> vagtCollection, int ugenummer)
        {
            var vagter = await PersistensFacade<VagtplanView>.LoadDB("api/VagtplanViews");
            for (int i = 0; i < vagtCollection.Count; i++)
            {
                var query =
                    from q in vagter
                    where q.UgedagId == i + 1 && q.Ugenummer == ugenummer && q.Brugernavn == "Ubemandet"
                    orderby q.Starttidspunkt ascending
                    select q;
                foreach (var item in query)
                {
                    vagtCollection[i].Add(item);
                }
            }
        }
    }
}
