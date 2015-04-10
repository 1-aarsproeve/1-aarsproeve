using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1aarsproeve.Model
{
    public class Singleton<T>
    {
        private static Singleton<T> _instance;
        private ObservableCollection<T> _lol;
    }
}
