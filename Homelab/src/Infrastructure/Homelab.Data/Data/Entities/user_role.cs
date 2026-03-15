using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Entities;

public partial class user_role
{
    public string user_id { get; set; } = null!;

    public string role_id { get; set; } = null!;

    public DateTime created_at { get; set; }

    public virtual role role { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
