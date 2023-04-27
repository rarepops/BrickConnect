using NPUBackend.Domain.Interfaces.Repositories;
using NPUBackend.Infra.DTO;
using NPUBackend.Infra.Interfaces.Services;

namespace NPUBackend.Infra.Services
{
    public class AssemblyService : IAssemblyService
    {
        private readonly IAssemblyRepository k_AssemblyRepository;

        public AssemblyService(IAssemblyRepository assemblyRepository)
        {
            k_AssemblyRepository = assemblyRepository;
        }

        public async Task<string> CreateAssemblyAsync(AssemblyDTO assembly)
        {
            var result = await k_AssemblyRepository.CreateAssemblyAsync(assembly);

            return result;
        }

        public async Task<AssemblyDTO?> GetAssemblyAsync(int assemblyId)
        {
            var result = await k_AssemblyRepository.GetAssemblyAsync(assemblyId);

            if (result == null || result.Id == -1)
            {
                return null;
            }

            var newAssemblyDTO = new AssemblyDTO(result);

            newAssemblyDTO.PartIds = await k_AssemblyRepository.GetPartIDsForAssemblyAsync(newAssemblyDTO.Id);

            return newAssemblyDTO;
        }

        public async Task<string> UpdateAssemblyAsync(AssemblyDTO assemblyDTO)
        {
            var result = await k_AssemblyRepository.UpdateAssemblyAsync(assemblyDTO);

            return result;
        }

        public async Task<string> DeleteAssemblyAsync(int assemblyId)
        {
            var result = await k_AssemblyRepository.DeleteAssemblyAsync(assemblyId);

            return result;
        }

        public async Task<ICollection<int>> GetPartIDsForAssembly(int assemblyId)
        {
            var result = await k_AssemblyRepository.GetPartIDsForAssemblyAsync(assemblyId);

            return result;
        }
    }
}
