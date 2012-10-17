using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Loggr;

namespace tests
{
    class TestLogClient : Loggr.LogClient
    {
        public const string PostServer = "post.loggr.net";
        public const string PostVersion = "1";
        public const string PostLogKey = "TESTLOGKEY";
        public const string PostApiKey = "TESTAPIKEY";

        public bool WasAsync { get; private set; }

        public TestHttpClient HttpClient { get; private set; }

        public TestLogClient()
            : this(PostLogKey, PostApiKey)
        {
        }

        public TestLogClient(string logKey, string apiKey)
            : base(logKey, apiKey, PostServer, PostVersion, false)
        {
            HttpClient = new TestHttpClient();
            this.SetHttpClient(HttpClient);
        }

        public override void Post(Event eventObj, bool async)
        {
            // remember client choice
            WasAsync = async;

            // testing is easier with non-async
            base.Post(eventObj, false);
        }

        public void AssertPostWasValid()
        {
            Assert.IsTrue(this.HttpClient.Uri.Scheme == (Secure ? "https" : "http"));
            Assert.IsTrue(this.HttpClient.Uri.Host == PostServer);
            Assert.IsTrue(this.HttpClient.Uri.PathAndQuery == string.Format("/{0}/logs/{1}/events", PostVersion, PostLogKey));
            Assert.IsTrue(this.HttpClient.Data.Keys.Count >= 1);
            Assert.IsTrue(this.HttpClient.Data["apikey"] == PostApiKey);
        }
    }
}
