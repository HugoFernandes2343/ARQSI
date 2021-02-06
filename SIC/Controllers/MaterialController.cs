using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIC.DTOs;
using SIC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIC.Controllers
{
    [Route("api/Material")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly SICContext _context;

        public MaterialController(SICContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Material> GetMaterial()
        {
            return _context.Material;
        }

        // GET: api/Material/5
        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetMaterial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var material = await _context.Material.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return Ok(new MaterialDto(material));
        }

        // PUT: api/Material/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial([FromRoute] int id, [FromBody] MaterialDto materialDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!MaterialExists(id))
            {
                return BadRequest();
            }

            if (MaterialNameExists(materialDto.name))
            {
                if (!_context.Material.Any(e => e.name == materialDto.name && e.MaterialId == id))
                {
                    return BadRequest("A material with that name already exists");
                }
            }

            var material = _context.Material.Find(id);
            List<Finish> fins = material.finish;
            List<Finish> newfins = new List<Finish>();

            foreach (FinishDto finDto in materialDto.finishDto)
            {
                foreach (Finish fin in fins)
                {
                    if (fin.name.Equals(finDto.name))
                    {
                        newfins.Add(fin);
                        break;
                    }
                    else
                    {
                        newfins.Add(new Finish(finDto.name));
                        break;
                    }
                }
            }
            foreach (Finish fin in fins)
            {
                if (!newfins.Contains(fin))
                {
                    _context.Finish.Remove(fin);
                }
            }
            material.name = materialDto.name;
            material.finish = newfins;
            _context.Entry(material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }

        // POST: api/Material
        [HttpPost]
        public async Task<IActionResult> PostMaterial([FromBody] MaterialDto materialDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (MaterialNameExists(materialDto.name))
            {
                return BadRequest("A material already exists with the same name");
            }

            List<Finish> fins = new List<Finish>();

            foreach (FinishDto finDto in materialDto.finishDto)
            {
                Finish fin = new Finish(finDto.name);

                fins.Add(fin);
            }
            Material mat = new Material(materialDto.name, fins);
            _context.Material.Add(mat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial", new { id = mat.MaterialId }, new MaterialDto(mat));
        }

        // DELETE: api/Material/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var material = await _context.Material.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            foreach (Finish fin in material.finish)
            {
                _context.Finish.Remove(fin);
            }

            _context.Material.Remove(material);
            await _context.SaveChangesAsync();

            return Ok(new MaterialDto(material));
        }

        private bool MaterialExists(int id)
        {
            return _context.Material.Any(e => e.MaterialId == id);
        }

        private bool MaterialNameExists(string name)
        {
            return _context.Material.Any(e => e.name == name);
        }
    }
}