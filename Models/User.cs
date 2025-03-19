using System;
using System.Collections.Generic;

namespace MiAppUsuarios.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int Age { get; set; }

    public string Email { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public DateTime? Createdat { get; set; }
}
