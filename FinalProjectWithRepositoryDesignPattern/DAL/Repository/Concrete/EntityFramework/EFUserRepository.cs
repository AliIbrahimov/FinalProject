using FinalProjectWithRepositoryDesignPattern.Core.DAL.Repository.Concrete.EFBaseRepository;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;

public class EFUserRepository : EFBaseRepository<User>, IUserRepository
{
    public EFUserRepository(AppDbContext context) : base(context)
    {
    }
}
