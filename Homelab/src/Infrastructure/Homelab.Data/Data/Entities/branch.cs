using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Entities;

public partial class branch
{
    public string id { get; set; } = null!;

    public string name { get; set; } = null!;

    public bool is_active { get; set; }

    public string street { get; set; } = null!;

    public string number { get; set; } = null!;

    public string complement { get; set; } = null!;

    public string neighborhood { get; set; } = null!;

    public string city { get; set; } = null!;

    public string state { get; set; } = null!;

    public string zip { get; set; } = null!;

    public string country { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public DateTime? deleted_at { get; set; }

    public string cnpj { get; set; } = null!;

    public DateTime? established_at { get; set; }
}
