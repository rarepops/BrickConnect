using NPUBackend.Domain.Entities;

namespace NPUBackend.Domain.Interfaces.Repositories
{
    public interface IScoringRepository
    {
        Task<Score> GetScoreAsync(int assemblyId);
        Task<Score> UpdateScoreAsync(int assemblyId);
        Task<Score> CreateScoreAsync(int assemblyId);

        Task RateAssemblyAsync(Assembly assembly, Score score);
        Task<ICollection<Score>> GetRatingsAsync(Assembly assembly);
    }
}
