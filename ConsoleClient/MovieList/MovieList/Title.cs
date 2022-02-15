using MovieList.Exceptions;

namespace MovieList
{
    public class Title
    {
        private string _name;
        private int _rating;

        public readonly int Id;

        public string Name  
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new UserInputException("Name can't be empty");
                _name = value;

            }
        }


        public int Rating
        {
            get => _rating; 
            set
            {
                if (value < 1 || value > 10)
                    throw new UserInputException("Rating has to be from 1 to 10");
                _rating = value;
            }
        }

        public Title ( string name, int rating, int id )
        {
            Name = name;
            Rating = rating;
            this.Id = id;
        }

        public override string ToString ()
        {
            return ($"{Id}. {Name} - {Rating}");
        }
    }
}