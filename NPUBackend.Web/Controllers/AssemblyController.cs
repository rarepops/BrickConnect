using NPUBackend.Infra.DTO;
using NPUBackend.Infra.Interfaces.Services;

namespace NPUBackend.Web.Controllers
{
    public class AssemblyController
    {
        private readonly IAssemblyService _assemblyService;

        public AssemblyController(IAssemblyService assemblyService)
        {
            _assemblyService = assemblyService;
        }

        public async Task<string> CreateAssembly(AssemblyDTO assembly)
        {
            throw new NotImplementedException();
        }

        public async Task<AssemblyDTO> GetAssembly(int assemblyId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateAssembly(AssemblyDTO assemblyDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteAssembly(int assemblyId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> RateAssembly(int assemblyId, int userId, int creativity, int uniqueness)
        {
            throw new NotImplementedException();
        }

        public async Task<AssemblyScoreDTO> GetRatingForAssembly(int assemblyId)
        {
            throw new NotImplementedException();
        }
    }
}
