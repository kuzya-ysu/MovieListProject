using System;

namespace MovieList.Exceptions
{
    public class UserInputException : Exception
    {
        public UserInputException ( string message ) : base(message) { }

    }
}
