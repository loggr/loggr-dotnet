using System;
using System.Collections.Generic;
using System.Text;

namespace Loggr
{
    public interface IHttpClient
    {
        byte[] PostData(string url, string data);
    }
}
