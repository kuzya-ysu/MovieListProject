using System;

namespace MovieListWebAPI.Exceptions
{
    public class UserInputException : Exception
    {
        public UserInputException ( string message ) : base(message) { }

    }
}
