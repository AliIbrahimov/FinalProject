using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;
using FinalProjectWithRepositoryDesignPattern.DTOs.ChooseUs;
using FinalProjectWithRepositoryDesignPattern.DTOs.Quote;
using FinalProjectWithRepositoryDesignPattern.DTOs.Service;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.ViewComponents;


public class ServiceViewComponent : ViewComponent
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;

    public ServiceViewComponent(IServiceRepository serviceRepository, IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        List<Service> services = await _serviceRepository.GetAllAsync("serviceActions");

        List<ServiceGetDto> serviceGets = _mapper.Map<List<ServiceGetDto>>(services);
        return View(serviceGets);
     
    }
}
