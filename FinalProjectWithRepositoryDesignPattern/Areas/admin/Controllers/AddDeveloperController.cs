using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;
using FinalProjectWithRepositoryDesignPattern.DTOs.Contact;
using FinalProjectWithRepositoryDesignPattern.DTOs.Developer;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Areas.admin.Controllers;
[Area("admin")]
public class AddDeveloperController : Controller
{
    private readonly IDeveloperRepository _repository;
    private readonly IMapper _mapper;

    public AddDeveloperController(IDeveloperRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        List<DeveloperGetDto> developers = _mapper.Map<List<DeveloperGetDto>>(await _repository.GetAllAsync());
        return View(developers);
    }
}
