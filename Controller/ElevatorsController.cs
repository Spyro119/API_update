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
    public class elevatorsController : ControllerBase
    {
        private readonly TodoContext _context;

        public elevatorsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/elevators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<elevators>>> Getelevators()
        {
            return await _context.elevators.ToListAsync();
        }

         // Action that recuperates a given elevators by Id 
        // GET: api/elevators/id
        [HttpGet("{id}")]
        public async Task<ActionResult<elevators>> GetelevatorsById(long id)
        {
            var elevators = await _context.elevators.FindAsync(id);

            if (elevators == null)
            {
                return NotFound();
            }

            return elevators;
        }

       
        //Action that recuperates the status of a given elevator
        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetelevatorStatus(long id)
        {
            var elevator = await _context.elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }

            return elevator.elevator_status;
        }


        //Action that gives the list of inactive elevators
        //GET : api/elevators/inactiveelevators
        [HttpGet("inactiveelevators")]
        public async Task<ActionResult<List<elevators>>> GetinactiveElevators()
        {
            var elevator = await _context.elevators
                .Where(c => c.elevator_status.Contains("Inactive")).ToListAsync();
                

            if (elevator == null)
            {
                return NotFound();
            }

            return elevator;
        }


       
        //Updating the status of a given elevator. Frist, identification of the elevator is needed.
        // PUT: api/elevators/id/updatestatus        
        [HttpPut("{id}/updatestatus")]
        public async Task<IActionResult> PutmodifyElevatorStatus(long id, string status)
        {
            if (status == null)
            {
                return BadRequest();
            }

            var elevator = await _context.elevators.FindAsync(id);

            elevator.elevator_status = status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!elevatorsExists(id))
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

        // // POST: api/elevators
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // // more details see https://aka.ms/RazorPagesCRUD.
        // [HttpPost]
        // public async Task<ActionResult<elevators>> Postelevators(elevators elevators)
        // {
        //     _context.elevators.Add(elevators);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("Getelevators", new { id = elevators.Id }, elevators);
        // }

        // // DELETE: api/elevators/5
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<elevators>> Deleteelevators(long id)
        // {
        //     var elevators = await _context.elevators.FindAsync(id);
        //     if (elevators == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.elevators.Remove(elevators);
        //     await _context.SaveChangesAsync();

        //     return elevators;
        // }

        private bool elevatorsExists(long id)
        {
            return _context.elevators.Any(e => e.Id == id);
        }
    }
}