using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobuy.License
{
    public class LicenseInfo
    {

        public string Email { get; set; }

        // Time on UTC
        public DateTime ExpireDate { get; set; }
    }
}
