using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class Dostawca
{
    public int Id { get; set; }

    public string NrDostawcy { get; set; } = null!;

    public string NazwaDostawcy { get; set; } = null!;

    public string DowodZakupu { get; set; } = null!;

    public string DataZakupu { get; set; } = null!;

    public double Netto23 { get; set; }

    public double? Podatek23 { get; set; }

    public double? Vat23 { get; set; }

    public double Netto8 { get; set; }

    public double? Podatek8 { get; set; }

    public double? Vat8 { get; set; }

    public double? Netto5 { get; set; }

    public double? Podatek5 { get; set; }

    public double? Vat5 { get; set; }

    public string? Kod1 { get; set; }

    public string? Kod2 { get; set; }

    public string? Kod3 { get; set; }

    public string? Kod4 { get; set; }

    public string? Kod5 { get; set; }

    public string? NumerZamowienia { get; set; }
}
