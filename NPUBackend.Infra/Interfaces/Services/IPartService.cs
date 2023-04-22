using NPUBackend.Infra.DTO;

namespace NPUBackend.Infra.Interfaces.Services
{
    public interface IPartService
    {
        public PartDTO GetPart(int id);
        public string PartImageURL(int  partID);
        public string GetColor(int partId);
        public string GetSize(int partId);
    }
}
