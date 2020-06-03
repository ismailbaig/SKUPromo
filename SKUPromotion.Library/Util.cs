using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKUPromotion.Library
{
    public static class Util
    {
       static double totalPromtionItems = 0, totalNonPromoItems = 0;

        public static double CalculatePromoPriceForSingleItem(double totalUnits, int unitForPromoItems, int PromoPrice, int nonPromoPrice)
        {
            try
            {
                totalPromtionItems = Math.Floor(totalUnits / unitForPromoItems);
                totalNonPromoItems = totalUnits % unitForPromoItems;

                return totalPromtionItems * PromoPrice + totalNonPromoItems * nonPromoPrice;
            }
            catch
            {
                throw;
            }
        }

    }
}
