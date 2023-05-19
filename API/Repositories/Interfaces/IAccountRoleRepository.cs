using API.Models;

namespace API.Repositories.Interfaces
{
    public interface IAccountRoleRepository : IGeneralRepository<AccountRole, int>
    {
        IEnumerable<string> GetRolesByEmail (string email);
    }
}
