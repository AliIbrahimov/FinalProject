using FinalProjectWithRepositoryDesignPattern.Core.DAL.Repository.Concrete.EFBaseRepository;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework
{
    public class EFProfileRepository : EFBaseRepository<AppUser>, IProfileRepository
    {
        public EFProfileRepository(AppDbContext context) : base(context)
        {
        }
    }
}
