using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKUPromotion.Library
{
    public static class Util
    {
       static double _totalAmount = 0, totalPromtionItems = 0, totalNonPromoItems = 0;

        public static double CalculatePromoPriceForSingleItem(double totalUnits, int unitForPromoItems, int PromoPrice, int nonPromoPrice)
        {
            try
            {
                totalPromtionItems = Math.Floor(totalUnits / (int)(unitForPromoItems));
                totalNonPromoItems = totalUnits % (int)(unitForPromoItems);

                return totalPromtionItems * (int)(PromoPrice) + totalNonPromoItems * (int)(nonPromoPrice);
            }
            catch
            {
                throw;
            }
        }

    }
}
