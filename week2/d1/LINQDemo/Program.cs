using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie("Blood Diamond", "Leonardo DiCaprio", 8, 2006),
                new Movie("The Departed", "Leonardo DiCaprio", 8.5, 2006),
                new Movie("Gladiator", "Russell Crowe", 8.5, 2000),
                new Movie("A Beautiful Mind", "Russell Crowe", 8.2, 2001),
                new Movie("Good Will Hunting", "Matt Damon", 8.3, 1997),
                new Movie("Fifth Element", "Bruce Willis", 8.3, 1997),
                new Movie("The Martian", "Matt Damon", 8, 2015),
            };

            List<Actor> actors = new List<Actor>
            {
                new Actor { FullName = "Matt Damon", Age = 48 },
                new Actor { FullName = "Leonardo DiCaprio", Age = 44 },
            };

            // Breaks when not found
            // Movie selectedMovie = movies.First(movies => movies.Title == "abc");
            Movie selectedMovie = movies.FirstOrDefault(movie => movie.Title == "abc");
            selectedMovie = movies.FirstOrDefault(m => m.Title == "Gladiator");
            Console.WriteLine(selectedMovie);

            decimal oldestYear = movies.Min(movie => movie.Year);
            List<Movie> selectedMovies = movies.Where(m => m.Year == oldestYear).ToList();

            // combined version of above
            selectedMovies = movies.Where(m => m.Year == movies.Min(movie => movie.Year)).ToList();

            selectedMovies = movies.OrderByDescending(m => m.Title).ToList();

            selectedMovies = movies.Where(m => m.Title.StartsWith("T")).ToList();

            selectedMovies = movies.Where(m => m.LeadActor == "Russell Crowe" && m.Year > 2000).ToList();
            PrintEach(selectedMovies, "filtered movies");

            /* .Select */
            IEnumerable<string> selectedMovieFields = movies.Select(m => m.Title);

            selectedMovieFields = movies
                .Where(m => m.LeadActor == "Matt Damon")
                .Select(m => m.Title)
                .OrderBy(title => title)
                .ToList();

            // PrintEach(selectedMovieFields, "selectedMovieFields");


            var selectedMovieMultipleFields = movies
                .Where(m => m.LeadActor == "Matt Damon")
                .OrderBy(dict => dict.Title)
                .Select(m => new { m.Title, m.Rating })
                .ToList();

            PrintEach(selectedMovieMultipleFields, "selectedMovieMultipleFields");

            var moviesAndActor = movies
                .Join(actors, // join with actors list
                    movie => movie.LeadActor, // movie.LeadActor ==
                    actor => actor.FullName, // actor.FullName
                    (movie, actor) => new { movie, actor } // return new dict with movie and actor inside
                ).Where(movieAndActor => movieAndActor.actor.FullName == "Leonardo DiCaprio")
                .ToList();

            var moviesAndActor2 = movies
                .Join(actors, // join with actors list
                    movie => movie.LeadActor, // movie.LeadActor ==
                    actor => actor.FullName, // actor.FullName
                    (movie, actor) => new { movie.Title, movie.LeadActor, actor.Age } // return new dict with movie and actor inside
                ).Where(movieAndActor => movieAndActor.LeadActor == "Leonardo DiCaprio")
                .ToList();

            PrintEach(moviesAndActor);
            Console.WriteLine(moviesAndActor[0].actor.Age);
        }

        public static void PrintEach(IEnumerable<dynamic> items, string msg = "")
        {
            Console.WriteLine("\n" + msg + ":");

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
