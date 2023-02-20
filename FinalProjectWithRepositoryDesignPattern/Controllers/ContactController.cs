using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DTOs.Contact;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Controllers;

public class ContactController : Controller
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public ContactController(IContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(ContactPostDto contactPost)
    {
        Contact contact = _mapper.Map<Contact>(contactPost);
        await _contactRepository.CreateAsync(contact);
        await _contactRepository.SaveAsync();
        return View();
    }
}

