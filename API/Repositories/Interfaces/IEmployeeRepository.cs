using API.Models;

namespace API.Repositories.Interfaces
{
    public interface IEmployeeRepository : IGeneralRepository<Employee, string>
    {
        string GetFullNameByEmail(string email);
    }
}
