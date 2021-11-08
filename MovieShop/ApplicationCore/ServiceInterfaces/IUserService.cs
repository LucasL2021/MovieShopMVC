using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<int> RegisterUser(UserRegisterRequestModel requestModel);
        Task<UserLoginResponseModel> LoginUser(UserLoginRequestModel requestModel);

        Task AddFavorite(FavoriteRequestModel favoriteRequest);
        Task RemoveFavorite(FavoriteRequestModel favoriteRequest);
        Task<FavoriteResponseModel> GetAllFavoritesForUser(int id);

        Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequest, int userId);
        Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest, int userId);
        Task<PurchaseResponseModel> GetAllPurchasesForUser(int id);
        Task<PurchaseDetailsResponseModel> GetPurchasesDetails(int userId, int movieId);

        Task AddMovieReview(ReviewRequestModel reviewRequest);
        Task UpdateMovieReview(ReviewRequestModel reviewRequest);
        Task DeleteMovieReview(int userId, int movieId);
        Task<UserReviewResponseModel> GetAllReviewsByUser(int id);
        Task<CastResponseModel> GetCastById(int id);
        Task<IEnumerable<Genre>> GetGenres();

    }
}