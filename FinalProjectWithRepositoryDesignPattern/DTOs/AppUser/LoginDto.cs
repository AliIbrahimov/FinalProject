using System.ComponentModel.DataAnnotations;

namespace FinalProjectWithRepositoryDesignPattern.DTOs.User;

public class LoginDto
{
    public string Mail { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
