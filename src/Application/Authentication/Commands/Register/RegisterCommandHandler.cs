using Application.Commons.Interfaces.Persistence;
using Application.Services.Authentication;
using Domain.Commons.Errors;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            // Create user (generate unique ID)
            User user = new()
            {
                FirstName = command.Firstname,
                LastName = command.Lastname,
                Email = command.Email,
                Password = command.Password
            };

            _userRepository.Add(user);


            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
