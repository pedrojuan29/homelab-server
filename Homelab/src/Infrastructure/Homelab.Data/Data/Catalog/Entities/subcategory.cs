using System;
using System.Collections.Generic;

using Homelab.Data.Data.Inventory.Entities;
namespace Homelab.Data.Data.Catalog.Entities;

public partial class subcategory
{
    public string id { get; set; } = null!;

    public string alias { get; set; } = null!;

    public string name { get; set; } = null!;

    public int order { get; set; }

    public string parentId { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public DateTime? deletedAt { get; set; }

    public virtual category parent { get; set; } = null!;

    public virtual ICollection<product> products { get; set; } = new List<product>();
}
