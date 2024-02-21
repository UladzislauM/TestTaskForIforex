using Microsoft.EntityFrameworkCore;
using TestTask.Data.Interfaces;
using TestTask.Models;

namespace TestTask.Data.Implementations
{
    /// <summary>
    /// Repository for work with order entities in the DB
    /// </summary>
    public class OrderRepository : IRepository<Order>
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Find the order with the largest order amount
        /// </summary>
        /// <returns>Task<Order></returns>
        public async Task<Order> Get()
        {
            Order orderWithLargestOrderAmount = await _dbContext.Orders
                 .OrderByDescending(o => o.Price * o.Quantity)
                 .FirstOrDefaultAsync();

            return orderWithLargestOrderAmount;
        }

        /// <summary>
        /// Find orders in which the quantity of the product is more than 10
        /// </summary>
        /// <returns>Task<Order></returns>
        public async Task<List<Order>> GetEntities()
        {
            List<Order> ordersInWhichQuantityOfProductIsMoreThan10 = await _dbContext.Orders
                .Where(o => o.Quantity > 10)
                .ToListAsync();

            return ordersInWhichQuantityOfProductIsMoreThan10;
        }

    }
}
