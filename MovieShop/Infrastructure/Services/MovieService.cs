using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieCardResponseModel>> GetTop30RevenueMovies()
        {
            var movies = await _movieRepository.GetTop30RevenueMovies();

            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    Title = movie.Title
                });

            return movieCards;
        }
        public async Task<IEnumerable<MovieCardResponseModel>> GetTop30RatedMovies()
        {
            var movies = await _movieRepository.GetTop30RatedMovies();

            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    Title = movie.Title
                });

            return movieCards;
        }

        public async Task<List<MovieCardResponseModel>> GetMoviesByGenreId(int id)
        {
            var movies = await _movieRepository.GetMoviesByGenreId(id);
            
            var movieCards = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
                movieCards.Add(new MovieCardResponseModel
                {
                    Id = movie.MovieId,
                    PosterUrl = movie.Movie.PosterUrl,
                    Title = movie.Movie.Title
                });

            return movieCards;
        }
        public async Task<List<ReviewResponseModel>> GetMovieReviews(int id)
        {
            var reviews = await _movieRepository.GetMovieReviews(id);
            var responseCards = new List<ReviewResponseModel>();
            foreach (var r in reviews)
                responseCards.Add(new ReviewResponseModel
                {
                    MovieId = r.MovieId,
                    UserId = r.UserId,
                    ReviewText = r.ReviewText,
                    Rating = r.Rating
                });

            return responseCards;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var movie = await _movieRepository.GetMovieById(id);
            if (movie == null) throw new Exception("Movie");
            // var favoritesCount = await _favoriteRepository.GetCountAsync(f => f.MovieId == id);
            var movieDetails = new MovieDetailsResponseModel
            {
                Id = movie.Id,
                Budget = movie.Budget,
                Overview = movie.Overview,
                Price = movie.Price,
                PosterUrl = movie.PosterUrl,
                Revenue = movie.Revenue,
                ReleaseDate = movie.ReleaseDate.GetValueOrDefault(),
                Rating = movie.Rating,
                Tagline = movie.Tagline,
                Title = movie.Title,
                RunTime = movie.RunTime,
                BackdropUrl = movie.BackdropUrl,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl
            };

            foreach (var movieGenre in movie.Genres)
                movieDetails.Genres.Add(new GenreModel
                {
                    Id = movieGenre.Genre.Id,
                    Name = movieGenre.Genre.Name
                });

            foreach (var movieCast in movie.Casts)
                movieDetails.Casts.Add(new CastResponseModel
                {
                    Id = movieCast.Cast.Id,
                    Name = movieCast.Cast.Name,
                    Character = movieCast.Character,
                    Gender = movieCast.Cast.Gender,
                    ProfilePath = movieCast.Cast.ProfilePath,
                    TmdbUrl = movieCast.Cast.TmdbUrl
                });

            foreach (var trailer in movie.Trailers)
                movieDetails.Trailers.Add(new TrailerResponseModel
                {
                    Id = trailer.Id,
                    Name = trailer.Name,
                    TrailerUrl = trailer.TrailerUrl,
                    MovieId = trailer.MovieId
                });
            return movieDetails;
        }

       

        
    }
}