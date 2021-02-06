using System.Collections.Generic;

namespace SIC.Models
{
    public class Material
    {
        public Material()
        {
        }

        public Material(string name, List<Finish> finish)
        {
            this.name = name;
            this.finish = finish;
        }

        public int MaterialId { get; set; }

        // [ForeignKey("FinishId")]
        public virtual List<Finish> finish { get; set; }

        public string name { get; set; }
    }
}