using System.Collections.ObjectModel;

namespace _1aarsproeve.Model
{
    public partial class Ugedage
    {
        /*public Ugedage(int ugedagId, string ugedag)
        {
            UgedagId = ugedagId;
            Ugedag = ugedag;
        }*/
        public int UgedagId { get; set; }
        public string Ugedag { get; set; }
        //public ObservableCollection<Vagter> VagtListe { get; set; }
    }
}
