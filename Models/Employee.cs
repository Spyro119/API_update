using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class employee
{
    public long Id { get; set; }
    public string author { get; set; }
    public customers customer_id { get; set; }
    public List<buildings> building_id { get; set; }
    public List<batteries> battery_id { get; set; }

     public string building_administrator_phone { get; set; }
    // public long  { get; set; }
    

     //public ICollection<batteries> batteries { get; set; }

}