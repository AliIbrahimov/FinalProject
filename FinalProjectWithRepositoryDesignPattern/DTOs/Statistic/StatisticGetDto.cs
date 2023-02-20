namespace FinalProjectWithRepositoryDesignPattern.DTOs.Statistic;

public class StatisticGetDto
{
    public int Id { get; set; }
    public decimal HappyClients { get; set; }
    public string? HappyClientsIcon { get; set; }
    public decimal ProjectsDone { get; set; }
    public string? ProjectsDoneIcon { get; set; }
    public decimal WinAwards { get; set; }
    public string? WinAwardsIcon { get; set; }
}
