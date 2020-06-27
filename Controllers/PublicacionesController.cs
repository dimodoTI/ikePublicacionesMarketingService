using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IkePublicacionesMarketingService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

namespace IkePublicacionesMarketingService.Controllers
{
    [Route("api/Publicaciones")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {
        private readonly IkePublicacionesMarketingServiceContext _context;

        public PublicacionesController(IkePublicacionesMarketingServiceContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> PutPublicacion(long id, Publicacion publicacion)
        {
            if (id != publicacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(publicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacionExists(id))
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

        // PUT: api/Usuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> PatchPublicacion(int id, [FromBody] JsonPatchDocument<Publicacion> PublicacionPatch)
        {
            Publicacion publicacion = await _context.Publicaciones.FirstOrDefaultAsync(u => u.Id == id);
            if (publicacion == null)
            {
                return NotFound();
            }

            try
            {
                PublicacionPatch.ApplyTo(publicacion);

                _context.Entry(publicacion).State = EntityState.Modified;

                await _context.SaveChangesAsync();


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublicacionExists(id))
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

        // POST: api/Publicaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<Publicacion>> PostPublicacion(Publicacion publicacion)
        {
            _context.Publicaciones.Add(publicacion);
            await _context.SaveChangesAsync();

            //return CreatedAtAction(nameof(GetPublicacion), new { id = publicacion.Id }, publicacion);
            return Ok();
        }

        // DELETE: api/Publicaciones/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Publicacion>> DeletePublicacion(long id)
        {
            var publicacion = await _context.Publicaciones.FindAsync(id);
            if (publicacion == null)
            {
                return NotFound();
            }

            _context.Publicaciones.Remove(publicacion);
            await _context.SaveChangesAsync();

            return publicacion;
        }

        private bool PublicacionExists(long id)
        {
            return _context.Publicaciones.Any(e => e.Id == id);
        }
    }
}
