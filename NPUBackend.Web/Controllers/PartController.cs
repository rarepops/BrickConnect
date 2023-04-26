using NPUBackend.Infra.DTO;
using NPUBackend.Infra.Interfaces.Services;

namespace NPUBackend.Web.Controllers
{
    public class PartController
    {
        private readonly IPartService k_PartService;

        public PartController(IPartService partService)
        {
            k_PartService = partService;
        }

        public async Task<PartDTO?> GetPart(int partId)
        {
            var result = await k_PartService.GetPartAsync(partId);
            return result;
        }

        public async Task<string> AddPartToAssembly(PartDTO part, int assemblyId)
        {
            var result = await k_PartService.AddPartToAssemblyAsync(part, assemblyId);
            return result;
        }

        public async Task<string> RemovePartFromAssembly(int partId, int assemblyId)
        {
            var result = await k_PartService.RemovePartFromAssemblyAsync(partId, assemblyId);
            return result;
        }

        public async Task<ICollection<int>> FindAssembliesWherePartIsUsed(string partName)
        {
            var result = await k_PartService.FindAssemblyIDsWherePartIsUsedAsync(partName);
            return result;
        }

        public async Task<string> GetPartColor(int partId)
        {
            var result = await k_PartService.GetPartColorAsync(partId);
            return result;
        }

        public async Task<string> GetPartCategory(int partId)
        {
            var result = await k_PartService.GetPartCategoryAsync(partId);
            return result;
        }

        public async Task<ICollection<int>> GetPartIDsForCategory(string category)
        {
            var result = await k_PartService.GetPartIDsForCategoryAsync(category);
            return result;
        }
    }
}
