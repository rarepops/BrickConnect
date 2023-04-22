namespace NPUBackend.Domain.Entities
{
    public class Score
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AssemblyId { get; set; }

        public int UniquenessScore { get; set; }
        public int CreativityScore { get; set; }
    }
}
