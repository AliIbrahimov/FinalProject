using FinalProjectWithRepositoryDesignPattern.Core.DAL.Repository.Concrete.EFBaseRepository;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework
{
    public class EFServiceRepository : EFBaseRepository<Service>, IServiceRepository
    {
        public EFServiceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
