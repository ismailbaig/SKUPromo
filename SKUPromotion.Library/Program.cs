using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKUPromotion.Library
{
    enum SKUUnitPrices : int
    {
        ANonPromoPrice = 50,
        BNonPromoPrice = 30,
        CNonPromoPrice = 20,
        DNonPromoPrice = 15,
        A_SKUs_To_Promo = 3,
        B_SKUs_To_Promo = 2,
        APromoPrice = 130,
        BPromoPrice = 45,
    }

    public class SKUPromotions
    {
        double _totalAmount = 0, totalPromtionItems = 0, totalNonPromoItems = 0;
		
		private double CalculatePromoPriceForSingleItem(double totalUnits, int unitForPromoItems, int PromoPrice, int nonPromoPrice)
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
        public double CalculateTotalSKUPromotionAmount(double ATotalUnits, double BTotalUnits, double CTotalUnits, double DTotalUnits)
        {
            try
            {

                #region A Promotion
                _totalAmount += CalculatePromoPriceForSingleItem(ATotalUnits, (int)SKUUnitPrices.A_SKUs_To_Promo, (int)SKUUnitPrices.APromoPrice, (int)SKUUnitPrices.ANonPromoPrice);
                #endregion

                _totalAmount += BTotalUnits / (int)SKUUnitPrices.B_SKUs_To_Promo > 0 ? ATotalUnits * (int)SKUUnitPrices.BNonPromoPrice : 0;
                
                //Logic for C or D Non Promo Price if left out
                _totalAmount += (CTotalUnits - DTotalUnits) > 0 ? Math.Abs(CTotalUnits - DTotalUnits) * (int)(SKUUnitPrices.CNonPromoPrice) :
                                                                    Math.Abs(CTotalUnits - DTotalUnits) * (int)(SKUUnitPrices.DNonPromoPrice);

                return _totalAmount;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            SKUPromotions sKUPromotions = new SKUPromotions();
            double AItems = 1, BItems = 1, CItems = 1, DItems = 0;

            Console.WriteLine("Total Cost of {0} A SKU's, {1} B SKU's, {2} C SKU's and {3} D SKU's after applying Active Promotion is {4} .",
                                AItems, BItems, CItems, DItems, sKUPromotions.CalculateTotalSKUPromotionAmount(AItems, BItems, CItems, DItems));
            Console.ReadKey();
        }
    }
}
