using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WordsDictionary.Models;

namespace WordsDictionary.Services
{
    public class WordsService : IWordsService
    {
        public string APIKey { get; set; }
        public WordsService(string apiKey)
        {
            APIKey = apiKey;
        }

        public async Task<Definition> GetDefinitionAsync(string word)
        {
            Definition result = new Definition();
            HttpClient client = new HttpClient();

            string uriString = $"https://wordsapiv1.p.rapidapi.com/words/{word}/definitions";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uriString),
                Headers = {
                    { "x-rapidapi-key", APIKey },
                    { "x-rapidapi-host", "wordsapiv1.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonPayload = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    result = await Task.Run(() =>
                           JsonConvert.DeserializeObject<Definition>(jsonPayload)
                        ).ConfigureAwait(false);
                }

                return result;
            }
        }

        public async Task<Synonym> GetInstanceAsync(string word)
        {
            Synonym result = new Synonym();
            HttpClient client = new HttpClient();

            string urlString = $"https://wordsapiv1.p.rapidapi.com/words/{word}/synonyms";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(urlString),
                Headers = {
                    { "x-rapidapi-key", APIKey },
                    { "x-rapidapi-host", "wordsapiv1.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonPayload = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    result = await Task.Run(() =>
                           JsonConvert.DeserializeObject<Synonym>(jsonPayload)
                        ).ConfigureAwait(false);
                }

                return result;
            }
        }

       
        public async Task<Category> GetCategory(string word)
        {
            Category categories = new Category();

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(Config.apiBaseAddress),
                DefaultRequestHeaders =
                {
                    { "x-rapidapi-key",  APIKey },
                    { "x-rapidapi-host", "wordsapiv1.p.rapidapi.com" }
                }
            };


            var response = await httpClient.GetAsync($"words/{word}/hasCategories").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!string.IsNullOrWhiteSpace(json))
            {

                categories = await Task.Run(() => JsonConvert.DeserializeObject<Category>(json)).ConfigureAwait(false);
                return categories;
            }

            return null;
        } 

    }
}
