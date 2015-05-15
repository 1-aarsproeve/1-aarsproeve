using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
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
        /// Navn property
        /// </summary>
        public string Navn { get; set; }
        /// <summary>
        /// Brugernavn property
        /// </summary>
        public string Brugernavn { get; set; }
        /// <summary>
        /// Password property
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Postnummer property
        /// </summary>
        public string Postnummer { get; set; }
        /// <summary>
        /// Adresse property
        /// </summary>
        public string Adresse { get; set; }
        /// <summary>
        /// Mobil property
        /// </summary>
        public string Mobil { get; set; }
        /// <summary>
        /// Email property
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Stilling property
        /// </summary>
        public Stillinger Stilling { get; set; }

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
            MessageDialog m = new MessageDialog("", "Fejl!");
            var u = PersistensFacade<Ansatte>.LoadDB("api/Ansattes").Result;
            foreach (var ansatte in u)
            {
                if (ansatte.Brugernavn == Brugernavn)
                {
                    m.Content += "Brugernavnet findes allerede!\n";
                }
            }
            try
            {
                Ansatte.CheckNavn(Navn);
            }
            catch (Exception)
            {
                m.Content += "Navn er forkert!\n";
            }
            try
            {
                Ansatte.CheckBrugernavn(Brugernavn);
            }
            catch (Exception)
            {
                m.Content += "Brugernavn er forkert!\n";
            }
            try
            {
                Ansatte.CheckPassword(Password);
            }
            catch (Exception)
            {
                m.Content += "Password er forkert!\n";
            }
            try
            {
                Ansatte.CheckEmail(Email);
            }
            catch (Exception)
            {
                m.Content += "Email er forkert!\n";
            }
            try
            {
                Ansatte.CheckAdresse(Adresse);
            }
            catch (Exception)
            {
                m.Content += "Adresse er forkert!\n";
            }
            try
            {
                Ansatte.CheckPostnummer(Postnummer);
            }
            catch (Exception)
            {
                m.Content += "Postnummer er forkert!\n";
            }
            try
            {
                Ansatte.CheckMobil(Mobil);
            }
            catch (Exception)
            {
                m.Content += "Mobil er forkert!\n";
            }
            if (Stilling == null)
            {
                m.Content += "Vælg en stilling!\n";
            }
            if (m.Content != "")
            {
                m.ShowAsync();
            }
            else
            {
                PersistensFacade<Ansatte>.GemDB("api/Ansattes", new Ansatte(Brugernavn, Navn, Password, Email, Mobil, Adresse, Postnummer, Stilling.StillingId));

                MessageDialog me = new MessageDialog("Brugeren blev oprettet", "Succes!");
                me.ShowAsync();
            }
      
        }
        /// <summary>
        /// Metoder der retter profil
        /// </summary>
        public void RedigerBruger()
        {
            MessageDialog m = new MessageDialog("", "Fejl!");
            try
            {
                Ansatte.CheckNavn(Navn);
            }
            catch (Exception)
            {
                m.Content += "Navn er forkert!\n";
            }
            try
            {
                Ansatte.CheckPassword(Password);
            }
            catch (Exception)
            {
                m.Content += "Password er forkert!\n";
            }
            try
            {
                Ansatte.CheckEmail(Email);
            }
            catch (Exception)
            {
                m.Content += "Email er forkert!\n";
            }
            try
            {
                Ansatte.CheckAdresse(Adresse);
            }
            catch (Exception)
            {
                m.Content += "Adresse er forkert!\n";
            }
            try
            {
                Ansatte.CheckPostnummer(Postnummer);
            }
            catch (Exception)
            {
                m.Content += "Postnummer er forkert!\n";
            }
            try
            {
                Ansatte.CheckMobil(Mobil);
            }
            catch (Exception)
            {
                m.Content += "Mobil er forkert!\n";
            }
            if (m.Content != "")
            {
                m.ShowAsync();
            }
            else
            {
                PersistensFacade<Ansatte>.RedigerDB("api/Ansattes",
                    new Ansatte(BrugerViewModel.AnsatteCollection[0].Brugernavn,
                        BrugerViewModel.AnsatteCollection[0].Navn, BrugerViewModel.AnsatteCollection[0].Password,
                        BrugerViewModel.AnsatteCollection[0].Email, BrugerViewModel.AnsatteCollection[0].Mobil,
                        BrugerViewModel.AnsatteCollection[0].Adresse, BrugerViewModel.AnsatteCollection[0].Postnummer,
                        BrugerViewModel.AnsatteCollection[0].StillingId),
                    streng: BrugerViewModel.AnsatteCollection[0].Brugernavn);

                var rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(Hovedmenu));

                MessageDialog me = new MessageDialog("Din profil blev redigeret", "Succes!");
                me.ShowAsync();
            }
        }
    }
}
