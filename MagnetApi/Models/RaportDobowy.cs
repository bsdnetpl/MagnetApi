using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public class RaportDobowy
{
    public int Id { get; set; }

    public string Data { get; set; } = null!;

    public double Zysk { get; set; }

    public double UtargBrutto { get; set; }

    public float Sva { get; set; }

    public float Svb { get; set; }

    public float Svc { get; set; }

    public float Svd { get; set; }

    public float Sve { get; set; }

    public float Svf { get; set; }

    public float Svg { get; set; }

    public string Raportujacy { get; set; } = null!;

    public string Godzina { get; set; } = null!;

    public string Gotowka { get; set; } = null!;

    public double RoznicaVat { get; set; }
}
