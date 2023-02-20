using FinalProjectWithRepositoryDesignPattern.Core.DAL.Repository.Concrete.EFBaseRepository;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework
{
    public class EFProjectRepository : EFBaseRepository<Project>, IProjectRepository
    {
        public EFProjectRepository(AppDbContext context) : base(context)
        {
        }
    }
}
