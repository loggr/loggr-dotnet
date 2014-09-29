using System;
using System.Collections.Generic;
using System.Text;

namespace Loggr.Utility
{
    public class Settings
    {
        public virtual string ApiKey { get; set; }
        public virtual string LogKey { get; set; }
        public virtual string Server { get; set; }
        public virtual string Version { get; set; }
        public virtual string Tags { get; set; }
        public virtual string Source { get; set; }
        public virtual string User { get; set; }
        public virtual bool? Secure { get; set; }
    }
}
