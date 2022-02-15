using Newtonsoft.Json;
using System.IO;

namespace MovieList.Managers
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