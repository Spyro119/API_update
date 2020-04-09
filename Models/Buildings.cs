using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class buildings
{
    public long Id { get; set; }
    public string building_administrator_full_name { get; set; }
     public string building_administrator_phone { get; set; }
    public long customer_id { get; set; }
    

     //public ICollection<batteries> batteries { get; set; }

}