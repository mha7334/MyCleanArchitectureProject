using Application.Authentication.Commands.Register;
using Application.Authentication.Queries;
using Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediatr;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediatR, IMapper mapper)
    {
        _mediatr = mediatR;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var authResult = await _mediatr.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        var authResult = await _mediatr.Send(query);


        //if (authResult.IsError && authResult.FirstError == Errors.Auth.InvalidCredentials))


        return authResult.Match(
                   authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                   errors => Problem(errors));
        //errors => Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);

    }
}
