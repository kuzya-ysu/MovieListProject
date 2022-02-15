using System;
using System.IO;
using MovieListWebAPI.Managers;
using MovieListWebAPI.Models;
using Xunit;

namespace MovieListWebAPI.UnitTests
{
    public class FileMovieListLoaderSaverTests: IDisposable
    {
        private const string FileName = "MovieListTest.txt";
        private readonly FileMovieListLoaderSaver _fileMovieListLoaderSaver = new FileMovieListLoaderSaver(FileName);
        private readonly MovieList _movieList;

        public FileMovieListLoaderSaverTests ()
        {
            _movieList = new MovieList();
        }

        [Fact]
        public void FileMovieListLoaderSaverWorksCorrectly ()
        {
            _movieList.CreateTitle(new Title { Id = _movieList.NextId, Name = "A", Rating = 10 });
            _movieList.CreateTitle(new Title { Id = _movieList.NextId, Name = "B", Rating = 8 });
            _movieList.CreateTitle(new Title { Id = _movieList.NextId, Name = "C", Rating = 5 });
            
            _fileMovieListLoaderSaver.SaveMovieList(_movieList);
            var loadedMovieList = _fileMovieListLoaderSaver.LoadMovieList();

            Assert.Equal(_movieList.ToString(), loadedMovieList.ToString());
        }

        [Fact]
        public void FileMovieListLoaderSaverWorksCorrectlyWithoutFile ()
        {
            var loadedMovieList = _fileMovieListLoaderSaver.LoadMovieList();

            Assert.Empty(loadedMovieList.Titles);
        }

        public void Dispose ()
        {
            File.Delete(FileName);
        }
    }
}