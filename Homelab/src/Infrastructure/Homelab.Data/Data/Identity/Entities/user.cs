using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Identity.Entities;

public partial class user
{
    public string id { get; set; } = null!;

    public string name { get; set; } = null!;

    public string email { get; set; } = null!;

    public string? avatar_url { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public DateTime? deletedAt { get; set; }

    public virtual ICollection<oauth_account> oauth_accounts { get; set; } = new List<oauth_account>();

    public virtual ICollection<password> passwords { get; set; } = new List<password>();

    public virtual ICollection<user_role> user_roles { get; set; } = new List<user_role>();
}
