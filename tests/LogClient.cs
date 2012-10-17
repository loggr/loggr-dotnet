using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Loggr;

namespace tests
{
    [TestClass]
    public class LogClient
    {
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void LogClient_PostNoText()
        {
            Loggr.LogClient client = new Loggr.LogClient();
            client.Post(new Event());
        }

        [TestMethod]
        public void LogClient_Post()
        {
            TestLogClient client = new TestLogClient();
            Event ev = new Event();
            ev.Text = "foo";
            client.Post(ev);
            client.AssertPostWasValid();
            Assert.IsTrue(client.HttpClient.Data["text"] == ev.Text);
        }

    }
}
