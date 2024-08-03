using Core.Persistence.Repositories;
using Entities;

namespace Repository.Abstract;

public interface ICategoryRepository : IAsyncRepository<Category, int>, IRepository<Category, int>
{

}