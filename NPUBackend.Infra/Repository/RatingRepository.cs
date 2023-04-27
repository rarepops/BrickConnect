using NPUBackend.Domain.Entities;
using NPUBackend.Domain.Interfaces.Repositories;

namespace NPUBackend.Infra.Repository
{
    internal class RatingRepository : IRatingRepository
    {
        public Task<string> RateAssemblyAsync(Rating rating)
        {
            throw new NotImplementedException();
        }

        public Task<Rating> GetRatingAsync(int assemblyId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateRatingAsync(Rating rating)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteRatingAsync(int ratingId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Rating>> GetRatingsForAssembly(int assemblyId)
        {
            throw new NotImplementedException();
        }
    }
}
