using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedShippingDomainsObjects.ValueObjects;
namespace DomainObjectsTests
{
    [TestClass]
    public class ValueObjectTests
    {

        [TestMethod]
        public void TestCargoQuantityEquality()
        {
            var qty1 = new CargoQuantity("MT", 10000);
            var qty2 = new CargoQuantity("MT", 10000);
            var qty3 = new CargoQuantity("M3", 10000);
            var qty4 = new CargoQuantity("MT", 10001);

            Assert.AreEqual(qty1, qty2);
            Assert.AreNotEqual(qty1, qty3);
            Assert.AreNotEqual(qty2, qty4);

        }


        [TestMethod]
        public void TestSpotCharterIdEquality()
        {
            var spotId = new SpotCharterId(Guid.NewGuid());
            var spotId1 = new SpotCharterId(spotId.Value);

            Assert.AreEqual(spotId, spotId1);
        }

    }
}
