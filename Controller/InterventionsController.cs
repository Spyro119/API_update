using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using System.ComponentModel.DataAnnotations;

namespace RocketElevatorsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterventionsController : ControllerBase
    {
        private readonly TodoContext _context;

        public InterventionsController(TodoContext context)
        {
            _context = context;
        }

        // Action that gives the list of interventions
        // GET: api/interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<interventions>>> Getinterventions()
        {
            return await _context.interventions.ToListAsync();
        }

        // Action that recuperates a given interventions   
        // GET: api/interventions/id
        [HttpGet("pending")]
        public async Task<ActionResult<List<interventions>>> GetinterventionsStatus()
        {
            var interventions = await _context.interventions
            .Where(i => i.status.Contains("pending") && i.start_datetime.HasValue == false).ToListAsync();
            

            if (interventions == null)
            {
                return NotFound();
            }

            return interventions;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<interventions>> GetinterventionsById(long id)
        {
            var interventions = await _context.interventions.FindAsync(id);

            if (interventions == null)
            {
                return NotFound();
            }

            return interventions;
        }


        // // PUT: api/interventions/id
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}/update1")]
        public async Task<IActionResult> Putinterventions(long id, interventions interventions)
        {
            

            if (id != interventions.Id)
            {
                return BadRequest();
            }
            // else if (interventions.start_datetime.HasValue != true && interventions.end_datetime.HasValue == true)
            // {
            //      return BadRequest();
            // }
            
            _context.Entry(interventions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!interventionsExists(id))
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
//          Patch update, to update only specific rows.
    //     [HttpPatch("{id}")]
    //     public async Task<ActionResult<interventions>> PatchinterventionsRequest([FromBody] PatchInterventionsRequest request)
    //     {
    //         var interventions = await _context.interventions.FindAsync();
    //         var interventionsList = interventions.FirstOrDefault(c => c.Id == request.Id);
    //     if( interventions == null)
    //         return NotFound();
    //     else
    //     {
    //         interventions.status = request.status;
    //         interventions.start_datetime = request.start_datetime;
    //     }
    //     return Ok();
    // }


        // // POST: api/interventions
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // // more details see https://aka.ms/RazorPagesCRUD.
        // [HttpPost]
        // public async Task<ActionResult<interventions>> Postinterventions(interventions interventions)
        // {
        //     _context.interventions.Add(interventions);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("Getinterventions", new { id = interventions.Id }, interventions);
        // }

        // // DELETE: api/interventions/5
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<interventions>> Deleteinterventions(long id)
        // {
        //     var interventions = await _context.interventions.FindAsync(id);
        //     if (interventions == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.interventions.Remove(interventions);
        //     await _context.SaveChangesAsync();

        //     return interventions;
        // }

        private bool interventionsExists(long id)
        {
            return _context.interventions.Any(e => e.Id == id);
        }
    }
}