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

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger, IConfiguration configuration)
        {
            _logger = logger;

            _configuration = configuration;

        }


        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            var client = new RestClient(_configuration.GetSection("APISettings").GetSection("APIURL").Value );
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-Access-token", _configuration.GetSection("APISettings").GetSection("X-Access-Token").Value);
            request.AddHeader("Content-Type", "application/json");
            IEnumerable<Movie> _movies = null;
            try
            {
                RestSharp.IRestResponse response = client.Execute(request);

                dynamic jsonResponse = JsonConvert.DeserializeObject<MovieList>(response.Content);


                _movies = jsonResponse.Movies;
               

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error happend trying to get response from API");
            }
            return _movies ;

        }
        [HttpGet("/movie/{id}")]
        public Movie GetMovieById(string Id)
        {
            var client = new RestClient(_configuration.GetSection("APISettings").GetSection("APIURL").Value + Id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-Access-token", _configuration.GetSection("APISettings").GetSection("X-Access-Token").Value);
            request.AddHeader("Content-Type", "application/json");
            Movie _movie = new Movie();
            RestSharp.IRestResponse response = client.Execute(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject<Movie>(response.Content);
            if (jsonResponse == null) return _movie;

            return jsonResponse;

        }
    }
}
