using Microsoft.EntityFrameworkCore;
using TestTask.Data.Interfaces;
using TestTask.Models;

namespace TestTask.Data.Implementations
{
    /// <summary>
    /// Repository for work with user entities in the DB
    /// </summary>
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        /// <summary>
        /// Find the user with the largest number of orders
        /// </summary>
        /// <returns>Task<User></returns>
        public async Task<User> Get()
        {
            List<User> usersWithOrders = await _dbContext.Users
                .Include(u => u.Orders)
                .ToListAsync();

            User userWithLargestNumberOfOrders = usersWithOrders
                .OrderByDescending(u => u.Orders.Count)
                .FirstOrDefault();

            return userWithLargestNumberOfOrders;
        }

        /// <summary>
        /// Find users with Inactive status
        /// </summary>
        /// <returns>Task<IEnumerable<User>></returns>
        public async Task<List<User>> GetEntities()
        {
            List<User> usersWithInactiveStatus = await _dbContext.Users
                .Where(u => u.Status == Enums.UserStatus.Inactive)
                .ToListAsync();

            return usersWithInactiveStatus;
        }

    }
}
