using API.Context;
using API.Models;
using API.Repositories.Interfaces;

namespace API.Repositories.Data;

public class RoleRepository : GeneralRepository<Role, int, MyContext>, IRoleRepository
{

    public RoleRepository(MyContext context) : base(context) { }


}


