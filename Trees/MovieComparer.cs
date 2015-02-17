using System;

namespace TryingOut.Trees
{
    public class MovieComparer
    {
        public static Func<Movie, Movie, bool> Rating
        {
            get { return (x, y) => x.Rating > y.Rating; }
        }

        public static Func<Movie, Movie, bool> InverseRating
        {
            get { return (x, y) => x.Rating < y.Rating; }
        }

        public static Func<Movie, Movie, bool> Name
        {
            get { return (x, y) => x.Name.CompareTo(y.Name) > 0; }
        }
    }
}