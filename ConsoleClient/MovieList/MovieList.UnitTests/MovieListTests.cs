using Xunit;
using System.Text;
using MovieList.Exceptions;

namespace MovieList.UnitTests
{
    public class MovieListTests
    {
        private readonly MovieList _movieList;

        public MovieListTests ()
        {
            _movieList = new MovieList();
            _movieList.CreateTitle("A", 10);
        }

        [Fact]
        public void CreateTitleWorksCorrectly ()
        {
            _movieList.CreateTitle("B", 9);

            Assert.Equal(2,_movieList.Titles.Count);
            Assert.Equal("2. B - 9", _movieList.Titles[1].ToString());
            Assert.Equal(3, _movieList.NextId);
        }

        [Fact]
        public void DeleteTitleWorksCorrectly ()
        {
            _movieList.DeleteTitle(1);

            Assert.Empty(_movieList.Titles);
        }

        [Fact]
        public void UpdateNameWorksCorrectly ()
        {
            _movieList.UpdateName(1, "B");

            Assert.Equal("B",_movieList.Titles[0].Name);
        }

        [Fact]
        public void UpdateRatingWorksCorrectly ()
        {
            _movieList.UpdateRating(1, 9);

            Assert.Equal(9, _movieList.Titles[0].Rating);
        }

        [Fact]
        public void ToStringReturnsCorrectValue ()
        {
            _movieList.CreateTitle("B", 9);
            _movieList.CreateTitle("C", 8);
            var result = new StringBuilder();
            result.AppendLine("1. A - 10");
            result.AppendLine("2. B - 9");
            result.AppendLine("3. C - 8");

            Assert.Equal(result.ToString(), _movieList.ToString());
        }

        [Fact]
        public void DeleteThrowsAnExceptionIfTitleDoesNotExist ()
        {
            var exception = Assert.Throws<NotFoundException>(() => _movieList.DeleteTitle(2));
            Assert.Equal("Title with that number does not exist", exception.Message);
        }

        [Fact]
        public void UpdateNameThrowsAnExceptionIfTitleDoesNotExist ()
        {
            var exception = Assert.Throws<NotFoundException>(() => _movieList.UpdateName(2, "B"));
            Assert.Equal("Title with that number does not exist", exception.Message); 
        }
        
        [Fact]
        public void UpdateRatingThrowsAnExceptionIfTitleDoesNotExist ()
        {
            var exception = Assert.Throws<NotFoundException>(() => _movieList.UpdateRating(2, 9));
            Assert.Equal("Title with that number does not exist", exception.Message);
        }
    }
}