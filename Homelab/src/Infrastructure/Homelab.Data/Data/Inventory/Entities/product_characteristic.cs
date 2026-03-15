using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Inventory.Entities;

public partial class product_characteristic
{
    public string id { get; set; } = null!;

    public string name { get; set; } = null!;

    public string value { get; set; } = null!;

    public string productId { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public DateTime? deletedAt { get; set; }

    public virtual product product { get; set; } = null!;
}
