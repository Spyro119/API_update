using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace RocketElevatorsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly TodoContext _context;

        public LeadsController(TodoContext context)
        {
            _context = context;
        }

        // Action that gives the list of leads
        // GET: api/Leads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<leads>>> Getleads()
        {
            return await _context.leads.ToListAsync();
        }

        // Action that recuperates a given leads   
        // GET: api/leads/id
        [HttpGet("{id}")]
        public async Task<ActionResult<leads>> GetLeadsById(long id)
        {
            var lead = await _context.leads.FindAsync(id);

            if (lead == null)
            {
                return NotFound();
            }

            return lead;
        }

        //Action that gives the list of Leads created in the last 30 days and are not customers
        // GET: api/leads/leadnotbeingcustomer
        [HttpGet("leadnotbeingcustomer")]
        public List<leads> Getleads(long id)
        {
            
            var leadNotBeingCustomer = (from lea in _context.leads
                        where lea.created_at >= DateTime.Now.AddDays(-30) 
                        && !(from cust in _context.customers
                        select cust.lead_id).Contains(lea.Id) 
                        select lea).Distinct().ToList();                                    
                           
           return leadNotBeingCustomer;
        }

        // // PUT: api/Leads/id
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // // more details see https://aka.ms/RazorPagesCRUD.
        // [HttpPut("{id}")]
        // public async Task<IActionResult> Putleads(long id, leads leads)
        // {
        //     if (id != leads.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(leads).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!leadsExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // // POST: api/Leads
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // // more details see https://aka.ms/RazorPagesCRUD.
        // [HttpPost]
        // public async Task<ActionResult<leads>> Postleads(leads leads)
        // {
        //     _context.leads.Add(leads);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("Getleads", new { id = leads.Id }, leads);
        // }

        // // DELETE: api/Leads/5
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<leads>> Deleteleads(long id)
        // {
        //     var leads = await _context.leads.FindAsync(id);
        //     if (leads == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.leads.Remove(leads);
        //     await _context.SaveChangesAsync();

        //     return leads;
        // }

        private bool leadsExists(long id)
        {
            return _context.leads.Any(e => e.Id == id);
        }
    }
}