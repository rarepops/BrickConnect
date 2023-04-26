using NPUBackend.Domain.Entities;

namespace NPUBackend.Domain.Interfaces.Repositories
{
    public interface IPartRepository
    {
        Task<int> CreatePartAsync(Part part);
        Task<Part> GetPartAsync(int partId);
        Task<Part> GetPartAsync(string partName);
        Task<ICollection<int>> GetAssemblyIdsWherePartIdIsUsedAsync(int partId);

        Task<string> AddAssemblyPartRelationAsync(AssemblyPartRelation partRelation);
        Task<AssemblyPartRelation> GetAssemblyPartRelationAsync(int assemblyId, int partId);
        Task<string> DeleteAssemblyPartRelationAsync(AssemblyPartRelation partRelation);
    }
}
