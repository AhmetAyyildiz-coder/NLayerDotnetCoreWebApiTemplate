using Core.Persistence.Repositories;

namespace Core.Entities;

public class User : Entity<int>
{
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    /// <summary>
    /// Kullanicinin sifresini guclendirmek icin
    /// </summary>
    public byte[] PasswordSalt { get; set; }
    /// <summary>
    /// Sifreli password
    /// </summary>
    public byte[] PasswordHash { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = null!;


}
