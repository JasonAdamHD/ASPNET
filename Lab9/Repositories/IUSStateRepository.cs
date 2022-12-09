using Lab9.DataObjects;

namespace Lab9.Repositories
{
    public interface IUSStateRepository
    {
        public IEnumerable<USState> GetAll();
    }
}
