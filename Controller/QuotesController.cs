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
    public class QuotesController : ControllerBase
    {
        private readonly TodoContext _context;

        public QuotesController(TodoContext context)
        {
            _context = context;
        }

        // Action that gives the list of leads
        // GET: api/Quotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<quotes>>> Getquotes()
        {
            return  await _context.quotes.ToListAsync();
        }

      // Action that gives the total number of quotes
      // GET: api/quotes/total
      [HttpGet("total")]
      public ActionResult TotalQuotes(long id)
      {
         var TotalNumberOfQuotes = _context.quotes.Count();         
         Console.WriteLine(TotalNumberOfQuotes);
         return Ok(TotalNumberOfQuotes);
      }

        //Action that gives the list of Leads created in the last 30 days and are not customers
        // GET: api/quotes/quotesnotyetcustomer
        [HttpGet("quotesnotyetcustomer")]
        public List<quotes> Getnotcustomerquotes(long id)
        {
            
            var leadNotBeingCustomer = (from quote in _context.quotes
                        where  !(from cust in _context.customers
                        select cust.quote_id).Contains(quote.Id) 
                        select quote).Distinct().ToList();                                    
                           
           return leadNotBeingCustomer;
        }

    }
}