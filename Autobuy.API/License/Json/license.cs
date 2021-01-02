using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobuy.License.Json
{
    public class license
    {
        public string id { get; set; }
        public string email { get; set; }
        public bool isBan { get; set; }
        public object banReason { get; set; }
        public object hardwareId { get; set; }
        public DateTime timeCreated { get; set; }
        public DateTime timeUpdated { get; set; }
        public DateTime timeExpired { get; set; }
        public string projectId { get; set; }
        public string projectName { get; set; }
    }
}
