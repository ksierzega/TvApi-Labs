using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TvApi_Lab.Models;
using TvApi_Lab.Services;

namespace TvApi_Lab.Controllers
{
    public class ReviewController : ApiController
    {
        private ReviewService _reviewService;

        public ReviewController()
        {
            _reviewService = new ReviewService();
        }

        [HttpPost, Route("movies/{movieId:int}/review")]
        public IHttpActionResult AddReviewToMovie(int movieId, ReviewRequest request)
        {
            _reviewService.AddReviewToMovie(movieId, request);
            return Ok();
        }

        [HttpGet, Route("movies/{movieId:int}/reviews")]
        public IHttpActionResult GetReviewsForMovie(int movieId)
        {
            return Ok(_reviewService.GetReviewsForMovie(movieId));            
        }
    }
}
