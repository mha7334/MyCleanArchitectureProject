﻿using Application.Services.Authentication;
using ErrorOr;

namespace Application.Commons.Interfaces.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    ErrorOr<AuthenticationResult> Login(string email, string password);
}
