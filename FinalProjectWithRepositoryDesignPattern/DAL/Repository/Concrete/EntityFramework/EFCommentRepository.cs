using FinalProjectWithRepositoryDesignPattern.Core.DAL.Repository.Concrete.EFBaseRepository;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework
{
    public class EFCommentRepository : EFBaseRepository<Comment>, ICommentRepository
    {
        public EFCommentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
