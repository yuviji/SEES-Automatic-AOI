﻿using System.Threading.Tasks;
using FluentValidation.Results;
using UserManagement.DataAccess;
using UserManagement.Models;
using UserManagement.Models.Validators;

namespace UserManagement
{
    public class Validator
    {
        private readonly CredentialValidator _credentialValidator;
        private readonly UserValidator _userValidator;
        public Validator(UserDataConnection connection)
        {
            var connection1 = connection;
            _credentialValidator = new(connection1);
            _userValidator = new(connection1);
        }
        public async Task<ValidationResult> ValidateCredential(Credential credential) => await _credentialValidator.ValidateAsync(credential);
        public async Task<ValidationResult> ValidateAsync(User user) => await _userValidator.ValidateAsync(user);
        public async Task<(ValidationResult, ValidationResult)> ValidateAll(User user, Credential credential) => (await _userValidator.ValidateAsync(user), await _credentialValidator.ValidateAsync(credential));
    }
}