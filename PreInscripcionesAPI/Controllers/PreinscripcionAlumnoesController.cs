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
    public class PreinscripcionAlumnoesController : ControllerBase
    {
        private readonly ApppreinscripcionContext _context;

        public PreinscripcionAlumnoesController(ApppreinscripcionContext context)
        {
            _context = context;
        }

        // GET: api/PreinscripcionAlumnoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreinscripcionAlumno>>> GetPreinscripcionAlumnos()
        {
            return await _context.PreinscripcionAlumnos.ToListAsync();
        }

        // GET: api/PreinscripcionAlumnoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreinscripcionAlumno>> GetPreinscripcionAlumno(string id)
        {
            var preinscripcionAlumno = await _context.PreinscripcionAlumnos.FindAsync(id);

            if (preinscripcionAlumno == null)
            {
                return NotFound();
            }

            return preinscripcionAlumno;
        }

        // PUT: api/PreinscripcionAlumnoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreinscripcionAlumno(string id, PreinscripcionAlumno preinscripcionAlumno)
        {
            if (id != preinscripcionAlumno.Id)
            {
                return BadRequest();
            }

            _context.Entry(preinscripcionAlumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreinscripcionAlumnoExists(id))
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

        // POST: api/PreinscripcionAlumnoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PreinscripcionAlumno>> PostPreinscripcionAlumno(PreinscripcionAlumno preinscripcionAlumno)
        {
            _context.PreinscripcionAlumnos.Add(preinscripcionAlumno);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PreinscripcionAlumnoExists(preinscripcionAlumno.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPreinscripcionAlumno", new { id = preinscripcionAlumno.Id }, preinscripcionAlumno);
        }

        // DELETE: api/PreinscripcionAlumnoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreinscripcionAlumno(string id)
        {
            var preinscripcionAlumno = await _context.PreinscripcionAlumnos.FindAsync(id);
            if (preinscripcionAlumno == null)
            {
                return NotFound();
            }

            _context.PreinscripcionAlumnos.Remove(preinscripcionAlumno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreinscripcionAlumnoExists(string id)
        {
            return _context.PreinscripcionAlumnos.Any(e => e.Id == id);
        }
    }
}
