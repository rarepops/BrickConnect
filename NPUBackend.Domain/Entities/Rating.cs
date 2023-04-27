namespace NPUBackend.Domain.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AssemblyId { get; set; }

        public int UniquenessRating { get; set; }
        public int CreativityRating { get; set; }
    }
}
