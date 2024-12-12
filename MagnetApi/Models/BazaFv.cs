using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class BazaFv
{
    public string Numer { get; set; } = null!;

    public string Klient { get; set; } = null!;

    public string Ulica { get; set; } = null!;

    public string KodMiasto { get; set; } = null!;

    public string KwotaBrut { get; set; } = null!;

    public string Nip { get; set; } = null!;

    public string Data { get; set; } = null!;

    public string DataWystawienia { get; set; } = null!;

    public string PozDoZap { get; set; } = null!;

    public string Zaplacono { get; set; } = null!;

    public string Termin { get; set; } = null!;

    public string Godzina { get; set; } = null!;

    public string DniTerminu { get; set; } = null!;

    public string Odbiorca { get; set; } = null!;

    public string Kod1 { get; set; } = null!;

    public string Kod2 { get; set; } = null!;

    public string Gtu1 { get; set; } = null!;

    public string Gtu2 { get; set; } = null!;

    public string Gtu3 { get; set; } = null!;

    public string Gtu4 { get; set; } = null!;

    public string Gtu5 { get; set; } = null!;

    public string Gtu6 { get; set; } = null!;

    public string Gtu7 { get; set; } = null!;

    public string Gtu8 { get; set; } = null!;

    public string Gtu9 { get; set; } = null!;

    public string Gtu10 { get; set; } = null!;

    public string Gtu11 { get; set; } = null!;

    public string Gtu12 { get; set; } = null!;

    public string Gtu13 { get; set; } = null!;

    public string? DataZaplaty { get; set; }

    public bool? CzyZgloszonoDoKsef { get; set; }

    public string? DataZgloszneiaDoKsef { get; set; }

    public string? KsefReferenceNumber { get; set; }

    public string? XmlFile { get; set; }

    public string? IdentificationNumberOfInvoiceInKseF { get; set; }

    public string? XmlContent { get; set; }
}
