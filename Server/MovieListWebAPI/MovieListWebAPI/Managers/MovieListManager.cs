using System.Collections.Generic;
using MovieListWebAPI.Models;

namespace MovieListWebAPI.Managers
{
    public class MovieListManager
    {
        private readonly MovieList _movieList;
        private readonly IMovieListLoaderSaver _movieListLoaderSaver;

        public MovieListManager(IMovieListLoaderSaver movieListLoaderSaver)
        {
            _movieListLoaderSaver = movieListLoaderSaver;
            _movieList = _movieListLoaderSaver.LoadMovieList();
        }

        public IEnumerable<Title> GetMovieList()
        {
            return _movieList.Titles;
        }

        public Title GetTitle(int titleId)
        {
            return _movieList.GetTitle(titleId);
        }

        public void CreateTitle(Title title)
        {
            _movieList.CreateTitle(title);

            SaveMovieList();
        }

        public void DeleteTitle(int titleId)
        {
            _movieList.DeleteTitle(titleId);

            SaveMovieList();
        }

        public void UpdateTitle(int titleId, Title title)
        {
            if (title.Rating != 0)
            {
                _movieList.UpdateRating(titleId, title.Rating);
            }
            
            if (title.Name != null)
            {
                _movieList.UpdateName(titleId, title.Name);
            }

            SaveMovieList();
        }

        private void SaveMovieList()
        {
            _movieListLoaderSaver.SaveMovieList(_movieList);
        }
    }
}
