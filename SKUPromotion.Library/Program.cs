using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKUPromotion.Library
{
    enum SKUUnitPrices : int
    {
        A_SKU_Non_Promo_Price = 50,
        B_SKU_Non_Promo_Price = 30,
        C_SKU_Non_Promo_Price = 20,
        D_SKU_Non_Promo_Price = 15,
        A_SKUs_To_Promo = 3,
        B_SKUs_To_Promo = 2,
        A_SKU_Promo_Price = 130,
        B_SKU_Promo_Price = 45,
        CnD_SKU_Promo_Pirce = 30,
    }

    public class SKUPromotions
    {
        double _totalAmount = 0;
		
        public double CalculateTotalSKUPromotionAmount(double ATotalUnits, double BTotalUnits, double CTotalUnits, double DTotalUnits)
        {
            try
            {

                #region A Promotion
                _totalAmount += Util.CalculatePromoPriceForSingleItem(ATotalUnits, (int)SKUUnitPrices.A_SKUs_To_Promo, (int)SKUUnitPrices.A_SKU_Promo_Price, (int)SKUUnitPrices.A_SKU_Non_Promo_Price);
                #endregion

                #region B Promotion 
                _totalAmount += Util.CalculatePromoPriceForSingleItem(BTotalUnits, (int)SKUUnitPrices.B_SKUs_To_Promo, (int)SKUUnitPrices.B_SKU_Promo_Price, (int)SKUUnitPrices.B_SKU_Non_Promo_Price);
                #endregion

                #region C n D Promotion
                _totalAmount += Math.Min(CTotalUnits, DTotalUnits) * (int)SKUUnitPrices.CnD_SKU_Promo_Pirce;
                #endregion

                #region C n D Left out Logic
                _totalAmount += (CTotalUnits - DTotalUnits) > 0 ? Math.Abs(CTotalUnits - DTotalUnits) * (int)(SKUUnitPrices.C_SKU_Non_Promo_Price) :
                                                                    Math.Abs(CTotalUnits - DTotalUnits) * (int)(SKUUnitPrices.D_SKU_Non_Promo_Price);
                #endregion

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
