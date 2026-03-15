using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Entities;

public partial class snapshot
{
    public string id { get; set; } = null!;

    public int quantity { get; set; }

    public DateTime processed_at { get; set; }

    public string inventory_item_id { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public virtual inventory_item inventory_item { get; set; } = null!;
}
