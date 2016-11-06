using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedShippingDomainsObjects.ValueObjects;
namespace DomainObjectsTests
{
    using converter = Newtonsoft.Json.JsonConvert;

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

            Assert.AreNotEqual(spotId, null);

            Assert.IsFalse(Object.ReferenceEquals(spotId, spotId1));
            Assert.AreEqual(spotId, spotId1);

            var spotId2 = new SpotCharterId(Guid.NewGuid());

            Assert.AreNotEqual(spotId, spotId2);

        }

        [TestMethod]
        public void SerializeDeserializeCharterpartyChanged()
        {
            var evt = new SpotCharterDomain.Events.CharterpartyChanged(Guid.NewGuid(), 1, new SpotCharterId(Guid.NewGuid()), new CounterpartyId(Guid.NewGuid()), "CHARTERPARTY");
            Type type = evt.GetType();
            var settings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                ContractResolver = new JsonNet.PrivateSettersContractResolvers.PrivateSetterContractResolver()
            };
            string jsonString = converter.SerializeObject(evt, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings() { TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto });
            var evt1 = converter.DeserializeObject(jsonString, type, settings);

            var cpevt = (SpotCharterDomain.Events.CharterpartyChanged)evt1;

            Assert.AreEqual(evt, evt1);
            Assert.AreEqual(evt.CharterpartyId, cpevt.CharterpartyId);
        }


        [TestMethod]
        public void DeserializeFromString()
        {
            var jsonString =
@"{
  ""CurrentName"": ""CHARTERPARTY"",
  ""CharterpartyId"": {
    ""Value"": ""a69f3cf3-422b-49bf-bfb0-bf008fae3543""
  },
  ""SouceId"": {
    ""Value"": ""abe39500-d56c-4347-aae5-f501cd5b0982""
  },
  ""EventId"": ""3324e369-38d5-410b-aaa1-18607d97c41e"",
  ""Version"": 1,
  ""Source"": null
}
";

            var settings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                ContractResolver = new JsonNet.PrivateSettersContractResolvers.PrivateSetterContractResolver()
            };

            Type type = typeof(SpotCharterDomain.Events.CharterpartyChanged);
            SpotCharterDomain.Events.CharterpartyChanged evt1 = (SpotCharterDomain.Events.CharterpartyChanged)converter.DeserializeObject(jsonString, type, settings);

            Assert.IsNotNull(evt1.CurrentName);

        }
    }
}
