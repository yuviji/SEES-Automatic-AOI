﻿using System;
using FluentValidation;
using LinqToDB;
using UserManagement.DataAccess;

namespace UserManagement.Models.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        private static readonly TimeSpan TenMinutes = new(0, 10, 0);
        public UserValidator(UserDataConnection connection)
        {
			RuleFor(x => x.FirstName).NotEmpty().NotNull().MaximumLength(100).MinimumLength(5);
			RuleFor(x => x.LastName).NotEmpty().NotNull().MaximumLength(100).MinimumLength(5);
			RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().MustAsync(async (guid, token) =>
                await connection.Users.SingleOrDefaultAsync(u => u.Email == guid) == null
            );
            RuleFor(x => x.Created).NotEmpty().NotNull().Must(time =>
                time <= DateTime.UtcNow && time > DateTime.UtcNow - TenMinutes
            );
            RuleFor(x => x.UserID).NotEmpty().NotNull().MustAsync(async (guid, token) =>
                await connection.Users.SingleOrDefaultAsync(u => u.UserID == guid) == null
            );
        }
    }
}