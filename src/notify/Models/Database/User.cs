using System;
using System.Collections.Generic;

namespace Notify.Models.Database;

public partial class User
{
    public Guid UserId { get; set; }

    public string NickName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Middlename { get; set; }

    public string Lastname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly? Birthday { get; set; }

    public virtual ICollection<Contact> Contacts { get; } = new List<Contact>();

}
