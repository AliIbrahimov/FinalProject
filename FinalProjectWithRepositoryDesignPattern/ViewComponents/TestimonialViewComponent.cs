using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;
using FinalProjectWithRepositoryDesignPattern.DTOs.ChooseUs;
using FinalProjectWithRepositoryDesignPattern.DTOs.Quote;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.ViewComponents
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IMapper _mapper;

        public TestimonialViewComponent(IQuoteRepository quoteRepository, IMapper mapper)
        {
            _quoteRepository = quoteRepository;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Quote> quoteTest = await _quoteRepository.GetAllAsync(p => p.IsActive == true, "AppUser");

            List<QuoteGetDto> quoteGets = _mapper.Map<List<QuoteGetDto>>(quoteTest);
            return View(quoteGets);
        }
    }
}
