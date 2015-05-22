using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using _1aarsproeve.Persistens;
using _1aarsproeve.ViewModel;

namespace _1aarsproeve.Model
{
    /// <summary>
    /// Generisk Singleton Klasse
    /// </summary>
    /// <typeparam name="T">Generisk type</typeparam>
    public class GeneriskSingleton<T>
    {
        private static GeneriskSingleton<T> _instance;
        private ObservableCollection<T> _collection;
        private GeneriskSingleton()
        {
            _collection = new ObservableCollection<T>();
            LoadGenerisk();
        }

        /// <summary>
        /// Collection Property
        /// </summary>
        public ObservableCollection<T> Collection
        {
            get { return _collection; }
            set { _collection = value; }
        }

        /// <summary>
        /// Instance metoden der definere singleton
        /// </summary>
        /// <returns>
        /// _instance som er et objekt af GeneriskSingleton
        /// </returns>
        public static GeneriskSingleton<T> Instance()
        {
            if (_instance == null)
            {
                _instance = new GeneriskSingleton<T>();
            }
            return _instance;
        }

        public void LoadGenerisk()
        {
            var query = PersistensFacade<T>.LoadDB("api/" + typeof(T).Name + "s").Result;
            foreach (var item in query)
            {
                Collection.Add(item);   
            }
        }
    }
}