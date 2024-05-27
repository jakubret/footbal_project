using BettingApp.Data;
using BettingApp.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BettingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PotsController : ControllerBase
    {
        private readonly BettingContext _context;

        public PotsController(BettingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pot>>> GetPots()
        {
            var pots = await _context.Pots.Find(_ => true).ToListAsync();
            return Ok(pots);
        }

        [HttpPost]
        public async Task<ActionResult<Pot>> PostPot(Pot pot)
        {
            await _context.Pots.InsertOneAsync(pot);
            return CreatedAtAction("GetPot", new { id = pot.Id }, pot);
        }
    }
}
