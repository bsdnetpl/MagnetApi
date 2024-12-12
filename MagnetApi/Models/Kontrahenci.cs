using FluentValidation;
using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class Kontrahenci
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public string Ulica { get; set; } = null!;

    public string Miasto { get; set; } = null!;

    public string Nip { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string OstatniaFv { get; set; } = null!;

    public float Obrot { get; set; }

    public string Reprezentant { get; set; } = null!;

    public string Skrot { get; set; } = null!;

    public string Odbiorca { get; set; } = null!;

    public string KodPocztowy { get; set; } = null!;

    public string NrDomu { get; set; } = null!;

    public string Wojewodztwo { get; set; } = null!;

    public string Powiat { get; set; } = null!;

    public string Gmina { get; set; } = null!;
}

public class KontrahenciValidator : AbstractValidator<Kontrahenci>
{
    public KontrahenciValidator()
    {
        RuleFor(k => k.Nazwa)
            .NotEmpty().WithMessage("Nazwa kontrahenta jest wymagana.")
            .MaximumLength(100).WithMessage("Nazwa kontrahenta nie może być dłuższa niż 100 znaków.");

        RuleFor(k => k.Ulica)
            .NotEmpty().WithMessage("Ulica jest wymagana.")
            .MaximumLength(100).WithMessage("Ulica nie może być dłuższa niż 100 znaków.");

        RuleFor(k => k.Miasto)
            .NotEmpty().WithMessage("Miasto jest wymagane.")
            .MaximumLength(50).WithMessage("Miasto nie może być dłuższe niż 50 znaków.");

        RuleFor(k => k.Nip)
            .NotEmpty().WithMessage("NIP jest wymagany.")
            .Matches(@"^\d{10}$").WithMessage("NIP musi składać się z 10 cyfr.");

        RuleFor(k => k.Telefon)
            .NotEmpty().WithMessage("Telefon jest wymagany.")
            .Matches(@"^\d{9}$").WithMessage("Telefon musi składać się z 9 cyfr.");

        RuleFor(k => k.Email)
            .NotEmpty().WithMessage("Email jest wymagany.")
            .EmailAddress().WithMessage("Email musi mieć poprawny format.");

        RuleFor(k => k.OstatniaFv)
            .NotEmpty().WithMessage("Numer ostatniej faktury jest wymagany.")
            .MaximumLength(50).WithMessage("Numer faktury nie może być dłuższy niż 50 znaków.");

        RuleFor(k => k.Obrot)
            .GreaterThan(0).WithMessage("Obrót musi być większy niż 0.");

        RuleFor(k => k.Reprezentant)
            .NotEmpty().WithMessage("Reprezentant jest wymagany.")
            .MaximumLength(100).WithMessage("Reprezentant nie może być dłuższy niż 100 znaków.");

        RuleFor(k => k.Skrot)
            .NotEmpty().WithMessage("Skrot jest wymagany.")
            .MaximumLength(10).WithMessage("Skrot nie może być dłuższy niż 10 znaków.");

        RuleFor(k => k.Odbiorca)
            .NotEmpty().WithMessage("Odbiorca jest wymagany.")
            .MaximumLength(100).WithMessage("Odbiorca nie może być dłuższy niż 100 znaków.");

        RuleFor(k => k.KodPocztowy)
            .NotEmpty().WithMessage("Kod pocztowy jest wymagany.")
            .Matches(@"^\d{2}-\d{3}$").WithMessage("Kod pocztowy musi mieć format 00-000.");

        RuleFor(k => k.NrDomu)
            .NotEmpty().WithMessage("Numer domu jest wymagany.")
            .MaximumLength(10).WithMessage("Numer domu nie może być dłuższy niż 10 znaków.");

        RuleFor(k => k.Wojewodztwo)
            .NotEmpty().WithMessage("Województwo jest wymagane.")
            .MaximumLength(50).WithMessage("Województwo nie może być dłuższe niż 50 znaków.");

        RuleFor(k => k.Powiat)
            .NotEmpty().WithMessage("Powiat jest wymagany.")
            .MaximumLength(50).WithMessage("Powiat nie może być dłuższy niż 50 znaków.");

        RuleFor(k => k.Gmina)
            .NotEmpty().WithMessage("Gmina jest wymagana.")
            .MaximumLength(50).WithMessage("Gmina nie może być dłuższa niż 50 znaków.");
    }
}
