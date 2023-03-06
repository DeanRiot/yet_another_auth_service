using System;
using System.Collections.Generic;

namespace Auth.Models.ORM;

public partial class Picture
{
    public Guid PicId { get; set; }

    public Guid? UserId { get; set; }

    public string Path { get; set; } = null!;

    public bool? IsAvatar { get; set; }

    public virtual User? User { get; set; }
}
