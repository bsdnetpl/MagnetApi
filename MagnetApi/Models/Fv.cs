using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class Fv
{
    public int NumerFv { get; set; }

    public int Sva { get; set; }

    public int Svb { get; set; }

    public int Svc { get; set; }

    public int Svd { get; set; }

    public int Sve { get; set; }

    public int Svf { get; set; }

    public string Svg { get; set; } = null!;

    public int Domyslna { get; set; }
}
