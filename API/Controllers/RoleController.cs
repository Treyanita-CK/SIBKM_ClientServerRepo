using API.Base;
using API.Models;
using API.Repositories.Interfaces;

using Microsoft.AspNetCore.Mvc;
//

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RoleController : GeneralController<IRoleRepository, Role, int>
{
    public RoleController(IRoleRepository repository) : base(repository) { }
}