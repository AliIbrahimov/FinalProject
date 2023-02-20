using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;
using FinalProjectWithRepositoryDesignPattern.DTOs.ChooseUs;
using FinalProjectWithRepositoryDesignPattern.DTOs.Slider;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Areas.admin.Controllers
{
    [Area("admin")]
    public class ChooseUsController : Controller
    {
        private readonly IChooseUsRepository _chooseUsRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ChooseUsController(IChooseUsRepository chooseUsRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _chooseUsRepository = chooseUsRepository;
            _mapper = mapper;
            _env = env;
        }

        public async  Task<IActionResult> Index()
        {
            ChooseUs chooseUs = await _chooseUsRepository.GetByIdAsync(p => p.Id == 1, "ChooseUsActions");
            ChooseUsGetDto chooseUsGet = _mapper.Map<ChooseUsGetDto>(chooseUs);
            return View(chooseUsGet);
        }
        public async Task<IActionResult> Edit()
        {
            ChooseUs chooseUs = await _chooseUsRepository.GetByIdAsync(p => p.Id == 1, "ChooseUsActions");
            if (chooseUs is null) return NotFound();
            ChooseUsGetDto chooseUsGet = _mapper.Map<ChooseUsGetDto>(chooseUs);
            ChooseUsEditDto chooseUsEdit = new ChooseUsEditDto() { getDto = chooseUsGet };
            return View(chooseUsEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ChooseUsEditDto chooseUsEdit)
        {
            ChooseUs chooseUs = await _chooseUsRepository.GetByIdAsync(p => p.Id == 1, "ChooseUsActions");
            chooseUsEdit.getDto = _mapper.Map<ChooseUsGetDto>(chooseUs);
            chooseUs.Name = chooseUsEdit.postDto.Name;
            chooseUs.Title = chooseUsEdit.postDto.Title;
            for (int i = 0; i < chooseUsEdit.postDto.ChooseUsActions.Count; i++)
            {
                chooseUs.ChooseUsActions[i].Name = chooseUsEdit.postDto.ChooseUsActions[i].Name;
            }
            if (chooseUsEdit.postDto.FormFile != null)
            {
                string imagename = Guid.NewGuid() + chooseUsEdit.postDto.FormFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "assets/img", imagename);
                using (FileStream file = new FileStream(path, FileMode.Create))
                {
                    chooseUsEdit.postDto.FormFile.CopyTo(file);
                }
                Helper.Helper.DeleteHelper(_env.WebRootPath, "assets/img", chooseUs.Image);
                chooseUs.Image = imagename;
            }
            _chooseUsRepository.Edit(chooseUs);
            await _chooseUsRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
