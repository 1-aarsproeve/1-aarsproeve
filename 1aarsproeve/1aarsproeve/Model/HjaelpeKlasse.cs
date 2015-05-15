using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
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
        /// <summary>
        /// Property til at skjule knapper
        /// </summary>
        public static Visibility SkjulKnap { get; set; }
        /// <summary>
        /// Konstruktør
        /// </summary>
        public HjaelpeKlasse()
        {
            SkjulKnap = new Visibility();
        }
        /// <summary>
        /// Logger brugeren ud
        /// </summary>
        public static void LogUd()
        {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Login));
        }
        /// <summary>
        /// Collapser knapper alt efter stilling
        /// </summary>
        /// <param name="stillingsId">Tager stillingsId som parameter</param>
        public static Visibility Stilling(int stillingsId)
        {
            if (stillingsId == 1)
            {
                SkjulKnap = Visibility.Visible;
            }
            else
            {
                SkjulKnap = Visibility.Collapsed;
            }
            return SkjulKnap;
        }
    }
}