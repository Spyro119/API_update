using System;
using System.ComponentModel.DataAnnotations;
public class leads
{
    public long Id { get; set; }
    public string lead_full_name { get; set; }
    public string lead_company_name { get; set; }
    public string lead_email { get; set; }
    public string lead_phone { get; set; }
    public string project_name { get; set; }
   
    public string department_of_service { get; set; }
   


    [DataType(DataType.Date)]
    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

}

