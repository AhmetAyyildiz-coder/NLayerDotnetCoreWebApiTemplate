
namespace DTOs.Users;

public record UserForLoginDto(string Email, string Password)
{
    public required string Email { get; set; } = Email;
    public required string Password { get; set; } = Password;
    
}