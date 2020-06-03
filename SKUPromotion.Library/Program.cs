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
    }

    public class SKUPromotions
    {
        double _totalAmount = 0;
        public double CalculateTotalSKUPromotionAmount(double ATotalUnits, double BTotalUnits, double CTotalUnits, double DTotalUnits)
        {
            try
            {
                _totalAmount += ATotalUnits / 3 > 0 ? ATotalUnits * (int)SKUUnitPrices.ANonPromoPrice : 0;
                _totalAmount += BTotalUnits / 2 > 0 ? ATotalUnits * (int)SKUUnitPrices.BNonPromoPrice : 0;
                
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
