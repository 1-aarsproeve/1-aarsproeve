using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using _1aarsproeve.Model;
using _1aarsproeve.Persistens;
using _1aarsproeve.View;
using _1aarsproeve.ViewModel;

namespace _1aarsproeve.Handler
{
    /// <summary>
    /// BrugerHandler klassen
    /// </summary>
    public class BrugerHandler
    {
        /// <summary>
        /// VagtplanViewModel property
        /// </summary>
        public BrugerViewModel BrugerViewModel { get; set; }
        /// <summary>
        /// BrugerHandler konstruktør
        /// </summary>
        /// <param name="brugerViewModel">BrugerViewModel objekt parameter</param>
        public BrugerHandler(BrugerViewModel brugerViewModel)
        {
            BrugerViewModel = brugerViewModel;
        }
        /// <summary>
        /// Metode der opretter en bruger
        /// </summary>
        public void OpretBruger()
        {
            PersistensFacade<Ansatte>.GemDB("api/Ansattes", new Ansatte(BrugerViewModel.Ansat.Brugernavn, BrugerViewModel.Ansat.Navn, BrugerViewModel.Ansat.Password, BrugerViewModel.Ansat.Email, BrugerViewModel.Ansat.Mobil, BrugerViewModel.Ansat.Adresse, BrugerViewModel.Ansat.Postnummer, BrugerViewModel.Ansat.StillingId));
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Hovedmenu));
        }

        public void RedigerBruger()
        {
            Ansatte a = new Ansatte(BrugerViewModel.AnsatteCollection[0].Brugernavn, BrugerViewModel.AnsatteCollection[0].Navn, BrugerViewModel.AnsatteCollection[0].Password, BrugerViewModel.AnsatteCollection[0].Email, BrugerViewModel.AnsatteCollection[0].Mobil, BrugerViewModel.AnsatteCollection[0].Adresse, BrugerViewModel.AnsatteCollection[0].Postnummer, BrugerViewModel.AnsatteCollection[0].StillingId);
            //PersistensFacade<Ansatte>.RedigerDB("api/Ansattes", BrugerViewModel.AnsatteCollection[0].Brugernavn, a);
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Hovedmenu));
        }
    }
}
