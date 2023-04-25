using NPUBackend.Domain.Entities;

namespace NPUBackend.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int userId);
        Task<Password> GetPasswordForUserAsync(int userId);
        Task<string> CreateUserAsync(User user, Password password);
        Task<string> DeleteUserAsync(int userId);
        Task<string> ChangeUserPasswordAsync(User user, Password newPassword);
    }
}
