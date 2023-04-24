using NPUBackend.Domain.Entities;
using NPUBackend.Domain.Interfaces.Repositories;

namespace NPUBackend.Infra.Repository
{
    internal class ScoringRepository : IScoringRepository
    {
        public async Task<Score> CreateScoreAsync(int assemblyId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Score>> GetRatingsAsync(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public async Task<Score> GetScoreAsync(int assemblyId)
        {
            throw new NotImplementedException();
        }

        public async Task RateAssemblyAsync(Assembly assembly, Score score)
        {
            throw new NotImplementedException();
        }

        public async Task<Score> UpdateScoreAsync(int assemblyId)
        {
            throw new NotImplementedException();
        }
    }
}
