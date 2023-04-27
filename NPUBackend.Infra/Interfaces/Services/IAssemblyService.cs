using NPUBackend.Infra.DTO;

namespace NPUBackend.Infra.Interfaces.Services
{
    public interface IAssemblyService
    {
        Task<string> CreateAssemblyAsync(AssemblyDTO assembly);
        Task<AssemblyDTO?> GetAssemblyAsync(int assemblyId);
        Task<string> UpdateAssemblyAsync(AssemblyDTO assemblyDTO);
        Task<string> DeleteAssemblyAsync(int assemblyId);

        Task<ICollection<int>> GetPartIDsForAssembly(int assemblyId);
    }
}
