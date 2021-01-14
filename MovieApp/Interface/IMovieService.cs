using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Interface
{
    public interface  IMovieService
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(string id);
    }
}
