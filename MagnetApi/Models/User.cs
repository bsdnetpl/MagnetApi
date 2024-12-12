using System;
using System.Collections.Generic;

namespace MagnetApi.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Haslo { get; set; } = null!;

    public string Data { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ImieNazwisko { get; set; } = null!;

    public string Ranga { get; set; } = null!;
}
