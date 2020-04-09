using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
public class elevators
{
    public long Id { get; set; }
    public string building_type { get; set; }
    public long elevator_serial_number { get; set; }
    public string elevator_model { get; set; }
    public string elevator_status { get; set; }
    public string elevator_information { get; set; }

    //[ForeignKey("columns")]
   
    public long column_id { get; set; }
    //public columns columns { get; set;} 

}
