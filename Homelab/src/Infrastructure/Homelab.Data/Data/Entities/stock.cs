using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Entities;

public partial class stock
{
    public string id { get; set; } = null!;

    public string name { get; set; } = null!;

    public string location_id { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public DateTime? deletedAt { get; set; }

    public virtual ICollection<inventory_item> inventory_items { get; set; } = new List<inventory_item>();

    public virtual location location { get; set; } = null!;
}
