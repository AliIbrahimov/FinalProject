using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;
using FinalProjectWithRepositoryDesignPattern.DTOs.ChooseUs;
using FinalProjectWithRepositoryDesignPattern.DTOs.Developer;
using FinalProjectWithRepositoryDesignPattern.DTOs.Home;
using FinalProjectWithRepositoryDesignPattern.DTOs.Quote;
using FinalProjectWithRepositoryDesignPattern.DTOs.Slider;
using FinalProjectWithRepositoryDesignPattern.DTOs.Statistic;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Controllers;

public class HomeController : Controller
{
    private readonly ISliderRepository _sliderRepository;
    private readonly IStatisticRepository _statisticRepository;
    private readonly IChooseUsRepository _chooseUsRepository;
    private readonly IDeveloperRepository _developerRepo;
    private readonly IMapper _mapper;
    private readonly IQuoteRepository _quoteRepository;
    private readonly UserManager<AppUser> _usermanager;
    public HomeController(ISliderRepository sliderRepository, IMapper mapper, IStatisticRepository statisticRepository, ISettingRepository settingRepository, IChooseUsRepository chooseUsRepository, IDeveloperRepository developerRepo, IQuoteRepository quoteRepository, UserManager<AppUser> usermanager)
    {
        _sliderRepository = sliderRepository;
        _mapper = mapper;
        _statisticRepository = statisticRepository;
        _chooseUsRepository = chooseUsRepository;
        _developerRepo = developerRepo;
        _quoteRepository = quoteRepository;
        _usermanager = usermanager;
    }

    public async Task<IActionResult> Index()
    {
        List<SliderGetDto> sliders = _mapper.Map<List<SliderGetDto>>(await _sliderRepository.GetAllAsync());
        List<StatisticGetDto> statistics = _mapper.Map<List<StatisticGetDto>>(await _statisticRepository.GetAllAsync());
        List<ChooseUsGetDto> whyChooseUs = _mapper.Map<List<ChooseUsGetDto>>(await _chooseUsRepository.GetAllAsync("ChooseUsActions"));




        HomeGetDto homeGetDto = new HomeGetDto()
        {
            SliderGetDtos = sliders,
            StatisticGetDtos = statistics,
            ChooseUsGetDtos = whyChooseUs,


        };
        return View(homeGetDto);
    }
    [HttpPost]
    public async Task<IActionResult> Index(QuotePostDto postDto)
    {
        AppUser appUser = await _usermanager.FindByNameAsync(HttpContext.User.Identity.Name);
        postDto.AppUser = appUser;
        postDto.Name = appUser.Name;
        postDto.Mail = appUser.Email;
        Quote quote = _mapper.Map<Quote>(postDto);
        await _quoteRepository.CreateAsync(quote);
        await _quoteRepository.SaveAsync();
        return RedirectToAction("index", "home");
    }
}