﻿using Domain.Commons.Models;
using Domain.Guest.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.User.ValueObjects;

namespace Domain.User
{
    public sealed class User : AggregateRoot<UserId>
    {

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }

        public HostId HostId { get; }

        public GuestId GuestId { get; }

        private User(UserId userId, string firstName, string lastName, string email, string password) : base(userId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static User Create(string firstName, string lastName, string email, string password)
        {
            return new(UserId.CreateUnique(), firstName, lastName, email, password);
        }
    }

}
