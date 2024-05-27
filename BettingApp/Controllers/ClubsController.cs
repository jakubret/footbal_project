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
    public class ClubsController : ControllerBase
    {
        private readonly BettingContext _context;

        public ClubsController(BettingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetClubs()
        {
            var clubs = await _context.Clubs.Find(_ => true).ToListAsync();
            return Ok(clubs);
        }

        [HttpGet("{id:length(24)}", Name = "GetClub")]
        public async Task<ActionResult<Club>> GetClub(string id)
        {
            var club = await _context.Clubs.Find<Club>(c => c.Id == id).FirstOrDefaultAsync();

            if (club == null)
            {
                return NotFound();
            }

            return Ok(club);
        }

        [HttpPost]
        public async Task<ActionResult<Club>> PostClub(Club club)
        {
            await _context.Clubs.InsertOneAsync(club);
            return CreatedAtRoute("GetClub", new { id = club.Id }, club);
        }
    }
}
