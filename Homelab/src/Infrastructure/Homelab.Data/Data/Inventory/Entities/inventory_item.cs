using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Inventory.Entities;

public partial class inventory_item
{
    public string id { get; set; } = null!;

    public string stock_id { get; set; } = null!;

    public string stock_item_id { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public virtual ICollection<movement> movements { get; set; } = new List<movement>();

    public virtual ICollection<snapshot> snapshots { get; set; } = new List<snapshot>();

    public virtual stock stock { get; set; } = null!;

    public virtual stock_item stock_item { get; set; } = null!;
}
