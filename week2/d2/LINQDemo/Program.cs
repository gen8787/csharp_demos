using System;
using System.Collections.Generic;
using System.Linq;
using LINQDemo.Models;

namespace LINQDemo
{
    class Program
    {

        public static void PrintEach(IEnumerable<dynamic> items, string msg = "")
        {
            Console.WriteLine("\n" + msg);

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie("Blood Diamond", "Leonardo DiCaprio", 8, 2006),
                new Movie("The Departed", "Leonardo DiCaprio", 8.5, 2006),
                new Movie("Gladiator", "Russell Crowe", 8.5, 2000),
                new Movie("A Beautiful Mind", "Russell Crowe", 8.2, 2001),
                new Movie("Good Will Hunting", "Matt Damon", 8.3, 1997),
                new Movie("The Martian", "Matt Damon", 8, 2015),
            };

            List<Actor> actors = new List<Actor>
            {
                new Actor { FullName = "Matt Damon", Age = 48 },
                new Actor { FullName = "Leonardo DiCaprio", Age = 44 },
            };

            Movie selectedMovie = movies.First(paramName => paramName.Title.Contains("The"));
            // Console.WriteLine($"selected movie: {selectedMovie}");


            // crashes because not found
            // selectedMovie = movies.First(m => m.Title == "abc");

            // Does not crash
            selectedMovie = movies.FirstOrDefault(m => m.Title == "abc");
            // Console.WriteLine($"selected movie: {selectedMovie}");

            // hard coded oldest year, not ideal because you might not know
            Movie oldestMovie = movies.Where(movie => movie.Year == 1997).FirstOrDefault();

            // long-form oldest movie
            int oldestYear = movies.Min(m => m.Year);
            oldestMovie = movies.FirstOrDefault(m => m.Year == oldestYear);

            // shorthand oldest movie
            oldestMovie = movies.FirstOrDefault(movie => movie.Year == movies.Min(mov => mov.Year));
            Console.WriteLine($"oldest movie: {selectedMovie}");


            // in case there are multiple movies with the same oldest year
            List<Movie> oldestMovies = movies.Where(m => m.Year == oldestYear).ToList();


            IEnumerable<Movie> alphabeticalMoviesByTitle = movies.OrderBy(movie => movie.Title);
            IEnumerable<Movie> reverseAlphabeticalMoviesByTitle = movies.OrderByDescending(movie => movie.Title);
            IEnumerable<Movie> filteredMovies = movies.Where(m => m.LeadActor == "Leonardo DiCaprio");

            filteredMovies = movies
                .Where(m => m.Title.StartsWith("T"))
                .OrderByDescending(m => m.Year);

            // long-form
            filteredMovies = movies
                .Where(movie => movie.LeadActor == "Russell Crowe")
                .Where(movie => movie.Year > 2000);

            // shorthand
            filteredMovies = movies.Where(movie => movie.LeadActor == "Russell Crowe" && movie.Year > 2000);

            PrintEach(filteredMovies, "Filtered Movies:");

            List<string> titles = movies.Select(m => m.Title).ToList();
            PrintEach(titles, "Titles Only:");

            var titlesAndActors = movies
                .Select(m => new { m.Title, m.LeadActor })
                .ToList();

            PrintEach(titlesAndActors, "Titles Only:");


            // Not needed for exam
            // Merge the movies list with the actors list so we can have the full actor's information for movies where leo is actor
            var moviesAndActor = movies
                .Join(actors, // join with actors list
                    movie => movie.LeadActor, // movie.LeadActor ==
                    actor => actor.FullName, // actor.FullName
                    (movie, actor) => new { movie, actor } // return new dict with movie and actor inside
                ).Where(movieAndActor => movieAndActor.actor.FullName == "Leonardo DiCaprio")
                .ToList();

            PrintEach(moviesAndActor);
            Console.WriteLine(moviesAndActor[0].actor.Age);
        }
    }
}
