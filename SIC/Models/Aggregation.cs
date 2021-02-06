using System;

namespace SIC.Models
{
    public class Aggregation
    {
        public Aggregation()
        {
        }

        public Aggregation(Product containingProduct, Product containedProduct)
        {
            if (!fit(containingProduct, containedProduct))
            {
                throw new ArgumentException();
            }
            this.containedProduct = containedProduct;
            this.containingProduct = containingProduct;
        }

        public int AggregationId { get; set; }

        public bool mandatory { get; set; }

        public virtual Product containedProduct { get; set; }

        public virtual Product containingProduct { get; set; }

        public Boolean fit(Product containingProduct, Product containedProduct)
        {
            foreach (Dimensions dim in containingProduct.dimensions)
            {
                foreach (Dimensions dim1 in containedProduct.dimensions)
                {
                    if (dim1.depth < dim.depth && dim1.height < dim.height && dim1.width < dim.width)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}