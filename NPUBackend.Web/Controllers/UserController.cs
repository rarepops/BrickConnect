using NPUBackend.Infra.DTO;
using NPUBackend.Infra.Interfaces.Services;

namespace NPUBackend.Web.Controllers
{
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> LogIn(UserDTO user)
        {
            return "Success";
        }

        public async Task<string> LogOut(UserDTO user)
        {
            return "Success";
        }

        public async Task<string> CreateUser(UserDTO user)
        {
            return "Success";
        }

        public async Task<string> DeleteUser(UserDTO user)
        {
            return "Success";
        }
    }
}
