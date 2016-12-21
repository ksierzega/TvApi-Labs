using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TvApi_Lab.DAL;
using TvApi_Lab.Models;

namespace TvApi_Lab.Services
{
    public class MovieService
    {             
        public MovieService()
        {
           
        }

        internal void Add(MovieRequest movie)
        {
            using(var ctx = new TvApiContext())
            {
                ctx.Movies.Add(new Movie()
                {
                    Title = movie.Title,
                    Year = movie.Year
                });
                ctx.SaveChanges();
            }
        }

        internal MovieResponse Find(int id)
        {
            using (var ctx = new TvApiContext())
            {
                var movie = ctx.Movies.Find(id);
                if(movie == null)
                {
                    return null;
                }

                return new MovieResponse()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year
                };
            }
        }

        internal IEnumerable<MovieResponse> GetAllMovies()
        {
            using (var ctx = new TvApiContext())
            {
                return ctx.Movies.Select(movie => new MovieResponse()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year
                }).ToList();
            }
        }

        internal void Delete(int id)
        {
            using (var ctx = new TvApiContext())
            {
                var movie = ctx.Movies.Find(id);
                if(movie == null)
                {
                    return;
                }

                ctx.Movies.Remove(movie);
                ctx.SaveChanges();
            }
        }
    }
}