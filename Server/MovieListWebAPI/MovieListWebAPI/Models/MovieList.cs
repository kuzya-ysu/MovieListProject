using System.Collections.Generic;
using System.Text;
using MovieListWebAPI.Exceptions;

namespace MovieListWebAPI.Models
{
    public class MovieList
    {
        public List<Title> Titles { get; }
        public int NextId { get; private set; }

        public MovieList ()
        {
            Titles = new List<Title>();
            NextId = 1;
        }

        public void CreateTitle(Title title)
        {
            title.Id=NextId;
            Titles.Add(title);
            NextId++;
        }

        public void DeleteTitle(int titleId)
        {
            var title = FindTitle(titleId);
            Titles.Remove(title);
        }

        public void UpdateName(int titleId, string name)
        {
            var title = FindTitle(titleId);
            title.Name = name;
        }

        public void UpdateRating(int titleId, int rating)
        {
            var title = FindTitle(titleId);
            title.Rating = rating;
        }

        public Title GetTitle(int titleId)
        {
            return FindTitle(titleId);
        }

        private Title FindTitle(int titleId)
        {
            var title = Titles.Find(title => title.Id == titleId);
            if (title == null)
                throw new NotFoundException("Title with that number does not exist");
            return title;
        }

        public override string ToString()
        {
            var list = new StringBuilder();
            foreach (var title in Titles)
            {
                list.AppendLine(title.ToString());
            }

            return list.ToString();
        }
    }
}