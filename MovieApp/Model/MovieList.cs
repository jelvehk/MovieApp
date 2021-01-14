using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Model
{
    /// <summary>
    /// this is the movie list contains list of movie object and it is to map json response from API to list of movies object
    /// </summary>
    public class MovieList
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}
