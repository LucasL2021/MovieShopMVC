using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetTop30RevenueMovies();
        Task<Movie> GetMovieById(int id);
        Task<IEnumerable<Review>> GetMovieReviews(int id, int pageSize = 30, int page = 1);
        Task<IEnumerable<Review>> GetMovieReviews(int id);

        Task<IEnumerable<Movie>> GetTop30RatedMovies();
        //Task<PagedResultSet<Movie>> GetMoviesByGenre(int genreId, int pageSize = 30, int page = 1);
        Task<IEnumerable<MovieGenre>> GetMoviesByGenreId(int id);
    }
}