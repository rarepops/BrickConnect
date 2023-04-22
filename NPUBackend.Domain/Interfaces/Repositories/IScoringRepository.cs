using NPUBackend.Domain.Entities;

namespace NPUBackend.Domain.Interfaces.Repositories
{
    public interface IScoringRepository
    {
        public Score GetScore(int assemblyId);
        public Score UpdateScore(int assemblyId);
        public Score CreateScore(int assemblyId);

        public void RateAssembly(Assembly assembly, Score score);
        public ICollection<Score> GetRating(Assembly assembly);
    }
}
