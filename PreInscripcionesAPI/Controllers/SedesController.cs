using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PreInscripcionesAPI.Models;

namespace PreInscripcionesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedesController : ControllerBase
    {
        private readonly ApppreinscripcionContext _context;

        public SedesController(ApppreinscripcionContext context)
        {
            _context = context;
        }

        // GET: api/Sedes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sede>>> GetSedes()
        {
            return await _context.Sedes.ToListAsync();
        }

        // GET: api/Sedes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sede>> GetSede(string id)
        {
            var sede = await _context.Sedes.FindAsync(id);

            if (sede == null)
            {
                return NotFound();
            }

            return sede;
        }

        // PUT: api/Sedes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSede(string id, Sede sede)
        {
            if (id != sede.IdSede)
            {
                return BadRequest();
            }

            _context.Entry(sede).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SedeExists(id))
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

        // POST: api/Sedes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sede>> PostSede(Sede sede)
        {
            _context.Sedes.Add(sede);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SedeExists(sede.IdSede))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSede", new { id = sede.IdSede }, sede);
        }

        // DELETE: api/Sedes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSede(string id)
        {
            var sede = await _context.Sedes.FindAsync(id);
            if (sede == null)
            {
                return NotFound();
            }

            _context.Sedes.Remove(sede);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SedeExists(string id)
        {
            return _context.Sedes.Any(e => e.IdSede == id);
        }
    }
}
