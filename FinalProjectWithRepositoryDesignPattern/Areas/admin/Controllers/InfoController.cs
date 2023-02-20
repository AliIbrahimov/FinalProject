using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;
using FinalProjectWithRepositoryDesignPattern.DTOs.Contact;
using FinalProjectWithRepositoryDesignPattern.DTOs.Setting;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Areas.admin.Controllers;
[Area("admin")]
public class InfoController : Controller
{
    private readonly ISettingRepository _settingRepository;
    private readonly IMapper _mapper;

    public InfoController(ISettingRepository settingRepository, IMapper mapper)
    {
        _settingRepository = settingRepository;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        List<SettingsGetDto> settings = _mapper.Map<List<SettingsGetDto>>(await _settingRepository.GetAllAsync());
        return View(settings); 
    }
}
