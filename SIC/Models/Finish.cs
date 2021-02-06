namespace SIC.Models
{
    public class Finish
    {
        public Finish()
        {
        }

        public Finish(string name)
        {
            this.name = name;
        }

        public int FinishId { get; set; }

        public string name { get; set; }
    }
}