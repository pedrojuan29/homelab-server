using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Entities;

public partial class brand
{
    public string id { get; set; } = null!;

    public string alias { get; set; } = null!;

    public string name { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public DateTime? deletedAt { get; set; }

    public virtual ICollection<product> products { get; set; } = new List<product>();
}
