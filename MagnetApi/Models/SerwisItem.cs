using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class SerwisItem
{
    public int Id { get; set; }

    public string NazwaProduktu { get; set; } = null!;

    public string? NumerSeryjny { get; set; }

    public DateOnly DataZakupu { get; set; }

    public DateOnly? DataSprzedazy { get; set; }

    public DateOnly DataOddaniaNaSerwis { get; set; }

    public string NumerRma { get; set; } = null!;

    public string? DokumentZakupu { get; set; }

    public string? DokumentSprzedazy { get; set; }

    public string TelefonKlienta { get; set; } = null!;

    public string? Komentarz { get; set; }

    public DateTime DataUtworzenia { get; set; }

    public DateTime DataAktualizacji { get; set; }
}
