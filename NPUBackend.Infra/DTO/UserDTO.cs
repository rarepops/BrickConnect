using NPUBackend.Domain.Entities;

namespace NPUBackend.Infra.DTO
{
    public class UserDTO : User
    {
        public UserDTO() { }

        public UserDTO(User user)
        {
            Id = user.Id;
            PasswordId = user.PasswordId;
            Username = user.Username;
            FirstName = user.FirstName;
            Surname = user.Surname;
            Birthday = user.Birthday;
            Email = user.Email;
        }

        public string PlaintextPassword { get; set; }
    }
}
