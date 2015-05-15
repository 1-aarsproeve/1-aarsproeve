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
    public class Hjaelpeklasse
    {
        /// <summary>
        /// Property til at skjule knapper
        /// </summary>
        public static Visibility SkjulKnap { get; set; }
        /// <summary>
        /// Konstruktør
        /// </summary>
        public Hjaelpeklasse()
        {
            SkjulKnap = new Visibility();
        }
        /// <summary>
        /// Viser MessageDialog ved succes
        /// </summary>
        /// <param name="meddelelse">Tager meddelelse som parameter</param>
        /// <returns>Returnerer dialogboksen</returns>
        public static MessageDialog SuccesMeddelelse(string meddelelse)
        {
            MessageDialog sm = new MessageDialog(meddelelse, "Handlingen blev gennemført!");
            return sm;
        }
        /// <summary>
        /// Viser MessageDialog ved fejl
        /// </summary>
        /// <param name="meddelelse">Tager meddelelse som parameter</param>
        /// <returns>Returnerer dialogboksen</returns>
        public static MessageDialog FejlMeddelelse(string meddelelse)
        {
            MessageDialog fm = new MessageDialog(meddelelse, "Ups, der skete en fejl!");
            return fm;
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