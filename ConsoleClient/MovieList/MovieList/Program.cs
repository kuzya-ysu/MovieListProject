using MovieList.Managers;

namespace MovieList
{
    internal class Program
    {
        private static void Main ()
        {
            var consoleTextWriterReader = new ConsoleTextWriterReader();
            var httpManager = new HttpManager();
            var app = new Application(consoleTextWriterReader, httpManager);
            app.ExecuteApp();
        }
    }
}