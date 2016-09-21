using CinePlazaApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CinePlazaApp.functions
{
    class ProcessaHTTP
    {
        private static string URL_CINEPLAZAAPI = "http://cineplazabqapi.herokuapp.com/movies";

        public static async Task<Movies> processaAPI()
        {
            Movies movies = null;
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(new Uri(URL_CINEPLAZAAPI));
            var buffer = await response.Content.ReadAsByteArrayAsync();
            var byteArray = buffer.ToArray();
            string resposta = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
            
            movies = JsonConvert.DeserializeObject<Movies>(resposta);

            return movies;
        }
    }
}
