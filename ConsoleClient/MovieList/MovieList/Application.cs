using System.Collections.Generic;
using System.Text;
using MovieList.Exceptions;
using MovieList.Managers;

namespace MovieList
{
    public class Application
    {
        private readonly ITextWriterReader _textWriterReader;
        private readonly IMovieListCommandManager _movieListCommandManager;

        public Application ( ITextWriterReader textWriterReader, IMovieListCommandManager movieListCommandManager)
        {
            _textWriterReader = textWriterReader;
            _movieListCommandManager = movieListCommandManager;
        }

        public void ExecuteApp ()
        {
            var isQuitMenuOptionSelected = false;

            while (!isQuitMenuOptionSelected)
            {
                try
                {
                    HandleExecuteApp(out isQuitMenuOptionSelected);
                }
                catch (UserInputException ex)
                {
                    ShowResultMessage(ex.Message);
                }
                catch
                {
                    ShowResultMessage("Oops something went wrong");
                }
            }
        }

        private void HandleExecuteApp (out bool isQuitMenuOptionSelected )
        {
            PrintMenu();
            var menuOptionSelection = GetMenuOptionSelection();
            isQuitMenuOptionSelected = false;

            switch (menuOptionSelection)
            {
                case 1:
                    {
                        AddTitle();
                        break;
                    }
                case 2:
                    {
                        UpdateName();
                        break;
                    }
                case 3:
                    {
                        UpdateRating();
                        break;
                    }
                case 4:
                    {
                        DeleteTitle();
                        break;
                    }
                case 5:
                    {
                        PrintMovieList();
                        break;
                    }
                case 6:
                    {
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

        private void AddTitle ()
        {
            var name = GetTitleName();
            var rating = GetTitleRating();
            var title = new Title{ Name = name, Rating = rating };
            _movieListCommandManager.CreateTitle(title);
            ShowResultMessage("Title added");
        }

        private void UpdateName ()
        {
            var titleNumber = GetTitleNumber();
            var newName = GetTitleName(true);
            var title = new Title { Name = newName };
            _movieListCommandManager.UpdateTitle(titleNumber,title);
            ShowResultMessage("Name updated");
        }

        private void UpdateRating ()
        {
            var titleNumber = GetTitleNumber();
            var newRating = GetTitleRating(true);
            var title = new Title { Rating = newRating };
            _movieListCommandManager.UpdateTitle(titleNumber, title);
            ShowResultMessage("Rating updated");
        }

        private void DeleteTitle ()
        {
            var titleNumber = GetTitleNumber();
            _movieListCommandManager.DeleteTitle(titleNumber);
            ShowResultMessage("Title deleted");
        }

        private void PrintMovieList ()
        {
            var titles = _movieListCommandManager.GetMovieList();
            ShowResultMessage(titles.Count == 0 ? "List is empty" : PrintTitles(titles));
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

        private string PrintTitles (List<Title> titles)
        {
            var list = new StringBuilder();
            foreach (var title in titles)
            {
                list.AppendLine($"{title.Id}. {title.Name} - {title.Rating}");
            }
            return list.ToString();
        }

        private void ShowResultMessage ( string message )
        {
            _textWriterReader.WriteLine("");
            _textWriterReader.WriteLine(message);
        }
    }
}
