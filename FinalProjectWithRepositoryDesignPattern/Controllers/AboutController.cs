using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;
using FinalProjectWithRepositoryDesignPattern.DTOs.AboutUs;
using FinalProjectWithRepositoryDesignPattern.DTOs.Contact;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Controllers;

public class AboutController : Controller
{
    private readonly IAboutRepository _aboutRepository;
    private readonly IMapper _mapper;

    public AboutController(IAboutRepository aboutRepository, IMapper mapper)
    {
        _aboutRepository = aboutRepository;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }
}
