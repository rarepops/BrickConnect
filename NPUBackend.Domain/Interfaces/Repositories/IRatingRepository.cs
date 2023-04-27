using NPUBackend.Domain.Entities;

namespace NPUBackend.Domain.Interfaces.Repositories
{
    public interface IRatingRepository
    {
        Task<string> RateAssemblyAsync(Rating rating);
        Task<Rating> GetRatingAsync(int assemblyId, int userId);
        Task<string> UpdateRatingAsync(Rating rating);
        Task<string> DeleteRatingAsync(int ratingId);

        Task<ICollection<Rating>> GetRatingsForAssembly(int assemblyId);
    }
}
