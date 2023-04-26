using NPUBackend.Domain.Entities;
using NPUBackend.Infra.DTO;

namespace NPUBackend.Infra.Interfaces.Services
{
    public interface IPartService
    {
        Task<PartDTO?> GetPartAsync(int partId);
        Task<string> AddPartToAssemblyAsync(Part part, int assemblyId);
        Task<string> RemovePartFromAssemblyAsync(int partId, int assemblyId);
        Task<ICollection<int>> FindAssemblyIDsWherePartIsUsedAsync(string partName);

        // External service
        Task<string> GetPartColorAsync(int partId);
        Task<string> GetPartCategoryAsync(int partId);
        Task<ICollection<int>> GetPartIDsForCategoryAsync(string category);
    }
}