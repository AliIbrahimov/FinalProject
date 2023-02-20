using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Controllers;

public class DeveloperController : Controller
{
    private readonly IDeveloperRepository _developer;
    private readonly IMapper _mapper;

    public DeveloperController(IDeveloperRepository developer, IMapper mapper)
    {
        _developer = developer;
        _mapper = mapper;
    }

    public IActionResult Developerprofile()
    {

        return View();
    }
}
