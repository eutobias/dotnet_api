using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientesApi.Data;
using ClientesApi.Models;

namespace ClientesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly ClientesApiContext _context;

        public EnderecosController(ClientesApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enderecos>>> GetEnderecos()
        {
            return await _context.Enderecos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Enderecos>> GetEnderecos(int id)
        {
            var enderecos = await _context.Enderecos.FindAsync(id);

            if (enderecos == null)
            {
                return NotFound();
            }

            return enderecos;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnderecos(int id, Enderecos enderecos)
        {
            if (id != enderecos.Id)
            {
                return BadRequest();
            }

            _context.Entry(enderecos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecosExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Enderecos>> PostEnderecos(Enderecos enderecos)
        {
            _context.Enderecos.Add(enderecos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnderecos", new { id = enderecos.Id }, enderecos);
        }

        // DELETE: api/Enderecos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Enderecos>> DeleteEnderecos(int id)
        {
            var enderecos = await _context.Enderecos.FindAsync(id);
            if (enderecos == null)
            {
                return NotFound();
            }

            _context.Enderecos.Remove(enderecos);
            await _context.SaveChangesAsync();

            return enderecos;
        }

        private bool EnderecosExists(int id)
        {
            return _context.Enderecos.Any(e => e.Id == id);
        }
    }
}
