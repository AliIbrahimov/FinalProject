using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DTOs.Quote;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Areas.admin.Controllers;
[Area("admin")]
public class QuoteController : Controller
{
    private readonly IQuoteRepository _quote;
    private readonly IMapper _mapper;

    public QuoteController(IQuoteRepository quote, IMapper mapper)
    {
        _quote = quote;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        
        List<QuoteGetDto> quotes = _mapper.Map<List<QuoteGetDto>>(await _quote.GetAllAsync("AppUser"));
        return View(quotes);
    }
    public async Task<IActionResult> ActiveQuote(int id)
    {
        var activateQuote = await _quote.GetByIdAsync(p=>p.Id==id);
        activateQuote.IsActive = true;
         _quote.Edit(activateQuote);
        await _quote.SaveAsync();
        return RedirectToAction("index", "quote");
    }
    public async Task<IActionResult> PassiveQuote(int id)
    {
        var activateQuote = await _quote.GetByIdAsync(p=>p.Id==id);
        activateQuote.IsActive = false;
         _quote.Edit(activateQuote);
        await _quote.SaveAsync();
        return RedirectToAction("index", "quote");
    }
}
