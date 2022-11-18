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
    public class CarrerasController : ControllerBase
    {
        private readonly ApppreinscripcionContext _context;

        public CarrerasController(ApppreinscripcionContext context)
        {
            _context = context;
        }

        // GET: api/Carreras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrera>>> GetCarreras()
        {
            return await _context.Carreras.ToListAsync();
        }

        // GET: api/Carreras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrera>> GetCarrera(string id)
        {
            var carrera = await _context.Carreras.FindAsync(id);

            if (carrera == null)
            {
                return NotFound();
            }

            return carrera;
        }

        // PUT: api/Carreras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrera(string id, Carrera carrera)
        {
            if (id != carrera.IdCarrera)
            {
                return BadRequest();
            }

            _context.Entry(carrera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarreraExists(id))
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

        // POST: api/Carreras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carrera>> PostCarrera(Carrera carrera)
        {
            _context.Carreras.Add(carrera);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarreraExists(carrera.IdCarrera))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCarrera", new { id = carrera.IdCarrera }, carrera);
        }

        // DELETE: api/Carreras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrera(string id)
        {
            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null)
            {
                return NotFound();
            }

            _context.Carreras.Remove(carrera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarreraExists(string id)
        {
            return _context.Carreras.Any(e => e.IdCarrera == id);
        }
    }
}
