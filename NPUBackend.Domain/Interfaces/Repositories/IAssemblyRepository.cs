using NPUBackend.Domain.Entities;

namespace NPUBackend.Domain.Interfaces.Repositories
{
    public interface IAssemblyRepository
    {
        Task<Assembly> GetAssemblyAsync(int assemblyId);
        Task<int> CreateAssemblyAsync(Assembly assembly);
        Task<string> UpdateAssemblyAsync(Assembly assembly);
        Task<string> DeleteAssemblyAsync(int assemblyId);
    }
}
