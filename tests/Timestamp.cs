using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Loggr;

namespace tests
{
    [TestClass]
    public class Timestamp
    {
        [TestMethod]
        public void Timestamp_Base()
        {
            var e = Events.Create().Timestamp(DateTime.Today).Event;
            Assert.IsTrue(e.Timestamp.HasValue);
            Assert.AreEqual(DateTime.Today.ToUniversalTime(), e.Timestamp);
        }

        [TestMethod]
        public void Timestamp_UTC_Base()
        {
            var e = Events.Create().Timestamp(DateTime.Today, true).Event;
            Assert.IsTrue(e.Timestamp.HasValue);
            Assert.AreEqual(DateTime.Today.ToUniversalTime(), e.Timestamp);
        }

        [TestMethod]
        public void Timestamp_NonUTC_Base()
        {
            var e = Events.Create().Timestamp(DateTime.Today, false).Event;
            Assert.IsTrue(e.Timestamp.HasValue);
            Assert.AreEqual(DateTime.Today, e.Timestamp);
        }

        [TestMethod]
        public void Timestamp_Clear()
        {
            var e = Events.Create().TimestampClear().Event;
            Assert.IsFalse(e.Timestamp.HasValue);
        }
    }
}
