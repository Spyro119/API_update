using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class addresses
{
    public long Id { get; set; }
    // public string building_administrator_full_name { get; set; }
     public string city { get; set; }
    public string address_type { get; set; }
    public string address_status { get; set; }
    public string street_number { get; set; }
    public string street_name { get; set; }
    public string suite_or_apartment { get; set; }
    public string postal_code { get; set; }
    

     //public ICollection<batteries> batteries { get; set; }

}