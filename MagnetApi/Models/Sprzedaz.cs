using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class Sprzedaz
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public double Cena { get; set; }

    public double Zarobek { get; set; }

    public double Ilosc { get; set; }

    public string Data { get; set; } = null!;

    public string Czas { get; set; } = null!;

    public string StawkaVat { get; set; } = null!;

    public double CenaNetto { get; set; }

    public string FormaPlatnosci { get; set; } = null!;

    public string DataZakupu { get; set; } = null!;

    public string NumerFv { get; set; } = null!;

    public string KodProduktu { get; set; } = null!;

    public double RoznicaVat { get; set; }
}
