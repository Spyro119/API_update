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
    public class addressesController : ControllerBase
    {
        private readonly TodoContext _context;

        public addressesController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<addresses>>> Getaddress()
        {
            return await _context.addresses.ToListAsync();
        }

         [HttpGet("city")]
        public async Task<ActionResult<IEnumerable<addresses>>> GetaddressCity()
        {
            var addresses = await _context.addresses.Distinct().ToListAsync();
            addresses = addresses.GroupBy(x => x.city).Select(y=>y.First()).Distinct().ToList();
            return addresses;
        }

    }
}