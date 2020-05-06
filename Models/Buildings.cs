using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class buildings
{
    public long Id { get; set; }
    public string building_administrator_full_name { get; set; }
     public string building_administrator_phone { get; set; }
     public string building_technical_contact_full_name { get; set; }
     public string building_technical_contact_email { get; set; }
     public string building_technical_contact_phone { get; set; }
     public DateTime created_at { get; set; }
     public DateTime updated_at { get; set; }
    public long customer_id { get; set; }
    public long battery_id { get; set; }
    

     //public ICollection<batteries> batteries { get; set; }

}