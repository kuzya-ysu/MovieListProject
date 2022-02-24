using System.Collections.Generic;
using WindowsFormClient.Models;

namespace WindowsFormClient.Managers
{
    public interface IMovieListCommandManager
    {
        public List<Title> GetMovieList ();

        public void CreateTitle (Title title);

        public void DeleteTitle (int titleId);

        public void UpdateTitle (int titleId, Title title);
    }
}
