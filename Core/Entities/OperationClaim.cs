using Core.Persistence.Repositories;

namespace Core.Entities;

public class OperationClaim : Core.Persistence.Repositories.Entity<int>
{
    public string Name { get; set; }
}