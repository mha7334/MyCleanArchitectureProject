using Application.Services.Authentication;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Commands.Register
{
    public record RegisterCommand(string Firstname,
                                  string Lastname,
                                  string Email,
                                  string Password) : IRequest<ErrorOr<AuthenticationResult>>;

}
