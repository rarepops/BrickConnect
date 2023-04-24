using NPUBackend.Domain.Entities;
using NPUBackend.Domain.Interfaces.Repositories;

namespace NPUBackend.Infra.Repository
{
    internal class UserRepository : IUserRepository
    {
        public async Task<int> CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
