using System.Collections.Generic;

namespace SIC.Models
{
    public class Catalog
    {
        public Catalog()
        {
        }

        public Catalog(List<Product> products)
        {
            this.products = products;
        }

        public int CatalogId { get; set; }

        public virtual List<Product> products { get; set; }
    }
}