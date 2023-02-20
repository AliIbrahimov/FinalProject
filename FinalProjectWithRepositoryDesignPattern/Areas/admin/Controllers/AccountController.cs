using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DTOs.User;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Areas.admin.Controllers;
[Area("admin")]

public class AccountController : Controller
{
    
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IMapper _mapper;

    public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }
/*    public async Task<IActionResult> Index()
    {
        AppUser user = new AppUser() { Email = "admin@gmail.com", UserName = "admin" };
        await _userManager.CreateAsync(user, "Admin123@");
        await _userManager.AddToRoleAsync(user, "Admin");
        return Json("Ok");
    }*/
    public async Task<IActionResult> Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var existUser = await _userManager.FindByEmailAsync(loginDto.Mail);
        if (existUser is null)
        {
            ModelState.AddModelError("", "User is not found!");
            return View(loginDto);
        }
        var result = await _signInManager.PasswordSignInAsync(existUser, loginDto.Password, true, true);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Username or password incorrect!");
            return View(loginDto);
        }
        return RedirectToAction("Index", "Dashboard");
    }
}
