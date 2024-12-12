using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class CorrectionInvoice
{
    public int Id { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateOnly IssueDateCorrection { get; set; }

    public DateOnly IssueDate { get; set; }

    public string CorrectionReason { get; set; } = null!;

    public string OriginalInvoiceId { get; set; } = null!;

    public decimal? TotalNet { get; set; }

    public decimal? TotalVat { get; set; }

    public decimal? TotalGross { get; set; }

    public string Nip { get; set; } = null!;
}
