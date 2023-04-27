using NPUBackend.Domain.Entities;

namespace NPUBackend.Domain.Interfaces.Repositories
{
    public interface IPartRepository
    {
        Task<int> CreatePartAsync(Part part);
        Task<Part> GetPartAsync(int partId);
        Task<Part> GetPartAsync(string partName);

        Task<string> AddAssemblyPartRelationAsync(AssemblyPartRelation partRelation);
        Task<string> DeleteAssemblyPartRelationAsync(AssemblyPartRelation partRelation);
        Task<ICollection<int>> GetAssemblyIdsWherePartIdIsUsedAsync(int partId);
        Task<AssemblyPartRelation> GetAssemblyPartRelationAsync(int assemblyId, int partId);
    }
}
