using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class Klucze
{
    public int Id { get; set; }

    public string NazwaKlucza { get; set; } = null!;

    public string Klucz { get; set; } = null!;

    public string? Opis { get; set; }

    public DateTime? Data { get; set; }
}
