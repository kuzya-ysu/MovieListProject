using System.Collections.Generic;
using MovieList.Managers;

namespace MovieList.UnitTests.Fake_Managers
{
    public class FakeConsoleTextWriterReader : ITextWriterReader
    {
        public List<string> TextInput { get; set; }
        public List<string> TextOutput { get; set; }
        public int InputId { get; set; }

        public FakeConsoleTextWriterReader ()
        {
            TextInput = new List<string>();
            TextOutput=new List<string>();
            InputId = 0;
        }
        public string ReadLine ()
        {
            var a = TextInput[InputId];
            InputId++;
            return a;
        }

        public void WriteLine ( string line )
        {
            TextOutput.Add(line);
        }
    }
}
