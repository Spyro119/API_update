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
    public class columnsController : ControllerBase
    {
        private readonly TodoContext _context;

        public columnsController(TodoContext context)
        {
            _context = context;
        }

        //Action that gives the list of all columns
        // GET: api/columns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<columns>>> Getcolumns()
        {
            return await _context.columns.ToListAsync();
        }

         // Action that recuperates a given column 
        // GET: api/columns/id
        [HttpGet("{id}")]
        public async Task<ActionResult<columns>> Getcolumns(long id)
        {
            var column = await _context.columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return column;
        }

       
        //Action that recuperates the status of a given column
        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetcolumnStatus(long id)
        {
            var column = await _context.columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return column.column_status;
        }

        //Action that gives the list of inactive columns
        //GET : api/columns/inactivecolumns
        [HttpGet("inactivecolumns")]
        public async Task<ActionResult<List<columns>>> GetinactiveColumns()
        {
            var column = await _context.columns
                .Where(c => c.column_status.Contains("Inactive")).ToListAsync();
                

            if (column == null)
            {
                return NotFound();
            }

            return column;
        }
        
        //Updating the status of a given column. Frist, identification of the column is needed.
        // PUT: api/columns/id/updatestatus        
        [HttpPut("{id}/updatestatus")]
        public async Task<IActionResult> PutmodifyColumnStatus(long id, string status)
        {
            if (status == null)
            {
                return BadRequest();
            }

            var column = await _context.columns.FindAsync(id);

            column.column_status = status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!columnsExists(id))
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

        private bool columnsExists(long id)
        {
            return _context.columns.Any(e => e.Id == id);
        }
    }
}