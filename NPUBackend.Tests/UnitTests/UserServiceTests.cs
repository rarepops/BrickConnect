using Moq;
using NPUBackend.Domain.Entities;
using NPUBackend.Domain.Interfaces.Repositories;
using NPUBackend.Infra.DTO;
using NPUBackend.Infra.Interfaces.Services;
using NPUBackend.Infra.Services;
using NUnit.Framework;

namespace NPUBackend.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private IUserService m_UserService;
        private Mock<IUserRepository> m_UserRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            m_UserRepositoryMock = new Mock<IUserRepository>();
            m_UserService = new UserService(m_UserRepositoryMock.Object);
        }

        [TestCase("password123", "password123123123", "123123", "SHA512", "Success")]
        [TestCase("password111", "password123123123", "123123", "SHA512", "Authentication failed")]
        public async Task LogInAsync_AuthenticatesUser_ReturnsExpectedResult(string inputPassword, string storedHashedValue, string storedSalt, string passwordPolicy, string expectedResult)
        {
            var userDto = new UserDTO
            {
                Id = 1,
                PlaintextPassword = inputPassword
            };

            var storedPassword = new Password
            {
                HashedValue = storedHashedValue,
                Salt = storedSalt,
                PasswordPolicy = passwordPolicy
            };

            m_UserRepositoryMock.Setup(x => x.GetPasswordForUserAsync(userDto.Id)).ReturnsAsync(storedPassword);

            var result = await m_UserService.LogInAsync(userDto);

            Assert.AreEqual(expectedResult, result);
            m_UserRepositoryMock.Verify(x => x.GetPasswordForUserAsync(userDto.Id), Times.Once);
        }

        [TestCase("password123", "password123123123", "123123", "SHA512", "Success")]
        [TestCase("password111", "password123123123", "123123", "SHA512", "Authentication failed")]
        public async Task LogOutAsync_AuthenticatesUser_ReturnsExpectedResult(string inputPassword, string storedHashedValue, string storedSalt, string passwordPolicy, string expectedResult)
        {
            var userDto = new UserDTO
            {
                Id = 1,
                PlaintextPassword = inputPassword
            };

            var storedPassword = new Password
            {
                HashedValue = storedHashedValue,
                Salt = storedSalt,
                PasswordPolicy = passwordPolicy
            };

            m_UserRepositoryMock.Setup(x => x.GetPasswordForUserAsync(userDto.Id)).ReturnsAsync(storedPassword);

            var result = await m_UserService.LogOutAsync(userDto);

            Assert.AreEqual(expectedResult, result);
            m_UserRepositoryMock.Verify(x => x.GetPasswordForUserAsync(userDto.Id), Times.Once);
        }

        [Test]
        public async Task ChangePasswordAsync_AuthenticatesUser_ChangesPassword()
        {
            var userDto = new UserDTO
            {
                Id = 1,
                PlaintextPassword = "password123"
            };

            var newPassword = "newPassword123";
            var storedPassword = new Password
            {
                HashedValue = "password123123123",
                Salt = "123123",
                PasswordPolicy = "SHA512"
            };

            m_UserRepositoryMock.Setup(x => x.GetPasswordForUserAsync(userDto.Id)).ReturnsAsync(storedPassword);
            m_UserRepositoryMock.Setup(x => x.ChangeUserPasswordAsync(userDto, It.IsAny<Password>())).ReturnsAsync("Success");

            var result = await m_UserService.ChangePasswordAsync(userDto, newPassword);

            Assert.AreEqual("Success", result);
            m_UserRepositoryMock.Verify(x => x.GetPasswordForUserAsync(userDto.Id), Times.Once);
            m_UserRepositoryMock.Verify(x => x.ChangeUserPasswordAsync(userDto, It.IsAny<Password>()), Times.Once);
        }

        [TestCase("testpassword123123", true, TestName = "WhenPasswordsHaveCorrectSalt_MatchesUserPassword_Pass")]
        [TestCase("wrongpassword123123", false, TestName = "WhenPasswordsHaveCorrectSalt_DoesNotMatchUserPassword_Fail")]
        public async Task AuthenticateUserAsync_ValidPasswordTests(string testPassword, bool expectedResult)
        {
            var validUser = new UserDTO
            {
                Id = 1,
                Username = "testuser",
                Email = "testuser@example.com",
                FirstName = "Test",
                Surname = "User",
                Birthday = DateTime.Now,
                PlaintextPassword = "testpassword"
            };

            m_UserRepositoryMock.Setup(x => x.GetPasswordForUserAsync(validUser.Id)).ReturnsAsync(new Password
            {
                HashedValue = testPassword,
                Salt = "123123"
            });

            var result = await m_UserService.AuthenticateUserAsync(validUser);

            Assert.AreEqual(expectedResult, "Success" == result);
            m_UserRepositoryMock.Verify(x => x.GetPasswordForUserAsync(validUser.Id), Times.Once);
        }

        [Test]
        public Task AuthenticateUserAsync_CorruptedPassword_Throws()
        {
            var validUser = new UserDTO
            {
                Id = 1,
                Username = "testuser",
                Email = "testuser@example.com",
                FirstName = "Test",
                Surname = "User",
                Birthday = DateTime.Now,
                PlaintextPassword = "testpassword"
            };

            m_UserRepositoryMock.Setup(x => x.GetPasswordForUserAsync(validUser.Id)).ReturnsAsync(new Password
            {
                HashedValue = "testpassword111111",
                Salt = "123123"
            });

            Assert.ThrowsAsync<ArgumentException>(async () => await m_UserService.AuthenticateUserAsync(validUser));
            m_UserRepositoryMock.Verify(x => x.GetPasswordForUserAsync(validUser.Id), Times.Once);

            return Task.CompletedTask;
        }

        [Test]
        public async Task CreateUserAsync_ValidUser_Success()
        {
            var newUser = new UserDTO
            {
                Username = "testuser",
                Email = "testuser@example.com",
                FirstName = "Test",
                Surname = "User",
                Birthday = DateTime.Now,
                PlaintextPassword = "testpassword"
            };

            m_UserRepositoryMock.Setup(x => x.CreateUserAsync(It.IsAny<User>(), It.IsAny<Password>())).ReturnsAsync("Success");

            var result = await m_UserService.CreateUserAsync(newUser);

            Assert.AreEqual("Success", result);
        }

        [Test]
        public async Task DeleteUserAsync_ValidUser_Success()
        {
            var validUser = new UserDTO
            {
                Id = 1,
                Username = "testuser",
                Email = "testuser@example.com",
                FirstName = "Test",
                Surname = "User",
                Birthday = DateTime.Now,
                PlaintextPassword = "testpassword"
            };

            m_UserRepositoryMock.Setup(x => x.GetPasswordForUserAsync(validUser.Id)).ReturnsAsync(new Password
            {
                HashedValue = validUser.PlaintextPassword + "123123",
                Salt = "123123"
            });
            m_UserRepositoryMock.Setup(x => x.DeleteUserAsync(validUser.Id)).ReturnsAsync("Success");

            var result = await m_UserService.DeleteUserAsync(validUser);

            Assert.AreEqual("Success", result);
        }

        [Test]
        public async Task GetUserByIdAsync_ValidUserId_ReturnsUserDTO()
        {
            int userId = 1;
            var user = new User
            {
                Id = userId,
                Username = "testuser",
                Email = "testuser@example.com",
                FirstName = "Test",
                Surname = "User",
                Birthday = DateTime.Now,
            };

            m_UserRepositoryMock.Setup(x => x.GetUserAsync(userId)).ReturnsAsync(user);

            var result = await m_UserService.GetUserByIdAsync(userId);

            Assert.IsInstanceOf<UserDTO>(result);
            Assert.AreEqual(user.Id, result.Id);
            Assert.AreEqual(user.Username, result.Username);
            Assert.AreEqual(user.Email, result.Email);
            Assert.AreEqual(user.FirstName, result.FirstName);
            Assert.AreEqual(user.Surname, result.Surname);
            Assert.AreEqual(user.Birthday, result.Birthday);
        }

        [Test]
        public async Task GetUserAsync_UserNotFound_ReturnsNull()
        {
            int userId = 1;
            var notFoundUser = new User
            {
                Id = -1
            };

            m_UserRepositoryMock.Setup(x => x.GetUserAsync(userId)).ReturnsAsync(notFoundUser);

            var result = await m_UserService.GetUserByIdAsync(userId);

            Assert.IsNull(result);
        }
    }
}