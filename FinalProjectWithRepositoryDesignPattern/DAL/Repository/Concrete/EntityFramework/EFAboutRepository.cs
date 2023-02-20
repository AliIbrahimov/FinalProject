using FinalProjectWithRepositoryDesignPattern.Core.DAL.Repository.Concrete.EFBaseRepository;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;

public class EFAboutRepository : EFBaseRepository<AboutUs>, IAboutRepository
{
    public EFAboutRepository(AppDbContext context) : base(context)
    {
    }
}
