using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobuy.License.Json
{
    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        public string version { get; set; }
        public int licenseCount { get; set; }
    }

    public class InfoProjects
    {
        public string shopId { get; set; }
        public string shopName { get; set; }
        public List<Project> projects { get; set; }
    }
}
