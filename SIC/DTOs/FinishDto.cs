using SIC.Models;

namespace SIC.DTOs
{
    public class FinishDto
    {
        public int finishId { get; set; }
        public string name { get; set; }

        public FinishDto(Finish finish)
        {
            this.finishId = finish.FinishId;
            this.name = finish.name;
        }

        public FinishDto()
        {
        }

        public Finish toFinish()
        {
            Finish fin = new Finish(name);

            return fin;
        }
    }
}