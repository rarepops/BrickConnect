using NPUBackend.Domain.Entities;

namespace NPUBackend.Infra.Interfaces.Services
{
    public interface IAssemblyService
    {
        public ICollection<Assembly> GetAssemblies();

        public Assembly GetAssemblyWithPartDetails();
    }
}
