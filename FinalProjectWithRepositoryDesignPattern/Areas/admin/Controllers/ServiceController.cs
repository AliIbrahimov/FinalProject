using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DTOs.Service;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Areas.admin.Controllers
{
    [Area("admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServiceController(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }

        public async  Task<IActionResult> Index()
        {
            List<Service> services = await _serviceRepository.GetAllAsync("serviceActions");
            List<ServiceGetDto> serviceGetDto = _mapper.Map<List<ServiceGetDto>>(services);
            return View(serviceGetDto);
        }
    }
}
