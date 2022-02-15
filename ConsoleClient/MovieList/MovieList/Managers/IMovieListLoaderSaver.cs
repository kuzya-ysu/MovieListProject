namespace MovieList.Managers
{
    public interface IMovieListLoaderSaver
    {
        public void SaveMovieList(MovieList movieList);
        public MovieList LoadMovieList();    
    }
}
