using System;
using System.Collections.Generic;

namespace Auth.Models.ORM;

public partial class Auth
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public string Type { get; set; } = null!;

    public string Cookie { get; set; } = null!;

    public DateTime Expire { get; set; }

    public string Device { get; set; } = null!;

    public virtual User? User { get; set; }
}
