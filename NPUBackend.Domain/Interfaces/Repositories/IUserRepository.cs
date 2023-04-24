using NPUBackend.Domain.Entities;

namespace NPUBackend.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string userId);
        Task<int> CreateUserAsync(User user);
        Task<string> DeleteUserAsync(string userId);
    }
}
