namespace SIC.Models
{
    public class Dimensions
    {
        public Dimensions()
        {
        }

        public Dimensions(double depth, double width, double height, double? maxDepth, double? maxWidth, double? maxHeight)
        {
            this.depth = depth;
            this.width = width;
            this.height = height;
            this.maxDepth = maxDepth;
            this.maxWidth = maxWidth;
            this.maxHeight = maxHeight;
        }

        public int DimensionsId { get; set; }

        public double depth { get; set; } // X

        public double width { get; set; } // Y

        public double height { get; set; } // Z

        public double? maxDepth { get; set; } // max X

        public double? maxWidth { get; set; } // max Y

        public double? maxHeight { get; set; } // max Z
    }
}