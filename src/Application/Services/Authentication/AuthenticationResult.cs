using Domain.User;

namespace Application.Services.Authentication;

public record AuthenticationResult(
    User user,
    string Token);
