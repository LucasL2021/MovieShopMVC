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
    public class ReviewRepository : EfRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Review>> GetAllReviews(int pageSize = 30, int pageIndex = 1)
        {
            var purchases = await _dbContext.Reviews.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return purchases;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsForUser(int userId)
        {
            var reviews = await _dbContext.Reviews.Where(p => p.UserId == userId).ToListAsync();
            return reviews;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsForMovie(int movieId)
        {
            var reviews = await _dbContext.Reviews.Where(p => p.MovieId == movieId).ToListAsync();
            return reviews;
        }
    }
}