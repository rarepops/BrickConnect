using NPUBackend.Domain.Entities;

namespace NPUBackend.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public User GetUser(string userId);
        public int CreateUser(User user);
        public string DeleteUser(string userId);
    }
}
