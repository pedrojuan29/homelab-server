using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Catalog.Entities;

public partial class category
{
    public string id { get; set; } = null!;

    public string alias { get; set; } = null!;

    public string name { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public DateTime? deletedAt { get; set; }

    public virtual ICollection<subcategory> subcategories { get; set; } = new List<subcategory>();
}
