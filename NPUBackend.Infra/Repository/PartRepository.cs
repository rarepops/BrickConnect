using NPUBackend.Domain.Entities;
using NPUBackend.Domain.Interfaces.Repositories;

namespace NPUBackend.Infra.Repository
{
    internal class PartRepository : IPartRepository
    {
        public async Task<int> CreatePartAsync(Part part)
        {
            throw new NotImplementedException();
        }

        public async Task<Part> GetPartAsync(int partId)
        {
            throw new NotImplementedException();
        }
        public async Task<Part> GetPartAsync(string partName)
        {
            throw new NotImplementedException();
        }

        public async Task<string> AddAssemblyPartRelationAsync(AssemblyPartRelation partRelation)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteAssemblyPartRelationAsync(AssemblyPartRelation partRelation)
        {
            throw new NotImplementedException();
        }
        public async Task<AssemblyPartRelation> GetAssemblyPartRelationAsync(int assemblyId, int partId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<int>> GetAssemblyIdsWherePartIdIsUsedAsync(int partId)
        {
            throw new NotImplementedException();
        }
    }
}
