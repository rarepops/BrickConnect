using NPUBackend.Infra.DTO;
using NPUBackend.Infra.Interfaces.Services;

namespace NPUBackend.Web.Controllers
{
    public class UserController
    {
        private readonly IUserService k_UserService;

        public UserController(IUserService userService)
        {
            k_UserService = userService;
        }

        public async Task<string> LogIn(UserDTO user)
        {
            string result = await k_UserService.LogInAsync(user);
            return result;
        }

        public async Task<string> LogOut(UserDTO user)
        {
            string result = await k_UserService.LogOutAsync(user);
            return result;
        }

        public async Task<string> CreateUser(UserDTO user)
        {
            string result = await k_UserService.CreateUserAsync(user);
            return result;
        }

        public async Task<UserDTO?> GetUser(int userId)
        {
            var result = await k_UserService.GetUserByIdAsync(userId);

            return result;
        }

        public async Task<string> DeleteUser(UserDTO user)
        {
            string result = await k_UserService.DeleteUserAsync(user);
            return result;
        }

        public async Task<string> ChangePassword(UserDTO user, string newPlaintextPassword)
        {
            string result = await k_UserService.ChangePasswordAsync(user, newPlaintextPassword);
            return result;
        }
    }
}
