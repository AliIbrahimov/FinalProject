using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DTOs.Quote;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.ViewComponents
{
    public class QuoteViewComponent : ViewComponent
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public QuoteViewComponent(IQuoteRepository quoteRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _quoteRepository = quoteRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            QuotePostDto quotePosts = new QuotePostDto();

            return View(quotePosts);
        }
    }
}
