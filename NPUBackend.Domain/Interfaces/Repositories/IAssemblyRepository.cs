using NPUBackend.Domain.Entities;

namespace NPUBackend.Domain.Interfaces.Repositories
{
    public interface IAssemblyRepository
    {
        public Assembly GetAssembly(int assemblyId);
        public int CreateAssembly(Assembly assembly);
        public string UpdateAssembly(Assembly assembly);
        public string DeleteAssembly(int assemblyId);
    }
}
