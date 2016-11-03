using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedShippingDomainsObjects.Entities;
using SharedShippingDomainsObjects.ValueObjects;
using SpotCharterDomain.Events;

namespace DomainObjectsTests
{
    [TestClass]
    public class SpotCharterAggregateTests
    {


        [TestMethod]
        public void CreateAggregateFromEventStream()
        {
            var spotId = new SpotCharterId(Guid.NewGuid());
            var counterparty = new Counterparty(new CounterpartyId(Guid.NewGuid()), "VITOL");
            var counterparty1 = new Counterparty(new CounterpartyId(Guid.NewGuid()), "FRATELLI SERPENTI");
            var vessel = new Vessel(new VesselId(Guid.NewGuid()), "99999999", "Santa maria");

            var laycan = new DateRange(DateTime.Now.AddDays(3).Date, DateTime.Now.Date);
            var demurrageRate = new DemurrageRate(0, 0, 72, new CostAmount(new Currency("USD", "US DOLLAR", "$"), 25000), SharedShippingDomainsObjects.Enums.DemurrageRateTimeUnit.Day);

            var spot = new SpotCharterDomain.SpotCharter(new SpotCharterCreated(Guid.NewGuid(), 1, spotId, DateTime.Now, counterparty, vessel, new CargoQuantity("MT", 85000)));

            spot.UpdateLaycan(laycan.From, laycan.To);
            spot.UpdateDemurrageRate(demurrageRate.LoadHoursLaytime, demurrageRate.DischargeHoursLaytime, demurrageRate.TotalHoursLaytime, demurrageRate.Price, demurrageRate.TimeUnit);

            spot.ChangeCharterparty(counterparty1);

            Assert.AreEqual(spot.DemurrageRate, demurrageRate);
            Assert.AreEqual(spot.VesselName, vessel.Name);
            Assert.AreEqual(spot.Laycan, laycan);

        }

    }
}
