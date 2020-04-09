using System;
using System.ComponentModel.DataAnnotations;
public class customers
{
    public long Id { get; set; }
    public long company_name { get; set; }
    public string company_contact_full_name { get; set; }
    public string company_contact_email { get; set; }
    public string company_contact_phone { get; set; }
    public string company_description { get; set; }
    public string service_technical_authority_full_name { get; set; }
    public string service_technical_authority_email { get; set; }
    public string service_technical_authority_phone { get; set; }
    public long user_id { get; set; }
    public long quote_id { get; set; }
    public long lead_id { get; set; }

    
    [DataType(DataType.Date)]
    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

}