﻿using Core.Persistence.Repositories;

namespace Core.Entities;

public class UserOperationClaim : Entity<int>
{
    public  int UserId { get; set; }
    public  int OperationClaimId { get; set; }
    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }
}