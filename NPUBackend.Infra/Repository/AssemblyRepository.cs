using NPUBackend.Domain.Entities;
using NPUBackend.Domain.Interfaces.Repositories;

namespace NPUBackend.Infra.Repository
{
    internal class AssemblyRepository : IAssemblyRepository
    {
        public Task<string> CreateAssemblyAsync(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public Task<Assembly> GetAssemblyAsync(int assemblyId)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAssemblyAsync(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAssemblyAsync(int assemblyId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<int>> GetPartIDsForAssemblyAsync(int assemblyId)
        {
            throw new NotImplementedException();
        }
    }
}
