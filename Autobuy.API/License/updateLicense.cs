using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobuy.License
{
    public class updateLicense
    {
        public string LicenseKey { get; set; }
        public DateTime TimeExpired { get; set; }
        public string Email { get; set; }
        public bool isBan { get; set; }
        public string BanReason { get; set; }
        public string HardwareId { get; set; }
    }
}
