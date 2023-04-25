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

        public async Task<string> CreatePartAsync(PartDTO part)
        {
            throw new NotImplementedException();
        }

        public async Task<PartDTO> GetPartAsync(int partId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<AssemblyDTO>> GetAssembliesWherePartIsUsedAsync(PartDTO part)
        {
            throw new NotImplementedException();
        }
    }
}
