using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpotCharterEventSourcedRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharedShippingDomainsObjects.ValueObjects;
using SpotCharterDomain;

namespace SpotCharterEventSourcedRepository.Tests
{
    [TestClass()]
    public class SpotCharterEventSourcedRepositoryTests
    {

        SpotCharterId spotId = new SpotCharterId(Guid.NewGuid());

        CounterpartyId cpId1 = new CounterpartyId(Guid.NewGuid());
        CounterpartyId cpId2 = new CounterpartyId(Guid.NewGuid());

        string counterparty1 = "VITOL";
        string counterparty2 = "FRATELLI SERPENTI";

        VesselId vesselId = new VesselId(Guid.NewGuid());
        string vesselName = "Santa maria";

        CargoQuantity minimumQuantityStart = new CargoQuantity("MT", 85000);

        DateRange laycan = new DateRange(DateTime.Now.AddDays(3).Date, DateTime.Now.Date);
        DemurrageRate demurrageRate = new DemurrageRate(0, 0, 72, new CostAmount(new Currency("USD", "US DOLLAR", "$"), 25000), SharedShippingDomainsObjects.Enums.DemurrageRateTimeUnit.Day);

        private SpotCharterDomain.SpotCharter GetSpotCharter()
        {
            var spot = new SpotCharterDomain.SpotCharter(DateTime.Now, cpId1, counterparty1, vesselId, vesselName, minimumQuantityStart);

            spot.ChangeLaycan(laycan.From, laycan.To);
            spot.ChangeDemurrageRate(demurrageRate.LoadHoursLaytime, demurrageRate.DischargeHoursLaytime, demurrageRate.TotalHoursLaytime, demurrageRate.Price, demurrageRate.TimeUnit);

            spot.ChangeCharterparty(cpId2, counterparty2);

            return spot;

        }



        [TestMethod()]
        public void CreateAndRetrieve()
        {
            var spot = GetSpotCharter();
            ISpotCharterRepository repository = new SpotCharterEventSourcedRepository
                ("SpotCharters", "spot_user", "spot_user", "spot_events", host: "sql-db");

            repository.Save(spot);

            var spot1 = repository.Get(spot.Id);

            Assert.IsNotNull(spot1);
            Assert.AreEqual(spot.Id, spot1.Id);
            Assert.AreEqual(spot.CharterpartyId, spot1.CharterpartyId);
            Assert.AreEqual(spot.CharterpartyName, spot1.CharterpartyName);
            Assert.AreEqual(spot.VesselId, spot1.VesselId);
            Assert.AreEqual(spot.VesselName, spot1.VesselName);
            Assert.AreNotEqual(spot.Version, spot1.Version);

            Assert.AreEqual(spot.Version, 0);
            Assert.AreNotEqual(spot1.Version, 4);

        }
    }
}