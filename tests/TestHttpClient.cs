using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

using Loggr;

namespace tests
{
    class TestHttpClient : IHttpClient
    {
        public Uri Uri { get; private set; }
        public NameValueCollection Data { get; private set; }

        public byte[] PostData(string url, string data)
        {
            Uri = new Uri(url);
            Data = HttpUtility.ParseQueryString(data);
            return new byte[] { };
        }
    }
}
