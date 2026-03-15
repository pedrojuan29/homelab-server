using System;
using System.Collections.Generic;

using Homelab.Data.Data.Inventory.Entities;
namespace Homelab.Data.Data.Location.Entities;

public partial class location
{
    public string id { get; set; } = null!;

    public string name { get; set; } = null!;

    public string address { get; set; } = null!;

    public bool is_active { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public DateTime? deletedAt { get; set; }

    public virtual stock? stock { get; set; }
}
