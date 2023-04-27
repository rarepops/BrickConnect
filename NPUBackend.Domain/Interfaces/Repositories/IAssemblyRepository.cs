using NPUBackend.Domain.Entities;

namespace NPUBackend.Domain.Interfaces.Repositories
{
    public interface IAssemblyRepository
    {
        Task<string> CreateAssemblyAsync(Assembly assembly);
        Task<Assembly> GetAssemblyAsync(int assemblyId);
        Task<string> UpdateAssemblyAsync(Assembly assembly);
        Task<string> DeleteAssemblyAsync(int assemblyId);

        Task<ICollection<int>> GetPartIDsForAssemblyAsync(int assemblyId);
    }
}
