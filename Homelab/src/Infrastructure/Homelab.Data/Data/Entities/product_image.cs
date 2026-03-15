using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Entities;

public partial class product_image
{
    public string id { get; set; } = null!;

    public string url { get; set; } = null!;

    public string productId { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public DateTime? deletedAt { get; set; }

    public virtual product product { get; set; } = null!;
}
