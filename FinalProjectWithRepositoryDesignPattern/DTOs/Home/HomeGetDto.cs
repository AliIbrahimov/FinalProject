using FinalProjectWithRepositoryDesignPattern.DTOs.ChooseUs;
using FinalProjectWithRepositoryDesignPattern.DTOs.Developer;
using FinalProjectWithRepositoryDesignPattern.DTOs.Quote;
using FinalProjectWithRepositoryDesignPattern.DTOs.Setting;
using FinalProjectWithRepositoryDesignPattern.DTOs.Slider;
using FinalProjectWithRepositoryDesignPattern.DTOs.Statistic;
using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DTOs.Home;

public class HomeGetDto
{
    public List<SliderGetDto> SliderGetDtos { get; set; }
    public List<StatisticGetDto> StatisticGetDtos { get; set; }
    public List<SettingsGetDto> SettingsGetDtos { get; set; }
    public List<ChooseUsGetDto> ChooseUsGetDtos { get; set; }
    public List<DeveloperGetDto> DeveloperGetDtos { get; set; }
    public List<AppUser> Users { get; set; }
    public List<Models.Quote> Quotes { get; set; }
    public List<QuoteGetDto> GetDtos { get; set; }
    public List<QuotePostDto> PostDtos { get; set; }
}
