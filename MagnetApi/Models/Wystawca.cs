using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class Wystawca
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public string Ulica { get; set; } = null!;

    public string Miasto { get; set; } = null!;

    public string NrKontaBankowego { get; set; } = null!;

    public string Wystawil { get; set; } = null!;

    public string MiejsceWystawienia { get; set; } = null!;

    public string Nip { get; set; } = null!;

    public string NazwaBanku { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string Wojewodztwo { get; set; } = null!;

    public string Powiat { get; set; } = null!;

    public string Gmina { get; set; } = null!;

    public string Regon { get; set; } = null!;

    public string? Bdo { get; set; }

    public string Waluta { get; set; } = null!;

    public bool KasfCzyWysylac { get; set; }
}
