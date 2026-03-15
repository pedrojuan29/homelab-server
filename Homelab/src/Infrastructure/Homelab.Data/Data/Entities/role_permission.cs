using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Entities;

public partial class role_permission
{
    public string role_id { get; set; } = null!;

    public string permission_id { get; set; } = null!;

    public DateTime created_at { get; set; }

    public virtual permission permission { get; set; } = null!;

    public virtual role role { get; set; } = null!;
}
