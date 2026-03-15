using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Entities;

public partial class password
{
    public string id { get; set; } = null!;

    public string content { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public DateTime? deletedAt { get; set; }

    public string userId { get; set; } = null!;

    public virtual user user { get; set; } = null!;
}
