using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using ApplicationCore.Models;

namespace MovieShop.UnitTests
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        /*  
         *  Arrange: Initialize objects, creates mocks with arguments that are passed to the method under test and adds expectations
         *  Act: Invokes the method or property under test with the arranged parameters.
         *  Assert: Verifies that the action of the method under test behaves as expected.
         */
        private MovieService _sut;
        private static List<Movie> _movies;
        private Mock<IMovieRepository> _mockMovieRespository;

        [TestInitialize]
        // [OneTimeSetup] in nUnit
        public void OneTimeSetup() 
        {
            _mockMovieRespository = new Mock<IMovieRepository>();

            // SUT System under Test MovieService => GetTopRevenueMovies
            _sut = new MovieService(_mockMovieRespository.Object);
            _mockMovieRespository.Setup(m => m.GetTop30RevenueMovies()).ReturnsAsync(_movies);
        }
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _movies = new List<Movie>
            {
                new Movie{ Id = 1, Title = "Avengers: Infinity War", Budget = 1200000},
                new Movie{ Id = 2, Title = "Avatar", Budget = 1200000}
            };
            
        }
        
        [TestMethod]
        public async Task TestListOfHighestGrossingMoviesFromFakeDataAsync()
        {
            

            // Arrange => creating mock objects, data, methods etc
            _sut = new MovieService(new MockMovieRepository());

            // Act
            var movies = await _sut.GetTop30RevenueMovies();

            // check the actual output with expected data.
            // AAA 
            // Arrange, Act and Assert

            // Assert = compare
            Assert.IsNotNull(movies);
            Assert.IsInstanceOfType(movies, typeof(IEnumerable<MovieCardResponseModel>));
            Assert.AreEqual(2, movies.Count);
        }
    }
    public class MockMovieRepository : IMovieRepository
    {
        public Task<Movie> Add(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> Get(Expression<Func<Movie, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCount(Expression<Func<Movie, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> GetMovieReviews(int id, int pageSize = 30, int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> GetMovieReviews(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieGenre>> GetMoviesByGenreId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetTop30RatedMovies()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> Update(Movie entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetTop30RevenueMovies()
        {
            // this method will get the fake data
            var _movies = new List<Movie>
            {
                new Movie{ Id = 1, Title = "Avengers: Infinity War", Budget = 1200000},
                new Movie{ Id = 2, Title = "Avatar", Budget = 1200000}
            };
            return _movies;
        }
    }
}
