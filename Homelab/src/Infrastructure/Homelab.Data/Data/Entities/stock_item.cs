using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Entities;

public partial class stock_item
{
    public string id { get; set; } = null!;

    public int costPrice { get; set; }

    public int salePrice { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public DateTime? deletedAt { get; set; }

    public virtual ICollection<inventory_item> inventory_items { get; set; } = new List<inventory_item>();
}
