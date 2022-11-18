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
    public class JornadumsController : ControllerBase
    {
        private readonly ApppreinscripcionContext _context;

        public JornadumsController(ApppreinscripcionContext context)
        {
            _context = context;
        }

        // GET: api/Jornadums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jornadum>>> GetJornada()
        {
            return await _context.Jornada.ToListAsync();
        }

        // GET: api/Jornadums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jornadum>> GetJornadum(int id)
        {
            var jornadum = await _context.Jornada.FindAsync(id);

            if (jornadum == null)
            {
                return NotFound();
            }

            return jornadum;
        }

        // PUT: api/Jornadums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJornadum(int id, Jornadum jornadum)
        {
            if (id != jornadum.IdJornada)
            {
                return BadRequest();
            }

            _context.Entry(jornadum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JornadumExists(id))
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

        // POST: api/Jornadums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jornadum>> PostJornadum(Jornadum jornadum)
        {
            _context.Jornada.Add(jornadum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJornadum", new { id = jornadum.IdJornada }, jornadum);
        }

        // DELETE: api/Jornadums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJornadum(int id)
        {
            var jornadum = await _context.Jornada.FindAsync(id);
            if (jornadum == null)
            {
                return NotFound();
            }

            _context.Jornada.Remove(jornadum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JornadumExists(int id)
        {
            return _context.Jornada.Any(e => e.IdJornada == id);
        }
    }
}
