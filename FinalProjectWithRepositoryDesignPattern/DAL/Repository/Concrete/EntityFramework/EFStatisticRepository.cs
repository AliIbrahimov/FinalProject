﻿using FinalProjectWithRepositoryDesignPattern.Core.DAL.Repository.Concrete.EFBaseRepository;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;

public class EFStatisticRepository : EFBaseRepository<Statistic>, IStatisticRepository
{
    public EFStatisticRepository(AppDbContext context) : base(context)
    {
    }
}
