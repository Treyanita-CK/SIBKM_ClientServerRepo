using API.Base;
using API.Handlers;
using API.Models;
using API.Repositories.Data;
using API.Repositories.Interfaces;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize (Roles = "admin")]
//[EnableCors("AnotherPolicy")]
public class AccountController : GeneralController<IAccountRepository, Account, string>
{
    private readonly ITokenService _tokenService;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IAccountRoleRepository _accountRoleRepository;

    public AccountController(
        IAccountRepository repository,
        ITokenService tokenService,
        IEmployeeRepository employeeRepository,
        IAccountRoleRepository accountRoleRepository) : base(repository)
    {
        _tokenService = tokenService;
        _employeeRepository = employeeRepository;
        _accountRoleRepository = accountRoleRepository;
    }
    
    [AllowAnonymous]
    [HttpPost("Login")]
    public ActionResult Login(LoginVM loginVM)
    {
        var login = _repository.Login(loginVM);
        if (login) {
            return Ok(new ResponseDataVM<string> {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Login Success"
            });
        }
        return NotFound(new ResponseErrorsVM<string> {
            Code = StatusCodes.Status404NotFound,
            Status = HttpStatusCode.NotFound.ToString(),
            Errors = "Login Failed, Account or Password Not Found!"
        });
    }

    [AllowAnonymous]
    [HttpPost("Register")]
    public ActionResult Register(RegisterVM registerVM)
    {
        var register = _repository.Register(registerVM);
        if (register > 0)
        {
            return Ok(new ResponseDataVM<string>
            {
                Code = StatusCodes.Status200OK,
                Status = HttpStatusCode.OK.ToString(),
                Message = "Insert Success"
            });
        }

        return BadRequest(new ResponseErrorsVM<string>
        {
            Code = StatusCodes.Status500InternalServerError,
            Status = HttpStatusCode.InternalServerError.ToString(),
            Errors = "Insert Failed / Lost Connection"
        });
    }
}