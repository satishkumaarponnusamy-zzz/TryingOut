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

    public class MaxMovieRatingComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.Rating.CompareTo(y.Rating);
        }
    }

    public class MinMovieRatingComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return y.Rating.CompareTo(x.Rating);
        }
    }
}