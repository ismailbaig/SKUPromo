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
        public void NoPromoIncludedTest()
        {
            //Arrange
            double AItems = 1, BItems = 1, CItems = 1, DItems = 0, expected = 100, actual = 0;

            //Act
            actual = _sut_skuPromos.CalculateTotalSKUPromotionAmount(AItems, BItems, CItems, DItems);

            //Assert            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoPromoFailIncludedTest()
        {
            //Arrange
            double AItems = 1, BItems = 1, CItems = 1, DItems = 0, expected = 110, actual = 0;

            //Act
            actual = _sut_skuPromos.CalculateTotalSKUPromotionAmount(AItems, BItems, CItems, DItems);

            //Assert            
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void OnlyAPromoTest()
        {
            //Arrange
            double AItems = 3, BItems = 1, CItems = 1, DItems = 0, expected = 180, actual = 0;

            //Act
            actual = _sut_skuPromos.CalculateTotalSKUPromotionAmount(AItems, BItems, CItems, DItems);

            //Assert            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OnlyAPromoFailTest()
        {
            //Arrange
            double AItems = 3, BItems = 1, CItems = 1, DItems = 0, expected = 200, actual = 0;

            //Act
            actual = _sut_skuPromos.CalculateTotalSKUPromotionAmount(AItems, BItems, CItems, DItems);

            //Assert            
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void OnlyBPromoTest()
        {
            //Arrange
            double AItems = 2, BItems = 2, CItems = 1, DItems = 0, expected = 165, actual = 0;

            //Act
            actual = _sut_skuPromos.CalculateTotalSKUPromotionAmount(AItems, BItems, CItems, DItems);

            //Assert            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OnlyBPromoFailTest()
        {
            //Arrange
            double AItems = 2, BItems = 2, CItems = 1, DItems = 0, expected = 190, actual = 0;

            //Act
            actual = _sut_skuPromos.CalculateTotalSKUPromotionAmount(AItems, BItems, CItems, DItems);

            //Assert            
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void OnlyCnDPromoPassTest()
        {
            //Arrange
            double AItems = 1, BItems = 1, CItems = 1, DItems = 1, expected = 110, actual = 0;

            //Act
            actual = _sut_skuPromos.CalculateTotalSKUPromotionAmount(AItems, BItems, CItems, DItems);

            //Assert            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OnlyCnDPromoFailTest()
        {
            //Arrange
            double AItems = 1, BItems = 1, CItems = 1, DItems = 1, expected = 200, actual = 0;

            //Act
            actual = _sut_skuPromos.CalculateTotalSKUPromotionAmount(AItems, BItems, CItems, DItems);

            //Assert            
            Assert.AreNotEqual(expected, actual);
        }

    }
}
