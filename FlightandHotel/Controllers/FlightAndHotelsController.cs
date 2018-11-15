using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightandHotel.Models;

namespace FlightandHotel.Controllers
{
    [Produces("application/json")]
    [Route("api/FlightAndHotels")]
    public class FlightAndHotelsController : Controller
    {
        private readonly FlightAndHotelContext _context;

        public FlightAndHotelsController(FlightAndHotelContext context)
        {
            _context = context;
        }

        // GET: api/FlightAndHotels
        [HttpGet]
        public IEnumerable<FlightAndHotel> GetFlightAndHotel()
        {
            return _context.FlightAndHotel;
        }

        // GET: api/FlightAndHotels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightAndHotel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flightAndHotel = await _context.FlightAndHotel.SingleOrDefaultAsync(m => m.ID == id);

            if (flightAndHotel == null)
            {
                return NotFound();
            }

            return Ok(flightAndHotel);
        }

        // PUT: api/FlightAndHotels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightAndHotel([FromRoute] int id, [FromBody] FlightAndHotel flightAndHotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flightAndHotel.ID)
            {
                return BadRequest();
            }

            _context.Entry(flightAndHotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightAndHotelExists(id))
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

        // POST: api/FlightAndHotels
        [HttpPost]
        public async Task<IActionResult> PostFlightAndHotel([FromBody] FlightAndHotel flightAndHotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FlightAndHotel.Add(flightAndHotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightAndHotel", new { id = flightAndHotel.ID }, flightAndHotel);
        }

        // DELETE: api/FlightAndHotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightAndHotel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flightAndHotel = await _context.FlightAndHotel.SingleOrDefaultAsync(m => m.ID == id);
            if (flightAndHotel == null)
            {
                return NotFound();
            }

            _context.FlightAndHotel.Remove(flightAndHotel);
            await _context.SaveChangesAsync();

            return Ok(flightAndHotel);
        }

        private bool FlightAndHotelExists(int id)
        {
            return _context.FlightAndHotel.Any(e => e.ID == id);
        }
    }
}