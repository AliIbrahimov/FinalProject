using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DTOs.Developer;
using FinalProjectWithRepositoryDesignPattern.DTOs.DeveloperProfile;
using FinalProjectWithRepositoryDesignPattern.DTOs.Project;
using FinalProjectWithRepositoryDesignPattern.DTOs.User;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Net;
using System.Net.Mail;

namespace FinalProjectWithRepositoryDesignPattern.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IDeveloperRepository _developerRepository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;
    private readonly IUserRepository _userRepository;
    private readonly IProfileRepository _profileRepository;
    private readonly IProjectRepository _projectRepository;

    public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper, IDeveloperRepository developerRepository, IWebHostEnvironment env, IUserRepository userRepository, IProfileRepository profileRepository, IProjectRepository projectRepository)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _mapper = mapper;
        _developerRepository = developerRepository;
        _env = env;
        _userRepository = userRepository;
        _profileRepository = profileRepository;
        _projectRepository = projectRepository;
    }

    /* public async Task<IActionResult> Index()
     {
         await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
         await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
         await _roleManager.CreateAsync(new IdentityRole { Name = "Developer" });
         return Json("Ok"); 
     }*/
    public async Task<IActionResult> Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        if (registerDto is null) return View(registerDto);
        AppUser appUser = new AppUser { Email = registerDto.Mail, UserName = registerDto.Username, isDeveloper = registerDto.isDeveloper };
        if (registerDto.isDeveloper)
        {
            Developer developer = new Developer()
            {
                Mail = registerDto.Mail,
                //Image = "avatar.webp",
                Username = registerDto.Username


            };
            await _developerRepository.CreateAsync(developer);
        }
        else
        {
            User user = new User()
            {
                Mail = registerDto.Mail,
                Username = registerDto.Username,
                //Image = "userAvatar.png"
            };
            await _userRepository.CreateAsync(user);
        }
        var result = await _userManager.CreateAsync(appUser, registerDto.Password);
        if (!result.Succeeded)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
                return View(registerDto);
            }
        }

        IdentityResult result2;
        if (appUser.isDeveloper == true)
        {

            result2 = await _userManager.AddToRoleAsync(appUser, "Developer");
        }
        else
        {

            result2 = await _userManager.AddToRoleAsync(appUser, "User");
        }


        if (!result2.Succeeded)
        {
            foreach (var item in result2.Errors)
            {
                ModelState.AddModelError("", item.Description);
                return View(registerDto);
            }
        }
        string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
        string? link = Url.Action(nameof(VerifyEmail), "Account", new { email = appUser.Email, token = token }, Request.Scheme, Request.Host.ToString());
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("finalproject864@gmail.com", "FinalProject");
        mailMessage.To.Add(appUser.Email);
        mailMessage.Subject = "Verify mail";
        mailMessage.Body = link;
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new NetworkCredential("finalproject864@gmail.com", "xgvscabcgzraekyv");
        smtpClient.Send(mailMessage);

        return RedirectToAction(nameof(Login));
    }
    public async Task<IActionResult> VerifyEmail(string email, string token)
    {
        AppUser appUser = await _userManager.FindByEmailAsync(email);
        if (appUser is null) NotFound();
        await _userManager.ConfirmEmailAsync(appUser, token);
        await _signInManager.SignInAsync(appUser, true);
        return Json("Account is active!");

    }
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
        /*if (!existUser.EmailConfirmed)
        {
            ModelState.AddModelError("", "Mail is not verified!");
            return View(loginDto);
        }*/
        if (!result.Succeeded)
        {

            ModelState.AddModelError("", "Username or password incorrect!");
            return View(loginDto);
        }
        return RedirectToAction("Index", "Home");
    }
    public async Task<IActionResult> ForgetPassword()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ForgetPassword(ResetPasswordDto dto)
    {
        AppUser appUser = await _userManager.FindByEmailAsync(dto.Mail);
        if (appUser is null) return NotFound();
        string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);
        string? link = Url.Action(nameof(ResetPassword), "Account", new { email = appUser.Email, token = token }, Request.Scheme, Request.Host.ToString());
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("finalproject864@gmail.com", "FinalProject");
        mailMessage.To.Add(appUser.Email);
        mailMessage.Subject = "Reset password";
        mailMessage.Body = link;
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new NetworkCredential("finalproject864@gmail.com", "xgvscabcgzraekyv");
        smtpClient.Send(mailMessage);
        return RedirectToAction("index", "home");
    }
    public async Task<IActionResult> ResetPassword(string email, string token)
    {
        AppUser appUser = await _userManager.FindByEmailAsync(email);
        if (appUser is null) return NotFound();
        ResetPasswordDto resetPasswordDto = new ResetPasswordDto()
        {
            Mail = email,
            Token = token
        };
        return View(resetPasswordDto);
    }
    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
    {
        AppUser appUser = await _userManager.FindByEmailAsync(resetPasswordDto.Mail);
        if (appUser is null) NotFound();
        IdentityResult identityResult = await _userManager.ResetPasswordAsync(appUser, resetPasswordDto.Token, resetPasswordDto.Password);
        if (!identityResult.Succeeded)
        {
            foreach (var item in identityResult.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View(resetPasswordDto);
        }
        return RedirectToAction("login", "account");
    }
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");

    }

    public async Task<IActionResult> Setting()
    {
        return View();
    }
    [Authorize(Roles = "Developer")]
    public async Task<IActionResult> Developerprofile()
    {

        var user = await _userManager.GetUserAsync(User);
        Developer userProfile = await _developerRepository.GetByIdAsync(p => p.Mail == user.Email,"Projects");
        DeveloperGetDto getDto = _mapper.Map<DeveloperGetDto>(userProfile);
        DeveloperProfileGetDto profileGetDto = new DeveloperProfileGetDto()
        {
            developerGet = getDto,

        };

        return View(profileGetDto);
    }
    [Authorize(Roles = "Developer")]
    public async Task<IActionResult> DeveloperEdit()
    {
        AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
        Developer developer = await _developerRepository.GetByIdAsync(p => p.Mail == user.Email,"Projects");
        DeveloperGetDto getDto = _mapper.Map<DeveloperGetDto>(developer);
        DeveloperEditDto developerEdit = new DeveloperEditDto()
        {
            getDto = getDto,
           
        };
        return View(developerEdit);

    }
    [HttpPost]
    public async Task<IActionResult> DeveloperEdit(DeveloperEditDto developer)
    {
        AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
         
        Developer editedUser = await _developerRepository.GetByIdAsync(p => p.Id == developer.getDto.Id,"Projects");
        developer.getDto = _mapper.Map<DeveloperGetDto>(editedUser);
        if (editedUser == null) return NotFound();
        developer.postDto.Projects.FirstOrDefault().AuthorName = editedUser.Name;
        developer.postDto.Projects.FirstOrDefault().DeveloperId = editedUser.Id;
        developer.postDto.Projects.FirstOrDefault().Developer = editedUser;
        var projects = developer.postDto.Projects;
        string image;
        if (developer.postDto.Projects.FirstOrDefault().FormFile != null)
        {
            string imagename = Guid.NewGuid() + developer.postDto.Projects.FirstOrDefault().FormFile.FileName;
            string path = Path.Combine(_env.WebRootPath, "assets/img", imagename);
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                developer.postDto.Projects.FirstOrDefault()?.FormFile.CopyTo(file);
            }
            developer.postDto.Projects.FirstOrDefault().Image = imagename;
            user.ProfileImage = imagename;
        }
        Project project = new Project()
        {
            DeveloperId = editedUser.Id, 
            AuthorName = user.UserName,
            ProjectUrl = developer.postDto.Projects.FirstOrDefault()?.ProjectUrl,
            Name = developer.postDto.Projects.FirstOrDefault()?.Name,
            Image = developer.postDto.Projects.FirstOrDefault()?.Image,
            Description = developer.postDto.Projects.FirstOrDefault()?.Description
          

            
        };
        await _projectRepository.CreateAsync(project);
        await _projectRepository.SaveAsync();
        editedUser.Phone = developer.postDto.Phone;
        editedUser.Adress = developer.postDto.Adress;
        editedUser.Surname = developer.postDto.Surname;
        editedUser.Name = developer.postDto.Name;
        editedUser.Position = developer.postDto.Position;
        editedUser.Username = developer.postDto.Username;
        user.Email = developer.postDto.Mail;
        user.PhoneNumber = developer.postDto.Phone;
        user.Position = developer.postDto.Position;
        user.Surname = developer.postDto.Surname;
        user.Name = developer.postDto.Name;


        if (developer.postDto.FormFile != null)
        {
            string imagename = Guid.NewGuid() + developer.postDto.FormFile.FileName;
            string path = Path.Combine(_env.WebRootPath, "assets/img", imagename);
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                developer.postDto.FormFile.CopyTo(file);
            }
            if (developer.postDto.FormFile != null && developer.getDto.Image != "avatar.webp" && developer.getDto.Image is not null)
            {
                Helper.Helper.DeleteHelper(_env.WebRootPath, "assets/img", editedUser.Image);
            }
            editedUser.Image = imagename;
        }


        _developerRepository.Edit(editedUser);
        await _developerRepository.SaveAsync();
        return RedirectToAction("DeveloperProfile", "Account");
    }
    [Authorize(Roles = "User")]
    public async Task<IActionResult> UserProfile()
    {

        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        User userProfile = await _userRepository.GetByIdAsync(p => p.Mail == user.Email);
        UserGetDto getDto = _mapper.Map<UserGetDto>(userProfile);

        return View(getDto);
    }
    [Authorize(Roles = "User")]
    public async Task<IActionResult> UserEdit()
    {
        AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
        User user = await _userRepository.GetByIdAsync(p => p.Mail == appUser.Email);
        UserGetDto getDto = _mapper.Map<UserGetDto>(user);
        UserEditDto userEdit = new UserEditDto()
        {
            getDto = getDto,
        };
        return View(userEdit);

    }
    [HttpPost]
    public async Task<IActionResult> UserEdit(UserEditDto user)
    {
        AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

        User editedUser = await _userRepository.GetByIdAsync(p => p.Id == user.getDto.Id);
        user.getDto = _mapper.Map<UserGetDto>(editedUser);
        if (editedUser == null) return NotFound();

        editedUser.Phone = user.postDto.Phone;
        editedUser.Adress = user.postDto.Adress;
        editedUser.Surname = user.postDto.Surname;
        editedUser.Name = user.postDto.Name;
        if (user.postDto.FormFile != null)
        {
            string imagename = Guid.NewGuid() + user.postDto.FormFile.FileName;
            string path = Path.Combine(_env.WebRootPath, "assets/img", imagename);
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                user.postDto.FormFile.CopyTo(file);
            }
            if (user.postDto.FormFile != null&& user.postDto.Image != "avatar.webp" && user.postDto.Image is not null)
            {
                Helper.Helper.DeleteHelper(_env.WebRootPath, "assets/img", editedUser.Image);
            }

            editedUser.Image = imagename;
        }

        appUser.PhoneNumber = user.postDto.Phone;
        appUser.Adress = user.postDto.Adress;
        appUser.Surname = user.postDto.Surname;
        appUser.Name = user.postDto.Name;
        if (user.postDto.FormFile != null)
        {
            string imagename = Guid.NewGuid() + user.postDto.FormFile.FileName;
            string path = Path.Combine(_env.WebRootPath, "assets/img", imagename);
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                user.postDto.FormFile.CopyTo(file);
            }
            if (user.postDto.FormFile != null && user.postDto.Image != "avatar.webp" && user.postDto.Image is not null)
            {
                Helper.Helper.DeleteHelper(_env.WebRootPath, "assets/img", appUser.ProfileImage);
            }
            appUser.ProfileImage = imagename;
        }

/*        _userRepository.Edit(editedUser);
*/         _profileRepository.Edit(appUser);
       await _profileRepository.SaveAsync();

        return RedirectToAction("UserProfile", "Account");
    }


}
