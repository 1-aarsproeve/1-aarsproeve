using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace _1aarsproeve.Persistency
{
    class PersistencyFacade <T>
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

        /*public static async Task<IEnumerable<object>> LoadDB(string api, object objekt)
        {
            const string serverUrl = "http://localhost:7656/";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var response = client.GetAsync("api/Vagters").Result;
                if (response.IsSuccessStatusCode)
                {
                    var vagter = response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                }
            }
        }*/
    }
}
