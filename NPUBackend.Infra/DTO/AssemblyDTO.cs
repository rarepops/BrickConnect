using NPUBackend.Domain.Entities;

namespace NPUBackend.Infra.DTO
{
    public class AssemblyDTO : Domain.Entities.Assembly
    {
        public ICollection<int> PartIds { get; set; }

        public AssemblyDTO() { }
        public AssemblyDTO(Domain.Entities.Assembly assembly)
        {
            Id = assembly.Id;
            UserId = assembly.UserId;
            ImageURL = assembly.ImageURL;
            Name = assembly.Name;
            Description = assembly.Description;
        }
    }
}
