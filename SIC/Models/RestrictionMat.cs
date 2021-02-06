using System.Collections.Generic;

namespace SIC.Models
{
    public class RestrictionMat : Restriction
    {
        public int containedMaterial { get; set; }
        public int containingMaterial { get; set; }

        public bool algorithm(int matFatherId, int matSonId)
        {
            List<int> containingProductMaterialsIds = new List<int>();

            foreach (Material m in aggregation.containingProduct.materials)
            {
                containingProductMaterialsIds.Add(m.MaterialId);
            }

            List<int> containedProductMaterialsIds = new List<int>();

            foreach (Material m in aggregation.containedProduct.materials)
            {
                containedProductMaterialsIds.Add(m.MaterialId);
            }

            if (containingProductMaterialsIds.Contains(matFatherId) && containedProductMaterialsIds.Contains(matSonId))
            {
                containingMaterial = matFatherId;
                containedMaterial = matSonId;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}