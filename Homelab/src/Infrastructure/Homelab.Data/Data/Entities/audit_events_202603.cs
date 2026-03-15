using System;
using System.Collections.Generic;

namespace Homelab.Data.Data.Entities;

public partial class audit_events_202603
{
    public string id { get; set; } = null!;

    public string type { get; set; } = null!;

    public DateTime occurred_at { get; set; }

    public string method { get; set; } = null!;

    public string endpoint { get; set; } = null!;

    public string? user_id { get; set; }

    public string? user_email { get; set; }

    public string? permission_id { get; set; }

    public string? permission_alias { get; set; }

    public string action { get; set; } = null!;

    public string criticality { get; set; } = null!;

    public int? status_code { get; set; }

    public int duration_ms { get; set; }
}
