using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace Homelab.Data.Data.Entities;

public partial class product
{
    public string id { get; set; } = null!;

    public string alias { get; set; } = null!;

    public string name { get; set; } = null!;

    public string description { get; set; } = null!;

    public double price { get; set; }

    public string sku { get; set; } = null!;

    public string subcategory_id { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public DateTime? deletedAt { get; set; }

    public string brand_id { get; set; } = null!;

    public NpgsqlTsVector? name_tsvector { get; set; }

    public NpgsqlTsVector? description_tsvector { get; set; }

    public virtual brand brand { get; set; } = null!;

    public virtual ICollection<product_characteristic> product_characteristics { get; set; } = new List<product_characteristic>();

    public virtual ICollection<product_image> product_images { get; set; } = new List<product_image>();

    public virtual subcategory subcategory { get; set; } = null!;
}
