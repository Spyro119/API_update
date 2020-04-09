using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
public class columns
{
    public long Id { get; set; }
    public string column_status { get; set ;}
    public string building_type { get; set; }
    public int served_floor_number { get; set; }
    public string column_information { get; set; }
    public string column_notes { get; set; }

    //[ForeignKey("batteries")]
    public long battery_id { get; set; }
    //public batteries batteries { get; set;} 

    //public ICollection<elevators> elevators { get; set; }

}
