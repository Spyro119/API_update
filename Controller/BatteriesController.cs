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
    public class batteriesController : ControllerBase
    {
        private readonly TodoContext _context;

        public batteriesController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/batteries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<batteries>>> Getbatteries()
        {
            return await _context.batteries.ToListAsync();
        }


        // Action that recuperates a given battery
        // GET: api/batteries/id
        [HttpGet("{id}")]
        public async Task<ActionResult<batteries>> Getbatteries(long id)
        {
            var batteries = await _context.batteries.FindAsync(id);

            if (batteries == null)
            {
                return NotFound();
            }

            return batteries;
        }
        
        // Action that recuperate the status of a given battery
        // GET batterystatus: 
        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetbatteryStatus(long id)
        {
            var batteries = await _context.batteries.FindAsync(id);

            if (batteries == null)
            {
                return NotFound();
            }

            return batteries.battery_status;

        }


        //Action that gives the list of inactive batteries
        //GET : api/batteries/inactivebatteries
        [HttpGet("inactivebatteries")]
        public async Task<ActionResult<List<batteries>>> GetinactiveBatteries()
        {
            var battery = await _context.batteries
                .Where(b => b.battery_status.Contains("Inactive")).ToListAsync();
                

            if (battery == null)
            {
                return NotFound();
            }

            return battery;
        }
        // // PUT: api/batteries/2
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // // more details see https://aka.ms/RazorPagesCRUD.
        // [HttpPut("{id}")]
        // public async Task<IActionResult> Putbatteries(long id, batteries batteries)
        // {
        //     if (id != batteries.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(batteries).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!batteriesExists(id))
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

        //Modification of Battery status. First, identification of a given battery is needed. 
         // PUT: api/batteries/id/updatestatus
        [HttpPut("{id}/updatestatus")]
        public async Task<IActionResult> PutmodifBatterySatus(long id, string status)
        {
                       
            if (status == null)
            {
                return BadRequest();
            }

            var battery = await _context.batteries.FindAsync(id);
            battery.battery_status = status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!batteriesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // // POST: api/batteries
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // // more details see https://aka.ms/RazorPagesCRUD.
        // [HttpPost]
        // public async Task<ActionResult<batteries>> Postbatteries(batteries batteries)
        // {
        //     _context.batteries.Add(batteries);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("Getbatteries", new { id = batteries.Id }, batteries);
        // }

        // // DELETE: api/batteries/5
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<batteries>> Deletebatteries(long id)
        // {
        //     var batteries = await _context.batteries.FindAsync(id);
        //     if (batteries == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.batteries.Remove(batteries);
        //     await _context.SaveChangesAsync();

        //     return batteries;
        // }

        private bool batteriesExists(long id)
        {
            return _context.batteries.Any(e => e.Id == id);
        }
    }
}