using NPUBackend.Domain.Entities;

namespace NPUBackend.Domain.Interfaces.Repositories
{
    public interface IPartRepository
    {
        public int CreatePart(Part part);
        public Part GetPart(int partId);
        public ICollection<Assembly> GetAssembliesWhereUsed(Part part);
    }
}
