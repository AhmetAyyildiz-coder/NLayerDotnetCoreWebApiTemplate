using Core.Persistence.Repositories;
using Entities;
using Repository.Abstract;
using Repository.Contexts;

namespace Repository.Concrete;

public class EfCategoryRepository(BaseDbContext context)
    : EfRepositoryBase<Category, int, BaseDbContext>(context), ICategoryRepository;