using NPUBackend.Domain.Entities;

namespace NPUBackend.Infra.DTO
{
    public class PartDTO : Part
    {
        public PartDTO() { }

        public PartDTO(Part part) 
        {
            Id = part.Id;
            DirectoryId = part.DirectoryId;
            Name = part.Name;
        }
    }
}
