using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace driver
{
    class Program
    {
        static void Main(string[] args)
        {
            // set log keys from code
            Loggr.Utility.Configuration.UseSettings(new Loggr.Utility.Settings { LogKey = "testlog", ApiKey = "xxxxxxxx" });

            string foo = "foo";
            var ex = new ApplicationException("This was an app exception");
            Loggr.Events.CreateFromException(ex, foo)
                .Text("test event")
                .Source("driver")
                .Post(false);

            Loggr.Users.TrackUser("test.user", "user@test.com", "/page");

            Console.ReadKey();
        }
    }
}
