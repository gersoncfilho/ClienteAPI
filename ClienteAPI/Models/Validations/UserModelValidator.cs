using System;
using System.Runtime.CompilerServices;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace ClienteAPI.Models.Validations
{
    public class UserModelValidator : AbstractValidator<User>
    {
        public UserModelValidator()
        {
            Initialize();

        }

        private void Initialize()
        {
            UsernameValidator();
            FirstNameValidator();
            LastNameValidator();
            EmailValidator();
            PasswordValidator();
            PhoneValidator();
            BirthDateValidator();
        }

        private void UsernameValidator()
        {
            RuleFor(c => c.Username)
                .NotNull()
                .NotEmpty()
                .WithMessage("Username obrigatório")
                .MinimumLength(2)
                .WithMessage("Mínimo de 2 caracteres")
                .MaximumLength(10)
                .WithMessage("Máximo de 10 caracteres");
        }

        private void FirstNameValidator()
        {
            RuleFor(c => c.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome obrigatório")
                .MinimumLength(2)
                .WithMessage("Nome com no mínimo de 2 caracteres")
                .MaximumLength(10)
                .WithMessage("Nome com no máximo de 10 caracteres");
        }

        private void LastNameValidator()
        {
            RuleFor(c => c.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Sobrenome obrigatório")
                .MinimumLength(2)
                .WithMessage("Sobrenome com no mínimo de 2 caracteres")
                .MaximumLength(10)
                .WithMessage("Sobrenome com no máximo de 10 caracteres");
        }

        private void EmailValidator()
        {
            RuleFor(c => c.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email obrigatório")
                .EmailAddress()
                .WithMessage("Email inválido");
        }

        private void PasswordValidator()
        {
            RuleFor(c => c.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Senha obrigatória");
        }

        private void PhoneValidator()
        {
            RuleFor(c => c.Phone)
                .NotNull()
                .NotEmpty()
                .WithMessage("Telefone obrigatório");

        }

        private void BirthDateValidator()
        {
            RuleFor(c => c.BirthDate)
                .NotNull()
                .NotEmpty()
                .WithMessage("Data da requisição obrigatória")
                .Must(BeAValidDate)
                .WithMessage("Data inválida");

        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

    }
}