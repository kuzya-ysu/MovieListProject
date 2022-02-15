using MovieListWebAPI.Models;

namespace MovieListWebAPI.Managers
{
    public interface IMovieListLoaderSaver
    {
        public void SaveMovieList(MovieList movieList);
        public MovieList LoadMovieList();    
    }
}
