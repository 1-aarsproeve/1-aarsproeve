using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using _1aarsproeve.ViewModel;

namespace _1aarsproeve.Strategy
{
    /// <summary>
    /// Strategy klasse der implmenterer IVagtSort interfacet
    /// </summary>
    public class MineVagter : IVagtSort
    {
        /// <summary>
        /// Gør det muligt at gemme værdier i local storage
        /// </summary>
        public ApplicationDataContainer Setting { get; set; }
        /// <summary>
        /// Brugernavn property
        /// </summary>
        public string Brugernavn { get; set; }
        /// <summary>
        /// Henter lokal variabel fra local storage
        /// </summary>
        public MineVagter()
        {
            Setting = ApplicationData.Current.LocalSettings;
            Brugernavn = (string)Setting.Values["Brugernavn"];
        }
        /// <summary>
        /// Sorterer vagterne udfra Mine vagter
        /// </summary>
        /// <param name="ugedageCollection">Angiver hvilken collection der skal sorteres</param>
        /// <param name="ugenummer">Angiver for hvilken uge vagterne skal vises i</param>
        public void Sort(ObservableCollection<Ugedage> ugedageCollection, int ugenummer)
        {
            ugedageCollection[0].AnsatteListe.Add(new Ansatte
            {
                Navn = "Daniel Winther",
                Tidspunkt = "16:00 - 19:50",
                Ugenummer = 15
            });
            ugedageCollection[4].AnsatteListe.Add(new Ansatte
            {
                Navn = "Ubemandet",
                Tidspunkt = "15:00 - 18:10",
                Ugenummer = 16
            });
            for (int i = 0; i < ugedageCollection.Count; i++)
            {
                var query =
                    from u in ugedageCollection[i].AnsatteListe.ToList()
                    where u.Navn == Brugernavn && u.Ugenummer == ugenummer
                    orderby u.Tidspunkt ascending
                    select u;
                ugedageCollection[i].AnsatteListe.Clear();

                foreach (var ansatte in query)
                {
                    ugedageCollection[i].AnsatteListe.Add(ansatte);
                }
            }
        }
    }
}
