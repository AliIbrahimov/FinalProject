using FinalProjectWithRepositoryDesignPattern.Core.DAL.Repository.Concrete.EFBaseRepository;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework
{
    public class EFSettingRepository : EFBaseRepository<Setting>, ISettingRepository
    {
        public EFSettingRepository(AppDbContext context) : base(context)
        {
        }
    }
}
