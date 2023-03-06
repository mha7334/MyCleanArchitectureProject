using Application.Authentication.Commands.Register;
using Application.Authentication.Queries;
using Application.Services.Authentication;

using Contracts.Authentication;

using Mapster;

namespace Api.Common.Mappings;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.user.Id.Value)
            .Map(dest => dest, src => src.user);
    }
}