using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;
using FinalProjectWithRepositoryDesignPattern.DTOs.Contact;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Areas.admin.Controllers;

[Area("admin")]
public class ContactController : Controller
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public ContactController(IContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        List<ContactGetDto> contactGet = _mapper.Map<List<ContactGetDto>>(await _contactRepository.GetAllAsync());
        return View(contactGet);
    }
    public async Task<IActionResult> Delete(int id)
    {
        Contact existContact = await _contactRepository.GetByIdAsync(p => p.Id == id);
        _contactRepository.Delete(existContact);
        await _contactRepository.SaveAsync();
        return RedirectToAction(nameof(Index));

    }
}
