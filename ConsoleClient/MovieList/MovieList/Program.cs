using MovieList.Managers;

namespace MovieList
{
    internal class Program
    {
        private static void Main ()
        {
            var fileMovieListLoaderSaver = new FileMovieListLoaderSaver("MovieList.txt");
            var consoleTextWriterReader = new ConsoleTextWriterReader();
            var app = new Application(fileMovieListLoaderSaver, consoleTextWriterReader);
            app.ExecuteApp();
        }
    }
}