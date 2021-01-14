using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using Microsoft.Extensions.Configuration;
using System.Net;
using MovieApp.Model;
using MovieApp.Interface;

namespace MovieApp.Controllers

{
    /// <summary>
    /// this is the movie Api controller to retrieve movies from api
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _service;
        public MovieController(ILogger<MovieController> logger, IConfiguration configuration,IMovieService service)
        {
            _logger = logger;
            _configuration = configuration;
            _service = service;

        }

        /// <summary>
        /// this method retrieve all movies from api and return list of movies
        /// </summary>
        /// <returns>IEnumerable<Movie></returns>
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            var items = _service.GetAllMovies ();
      
            return items;

        }
        /// <summary>
        /// This method get a movie by Id
        /// </summary>
        /// <param name="Id"></param> id of movie
        /// <returns>movie</returns>
        [HttpGet("/movie/{id}")]
        public Movie GetMovieById(string id)
        {
            var item = _service.GetMovieById(id);
            return item;

        }
    }
}
