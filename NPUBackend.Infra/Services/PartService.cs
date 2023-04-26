using NPUBackend.Domain.Entities;
using NPUBackend.Domain.Interfaces.Repositories;
using NPUBackend.Infra.DTO;
using NPUBackend.Infra.Interfaces.Services;

namespace NPUBackend.Infra.Services
{
    public class PartService : IPartService
    {
        private readonly IPartRepository k_PartRepository;

        public PartService(IPartRepository partRepository)
        {
            k_PartRepository = partRepository;
        }

        public async Task<PartDTO?> GetPartAsync(int partId)
        {
            var result = await k_PartRepository.GetPartAsync(partId);

            if (result == null || result.Id == -1)
            {
                return null;
            }

            var partDTO = new PartDTO(result);

            return partDTO;
        }

        public async Task<string> AddPartToAssemblyAsync(Part part, int assemblyId)
        {
            Part existingPart = await k_PartRepository.GetPartAsync(part.Id);
            var assemblyPartRelation = await k_PartRepository.GetAssemblyPartRelationAsync(assemblyId, part.Id);

            if (existingPart.Id != -1)
            {
                await k_PartRepository.CreatePartAsync(part);
            }

            // Check if the found relation matches what was found in the database.
            if (assemblyPartRelation.PartId != part.Id && assemblyPartRelation.AssemblyId != assemblyId)
            {
                await k_PartRepository.AddAssemblyPartRelationAsync(assemblyPartRelation);
            }

            return "Success";
        }

        public async Task<string> RemovePartFromAssemblyAsync(int partId, int assemblyId)
        {
            var assemblyPartRelation = await k_PartRepository.GetAssemblyPartRelationAsync(assemblyId, partId);

            // Check if the found relation matches what was found in the database.
            if (assemblyPartRelation.PartId == partId && assemblyPartRelation.AssemblyId == assemblyId)
            {
                await k_PartRepository.DeleteAssemblyPartRelationAsync(assemblyPartRelation);
            }

            return "Success";
        }

        public async Task<ICollection<int>> FindAssemblyIDsWherePartIsUsedAsync(string partName)
        {
            var part = await k_PartRepository.GetPartAsync(partName);

            var result = await k_PartRepository.GetAssemblyIdsWherePartIdIsUsedAsync(part.Id);

            return result;
        }

        public Task<string> GetPartCategoryAsync(int partId)
        {
            // Implement external service here

            throw new NotImplementedException();
        }

        public Task<string> GetPartColorAsync(int partId)
        {
            // Implement external service here

            throw new NotImplementedException();
        }

        public Task<ICollection<int>> GetPartIDsForCategoryAsync(string category)
        {
            // Implement external service here

            throw new NotImplementedException();
        }
    }
}
