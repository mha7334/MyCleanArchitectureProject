using System.ComponentModel.DataAnnotations;

namespace Application.Authentication
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password
        );

    public record AuthenticationResponse(
       Guid Id,
       string FirstName,
       string LastName,
       string Email,
       string Token
       );

    public record LoginRequest(        
        string Email,
        string Password);

}
