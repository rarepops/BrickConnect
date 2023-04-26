using NPUBackend.Domain.Entities;
using NPUBackend.Domain.Interfaces.Repositories;

namespace NPUBackend.Infra.Repository
{
    internal class AssemblyRepository : IAssemblyRepository
    {
        public async Task<int> CreateAssemblyAsync(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteAssemblyAsync(int assemblyId)
        {
            throw new NotImplementedException();
        }

        public async Task<Assembly> GetAssemblyAsync(int assemblyId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Part>> GetPartsForAssemblyAsync(int assemblyId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateAssemblyAsync(Assembly assembly)
        {
            throw new NotImplementedException();
        }
    }
}
