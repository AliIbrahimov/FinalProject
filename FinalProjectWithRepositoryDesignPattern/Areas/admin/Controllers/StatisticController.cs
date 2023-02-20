using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;
using FinalProjectWithRepositoryDesignPattern.DTOs.Slider;
using FinalProjectWithRepositoryDesignPattern.DTOs.Statistic;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Areas.admin.Controllers;
[Area("admin")]
public class StatisticController : Controller
{
    private readonly IStatisticRepository _statisticRepository;
    private readonly IMapper _mapper;


    public StatisticController(IStatisticRepository statisticRepository, IMapper mapper)
    {
        _statisticRepository = statisticRepository;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        List<StatisticGetDto> statistics = _mapper.Map<List<StatisticGetDto>>(await _statisticRepository.GetAllAsync());
        return View(statistics);
    }
    public async Task<IActionResult> Edit(int id)
    {
        Statistic statistic = await _statisticRepository.GetByIdAsync(p => p.Id == id);
        if (statistic is null) return NotFound();
        StatisticGetDto GetDto = _mapper.Map<StatisticGetDto>(statistic);
        StatisticEditDto statisticEdit = new StatisticEditDto() { StatisticGets = GetDto };
        return View(statisticEdit);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(StatisticEditDto statisticEdit)
    {
        Statistic statistic = await _statisticRepository.GetByIdAsync(p => p.Id == statisticEdit.StatisticGets.Id);
        statisticEdit.StatisticGets = _mapper.Map<StatisticGetDto>(statistic);
        if (!ModelState.IsValid) return View(statisticEdit);
        statistic.ProjectsDone = statisticEdit.StatisticPost.ProjectsDone;
        statistic.HappyClients = statisticEdit.StatisticPost.HappyClients;
        statistic.WinAwards = statisticEdit.StatisticPost.WinAwards;
        _statisticRepository.Edit(statistic);
        await _statisticRepository.SaveAsync();
        return RedirectToAction(nameof(Index));
    }
}
