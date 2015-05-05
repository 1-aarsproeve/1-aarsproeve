﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using _1aarsproeve.Model;
using _1aarsproeve.ViewModel;

namespace _1aarsproeve.Persistens
{
    /// <summary>
    /// Persistens-klasse der indeholder CRUD-funktioner
    /// </summary>
    /// <typeparam name="T">Generisk type</typeparam>
    class PersistensFacade<T>
    {
        /// <summary>
        /// Gemmer data i databasen
        /// </summary>
        /// <param name="api">Tager API-url som string</param>
        /// <param name="objekt">Tager objekt som skal gemmes</param>
        public static void GemDB(string api, object objekt)
        {
            HovedViewModel.Client.PostAsJsonAsync(api, objekt);
        }
        /// <summary>
        /// Sletter data i databasen
        /// </summary>
        /// <param name="api">Tager API-url som string</param>
        /// <param name="id">Tager ID som skal slettes</param>
        public static void DeleteDB(string api, int id)
        {
            HovedViewModel.Client.DeleteAsync(api + id);
        }
        /// <summary>
        /// Redigerer data i databasen
        /// </summary>
        /// <param name="api">Tager API-url som string</param>
        /// <param name="id">Tager ID som skal redigeres</param>
        /// <param name="objekt">Tager objekt som skal redigeres</param>
        public static void RedigerDB(string api, int id, object objekt)
        {
            HovedViewModel.Client.PutAsJsonAsync(api + id, objekt);
        }
        /// <summary>
        /// Henter data i databasen
        /// </summary>
        /// <param name="api">Tager API-url som string</param>
        public static async Task<List<T>> LoadDB(string api)
        {
            var response = HovedViewModel.Client.GetAsync(api).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<T>>().Result.ToList();
            }
            return null;
        }
    }
}