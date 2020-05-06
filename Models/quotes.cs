
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class quotes
{
    public long Id { get; set; }
    public string BuildingType { get; set; }
    public long? user_id { get; set; }
    public long? lead_id { get; set; }
    public float? TotalPrice { get; set; }
    public DateTime? created_at { get; set; } = null;

}
