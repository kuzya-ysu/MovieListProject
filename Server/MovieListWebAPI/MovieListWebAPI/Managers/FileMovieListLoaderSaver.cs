using System.IO;
using MovieListWebAPI.Models;
using Newtonsoft.Json;

namespace MovieListWebAPI.Managers
{
    public class FileMovieListLoaderSaver: IMovieListLoaderSaver
    {
        private readonly string _fileName;

        public FileMovieListLoaderSaver ( string fileName )
        {
            _fileName = fileName;
        }

        public void SaveMovieList(MovieList movieList)
        {
            File.WriteAllText(_fileName, JsonConvert.SerializeObject(movieList));
        }

        public MovieList LoadMovieList()
        {
            return !File.Exists(_fileName) ? new MovieList() : JsonConvert.DeserializeObject<MovieList>(File.ReadAllText(_fileName));
        }
    }
}