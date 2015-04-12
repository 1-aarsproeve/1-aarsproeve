using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace _1aarsproeve.Model
{
    public class VagtplanSingleton<T> where T : class
    {
        #region Members

        /// <summary>
        /// Static instance. Needs to use lambda expression
        /// to construct an instance (since constructor is private).
        /// </summary>
        private static readonly Lazy<T> sInstance = new Lazy<T>(() => CreateInstanceOfT());

        public ObservableCollection<Ugedage> Ugedage { get; set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance of this singleton.
        /// </summary>
        public static T Instance { get { return sInstance.Value; } }

        #endregion

        #region Methods

        /// <summary>
        /// Creates an instance of T via reflection since T's constructor is expected to be private.
        /// </summary>
        /// <returns></returns>
        private static T CreateInstanceOfT()
        {
            return Activator.CreateInstance(typeof(T), true) as T;
        }

        /*private VagtplanSingleton()
        {
            Ugedage = new ObservableCollection<Ugedage>()
            {
                new Ugedage {Ugedag = "Mandag", AnsatteListe = new ObservableCollection<Ansatte>()},
                new Ugedage {Ugedag = "Tirsdag", AnsatteListe = new ObservableCollection<Ansatte>()},
                new Ugedage {Ugedag = "Onsdag", AnsatteListe = new ObservableCollection<Ansatte>()},
                new Ugedage {Ugedag = "Torsdag", AnsatteListe = new ObservableCollection<Ansatte>()},
                new Ugedage {Ugedag = "Fredag", AnsatteListe = new ObservableCollection<Ansatte>()},
                new Ugedage {Ugedag = "Lørdag", AnsatteListe = new ObservableCollection<Ansatte>()},
                new Ugedage {Ugedag = "Søndag", AnsatteListe = new ObservableCollection<Ansatte>()},
            };

            Ugedage[0].AnsatteListe.Add(new Ansatte
            {
                Navn = "Daniel Winther",
                Tidspunkt = "16:00 - 19:50",
                Ugenummer = 15
            });
        }*/

        #endregion
    }
}
