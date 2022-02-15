using MovieList.Exceptions;
using MovieList.Managers;

namespace MovieList
{
    public class Application
    {
        private readonly IMovieListLoaderSaver _movieListLoaderSaver;
        private readonly ITextWriterReader _textWriterReader;

        public Application ( IMovieListLoaderSaver movieListLoaderSaver, ITextWriterReader textWriterReader )
        {
            _movieListLoaderSaver = movieListLoaderSaver;
            _textWriterReader = textWriterReader; //do fake classes
        }

        public void ExecuteApp ()
        {
            var movieList = _movieListLoaderSaver.LoadMovieList();
            var isQuitMenuOptionSelected = false;

            while (!isQuitMenuOptionSelected)
            {
                try
                {
                    HandleExecuteApp(movieList, out isQuitMenuOptionSelected);
                }
                catch (UserInputException ex)
                {
                    ShowResultMessage(ex.Message);
                }
                catch (NotFoundException ex)
                {
                    ShowResultMessage(ex.Message);
                }
                catch
                {
                    ShowResultMessage("Oops something went wrong");
                }
            }
        }

        private void HandleExecuteApp ( MovieList movieList, out bool isQuitMenuOptionSelected )
        {
            PrintMenu();
            var menuOptionSelection = GetMenuOptionSelection();
            isQuitMenuOptionSelected = false;

            switch (menuOptionSelection)
            {
                case 1:
                    {
                        AddTitle(movieList);
                        break;
                    }
                case 2:
                    {
                        UpdateName(movieList);
                        break;
                    }
                case 3:
                    {
                        UpdateRating(movieList);
                        break;
                    }
                case 4:
                    {
                        DeleteTitle(movieList);
                        break;
                    }
                case 5:
                    {
                        PrintMovieList(movieList);
                        break;
                    }
                case 6:
                    {
                        _movieListLoaderSaver.SaveMovieList(movieList);
                        isQuitMenuOptionSelected=true;
                        break;
                    }
            }
        }

        private void PrintMenu ()
        {
            _textWriterReader.WriteLine("");
            _textWriterReader.WriteLine("1. Add title");
            _textWriterReader.WriteLine("2. Change name");
            _textWriterReader.WriteLine("3. Change rating");
            _textWriterReader.WriteLine("4. Delete title");
            _textWriterReader.WriteLine("5. Show list");
            _textWriterReader.WriteLine("6. Exit");
            _textWriterReader.WriteLine("");
            _textWriterReader.WriteLine("Select menu option:");
        }

        private int GetMenuOptionSelection ()
        {
            var inputMenuOptionSelection = _textWriterReader.ReadLine();
            if (!int.TryParse(inputMenuOptionSelection, out var menuOptionSelection) || menuOptionSelection < 1 ||
                menuOptionSelection > 6)
                throw new UserInputException("Menu option has to be a whole number from 1 to 6");
            return menuOptionSelection;
        }

        private void AddTitle ( MovieList movieList )
        {
            var name = GetTitleName();
            var rating = GetTitleRating();
            movieList.CreateTitle(name, rating);
            ShowResultMessage("Title added");
        }

        private void UpdateName ( MovieList movieList )
        {
            var titleNumber = GetTitleNumber();
            var newName = GetTitleName(true);
            movieList.UpdateName(titleNumber, newName);
            ShowResultMessage("Name updated");
        }

        private void UpdateRating ( MovieList movieList )
        {
            var titleNumber = GetTitleNumber();
            var newRating = GetTitleRating(true);
            movieList.UpdateRating(titleNumber, newRating);
            ShowResultMessage("Rating updated");
        }

        private void DeleteTitle ( MovieList movieList )
        {
            var titleNumber = GetTitleNumber();
            movieList.DeleteTitle(titleNumber);
            ShowResultMessage("Title deleted");
        }

        private void PrintMovieList ( MovieList movieList )
        {
            ShowResultMessage(movieList.Titles.Count == 0 ? "List is empty" : movieList.ToString());
        }

        private int GetTitleNumber ()
        {
            _textWriterReader.WriteLine("Enter title number");
            var inputTitleNumber = _textWriterReader.ReadLine();
            if (!int.TryParse(inputTitleNumber, out var titleNumber))
                throw new UserInputException("Title number has to be a whole number");
            return titleNumber;
        }

        private string GetTitleName ( bool isNew = false )
        {
            _textWriterReader.WriteLine(isNew ? "Enter new name" : "Enter the name");
            return _textWriterReader.ReadLine();
        }

        private int GetTitleRating ( bool isNew = false )
        {
            _textWriterReader.WriteLine(isNew ? "Enter new rating" : "Enter the rating");
            var inputRating = _textWriterReader.ReadLine();
            if (!int.TryParse(inputRating, out var rating))
                throw new UserInputException("Rating has to be a whole number from 1 to 10");
            return rating;
        }

        private void ShowResultMessage ( string message )
        {
            _textWriterReader.WriteLine("");
            _textWriterReader.WriteLine(message);
        }
    }
}
