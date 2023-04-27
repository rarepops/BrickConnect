using NPUBackend.Infra.DTO;
using NPUBackend.Infra.Interfaces.Services;

namespace NPUBackend.Web.Controllers
{
    public class AssemblyController
    {
        private readonly IAssemblyService k_AssemblyService;
        private readonly IRatingService k_RatingService;

        public AssemblyController(IAssemblyService assemblyService, IRatingService ratingService)
        {
            k_AssemblyService = assemblyService;
            k_RatingService = ratingService;
        }

        public async Task<string> CreateAssembly(AssemblyDTO assembly)
        {
            var result = await k_AssemblyService.CreateAssemblyAsync(assembly);

            return result;
        }

        public async Task<AssemblyDTO?> GetAssembly(int assemblyId)
        {
            var result = await k_AssemblyService.GetAssemblyAsync(assemblyId);

            return result;
        }

        public async Task<string> UpdateAssembly(AssemblyDTO assemblyDTO)
        {
            var result = await k_AssemblyService.UpdateAssemblyAsync(assemblyDTO);

            return result;
        }

        public async Task<string> DeleteAssembly(int assemblyId)
        {
            var result = await k_AssemblyService.DeleteAssemblyAsync(assemblyId);

            return result;
        }

        public async Task<ICollection<int>?> GetPartIDsForAssembly(int assemblyId)
        {
            var result = await k_AssemblyService.GetPartIDsForAssembly(assemblyId);

            return result;
        }



        public async Task<string> RateAssembly(int assemblyId, int userId, int creativity, int uniqueness)
        {
            var result = await k_RatingService.RateAssemblyAsync(assemblyId, userId, creativity, uniqueness);

            return result;
        }

        public async Task<int> GetRatingId(int assemblyId, int userId)
        {
            var result = await k_RatingService.GetRatingIdAsync(assemblyId, userId);

            return result;
        }

        public async Task<AssemblyRatingDTO?> GetRating(int assemblyId, int userId)
        {
            var result = await k_RatingService.GetRatingAsync(assemblyId, userId);

            return result;
        }

        public async Task<string> DeleteRating(int ratingId)
        {
            var result = await k_RatingService.DeleteRatingAsync(ratingId);

            return result;
        }

        public async Task<AssemblyRatingDTO?> GetTotalRatingForAssembly(int assemblyId)
        {
            var result = await k_RatingService.GetTotalRatingForAssemblyAsync(assemblyId);

            return result;
        }
    }
}
