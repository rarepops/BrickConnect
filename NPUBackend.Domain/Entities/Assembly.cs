namespace NPUBackend.Domain.Entities
{
    public class Assembly
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
    }
}
