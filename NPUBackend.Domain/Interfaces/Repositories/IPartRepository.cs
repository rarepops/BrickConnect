using NPUBackend.Domain.Entities;

namespace NPUBackend.Domain.Interfaces.Repositories
{
    public interface IPartRepository
    {
        Task<int> CreatePartAsync(Part part);
        Task<Part> GetPartAsync(int partId);
        Task<ICollection<Assembly>> GetAssembliesWhereUsedAsync(Part part);
    }
}
