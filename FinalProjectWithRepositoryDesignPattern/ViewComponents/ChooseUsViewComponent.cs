using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;
using FinalProjectWithRepositoryDesignPattern.DTOs.AboutUs;
using FinalProjectWithRepositoryDesignPattern.DTOs.ChooseUs;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.ViewComponents
{
    public class ChooseUsViewComponent : ViewComponent
    {
        private readonly IChooseUsRepository _chooseUsRepository;
        private readonly IMapper _mapper;

        public ChooseUsViewComponent(IChooseUsRepository chooseUsRepository, IMapper mapper)
        {
            _chooseUsRepository = chooseUsRepository;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ChooseUs chooseUs = await _chooseUsRepository.GetByIdAsync(p => p.Id == 1, "ChooseUsActions");
            ChooseUsGetDto chooseUsGet = _mapper.Map<ChooseUsGetDto>(chooseUs);
            return View(chooseUsGet);
        }
    }
}
