using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using _1aarsproeve.View;

namespace _1aarsproeve.Model
{
    /// <summary>
    /// Hjælpeklasse indeholdende statiske metoder
    /// </summary>
    public class HjaelpeKlasse
    {
        
        private static ApplicationDataContainer Setting { get; set; }

        public HjaelpeKlasse()
        {
            StillingsId = (int)Setting.Values["StillingId"];
            SkjulKnap = new Visibility();
        }
        /// <summary>
        /// StillingId property
        /// </summary>
        public static int StillingsId { get; set; }
        /// <summary>
        /// Property til at skjule knapper
        /// </summary>
        public static Visibility SkjulKnap { get; set; }
        /// <summary>
        /// Logger brugeren ud
        /// </summary>
        public static void LogUd()
        {
            //AnsatteCollection.Clear();
            Setting.Values.Remove("Brugernavn");
            Setting.Values.Remove("StillingId");

            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Login));

        }
        /// <summary>
        /// Collapser knapper alt efter stilling
        /// </summary>
        public static void Stilling()
        {
            if (StillingsId != 1)
            {
                SkjulKnap = Visibility.Collapsed;
            }
        }
    }
}
