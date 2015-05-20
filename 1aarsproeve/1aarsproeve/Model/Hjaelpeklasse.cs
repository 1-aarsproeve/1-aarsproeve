using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage;
using Windows.Storage.Streams;
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
        private static HttpClient _client;
        /// <summary>
        /// Get til klienten til forbindelsen til databasen
        /// </summary
        public static HttpClient Client
        {
            get { return _client; }
        }
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
            MessageDialog fm = new MessageDialog(meddelelse, "Ups, der opstod en fejl!");
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
        /// <summary>
        /// Åbner forbindelsen til database
        /// </summary>
        public static void AabenForbindelse()
        {
            try
            {
                const string serverUrl = "http://localhost:9999/";
                HttpClientHandler handler = new HttpClientHandler();
                handler.UseDefaultCredentials = true;
                _client = new HttpClient(handler);
                _client.BaseAddress = new Uri(serverUrl);
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch (Exception)
            {
                MessageDialog m = FejlMeddelelse("Der kunne ikke oprettes forbindelse til databasen");
                m.ShowAsync();
            }
        }
        /// <summary>
        /// Krypterer streng med MD5-hashalgoritme
        /// </summary>
        /// <param name="streng">Tager streng som parameter</param>
        /// <returns>Returnerer krypteret streng</returns>
        public static string KrypterStreng(string streng)
        {
            const string salt = "WmkqCmP4y4oi483xXOnb";
            var alg = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Md5);
            IBuffer buff = CryptographicBuffer.ConvertStringToBinary(streng + salt, BinaryStringEncoding.Utf8);
            var hashed = alg.HashData(buff);
            var resultat = CryptographicBuffer.EncodeToHexString(hashed);
            return resultat;
        }
    }
}