using TestTask.Data.Interfaces;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    /// <summary>
    /// Buisness logic for work with the order model
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Find the order with the largest order amount
        /// </summary>
        /// <returns>Task<Order></returns>
        public Task<Order> GetOrder()
        {
            Task<Order> order = _orderRepository.Get();

            return order;
        }

        /// <summary>
        /// Find orders in which the quantity of the product is more than 10
        /// </summary>
        /// <returns>Task<List<Order>></returns>
        public Task<List<Order>> GetOrders()
        {
            Task<List<Order>> orders = _orderRepository.GetEntities();

            return orders;
        }

    }
}
