using SIC.Models;

namespace SIC.DTOs
{
    public class DimensionsDto
    {
        public int dimensionsId { get; set; }

        public double depth { get; set; } // X

        public double width { get; set; } // Y

        public double height { get; set; } // Z

        public double? maxDepth { get; set; } // max X

        public double? maxWidth { get; set; } // max Y

        public double? maxHeight { get; set; } // max Z

        public DimensionsDto()
        {
        }

        public DimensionsDto(Dimensions dimension)
        {
            this.depth = dimension.depth;
            this.height = dimension.height;
            this.width = dimension.width;
            this.maxDepth = dimension.maxDepth;
            this.maxHeight = dimension.maxHeight;
            this.maxWidth = dimension.maxWidth;
        }

        public Dimensions toDimensions()
        {
            return new Dimensions(depth, width, height, maxDepth, maxWidth, maxHeight);
        }
    }
}