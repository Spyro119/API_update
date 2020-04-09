using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TodoApi.Models;


namespace RocketElevatorsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class buildingsController : ControllerBase
    {
        private readonly TodoContext _context;

        public buildingsController(TodoContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<batteries>>> Getbatteries()
        {
            return await _context.batteries.ToListAsync();
        }
        
        // Action that gives the list of buildings
        // GET: api/buildings/listofbuildings
        [HttpGet("listofbuildings")]
        public async Task<ActionResult<IEnumerable<buildings>>> GetbuildingList()
        {
         
            
             var building = await (from cust in _context.buildings
                            join bat in _context.batteries on cust.Id equals bat.building_id
                            join col in _context.columns on bat.Id equals col.battery_id
                            join ele in _context.elevators on col.Id equals ele.column_id
                            where ele.elevator_status == "Intervention" || col.column_status == "Intervention" || bat.battery_status == "Intervention"
                            select cust).Distinct().ToListAsync();
                  
            if (building == null)
            {
                return NotFound();
            }

            return building;
        }
    }

}









