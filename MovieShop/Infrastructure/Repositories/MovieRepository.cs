using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext): base(dbContext)
        {
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.Casts).ThenInclude(m => m.Cast)
                .Include(m => m.Genres).ThenInclude(m => m.Genre)
                .Include(m => m.Trailers)
                .FirstOrDefaultAsync(m => m.Id == id);
            var movieRating = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty()
                .AverageAsync(r => r == null ? 0 : r.Rating);
            if (movieRating > 0) movie.Rating = movieRating;
            return movie;
        }
        public async Task<IEnumerable<MovieGenre>> GetMoviesByGenreId(int id)
        {
            var movies = await _dbContext.MovieGenres.Include(mg => mg.Movie)
                .Where(mg => mg.GenreId == id).ToListAsync();
            return movies;
        }

        public async Task<IEnumerable<Movie>> GetTop30RevenueMovies()
        {
            // we are gonna use EF with LINQ to get 30 top movies by revenue
            // SQL select top 30 * from Movies order by Revenue
            // I/O bound operation
            // u can only await on Tasks
            // EF and Dapper have both sync and async methods
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }
        public async Task<IEnumerable<Movie>> GetTop30RatedMovies()
        {
            // var movies = await _dbContext.Movies.OrderByDescending(m => m.Rating).Take(30).ToListAsync();
            // going to review table
            // movieid, title, posterurl, rating =>
            // 
            var movies = await _dbContext.Reviews.Include(r => r.Movie)
                .GroupBy(r => new { Id = r.MovieId, r.Movie.PosterUrl, r.Movie.Title })
                .OrderByDescending(g => g.Average(m => m.Rating))
                .Select(m =>
                new Movie
                {
                    Id = m.Key.Id,
                    PosterUrl = m.Key.PosterUrl,
                    Title = m.Key.Title,
                    Rating = m.Average(x => x.Rating)
                }).Take(30).ToListAsync();
            return movies;
        }
        public async Task<IEnumerable<Review>> GetMovieReviews(int id, int pageSize = 30, int page = 1)
        {
            var reviews = await _dbContext.Reviews.Where(r => r.MovieId == id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return reviews;
        }
        public async Task<IEnumerable<Review>> GetMovieReviews(int id)
        {
            var reviews = await _dbContext.Reviews.Where(r => r.MovieId == id).ToListAsync();
            return reviews;
        }
    }
}
