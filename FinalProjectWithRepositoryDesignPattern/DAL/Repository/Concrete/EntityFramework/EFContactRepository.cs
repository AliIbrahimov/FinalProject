using FinalProjectWithRepositoryDesignPattern.Core.DAL.Repository.Concrete.EFBaseRepository;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;

public class EFContactRepository : EFBaseRepository<Contact>, IContactRepository
{
    private readonly AppDbContext _context;
    public EFContactRepository(AppDbContext context) : base(context)
    {
    }
}
