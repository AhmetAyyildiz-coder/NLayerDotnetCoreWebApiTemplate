namespace DTOs.UserOperationClaims;

public record UserOperationClaimDto
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public int OperationClaimId { get; init; }
}