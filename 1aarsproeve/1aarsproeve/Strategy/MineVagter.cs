using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using _1aarsproeve.ViewModel;

namespace _1aarsproeve.Strategy
{
    public class MineVagter : IVagtSort
    {
        public ApplicationDataContainer Setting { get; set; }
        public string Brugernavn { get; set; }

        public MineVagter()
        {
            Setting = ApplicationData.Current.LocalSettings;

            Brugernavn = (string)Setting.Values["Brugernavn"];
        }

        public void Sort(ObservableCollection<Ugedage> UgedageCollection)
        {
            UgedageCollection[0].AnsatteListe.Add(new Ansatte
            {
                Navn = "Daniel Winther",
                Tidspunkt = "16:00 - 19:50"
            });
            UgedageCollection[4].AnsatteListe.Add(new Ansatte
            {
                Navn = "Ubemandet",
                Tidspunkt = "15:00 - 18:10"
            });
            for (int i = 0; i < UgedageCollection.Count; i++)
            {
                var query =
                    from u in UgedageCollection[i].AnsatteListe.ToList()
                    where u.Navn == Brugernavn
                    orderby u.Tidspunkt, u.Navn ascending
                    select u;
                UgedageCollection[i].AnsatteListe.Clear();

                foreach (var ansatte in query)
                {
                    UgedageCollection[i].AnsatteListe.Add(ansatte);
                }
            }
        }
    }
}
