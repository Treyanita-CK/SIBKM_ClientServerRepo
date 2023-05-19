using API.Base;
using API.Models;
using API.Repositories.Interfaces;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UniversityControllers : GeneralController<IUniversityRepository, University, int>
{
    public UniversityControllers(IUniversityRepository repository) : base(repository) { }
}
 //
