using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class Odbiorca
{
    public int Id { get; set; }

    public string Nazwa { get; set; } = null!;

    public string Adres { get; set; } = null!;

    public string Nip { get; set; } = null!;
}
