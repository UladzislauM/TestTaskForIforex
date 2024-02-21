using TestTask.Data.Interfaces;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    /// <summary>
    /// Buisness logic for work with the user model
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Find the user with the largest number of orders
        /// </summary>
        /// <returns>Task<User></returns>
        public Task<User> GetUser()
        {
            Task<User> user = _userRepository.Get();

            return user;
        }

        /// <summary>
        /// Find users with Inactive status
        /// </summary>
        /// <returns>Task<List<User>></returns>
        public Task<List<User>> GetUsers()
        {
            Task<List<User>> users = _userRepository.GetEntities();

            return users;
        }

    }
}
