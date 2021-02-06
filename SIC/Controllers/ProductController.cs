using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIC.DTOs;
using SIC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIC.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly SICContext _context;

        public ProductController(SICContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> GetProduct()
        {
            return _context.Product;
        }

        // GET: api/Product/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(new ProductDto(product));
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!ProductExists(id))
            {
                return BadRequest();
            }

            if (ProductNameExists(productDto.name))
            {
                if (!_context.Product.Any(e => e.name == productDto.name && e.ProductId == id))
                {
                    return BadRequest("There already is a product with this name");
                }
            }

            string cat = productDto.cat.name.Split(";").Last();
            if (!_context.Category.Any(c => c.name == cat))
            {
                return BadRequest("Category does not exists");
            }
            var category = await _context.Category.SingleOrDefaultAsync(c => c.name == productDto.cat.name.Split().Last());
            var product = await _context.Product.FindAsync(id);

            foreach (Dimensions dim in product.dimensions)
            {
                _context.Dimensions.Remove(dim);
            }

            foreach (Material m in product.materials)
            {
                foreach (Finish fin in m.finish)
                {
                    _context.Finish.Remove(fin);
                }
                _context.Material.Remove(m);
            }

            List<Material> materials = new List<Material>();
            List<Dimensions> dims = new List<Dimensions>();

            foreach (DimensionsDto dimensionsDto in productDto.dimensions)
            {
                dims.Add(dimensionsDto.toDimensions());
            }

            foreach (MaterialDto mDto in productDto.materials)
            {
                materials.Add(mDto.toMaterial());
            }

            product.name = productDto.name;
            product.cat = category;
            product.materials = materials;
            product.dimensions = dims;

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ProductNameExists(productDto.name))
            {
                return BadRequest("There already is a product with this name");
            }

            List<Dimensions> dims = new List<Dimensions>();
            List<Material> mats = new List<Material>();
            foreach (DimensionsDto dim in productDto.dimensions)
            {
                dims.Add(dim.toDimensions());
            }

            foreach (MaterialDto mat in productDto.materials)
            {
                mats.Add(mat.toMaterial());
            }

            string nameCate = productDto.cat.name.Split(";").Last();
            var cate = await _context.Category.SingleOrDefaultAsync(e => e.name == nameCate);
            if (cate == null)
            {
                return BadRequest("Such a category doesnt currently exist");
            }

            Product product = new Product(productDto.name, dims, mats, cate);
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, new ProductDto(product));
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            foreach (Dimensions dimension in product.dimensions)
            {
                _context.Dimensions.Remove(dimension);
            }

            foreach (Material material in product.materials)
            {
                foreach (Finish finish in material.finish)
                {
                    _context.Finish.Remove(finish);
                }
                _context.Material.Remove(material);
            }

            List<Restriction> rest = new List<Restriction>();
            var deleteRestQuery = from r in _context.Restriction where r.aggregation.containingProduct.ProductId == id || r.aggregation.containedProduct.ProductId == id select r;
            rest = deleteRestQuery.ToList();

            foreach (Restriction r in rest)
            {
                _context.Restriction.Remove(r);
            }

            List<Aggregation> aggrs = new List<Aggregation>();
            var deleteAggrsQuery = from a in _context.Aggregation where a.containingProduct.ProductId == id || a.containedProduct.ProductId == id select a;
            aggrs = deleteAggrsQuery.ToList();

            foreach (Aggregation a in aggrs)
            {
                _context.Aggregation.Remove(a);
            }

            Category c = product.cat;

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            product.cat = c;

            return Ok(new ProductDto(product));
        }

        private bool ProductNameExists(string name)
        {
            return _context.Product.Any(e => e.name == name);
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }

        // GET: api/Product/id/Parts
        [HttpGet("{id}/Parts")]
        public async Task<IActionResult> GetParts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Product> result = new List<Product>();
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var query = from e in _context.Aggregation where e.containingProduct.ProductId == product.ProductId select e.containedProduct;
            result = query.ToList();

            List<ProductDto> components = new List<ProductDto>();

            foreach (Product part in result)
            {
                components.Add(new ProductDto(part));
            }

            return Ok(components);
        }

        // GET: api/Product/id/PartOff
        [HttpGet("{id}/PartOff")]
        public async Task<IActionResult> GetPartOff([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Product> result = new List<Product>();
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var query = from e in _context.Aggregation where e.containedProduct.ProductId == product.ProductId select e.containingProduct;
            result = query.ToList();

            List<ProductDto> containers = new List<ProductDto>();

            foreach (Product prod in result)
            {
                containers.Add(new ProductDto(prod));
            }

            return Ok(containers);
        }

        // GET: api/Product/id/Restrictions
        [HttpGet("{id}/Restrictions")]
        public IActionResult GetRestrictions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Restriction> result = new List<Restriction>();
            var query = from e in _context.Restriction where e.aggregation.containingProduct.ProductId == id || e.aggregation.containedProduct.ProductId == id select e;
            result = query.ToList();

            List<RestrictionDto> rests = new List<RestrictionDto>();

            foreach (Restriction r in result)
            {
                if (r is RestrictionSizes)
                {
                    RestrictionSizes rSizes = (RestrictionSizes)r;
                    RestrictionSizesDto sizesDto = new RestrictionSizesDto();

                    sizesDto.aggregation = new AggregationDto(rSizes.aggregation);
                    sizesDto.restrictionId = rSizes.RestrictionId;

                    sizesDto.x = rSizes.x;
                    sizesDto.y = rSizes.y;
                    sizesDto.z = rSizes.z;

                    rests.Add(sizesDto);
                }
                if (r is RestrictionMat)
                {
                    RestrictionMat rMat = (RestrictionMat)r;
                    RestrictionMatDto matDto = new RestrictionMatDto();
                    matDto.aggregation = new AggregationDto(rMat.aggregation);
                    matDto.containingMaterial = rMat.containingMaterial;
                    matDto.containedMaterial = rMat.containedMaterial;
                    rests.Add(matDto);
                }
            }

            return Ok(rests);
        }

        // GET: api/Product/Search/{name}
        [HttpGet("Search/{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Product.SingleOrDefaultAsync(e => e.name == name);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(new ProductDto(product));
        }
    }
}