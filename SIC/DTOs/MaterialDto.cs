using SIC.Models;
using System.Collections.Generic;

namespace SIC.DTOs
{
    public class MaterialDto
    {
        public int materialId { get; set; }

        public string name { get; set; }

        public List<FinishDto> finishDto { get; set; }

        public MaterialDto()
        {
        }

        public MaterialDto(Material material)
        {
            this.materialId = material.MaterialId;
            this.name = material.name;
            this.finishDto = new List<FinishDto>();

            foreach (Finish fin in material.finish)
            {
                this.finishDto.Add(new FinishDto(fin));
            }
        }

        public Material toMaterial()
        {
            List<Finish> fins = new List<Finish>();
            foreach (FinishDto fin in this.finishDto)
            {
                fins.Add(fin.toFinish());
            }

            Material mat = new Material(this.name, fins);

            return mat;
        }
    }
}