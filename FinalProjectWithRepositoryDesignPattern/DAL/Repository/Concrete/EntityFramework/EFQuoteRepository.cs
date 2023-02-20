using FinalProjectWithRepositoryDesignPattern.Core.DAL.Repository.Concrete.EFBaseRepository;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework
{
    public class EFQuoteRepository : EFBaseRepository<Quote>, IQuoteRepository
    {
        public EFQuoteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
