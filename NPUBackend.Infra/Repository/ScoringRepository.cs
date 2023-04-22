using NPUBackend.Domain.Entities;
using NPUBackend.Domain.Interfaces.Repositories;

namespace NPUBackend.Infra.Repository
{
    internal class ScoringRepository : IScoringRepository
    {
        public Score CreateScore(int assemblyId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Score> GetRating(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public Score GetScore(int assemblyId)
        {
            throw new NotImplementedException();
        }

        public void RateAssembly(Assembly assembly, Score score)
        {
            throw new NotImplementedException();
        }

        public Score UpdateScore(int assemblyId)
        {
            throw new NotImplementedException();
        }
    }
}
