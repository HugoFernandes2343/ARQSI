using System.Collections.Generic;

namespace SIC.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string name, List<Dimensions> dimensions, List<Material> materials, Category cat)
        {
            this.name = name;
            this.dimensions = dimensions;
            this.materials = materials;
            this.cat = cat;
        }

        public int ProductId { get; set; }

        public string name { get; set; }

        public virtual List<Dimensions> dimensions { get; set; }

        public virtual List<Material> materials { get; set; }

        public virtual Category cat { get; set; }
    }
}