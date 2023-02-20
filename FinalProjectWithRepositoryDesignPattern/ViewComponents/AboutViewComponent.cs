using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DTOs.AboutUs;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IMapper _mapper;

        public AboutViewComponent(IAboutRepository aboutRepository, IMapper mapper)
        {
            _aboutRepository = aboutRepository;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            AboutUs aboutUs = await _aboutRepository.GetByIdAsync(p => p.Id == 1,"AboutActions");
            AboutUsGetDto aboutUsGet = _mapper.Map<AboutUsGetDto>(aboutUs); 
            return View(aboutUsGet);
        }
    }
}
