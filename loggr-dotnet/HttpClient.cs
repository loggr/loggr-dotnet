using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;

namespace Loggr
{
    internal class HttpClient : IHttpClient
    {
        public byte[] PostData(string url, string data)
        {
            NoKeepAliveClient cli = new NoKeepAliveClient();
            cli.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            return cli.UploadData(new Uri(url), "POST", System.Text.Encoding.ASCII.GetBytes(data));
        }

        class NoKeepAliveClient : WebClient
        {
            protected override WebRequest GetWebRequest(System.Uri address)
            {
                WebRequest req = base.GetWebRequest(address);
                if (req is HttpWebRequest)
                {
                    ((HttpWebRequest)req).KeepAlive = false;
                }
                return req;
            }
        }
    }
}