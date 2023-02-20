using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DTOs.AboutUs;
using FinalProjectWithRepositoryDesignPattern.DTOs.ChooseUs;
using FinalProjectWithRepositoryDesignPattern.DTOs.Comment;
using FinalProjectWithRepositoryDesignPattern.DTOs.Contact;
using FinalProjectWithRepositoryDesignPattern.DTOs.Developer;
using FinalProjectWithRepositoryDesignPattern.DTOs.Home;
using FinalProjectWithRepositoryDesignPattern.DTOs.Project;
using FinalProjectWithRepositoryDesignPattern.DTOs.Quote;
using FinalProjectWithRepositoryDesignPattern.DTOs.Service;
using FinalProjectWithRepositoryDesignPattern.DTOs.Setting;
using FinalProjectWithRepositoryDesignPattern.DTOs.Slider;
using FinalProjectWithRepositoryDesignPattern.DTOs.Statistic;
using FinalProjectWithRepositoryDesignPattern.DTOs.User;
using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.Profiles;

public class Mapper:Profile
{
	public Mapper()
	{
		CreateMap<SliderGetDto, Slider>().ReverseMap();
		CreateMap<SliderPostDto, Slider>().ReverseMap();
		CreateMap<SliderEditDto, Slider>().ReverseMap();
		CreateMap<Contact,ContactGetDto > ();
		CreateMap<ContactPostDto, Contact>();
		CreateMap<RegisterDto, AppUser>();
		CreateMap<StatisticGetDto, Statistic>().ReverseMap();
		CreateMap<AboutUsGetDto, AboutUs>().ReverseMap();
		CreateMap<AboutUsEditDto, AboutUs>().ReverseMap();
		CreateMap<ChooseUs, ChooseUsGetDto>();
		CreateMap<SettingsGetDto,Setting>().ReverseMap();
		CreateMap<DeveloperGetDto,Developer>().ReverseMap();
		CreateMap<QuotePostDto,Quote>().ReverseMap();
		CreateMap<Quote,QuoteGetDto>().ReverseMap();
		CreateMap<UserGetDto,User>().ReverseMap();
		CreateMap<UserEditDto,User>().ReverseMap();
		CreateMap<DeveloperEditDto,Developer>().ReverseMap();
		CreateMap<ProjectGetDto,Project>().ReverseMap();
		CreateMap<ChooseUsGetDto,ChooseUs>().ReverseMap();
		CreateMap<Project,ProjectGetDto>().ReverseMap();
		CreateMap<ProjectEditDto, Project>().ReverseMap();
		CreateMap<ProjectPostDto, Project>().ReverseMap();
		CreateMap<Service, ServiceGetDto>();
		CreateMap<CommentPostDto, Comment>();

	}
}
