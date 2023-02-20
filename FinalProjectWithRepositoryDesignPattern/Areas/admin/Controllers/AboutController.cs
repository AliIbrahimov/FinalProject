using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;
using FinalProjectWithRepositoryDesignPattern.DTOs.AboutUs;
using FinalProjectWithRepositoryDesignPattern.DTOs.Slider;
using FinalProjectWithRepositoryDesignPattern.Extensions;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Areas.admin.Controllers;
[Area("admin")]

public class AboutController : Controller
{
    private readonly IAboutRepository _about;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;

    public AboutController(IAboutRepository about, IMapper mapper, IWebHostEnvironment env)
    {
        _about = about;
        _mapper = mapper;
        _env = env;
    }

    public async Task<IActionResult> Index()
    {
        List<AboutUsGetDto> getDtos = _mapper.Map<List<AboutUsGetDto>>(await _about.GetAllAsync(p => p.Id == 1, "AboutActions"));
        return View(getDtos);
    }
    public async Task<IActionResult> Edit(int id)
    {
        AboutUs aboutUs = await _about.GetByIdAsync(p => p.Id == id,"AboutActions");
        AboutUsGetDto aboutData = _mapper.Map<AboutUsGetDto>(aboutUs);
        AboutUsPostDto aboutUsPostDto = new AboutUsPostDto
        {
            AboutActions = aboutData.AboutActions
        };
        AboutUsEditDto editDto = new AboutUsEditDto() { getDto = aboutData };
        return View(editDto);
    }
    [HttpPost]  
    public async Task<IActionResult> Edit(AboutUsEditDto aboutUsEdit)
    {
        AboutUs aboutUs = await _about.GetByIdAsync(p => p.Id == aboutUsEdit.getDto.Id,"AboutActions");
        aboutUsEdit.getDto =  _mapper.Map<AboutUsGetDto>(aboutUs);
        aboutUs.AboutName = aboutUsEdit.postDto.AboutName;
        aboutUs.AboutTitle = aboutUsEdit.postDto.AboutTitle;
        aboutUs.Aboutdescription = aboutUsEdit.postDto.Aboutdescription;
        //foreach (var item in aboutUs.AboutActions)
        //{
        //    aboutUs.AboutActions.Find(p => p.Id == item.Id).Name = aboutUsEdit.postDto.AboutActions.Find(p => p.Id == item.Id).Name;
        //}
        for (int i = 0; i < aboutUs.AboutActions.Count; i++)
        {
            aboutUs.AboutActions[i].Name = aboutUsEdit.postDto.AboutActions[i].Name;
        }
        if (aboutUsEdit.postDto.FormFile != null)
        {
            aboutUs.Image=aboutUsEdit.postDto.FormFile.UploadFile(_env.WebRootPath, "assets/img");
            
        }
        _about.Edit(aboutUs);
        await _about.SaveAsync();
        return RedirectToAction(nameof(Index));
    }

}
