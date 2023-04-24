using NPUBackend.Domain.Entities;
using NPUBackend.Infra.DTO;

namespace NPUBackend.Infra.Interfaces.Services
{
    public interface IAssemblyService
    {
        public Task<ICollection<Assembly>> GetAssemblies();

        public Task<Assembly> GetAssembliesWithPartDetails(PartDTO part);
    }
}
