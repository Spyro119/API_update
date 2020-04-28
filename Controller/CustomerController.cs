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
    public class CustomerController : ControllerBase
    {
         private readonly TodoContext _context;

        public CustomerController(TodoContext context)
        {
            _context = context;
        }

         [HttpGet]
        public async Task<ActionResult<IEnumerable<customers>>> GetCustomers()
        {
            return await _context.customers.ToListAsync();
        }

         // Action that recuperates a given column 
        // GET: api/columns/id
        [HttpGet("{id}")]
        public async Task<ActionResult<customers>> Getcustomer(long id)
        {
            var customer = await _context.customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
        [HttpGet("Infos/{id}")]
        public async Task<ActionResult<IEnumerable<customers>>> GetCustomerInfo(long id)
        {
    //      IQueryable<Customer> custQuery =  
    // from cust in _context.Customers  
    // where cust.City == "London"  
    // select cust;  
            
             var customerslist = await (from customers in _context.customers where customers.Id == id
                            join building in _context.buildings on customers.Id equals building.customer_id
                            // join battery in _context.batteries on building.battery_id equals battery.Id
                            // join col in _context.columns on battery.column_id equals col.battery_id
                            // join ele in _context.elevators on col.Id equals ele.column_id
                            // where ele.elevator_status == "Intervention" || col.column_status == "Intervention"
                            select customers).Distinct().ToListAsync();

                  
            if (customerslist == null)
            {
                return NotFound();
            }

            return customerslist;
        }   

    // There are currently XXX elevators deployed in the XXX buildings of your XXX customers
    // Number of elevators in x building for x customer
    }
}