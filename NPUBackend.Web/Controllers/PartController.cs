using NPUBackend.Infra.DTO;
using NPUBackend.Infra.Interfaces.Services;

namespace NPUBackend.Web.Controllers
{
    public class PartController
    {
        private readonly IPartService _partService;

        public PartController(IPartService partService)
        {
            _partService = partService;
        }

        public async Task<string> CreatePart(PartDTO part)
        {
            throw new NotImplementedException();
        }

        public async Task<PartDTO> GetPart(int partId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AssemblyDTO>> GetAssembliesWherePartIsUsed(PartDTO part)
        {
            throw new NotImplementedException();
        }
    }
}
