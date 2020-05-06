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
    public class employeesController : ControllerBase
    {
        private readonly TodoContext _context;

        public employeesController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<employees>>> GetEmployees()
        {
            return await _context.employees.ToListAsync();
        }

         // Action that recuperates a given elevators by Id 
        // GET: api/elevators/id
        [HttpGet("{id}")]
        public async Task<ActionResult<employees>> GetEmployeesById(long id)
        {
            var employee = await _context.employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

         [HttpGet("profile/{AiProfile}")]
        public async Task<ActionResult<List<employees>>> GetEmployeesByAiProfile(string AiProfile)
        {
           var employee = await _context.employees
                .Where(c => c.AiProfile.Contains(AiProfile)).ToListAsync();

            if (employee == null)
            {
                return NotFound();
            }

            else if (AiProfile == "null")
            {
                employee = await _context.employees
                .Where(c => c.AiProfile == null)
                .ToListAsync();
            }

            return employee;
        }

[HttpGet("profiles")]
        public async Task<ActionResult<List<employees>>> GetAllEmployeesAiProfile()
        {
           var employee = await _context.employees
                .Where(c => c.AiProfile != null).ToListAsync();

            if (employee == null)
            {
                return NotFound();
            }
            
            return employee;
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

        private bool employeesExist(long id)
        {
            return _context.employees.Any(e => e.Id == id);
        }
    }
}