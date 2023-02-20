using FinalProjectWithRepositoryDesignPattern.Core.DAL.Repository.Concrete.EFBaseRepository;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;

public class EFSliderRepository : EFBaseRepository<Slider>,ISliderRepository
{
    private readonly AppDbContext _context;

    public EFSliderRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
}
