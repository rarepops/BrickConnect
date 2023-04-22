using NPUBackend.Domain.Entities;
using NPUBackend.Domain.Interfaces.Repositories;

namespace NPUBackend.Infra.Repository
{
    internal class PartRepository : IPartRepository
    {
        public int CreatePart(Part part)
        {
            throw new NotImplementedException();
        }

        public ICollection<Assembly> GetAssembliesWhereUsed(Part part)
        {
            throw new NotImplementedException();
        }

        public Part GetPart(int partId)
        {
            throw new NotImplementedException();
        }
    }
}
