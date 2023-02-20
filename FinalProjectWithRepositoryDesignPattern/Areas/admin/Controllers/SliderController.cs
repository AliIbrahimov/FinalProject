using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DTOs.Slider;
using FinalProjectWithRepositoryDesignPattern.Helper;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Numerics;

namespace FinalProjectWithRepositoryDesignPattern.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {

        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IMapper mapper, ISliderRepository sliderRepository, IWebHostEnvironment env)
        {
            _mapper = mapper;
            _sliderRepository = sliderRepository;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {

            List<SliderGetDto> sliders = _mapper.Map<List<SliderGetDto>>(await _sliderRepository.GetAllAsync());
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SliderPostDto sliderCreateDto)
        {
            if (!sliderCreateDto.FormFile.ContentType.Contains("image"))
            {
                ModelState.AddModelError("FormFile", "please send image");
                return View(sliderCreateDto);
            }
            Slider slider = _mapper.Map<Slider>(sliderCreateDto);
            string imagename = Guid.NewGuid() + sliderCreateDto.FormFile.FileName;
            string path = Path.Combine(_env.WebRootPath, "assets/img", imagename);
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                sliderCreateDto.FormFile.CopyTo(file);
            }
            slider.Image = imagename;
            _sliderRepository.CreateAsync(slider);
            _sliderRepository.SaveAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Slider slider =await _sliderRepository.GetByIdAsync(p=>p.Id==id);
            if (slider is null) return NotFound();
            SliderGetDto GetDto = _mapper.Map<SliderGetDto>(slider);
            SliderEditDto sliderEdit = new SliderEditDto() { GetDto=GetDto };
            return View(sliderEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SliderEditDto sliderEdit)
        {
            Slider slider = await _sliderRepository.GetByIdAsync(p => p.Id == sliderEdit.GetDto.Id);
            sliderEdit.GetDto = _mapper.Map<SliderGetDto>(slider);
            if (!ModelState.IsValid) return View(sliderEdit);
            slider.Title = sliderEdit.PostDto.Title;
            slider.Text = sliderEdit.PostDto.Text;
            if (sliderEdit.PostDto.FormFile != null)
            {
                string imagename = Guid.NewGuid() + sliderEdit.PostDto.FormFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "assets/img", imagename);
                using (FileStream file = new FileStream(path, FileMode.Create))
                {
                    sliderEdit.PostDto.FormFile.CopyTo(file);
                }
                Helper.Helper.DeleteHelper(_env.WebRootPath, "assets/img", slider.Image);
                slider.Image = imagename;
            }
            _sliderRepository.Edit(slider);
            await _sliderRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await _sliderRepository.GetByIdAsync(p => p.Id == id);
            _sliderRepository.Delete(slider);
            await _sliderRepository.SaveAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
