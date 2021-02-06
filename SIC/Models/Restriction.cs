namespace SIC.Models
{
    public class Restriction
    {
        public int RestrictionId { get; set; }

        public virtual Aggregation aggregation { get; set; }

        public string type { get; set; }
    }
}