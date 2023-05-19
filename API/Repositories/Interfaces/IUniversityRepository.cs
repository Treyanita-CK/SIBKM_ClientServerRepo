using API.Models;

namespace API.Repositories.Interfaces
{
    public interface IUniversityRepository : IGeneralRepository<University, int>
    {
        IEnumerable<University> GetByName(string name);
    }
}
