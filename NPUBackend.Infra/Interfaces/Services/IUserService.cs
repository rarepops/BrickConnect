using NPUBackend.Infra.DTO;

namespace NPUBackend.Infra.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> LogInAsync(UserDTO user);
        Task<string> LogOutAsync(UserDTO user);
        Task<string> CreateUserAsync(UserDTO user);
        Task<UserDTO?> GetUserByIdAsync(int id);
        Task<string> DeleteUserAsync(UserDTO user);
        Task<string> AuthenticateUserAsync(UserDTO user);
        Task<string> ChangePasswordAsync(UserDTO user, string newPlaintextPassword);
    }
}
