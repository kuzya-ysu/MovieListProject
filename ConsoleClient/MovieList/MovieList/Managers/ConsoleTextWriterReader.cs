using System;

namespace MovieList.Managers
{
    internal class ConsoleTextWriterReader: ITextWriterReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
