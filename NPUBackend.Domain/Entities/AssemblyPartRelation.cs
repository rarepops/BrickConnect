namespace NPUBackend.Domain.Entities
{
    public class AssemblyPartRelation
    {
        public int AssemblyId { get; set; }
        public int PartId { get; set; }

        public AssemblyPartRelation(int assemblyId, int partId)
        {
            AssemblyId = assemblyId;
            PartId = partId;
        }
    }
}
