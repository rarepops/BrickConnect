using NPUBackend.Domain.Entities;
using NPUBackend.Domain.Interfaces.Repositories;

namespace NPUBackend.Infra.Repository
{
    internal class UserRepository : IUserRepository
    {
        public async Task<string> CreateUserAsync(User user, Password password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Password> GetPasswordForUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ChangeUserPasswordAsync(User user, Password newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
