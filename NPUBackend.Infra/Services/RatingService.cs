using NPUBackend.Domain.Entities;
using NPUBackend.Domain.Interfaces.Repositories;
using NPUBackend.Infra.DTO;
using NPUBackend.Infra.Interfaces.Services;

namespace NPUBackend.Infra.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository k_RatingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            k_RatingRepository = ratingRepository;
        }

        public async Task<string> RateAssemblyAsync(int assemblyId, int userId, int creativity, int uniqueness)
        {
            var newRating = new Rating()
            {
                AssemblyId = assemblyId,
                UserId = userId,
                CreativityRating = creativity,
                UniquenessRating = uniqueness,
            };

            var result = await k_RatingRepository.RateAssemblyAsync(newRating);

            return result;
        }

        public async Task<string> DeleteRatingAsync(int ratingId)
        {
            var result = await k_RatingRepository.DeleteRatingAsync(ratingId);

            return result;
        }

        public async Task<AssemblyRatingDTO?> GetRatingAsync(int assemblyId, int userId)
        {
            var rating = await k_RatingRepository.GetRatingAsync(assemblyId, userId);

            if (rating == null)
            {
                return null;
            }

            var ratingDTO = new AssemblyRatingDTO
            {
                Creativity = rating.CreativityRating,
                Uniqueness = rating.UniquenessRating
            };

            return ratingDTO;
        }

        public async Task<int> GetRatingIdAsync(int assemblyId, int userId)
        {
            var rating = await k_RatingRepository.GetRatingAsync(assemblyId, userId);

            return rating.Id;
        }

        public async Task<AssemblyRatingDTO?> GetTotalRatingForAssemblyAsync(int assemblyId)
        {
            var totalRating = new AssemblyRatingDTO()
            {
                Creativity = 0,
                Uniqueness = 0
            };

            var allAssemblyRatings = await k_RatingRepository.GetRatingsForAssembly(assemblyId);

            foreach(var rating in allAssemblyRatings)
            {
                totalRating.Creativity += rating.CreativityRating;
                totalRating.Uniqueness += rating.UniquenessRating;
            }

            totalRating.Creativity/= allAssemblyRatings.Count();
            totalRating.Uniqueness /= allAssemblyRatings.Count();

            return totalRating;
        }
    }
}
