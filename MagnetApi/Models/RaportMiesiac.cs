using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class RaportMiesiac
{
    public int Id { get; set; }

    public string Data { get; set; } = null!;

    public double UtargBrutto { get; set; }

    public double Zysk { get; set; }

    public float Sva { get; set; }

    public float Svb { get; set; }

    public float Svc { get; set; }

    public float Svd { get; set; }

    public float Sve { get; set; }

    public float Svf { get; set; }

    public float Svg { get; set; }

    public int IloscDni { get; set; }

    public float SredniZysk { get; set; }

    public float SredniUtarg { get; set; }
}
