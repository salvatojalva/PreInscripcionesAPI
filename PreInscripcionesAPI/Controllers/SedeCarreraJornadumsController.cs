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
    public class SedeCarreraJornadumsController : ControllerBase
    {
        private readonly ApppreinscripcionContext _context;

        public SedeCarreraJornadumsController(ApppreinscripcionContext context)
        {
            _context = context;
        }

        // GET: api/SedeCarreraJornadums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SedeCarreraJornadum>>> GetSedeCarreraJornada()
        {
            return await _context.SedeCarreraJornada.ToListAsync();
        }

        // GET: api/SedeCarreraJornadums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SedeCarreraJornadum>> GetSedeCarreraJornadum(int id)
        {
            var sedeCarreraJornadum = await _context.SedeCarreraJornada.FindAsync(id);

            if (sedeCarreraJornadum == null)
            {
                return NotFound();
            }

            return sedeCarreraJornadum;
        }

        // PUT: api/SedeCarreraJornadums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSedeCarreraJornadum(int id, SedeCarreraJornadum sedeCarreraJornadum)
        {
            if (id != sedeCarreraJornadum.IdSedeCarreraJornada)
            {
                return BadRequest();
            }

            _context.Entry(sedeCarreraJornadum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SedeCarreraJornadumExists(id))
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

        // POST: api/SedeCarreraJornadums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SedeCarreraJornadum>> PostSedeCarreraJornadum(SedeCarreraJornadum sedeCarreraJornadum)
        {
            _context.SedeCarreraJornada.Add(sedeCarreraJornadum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSedeCarreraJornadum", new { id = sedeCarreraJornadum.IdSedeCarreraJornada }, sedeCarreraJornadum);
        }

        // DELETE: api/SedeCarreraJornadums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSedeCarreraJornadum(int id)
        {
            var sedeCarreraJornadum = await _context.SedeCarreraJornada.FindAsync(id);
            if (sedeCarreraJornadum == null)
            {
                return NotFound();
            }

            _context.SedeCarreraJornada.Remove(sedeCarreraJornadum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SedeCarreraJornadumExists(int id)
        {
            return _context.SedeCarreraJornada.Any(e => e.IdSedeCarreraJornada == id);
        }
    }
}
