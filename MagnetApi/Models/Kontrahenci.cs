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
