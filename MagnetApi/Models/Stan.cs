using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class Stan
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public string KodKreskowy { get; set; } = null!;

    public double Ilosc { get; set; }

    public double Zarobek { get; set; }

    public double NettoZakup { get; set; }

    public double KursEuro { get; set; }

    public double KursUsd { get; set; }

    public double Cena { get; set; }

    public double CenaNetto { get; set; }

    public string StawkaVat { get; set; } = null!;

    public float IloscWOpakowanju { get; set; }

    public string DataZakupu { get; set; } = null!;

    public string NumerFv { get; set; } = null!;

    public string KodProduktu { get; set; } = null!;

    public double RoznicaVat { get; set; }

    public string Gtu { get; set; } = null!;
}
