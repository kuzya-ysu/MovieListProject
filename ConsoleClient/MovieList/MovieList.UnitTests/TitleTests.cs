using MovieList.Exceptions;
using Xunit;

namespace MovieList.UnitTests
{
    public class TitleTests
    {
        private readonly Title _title;
        public TitleTests ()
        {
            _title = new Title("A", 10, 1);
        }

        [Fact]
        public void SetNameWorksCorrectly ()
        {
            _title.Name = "B";

            Assert.Equal("B",_title.Name);
        }

        [Fact]
        public void SetRatingWorksCorrectly ()
        {
            _title.Rating = 1;

            Assert.Equal(1, _title.Rating);
        }

        [Fact]
        public void ToStringReturnsCorrectValue ()
        {
            Assert.Equal($"{_title.Id}. {_title.Name} - {_title.Rating}", _title.ToString());
        }

        [Fact]
        public void SetNameThrowsAnExceptionIfPassedNameIsEmpty ()
        {
            var exception = Assert.Throws<UserInputException>(() => _title.Name = "");
            Assert.Equal("Name can't be empty", exception.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        public void SetRatingThrowsAnExceptionIfPassedRatingIsInvalid ( int passedRating )
        {
            var exception = Assert.Throws<UserInputException>(() => _title.Rating = passedRating);
            Assert.Equal("Rating has to be from 1 to 10", exception.Message);
        }
    }
}
