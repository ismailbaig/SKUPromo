using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SKUPromotions.Tests
{
    [TestClass]
    public class SKUPromoCalcTest
    {

        private readonly SKUPromotion.Library.SKUPromotions _sut_skuPromos;

        public SKUPromoCalcTest()
        {
            _sut_skuPromos = new SKUPromotion.Library.SKUPromotions();
        }

        [TestMethod]
        public void DummyTestToCheckIfRefactorWorked()
        {
            //Arrange
            double AItems = 1, BItems = 1, CItems = 1, DItems = 1, expected = 4, actual = 0;

            //Act
            actual = _sut_skuPromos.Add(AItems, BItems, CItems, DItems);

            //Assert            
            Assert.AreEqual(expected, actual);
        }
    }
}
