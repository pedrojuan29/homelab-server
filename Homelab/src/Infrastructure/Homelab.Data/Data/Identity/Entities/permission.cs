using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Identity.Entities;

public partial class permission
{
    public string id { get; set; } = null!;

    public string name { get; set; } = null!;

    public string description { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public DateTime? deletedAt { get; set; }

    public string alias { get; set; } = null!;

    public virtual ICollection<role_permission> role_permissions { get; set; } = new List<role_permission>();
}
