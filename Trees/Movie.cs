using System.Collections.Generic;

namespace TryingOut.Trees
{
    public class Movie
    {
        public string Name { get; private set; }
        public double Rating { get; set; }

        public Movie(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }
    }
}