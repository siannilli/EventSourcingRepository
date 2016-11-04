using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using BaseDomainObjects;
using BaseDomainObjects.Events;
using SharedShippingDomainsObjects.Entities;
using SharedShippingDomainsObjects.ValueObjects;
using SpotCharterDomain.Events;

namespace DomainObjectsTests
{
    [TestClass]
    public class SpotCharterAggregateTests
    {

        SpotCharterId spotId = new SpotCharterId(Guid.NewGuid());
        Counterparty counterparty = new Counterparty(new CounterpartyId(Guid.NewGuid()), "VITOL");
        Counterparty  counterparty1 = new Counterparty(new CounterpartyId(Guid.NewGuid()), "FRATELLI SERPENTI");
        Vessel vessel = new Vessel(new VesselId(Guid.NewGuid()), "99999999", "Santa maria");
        CargoQuantity minimumQuantityStart = new CargoQuantity("MT", 85000);

        DateRange laycan = new DateRange(DateTime.Now.AddDays(3).Date, DateTime.Now.Date);
        DemurrageRate demurrageRate = new DemurrageRate(0, 0, 72, new CostAmount(new Currency("USD", "US DOLLAR", "$"), 25000), SharedShippingDomainsObjects.Enums.DemurrageRateTimeUnit.Day);

        [TestMethod]
        public void CreateAggregateFromUpdates()
        {
            var spot = new SpotCharterDomain.SpotCharter(new SpotCharterCreated(Guid.NewGuid(), 1, spotId, DateTime.Now, counterparty.Id, counterparty.Name, vessel.Id, vessel.Name, minimumQuantityStart));

            spot.UpdateLaycan(laycan.From, laycan.To);
            spot.UpdateDemurrageRate(demurrageRate.LoadHoursLaytime, demurrageRate.DischargeHoursLaytime, demurrageRate.TotalHoursLaytime, demurrageRate.Price, demurrageRate.TimeUnit);

            spot.ChangeCharterparty(counterparty1);

            Assert.AreEqual(spot.DemurrageRate, demurrageRate);
            Assert.AreEqual(spot.VesselName, vessel.Name);
            Assert.AreEqual(spot.Laycan, laycan);

            Assert.AreEqual(spot.Version, 0);

        }


        [TestMethod]
        public void CreateAggregateFromEventStream()
        {
            var eventStream = new List<IEvent>()
            {
                new SpotCharterCreated(Guid.NewGuid(), 1, spotId, DateTime.Now, counterparty.Id, counterparty.Name, vessel.Id, vessel.Name, minimumQuantityStart),
                new LaycanChanged(Guid.NewGuid(), 2, spotId, laycan ),
                new DemurrageRateChanged(Guid.NewGuid(), 3, spotId, demurrageRate),
                new CharterpartyChanged(Guid.NewGuid(), 4, spotId, counterparty1.Id, counterparty1.Name),                
            };

            var spot = new SpotCharterDomain.SpotCharter(eventStream);

            Assert.AreEqual(spot.DemurrageRate, demurrageRate);
            Assert.AreEqual(spot.VesselName, vessel.Name);
            Assert.AreEqual(spot.Laycan, laycan);

            Assert.AreEqual(spot.Version, 4);
            

        }

    }
}
