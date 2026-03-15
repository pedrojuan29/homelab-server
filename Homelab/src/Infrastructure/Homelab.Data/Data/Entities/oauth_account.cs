using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Entities;

public partial class oauth_account
{
    public string id { get; set; } = null!;

    public string provider_user_id { get; set; } = null!;

    public string email { get; set; } = null!;

    public bool email_verified { get; set; }

    public string? name { get; set; }

    public string? avatar_url { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public string user_id { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
