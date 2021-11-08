using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using static ApplicationCore.Models.FavoriteResponseModel;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly ICastRepository _castRepository;
        private readonly IGenreRepository _genreRepository;


        public UserService(IUserRepository userRepository, IPurchaseRepository purchaseRepository, IFavoriteRepository favoriteRepository, IReviewRepository reviewRepository, ICastRepository castRepository, IGenreRepository genreRepository)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
            _favoriteRepository = favoriteRepository;
            _reviewRepository = reviewRepository;
            _castRepository = castRepository;
            _genreRepository = genreRepository;
        }

        public async Task<int> RegisterUser(UserRegisterRequestModel requestModel)
        {
            // check whether email exists in the database
            var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);
            if (dbUser != null)
                //email exists in the database
                throw new Exception("Email already exists, please login");

            // generate a random unique salt
            var salt = GetSalt();

            // create the hashed password with salt generated in the above step
            var hashedPassword = GetHashedPassword(requestModel.Password, salt);

            // save the user object to db
            // create user entity object
            var user = new User
            {
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                Email = requestModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                DateOfBirth = requestModel.DateOfBirth
            };

            // use EF to save this user in the user table
            var newUser = await _userRepository.Add(user);
            return newUser.Id;
        }

        public async Task<UserLoginResponseModel> LoginUser(UserLoginRequestModel requestModel)
        {
            // get the salt and hashedpassword from databse for this user
            var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);
            if (dbUser == null) throw null;

            // hash the user entered password with salt from the database

            var hashedPassword = GetHashedPassword(requestModel.Password, dbUser.Salt);
            // check the hashedpassword with database hashed password
            if (hashedPassword == dbUser.HashedPassword)
            {
                // user entered correct password
                var userLoginResponseModel = new UserLoginResponseModel
                {
                    Id = dbUser.Id,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    DateOfBirth = dbUser.DateOfBirth.GetValueOrDefault(),
                    Email = dbUser.Email
                };
                return userLoginResponseModel;
            }

            return null;
        }
        private string GetSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string GetHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                Convert.FromBase64String(salt),
                KeyDerivationPrf.HMACSHA512,
                10000,
                256 / 8));
            return hashed;
        }

        public async Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            var movieId = favoriteRequest.MovieId;
            var userId = favoriteRequest.UserId;
            var favorite = new Favorite
            {
                MovieId = movieId,
                UserId = userId
            };
            await _favoriteRepository.Add(favorite);
        }

        public async Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            var movieId = favoriteRequest.MovieId;
            var userId = favoriteRequest.UserId;
            var favorite = new Favorite
            {
                MovieId = movieId,
                UserId = userId
            };
            await _favoriteRepository.Delete(favorite);
        }

        public async Task<FavoriteResponseModel> GetAllFavoritesForUser(int id)
        {
            var favorites = await _favoriteRepository.GetAllFavoritesForUser(id);
            var favoriteResponseModel = new FavoriteResponseModel
            {
                UserId = id,
                FavoriteMovies = new List<FavoriteMovieResponseModel>()
            };             
            foreach (var favorite in favorites)
                favoriteResponseModel.FavoriteMovies.Add(new FavoriteMovieResponseModel
                {
                        Id = favorite.Id,
                        PosterUrl = favorite.Movie.PosterUrl,
                        Title = favorite.Movie.Title
                });
            return favoriteResponseModel;
        }

        public async Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId)
        {
            if (await IsMoviePurchased(purchaseRequest, userId) == false)
            {
                var purchase = new Purchase
                {
                    UserId = userId,
                    PurchaseNumber = purchaseRequest.PurchaseNumber.GetValueOrDefault(),
                    PurchaseDateTime = purchaseRequest.PurchaseDateTime.GetValueOrDefault(),
                    MovieId = purchaseRequest.MovieId
                };
                await _purchaseRepository.Add(purchase);
                return true;
            }
            else
                return false;
        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId)
        {
            if (await _purchaseRepository.GetPurchaseDetails(userId, purchaseRequest.MovieId) != null)
            {
                return true;
            }
            else
                return false;
        }

        public async Task<PurchaseResponseModel> GetAllPurchasesForUser(int id)
        {
            var purchases = await _purchaseRepository.GetAllPurchasesForUser(id);
            var purchasedMovies = new List<MovieCardResponseModel>();
            foreach (var purchase in purchases)
            {
                var movieCard = new MovieCardResponseModel
                {
                    Id = purchase.MovieId,
                    Title = purchase.Movie.Title,
                    PosterUrl = purchase.Movie.PosterUrl
                };
                purchasedMovies.Add(movieCard);
            }

            var purchaseResponseModel = new PurchaseResponseModel
            {
                PurchasedMovies = purchasedMovies,
                TotalMoviesPurchased = purchasedMovies.Count
            };

            return purchaseResponseModel;
        }

        public async Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId)
        {
            var purchaseDetails = await _purchaseRepository.GetPurchaseDetails(userId, movieId);
            var purchaseResponse = new PurchaseDetailsResponseModel 
            {
                Id = purchaseDetails.Id,
                UserId = userId,
                PurchaseNumber = purchaseDetails.PurchaseNumber,
                TotalPrice = purchaseDetails.TotalPrice,
                PurchaseDateTime = purchaseDetails.PurchaseDateTime,
                MovieId = movieId,
                Title = purchaseDetails.Movie.Title,
                PosterUrl = purchaseDetails.Movie.PosterUrl,
                ReleaseDate = purchaseDetails.Movie.ReleaseDate
            };
            return purchaseResponse;
        }

        public async Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            var review = new Review
            {
                MovieId = reviewRequest.MovieId,
                UserId = reviewRequest.UserId,
                Rating = reviewRequest.Rating,
                ReviewText = reviewRequest.ReviewText
            };
            await _reviewRepository.Add(review);
        }

        public async Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            var review = new Review
            {
                MovieId = reviewRequest.MovieId,
                UserId = reviewRequest.UserId,
                Rating = reviewRequest.Rating,
                ReviewText = reviewRequest.ReviewText
            };
            await _reviewRepository.Update(review);
        }

        public async Task DeleteMovieReview(int userId, int movieId)
        {
            var review = new Review
            {
                MovieId = movieId,
                UserId = userId
            };
            await _reviewRepository.Delete(review);
        }

        public async Task<UserReviewResponseModel> GetAllReviewsByUser(int id)
        {
            var reviews = await _reviewRepository.GetAllReviewsForUser(id);
            var userResponse = new UserReviewResponseModel
            {
                UserId = id,
                MovieReviews = new List<MovieReviewResponseModel>()
            };
            foreach (var review in reviews)
            {
                var reviewResponse = new MovieReviewResponseModel
                {
                    UserId = review.UserId,
                    MovieId = review.MovieId,
                    ReviewText = review.ReviewText,
                    Rating = review.Rating
                };
                userResponse.MovieReviews.Add(reviewResponse);
            }
            return userResponse;
        }
        public async Task<CastResponseModel> GetCastById(int id) 
        {
            var cast = await _castRepository.GetById(id);
            var castResponse = new CastResponseModel
            {
                Id = cast.Id,
                Name = cast.Name,
                Gender = cast.Gender,
                TmdbUrl = cast.Gender,
                ProfilePath = cast.ProfilePath
            };

            return castResponse;
        }
        public async Task<IEnumerable<Genre>> GetGenres()
        {
            var genres = await _genreRepository.GetAll();
            return genres;
        }
    }
}