using System;
using System.Collections.Generic;

namespace Notify.Models.Database;

public partial class Contact
{
    public Guid ContactId { get; set; }

    public Guid? UserId { get; set; }

    public string Type { get; set; } = null!;

    public string Data { get; set; } = null!;

    public bool? UseInMsgSend { get; set; }

    public virtual User? User { get; set; }
}
