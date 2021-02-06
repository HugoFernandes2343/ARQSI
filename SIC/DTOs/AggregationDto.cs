using SIC.Models;

namespace SIC.DTOs
{
    public class AggregationDto
    {
        public int aggregationId { get; set; }

        public string containingProduct { get; set; }

        public string containedProduct { get; set; }

        public bool mandatory { get; set; }

        public AggregationDto(Aggregation aggregation)
        {
            this.containingProduct = aggregation.containingProduct.name;
            this.containedProduct = aggregation.containedProduct.name;
            this.aggregationId = aggregation.AggregationId;
        }

        public AggregationDto()
        {
        }
    }
}