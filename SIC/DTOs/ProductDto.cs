using SIC.Models;
using System.Collections.Generic;

namespace SIC.DTOs
{
    public class ProductDto
    {
        public int productsId { get; set; }

        public string name { get; set; }

        public List<DimensionsDto> dimensions { get; set; }

        public List<MaterialDto> materials { get; set; }

        public CategoryDto cat { get; set; }

        public ProductDto()
        {
        }

        public ProductDto(Product product)
        {
            this.productsId = product.ProductId;
            this.name = product.name;
            this.cat = new CategoryDto(product.cat);
            this.dimensions = new List<DimensionsDto>();
            this.materials = new List<MaterialDto>();
            foreach (Dimensions dim in product.dimensions)
            {
                this.dimensions.Add(new DimensionsDto(dim));
            }
            foreach (Material mat in product.materials)
            {
                this.materials.Add(new MaterialDto(mat));
            }
        }

        public Product toProduct()
        {
            return null; //
        }
    }
}