using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class interventions
{
    public long Id { get; set; }
    public long author { get; set; }
    public long customer_id { get; set; }
    public long? building_id { get; set; } = null;
    public long? battery_id { get; set; } = null;
    public long? elevator_id { get; set; } = null;
    public long? employee_id { get; set; } = null;
    public DateTime? start_datetime { get; set; } = null;
    public DateTime? end_datetime { get; set; } = null;
    public string result { get; set; }
    public string status { get; set; }
     public string report { get; set; }
    

     //public ICollection<batteries> batteries { get; set; }

}