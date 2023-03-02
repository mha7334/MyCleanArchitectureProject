using Application.Commons.Interfaces.Persistence;
using Application.Services.Authentication;
using Domain.Commons.Errors;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Queries
{
    public class LoginQueryHanlder : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHanlder(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Auth.InvalidCredentials;
            }

            if (user.Password != query.Password)
            {
                return Errors.Auth.InvalidCredentials;
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
