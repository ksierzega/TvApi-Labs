using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using TvApi_Lab.Filters;
using TvApi_Lab.Models;
using TvApi_Lab.Services;

namespace TvApi_Lab.Controllers
{
    public class MovieController : ApiController
    {
        private MovieService _movieService;

        public MovieController()
        {
            _movieService = new MovieService();
        }

        [ExecutionTime]
        [HttpGet, Route("movies")]
        public IHttpActionResult GetAllMovies()
        {
            var movies = _movieService.GetAllMovies();
            return Ok(movies);
        }

        [ModelValidation]
        [HttpPost, Route("movies")]
        public IHttpActionResult AddMovie([FromBody]MovieRequest movie)
        {
            _movieService.Add(movie);
            return Ok("added");
        }

        [HttpGet, Route("movies/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var movie = _movieService.Find(id);
            return Ok(movie);
        }

        [HttpDelete, Route("movies/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok();
        }
    }
}