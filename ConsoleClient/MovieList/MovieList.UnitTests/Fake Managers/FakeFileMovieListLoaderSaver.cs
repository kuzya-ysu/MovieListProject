using MovieList.Managers;
using Newtonsoft.Json;

namespace MovieList.UnitTests.Fake_Managers
{
    public class FakeFileMovieListLoaderSaver: IMovieListLoaderSaver
    {
        public string MovieListSave { get; set; }
        public void SaveMovieList ( MovieList movieList )
        {

            MovieListSave = JsonConvert.SerializeObject(movieList);
        }

        public MovieList LoadMovieList ()
        {
            return MovieListSave == null ? new MovieList() : JsonConvert.DeserializeObject<MovieList>(MovieListSave);
        }
    }
}