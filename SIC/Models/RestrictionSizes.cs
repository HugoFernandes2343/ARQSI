using System.Collections.Generic;

namespace SIC.Models
{
    public class RestrictionSizes : Restriction
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public bool algorithm(float vx, float vy, float vz)
        {
            this.x = vx / 100;
            this.y = vy / 100;
            this.z = vz / 100;

            Product father = aggregation.containingProduct;
            Product son = aggregation.containedProduct;

            List<Dimensions> dimsF = new List<Dimensions>();
            List<Dimensions> dimsS = new List<Dimensions>();

            foreach (Dimensions d in father.dimensions)
            {
                foreach (Dimensions d2 in son.dimensions)
                {
                    // enters the if under the condition that only one of the two dimensions objects is variant between intrevals
                    if ((d.maxDepth == null && d.maxWidth == null && d.maxHeight == null) ^ (d2.maxDepth == null && d2.maxWidth == null && d2.maxHeight == null))
                    {
                        if (d.maxDepth == null)
                        {
                            // compares the depth percentage
                            if (d.depth * x > d2.depth)
                            {
                                // compares the width percentage
                                if (d.width * y > d2.width)
                                {
                                    // compares the height percentage
                                    if (d.height * z > d2.height)
                                    {
                                        dimsF.Add(d);
                                        dimsS.Add(d2);
                                    }
                                }
                            }
                        }

                        if (d2.maxDepth == null)
                        {
                            // compares the depth percentage
                            if (d.maxDepth * x > d2.depth)
                            {
                                // compares the width percentage
                                if (d.maxWidth * y > d2.width)
                                {
                                    // compares the height percentage
                                    if (d.maxHeight * z > d2.height)
                                    {
                                        dimsF.Add(d);
                                        dimsS.Add(d2);
                                    }
                                }
                            }
                        }
                    }

                    // enters the if under the condition that both are variable
                    if ((d.maxDepth != null && d.maxWidth != null && d.maxHeight != null) && ((d2.maxDepth != null && d2.maxWidth != null && d2.maxHeight != null)))
                    {
                        // compares the depth percentage
                        if (d.maxDepth * x > d2.depth)
                        {
                            // compares the width percentage
                            if (d.maxWidth * y > d2.width)
                            {
                                // compares the height percentage
                                if (d.maxHeight * z > d2.height)
                                {
                                    dimsF.Add(d);
                                    dimsS.Add(d2);
                                }
                            }
                        }
                    }

                    // enters the if under the condition that both are set
                    if ((d.maxDepth == null && d.maxWidth == null && d.maxHeight == null) && ((d2.maxDepth == null && d2.maxWidth == null && d2.maxHeight == null)))
                    {
                        // compares the depth percentage
                        if (d.depth * x > d2.depth)
                        {
                            // compares the width percentage
                            if (d.width * y > d2.width)
                            {
                                // compares the height percentage
                                if (d.height * z > d2.height)
                                {
                                    dimsF.Add(d);
                                    dimsS.Add(d2);
                                }
                            }
                        }
                    }
                }
            }

            if (dimsF.Count > 0 && dimsS.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}