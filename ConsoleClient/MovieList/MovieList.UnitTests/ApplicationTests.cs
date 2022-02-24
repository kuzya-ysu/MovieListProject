using MovieList.UnitTests.Fake_Managers;
using System.Collections.Generic;
using Moq;
using MovieList.Managers;
using Xunit;

namespace MovieList.UnitTests
{
    public class ApplicationTests
    {
        private readonly FakeTextWriterReader _fakeTextWriterReader;
        public Application TestApplication { get; }

        public ApplicationTests ()
        {
            var mock = new Mock<IMovieListCommandManager>();
            _fakeTextWriterReader = new FakeTextWriterReader();
            
            TestApplication = new Application(_fakeTextWriterReader, mock.Object);
        }

        [Fact]
        public void MenuPrintsCorrectly ()
        {
            var expectedMenu = new List<string>
            {
                "",
                "1. Add title",
                "2. Change name",
                "3. Change rating",
                "4. Delete title",
                "5. Show list",
                "6. Exit",
                "",
                "Select menu option:"
            };
            _fakeTextWriterReader.TextInput.Add("6");

            TestApplication.ExecuteApp();

            Assert.Equal(expectedMenu.Count, _fakeTextWriterReader.TextOutput.Count);
            for (var i = 0; i < expectedMenu.Count; i++)
            {
                Assert.Equal(expectedMenu[i], _fakeTextWriterReader.TextOutput[i]);
            }
        }

        [Fact]
        public void TitleAddsCorrectly ()
        {
            _fakeTextWriterReader.TextInput.AddRange(new[] { "1", "A", "10", "6" });

            TestApplication.ExecuteApp();

            Assert.Equal("Enter the name", _fakeTextWriterReader.TextOutput[9]);
            Assert.Equal("Enter the rating", _fakeTextWriterReader.TextOutput[10]);
            Assert.Equal("", _fakeTextWriterReader.TextOutput[11]);
            Assert.Equal("Title added", _fakeTextWriterReader.TextOutput[12]);
        }

        [Fact]
        public void NameChangesCorrectly ()
        {
            _fakeTextWriterReader.TextInput.AddRange(new[] { "2", "1", "B", "6" });

            TestApplication.ExecuteApp();

            Assert.Equal("Enter title number", _fakeTextWriterReader.TextOutput[9]);
            Assert.Equal("Enter new name", _fakeTextWriterReader.TextOutput[10]);
            Assert.Equal("", _fakeTextWriterReader.TextOutput[11]);
            Assert.Equal("Name updated", _fakeTextWriterReader.TextOutput[12]);
        }

        [Fact]
        public void RatingChangesCorrectly ()
        {
            _fakeTextWriterReader.TextInput.AddRange(new[] { "3", "1", "9", "6" });

            TestApplication.ExecuteApp();

            Assert.Equal("Enter title number", _fakeTextWriterReader.TextOutput[9]);
            Assert.Equal("Enter new rating", _fakeTextWriterReader.TextOutput[10]);
            Assert.Equal("", _fakeTextWriterReader.TextOutput[11]);
            Assert.Equal("Rating updated", _fakeTextWriterReader.TextOutput[12]);
        }

        [Fact]
        public void TitleDeletesCorrectly ()
        {
            _fakeTextWriterReader.TextInput.AddRange(new[] { "4", "1", "6" });

            TestApplication.ExecuteApp();

            Assert.Equal("Enter title number", _fakeTextWriterReader.TextOutput[9]);
            Assert.Equal("", _fakeTextWriterReader.TextOutput[10]);
            Assert.Equal("Title deleted", _fakeTextWriterReader.TextOutput[11]);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("7")]
        [InlineData("0")]
        [InlineData("1.5")]
        public void ApplicationWorksCorrectlyIfMenuOptionSelectionIsInvalid ( string passedMenuOptionSelection )
        {
            _fakeTextWriterReader.TextInput.AddRange(new[] { passedMenuOptionSelection, "6" });

            TestApplication.ExecuteApp();

            Assert.Equal("Menu option has to be a whole number from 1 to 6", _fakeTextWriterReader.TextOutput[10]);
        }
    }
}
