using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1aarsproeve.Model;
using _1aarsproeve.ViewModel;

namespace _1aarsproeve.Strategy
{
    /// <summary>
    /// Interface der ved implementering implementerer en sorteringsmetode
    /// </summary>
    public interface IVagtSort
    {
        void Sort(ObservableCollection<ObservableCollection<VagtplanView>> vagtCollection, int ugenummer);
    }
}