using System;

namespace MovieList.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException ( string message ) : base(message) { }
    }
}
