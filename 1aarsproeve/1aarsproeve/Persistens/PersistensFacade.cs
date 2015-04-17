using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using _1aarsproeve.Model;

namespace _1aarsproeve.Persistens
{
    class PersistensFacade<T>
    {
        public static async void GemDB(string api, object objekt)
        {
            const string serverUrl = "http://localhost:7656";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.PostAsJsonAsync(api, objekt).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageDialog m = new MessageDialog("den gik igennem!");
                    m.ShowAsync();
                }

            }
        }

        public static async Task<List<T>> LoadDB(string api)
        {
            const string serverUrl = "http://localhost:7656/";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(api).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<T>>().Result.ToList();
                }
                return null;
            }
        }
    }
}
