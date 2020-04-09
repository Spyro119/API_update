
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class batteries
{
    public long Id { get; set; }
    public string building_type { get; set; }
    public string battery_status { get; set; }
    public string battery_notes { get; set; }
    public string battery_operation_certificate { get; set; }
    public long employee_id { get; set; }

    //[ForeignKey("buildings")]
    public long building_id { get; set; }
    //public buildings  buildings { get; set; }

    //public ICollection<columns> columns { get; set; }

}
