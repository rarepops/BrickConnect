using NPUBackend.Domain.Entities;
using NPUBackend.Infra.DTO;

namespace NPUBackend.Infra.Interfaces.Services
{
    public interface IAssemblyService
    {
        Task<ICollection<int>> GetPartsForAssemblyAsync(int assemblyId);
    }
}
