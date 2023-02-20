using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FinalProjectWithRepositoryDesignPattern.DTOs.User;

public class RegisterDto
{
    public string Username { get; set; }
    public string Mail { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool isDeveloper { get; set; }
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public string ConfirmedPassword { get; set; }

}
