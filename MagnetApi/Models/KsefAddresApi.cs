using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class KsefAddresApi
{
    public int Id { get; set; }

    public string Address { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool Selected { get; set; }

    public string PublicKeyPem { get; set; } = null!;

    public string? Token { get; set; }

    public string? Data { get; set; }

    public string? Nip { get; set; }
}
