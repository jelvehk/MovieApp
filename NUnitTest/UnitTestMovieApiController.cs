using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieApp;
using MovieApp.Controllers;
using MovieApp.Interface;
using MovieApp.Model;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           
            var movie = new Movie()
            {
                ID = "x1",
                Poster = "test.jpg",
                Title = "New Life",
                Year = "2020"
            };
           ;
        }

        [Test]
        public void TestGetByID()
        {
           
            //Arrange
            var movieId = "movie01";
            var movie1 = new Movie()
            {
                ID = "movie01",
                Poster = "newLife.jpg",
                Title = "New Life",
                Year = "2020"
            };
            var movie2 = new Movie()
            {
                ID = "movie02",
                Poster = "sweethome.jpg",
                Title = "Our Sweet home",
                Year = "2019"
            };
            var movieServiceMock = new Mock<IMovieService>();
            var movieList = new MovieList();
            var m = new List<Movie>();
            m.Add(movie1);
            m.Add(movie2);
            movieList.Movies = m;
            
            movieServiceMock.Setup(x => x.GetMovieById(
              It.Is<string>(id => id == movie1.ID)
           
            )).Returns(movie1);

           

            //Act
            var moviecontoller = new MovieController(null,null,movieServiceMock.Object);
            // IEnumerable <Movie> output = moviecontoller.GetMovies().Value;
            var output = moviecontoller.GetMovieById(movieId);
             
            // assert
            Assert.IsNotNull(output);
            //Assert
            Assert.AreEqual(output, movie1 );
          
        }

        [Test]
        public void TestGetAllMovies()
        {

            //Arrange
            var movieId = "movie01";
            var movie1 = new Movie()
            {
                ID = "movie01",
                Poster = "newLife.jpg",
                Title = "New Life",
                Year = "2020"
            };
            var movie2 = new Movie()
            {
                ID = "movie02",
                Poster = "sweethome.jpg",
                Title = "Our Sweet home",
                Year = "2019"
            };
            var movieServiceMock = new Mock<IMovieService>();
            var movieList = new MovieList();
            var m = new List<Movie>();
            m.Add(movie1);
            m.Add(movie2);
            movieList.Movies = m;

            movieServiceMock.Setup(x => x.GetMovieById(
              It.Is<string>(id => id == movie1.ID)

            )).Returns(movie1);

            movieServiceMock.Setup(x => x.GetAllMovies()).Returns(movieList.Movies);

            //Act
            var moviecontoller = new MovieController(null, null, movieServiceMock.Object);
            var output = moviecontoller.GetMovies();
            

            // assert
            Assert.IsNotNull(output);
            //Assert
            Assert.AreEqual(output.Count<Movie>() , movieList.Movies.Count<Movie>());

        }
    }
}