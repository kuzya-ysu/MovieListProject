using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace MovieList.Managers
{
    public class HttpManager: IMovieListCommandManager
    {
        private readonly HttpClient _httpClient;
        private const string Uri = "https://localhost:44388/movielist/";

        public HttpManager ()
        {
            _httpClient = new HttpClient();
        }

        public List<Title> GetMovieList()
        {
            return JsonConvert.DeserializeObject<List<Title>>(_httpClient.GetStringAsync(Uri).Result);
        }

        public void CreateTitle ( Title title )
        {
            _httpClient.PostAsync(Uri, GetContent(title));
        }

        public void DeleteTitle ( int titleId )
        {
            _httpClient.DeleteAsync(Uri + titleId);
        }

        public void UpdateTitle ( int titleId, Title title )
        {
            _httpClient.PatchAsync(Uri + titleId, GetContent(title));
        }

        private static StringContent GetContent ( Title title )
        {
            return new StringContent(JsonConvert.SerializeObject(title), Encoding.UTF8, "application/json");
        }
    }
}
