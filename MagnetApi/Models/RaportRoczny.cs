using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class RaportRoczny
{
    public int Id { get; set; }

    public string Miesiac { get; set; } = null!;

    public double UtargBrutto { get; set; }

    public double Zysk { get; set; }

    public float Sva { get; set; }

    public float Svb { get; set; }

    public float Svc { get; set; }

    public float Svd { get; set; }

    public float Sve { get; set; }

    public float Svf { get; set; }

    public float Svg { get; set; }
}
