using ErrorOr;

namespace Domain.Commons.Errors;

public static partial class Errors
{
    public static class Auth
    {
        public static Error InvalidCredentials => Error.Conflict(code: "Authentication.InvalidCredentials",
                                                             description: "invalid credentials");

    }
}