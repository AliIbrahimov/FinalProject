using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;
using FinalProjectWithRepositoryDesignPattern.DTOs.Comment;
using FinalProjectWithRepositoryDesignPattern.DTOs.Pagination;
using FinalProjectWithRepositoryDesignPattern.DTOs.Project;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepo;
        private readonly ICommentRepository _commentRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public ProjectController(IProjectRepository projectRepo, IMapper mapper, ICommentRepository commentRepo, UserManager<AppUser> userManager)
        {
            _projectRepo = projectRepo;
            _mapper = mapper;
            _commentRepo = commentRepo;
            _userManager = userManager;
        }

        public async Task<IActionResult> ProjectGrid(int currentpage = 1, int take = 8)
        {
            List<Project> projects = await _projectRepo.GetAllAsync();
            List<ProjectGetDto> projectGets = _mapper.Map<List<ProjectGetDto>>(projects);

            projectGets = projectGets
               .OrderByDescending(d => d.CreatedDate)
               .Skip((currentpage - 1) * take)
               .Take(take)
               .ToList();
            int pageCount = (int)Math.Ceiling((decimal)projects.Count / take);
            if (pageCount == 0) pageCount = 1;

            PaginationDto<ProjectGetDto> pagination = new PaginationDto<ProjectGetDto>
            {
                Models = projectGets,
                CurrentPage = currentpage,
                PageCount = pageCount,
                NextPage = currentpage < pageCount,
                Previous = currentpage > 1
            };

            return View(pagination);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Project existProject = await _projectRepo.GetByIdAsync(p => p.Id == id);
            _projectRepo.Delete(existProject);
            await _projectRepo.SaveAsync();
            return RedirectToAction("DeveloperProfile", "Account");
        }
        public async Task<IActionResult> Detail(int id)
        {
/*            AppUser? appUser = await _userManager.FindByNameAsync(HttpContext.User.Identity?.Name);
*/
            Project project = await _projectRepo.GetByIdAsync(p => p.Id == id,"Comments","Developer");
            ProjectGetDto projectGet = _mapper.Map<ProjectGetDto>(project);
            List<Comment> comments =await  _commentRepo.GetAllAsync();
            
            ProjectEditDto projectEdit = new ProjectEditDto()
            {
                getDto = projectGet
            };
            for (int i = 0; i < projectEdit.getDto.Comments.Count; i++)
            {
                projectEdit.getDto.Comments[i].AppUser = await _userManager.FindByIdAsync(projectEdit.getDto.Comments[i].AppUserId);
            }
            return View(projectEdit);
        }
        [HttpPost]
        public async Task<IActionResult> Comment(CommentPostDto postDto)
        {
            AppUser appUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            Project project = await _projectRepo.GetByIdAsync(p => p.Id == postDto.ProjectId);
            Comment comment = new Comment()
            {
                AppUser = appUser,
                Message=postDto.Message,
                ProjectId = postDto.ProjectId,
                AppUserId = appUser.Id,
                SendedDate = DateTime.Now,
                Project = project,
            };
            await _commentRepo.CreateAsync(comment);
            await _commentRepo.SaveAsync();
            postDto.AppUser = appUser;
            postDto.AppUser.Name = appUser.Name;
            postDto.AppUser.Email = appUser.Email;
            postDto.AppUser.ProfileImage = appUser.ProfileImage;
            

            return RedirectToAction("ProjectGrid", "Project");
        }
    }
}
