namespace NPUBackend.Domain.Entities
{
    public class Password
    {
        public int Id { get; set; }

        public string HashedValue { get; set; }
        public string PasswordPolicy { get; set; }
        public string Salt { get; set; }

        public DateTime LastChanged { get; set; }
    }
}
