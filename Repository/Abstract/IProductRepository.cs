using Core.Persistence.Repositories;
using Entities;

namespace Repository.Abstract;

public interface IProductRepository : IAsyncRepository<Product,int>, IRepository<Product,int>
{
    
}