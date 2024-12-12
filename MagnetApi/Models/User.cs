using FluentValidation;
using MagnetApi.Service;
using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Haslo { get; set; } = null!;

    public string Data { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ImieNazwisko { get; set; } = null!;

    public string Ranga { get; set; } = null!;
}

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.Login)
            .NotEmpty().WithMessage("Login jest wymagany.")
            .Length(3, 50).WithMessage("Login musi mieć od 3 do 50 znaków.");

        RuleFor(u => u.Haslo)
            .NotEmpty().WithMessage("Hasło jest wymagane.")
            .Length(9, 100).WithMessage("Hasło musi mieć od 9 do 100 znaków.");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email jest wymagany.")
            .EmailAddress().WithMessage("Email musi mieć poprawny format.");

        RuleFor(u => u.ImieNazwisko)
            .NotEmpty().WithMessage("Imię i nazwisko jest wymagane.")
            .Length(3, 100).WithMessage("Imię i nazwisko musi mieć od 3 do 100 znaków.");

        RuleFor(u => u.Ranga)
            .NotEmpty().WithMessage("Ranga jest wymagana.")
            .Length(3, 50).WithMessage("Ranga musi mieć od 3 do 50 znaków.");
    }
}