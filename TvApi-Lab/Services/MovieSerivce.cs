using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TvApi_Lab.Models;

namespace TvApi_Lab.Services
{
    public class MovieService
    {
        private static MovieService _instance;

        public static MovieService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MovieService();
                }

                return _instance;
            }
        }

        private List<Movie> _movies;

        public MovieService()
        {
            _movies = new List<Movie>()
            {
                new Movie
                {
                    Author = "Jan Kowalski",
                    Title ="Super historia",
                    Year = 2033,
                    Id =1,
                    Comments = new List<string> { "super", "mega" },
                },
                new Movie
                {
                    Id = 2 ,
                    Author ="Mario Men",
                    Title="Super film",
                    Year = 1999,
                    Comments = new List<string>(),
                }
            };
        }

        internal void Add(Movie movie)
        {
            _movies.Add(movie);
        }

        internal Movie Find(int id)
        {
            return _movies.SingleOrDefault(movie => movie.Id == id);
        }

        internal IEnumerable<Movie> GetAllMovies()
        {
            return _movies;
        }

        internal void Delete(int id)
        {
            Movie movie = Find(id);
            _movies.Remove(movie);
        }
    }
}