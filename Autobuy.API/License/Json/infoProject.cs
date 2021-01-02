using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobuy.License.Json
{
    public class infoProject
    {
        public string Id { get; set; }
        public bool IsBan { get; set; }
        public DateTime TimeExpired { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectVersion { get; set; }
    }
}
