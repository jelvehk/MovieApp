using Microsoft.Extensions.Configuration;
using MovieApp.Interface;
using MovieApp.Model;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Service
{
    public class MovieService : IMovieService
    {
        private readonly IConfiguration _configuration;
        private readonly RestClient client;
        private readonly RestRequest request;
        public MovieService ( IConfiguration configuration)
        {
            _configuration = configuration;
           
            request = new RestRequest(Method.GET);
            request.AddHeader("X-Access-token", _configuration.GetSection("APISettings").GetSection("X-Access-Token").Value);
            request.AddHeader("Content-Type", "application/json");
        }
           

        public Movie Add(Movie newItem)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Movie> GetAllMovies()
        {
            var client = new RestClient(_configuration.GetSection("APISettings").GetSection("APIURL").Value);            
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
            return _movies;
        }
        public Movie GetMovieById(string id)
        {
            var client = new RestClient(_configuration.GetSection("APISettings").GetSection("APIURL").Value + id);

            Movie _movie = new Movie();
            RestSharp.IRestResponse response = client.Execute(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject<Movie>(response.Content);
            if (jsonResponse == null) return _movie;

            return jsonResponse;
        }
        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
