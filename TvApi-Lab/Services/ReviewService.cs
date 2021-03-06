﻿using System.Collections.Generic;
using System.Linq;
using NLog;
using TvApi_Lab.Common;
using TvApi_Lab.DAL;
using TvApi_Lab.Models;

namespace TvApi_Lab.Services
{
    public class ReviewService
    {
        protected static readonly Logger Nlog = LogManager.GetCurrentClassLogger();

        internal void AddReviewToMovie(int movieId, ReviewRequest request)
        {
            using (var ctx = new TvApiContext())
            {
                var movie = ctx.Movies.Find(movieId);
                if (movie == null)
                {
                    throw new TvApiException($"Cannot add review. Invalid move id = {movieId}");
                }

                movie.Reviews.Add(new Review()
                {
                    Comment = request.Comment,
                    Rate = request.Rate
                });

                ctx.SaveChanges();
            }
        }

        internal IEnumerable<ReviewResponse> GetReviewsForMovie(int movieId)
        {
            using (var ctx = new TvApiContext())
            {
                var movie = ctx.Movies.Find(movieId);
                return movie.Reviews.Select(x => new ReviewResponse()
                {
                    Id = x.Id,
                    Comment = x.Comment,
                    Rate = x.Rate
                }).ToList();
            }
        }
    }
}