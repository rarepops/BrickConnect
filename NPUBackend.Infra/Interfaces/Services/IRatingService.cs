using NPUBackend.Infra.DTO;

namespace NPUBackend.Infra.Interfaces.Services
{
    public interface IRatingService
    {
        Task<string> RateAssemblyAsync(int assemblyId, int userId, int creativity, int uniqueness);
        Task<int> GetRatingIdAsync(int assemblyId, int userId);
        Task<AssemblyRatingDTO?> GetRatingAsync(int assemblyId, int userId);
        Task<string> DeleteRatingAsync(int ratingId);
        Task<AssemblyRatingDTO?> GetTotalRatingForAssemblyAsync(int assemblyId);
    }
}
