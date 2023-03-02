using Application.Authentication.Commands.Register;
using Application.Authentication.Queries;
using Application.Services.Authentication;
using Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediatr;

    public AuthenticationController(IMediator mediatR)
    {
        _mediatr = mediatR;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

        var authResult = await _mediatr.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);

        var authResult = await _mediatr.Send(query);


        //if (authResult.IsError && authResult.FirstError == Errors.Auth.InvalidCredentials))


        return authResult.Match(
                   authResult => Ok(MapAuthResult(authResult)),
                   errors => Problem(errors));
        //errors => Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.user.Id,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token);
    }
}
