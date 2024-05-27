using BettingApp.Data;
using BettingApp.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BettingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawController : ControllerBase
    {
        private readonly BettingContext _context;

        public DrawController(BettingContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Draw()
        {
            var pots = await _context.Pots.Find(_ => true).ToListAsync();
            var drawResult = new List<Club>();

            foreach (var pot in pots.OrderBy(p => p.Number))
            {
                drawResult.AddRange(pot.Clubs.OrderBy(_ => Guid.NewGuid()).ToList());
            }

            return Ok(drawResult);
        }
    }
}
