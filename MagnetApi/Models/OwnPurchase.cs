using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class OwnPurchase
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Price { get; set; } = null!;

    public string Date { get; set; } = null!;

    public string InvoiceNr { get; set; } = null!;
}
