namespace NPUBackend.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int PasswordId { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
