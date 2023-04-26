using NPUBackend.Domain.Entities;
using NPUBackend.Domain.Interfaces.Repositories;
using NPUBackend.Infra.DTO;
using NPUBackend.Infra.Interfaces.Services;

namespace NPUBackend.Infra.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository k_UserRepository;

        private readonly string k_Salt = "123123";
        private readonly string k_HashingAlgorithm = "SHA512";

        public UserService(IUserRepository userRepository)
        {
            k_UserRepository = userRepository;
        }

        public async Task<string> LogInAsync(UserDTO user)
        {
            var authResult = await AuthenticateUserAsync(user);

            if (authResult == "Success")
            {
                // Do LogIn things.
            }

            return authResult;
        }

        public async Task<string> LogOutAsync(UserDTO user)
        {
            var authResult = await AuthenticateUserAsync(user);

            if (authResult == "Success")
            {
                // Do LogOut things.
            }

            return authResult;
        }

        public async Task<UserDTO?> GetUserByIdAsync(int userId)
        {
            var user = await k_UserRepository.GetUserAsync(userId);

            if (user == null || user.Id == -1)
            {
                return null;
            }

            var userDTO = new UserDTO(user);

            return userDTO;
        }

        public async Task<string> CreateUserAsync(UserDTO user)
        {
            var newPassword = new Password
            {
                HashedValue = ComputeHashedPassword(user.PlaintextPassword, k_Salt, k_HashingAlgorithm),
                Salt = k_Salt,
                PasswordPolicy = k_HashingAlgorithm
            };

            string result = await k_UserRepository.CreateUserAsync(user, newPassword);
            return result;
        }

        public async Task<string> DeleteUserAsync(UserDTO user)
        {
            var authResult = await AuthenticateUserAsync(user);

            if (authResult == "Success")
            {
                return await k_UserRepository.DeleteUserAsync(user.Id);
            }

            return authResult;
        }

        public async Task<string> ChangePasswordAsync(UserDTO user, string newPlaintextPassword)
        {
            var authResult = await AuthenticateUserAsync(user);

            if (authResult == "Success")
            {
                var newPassword = new Password
                {
                    HashedValue = ComputeHashedPassword(newPlaintextPassword, k_Salt, k_HashingAlgorithm),
                    Salt = k_Salt,
                    PasswordPolicy = k_HashingAlgorithm
                };

                var result = await k_UserRepository.ChangeUserPasswordAsync(user, newPassword);

                return result;
            }

            return authResult;
        }

        public async Task<string> AuthenticateUserAsync(UserDTO user)
        {
            var storedPassword = await k_UserRepository.GetPasswordForUserAsync(user.Id);

            var decryptedStoredPassword = DecryptHashedPassword(storedPassword);

            if(user.PlaintextPassword == decryptedStoredPassword)
            {
                return "Success";
            }

            return "Authentication failed";
        }

        private static string ComputeHashedPassword(string plaintextPassword, string salt, string algorithm)
        {
            // Make an actual hashing algorithm here.
            return plaintextPassword + salt;
        }

        private static string DecryptHashedPassword(Password hashedPassword)
        {
            // Make an actual decrypt algorithm here.
            if(!hashedPassword.HashedValue.EndsWith(hashedPassword.Salt))
            {
                throw new ArgumentException("Password decryption has failed");
            }

            return hashedPassword.HashedValue.Substring(0, hashedPassword.HashedValue.Length - hashedPassword.Salt.Length);
        }
    }
}
