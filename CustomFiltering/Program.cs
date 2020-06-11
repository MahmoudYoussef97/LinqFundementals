using System;
using System.Collections.Generic;

namespace CustomFiltering
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>()
            { 
                new Movie {Name = "Dark Night", Rating = 9.5f, Year = 2016},
                new Movie {Name = "Shazam", Rating = 9.5f, Year = 2013},
                new Movie {Name = "Avengers", Rating = 9.5f, Year = 2010}
            };

            var query = movies.Filter(m => m.Year > 2010);

            foreach (var movie in query)
            {
                Console.WriteLine(movie.Name);
            }
        }
    }
}
