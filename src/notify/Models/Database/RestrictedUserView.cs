using System;
using System.Collections.Generic;

namespace Notify.Models.Database;

public partial class RestrictedUserView
{
    public Guid? UserId { get; set; }

    public string? NickName { get; set; }

    public string? Name { get; set; }

    public string? Middlename { get; set; }

    public string? Lastname { get; set; }
}
