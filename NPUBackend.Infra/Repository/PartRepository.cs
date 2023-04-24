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

        public async Task<ICollection<Assembly>> GetAssembliesWhereUsedAsync(Part part)
        {
            throw new NotImplementedException();
        }

        public async Task<Part> GetPartAsync(int partId)
        {
            throw new NotImplementedException();
        }
    }
}
