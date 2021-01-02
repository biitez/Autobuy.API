using Autobuy.License.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Autobuy.License
{
    public class Projects
    {
        public async Task<InfoProjects> GetAllProjectsAsync()
        {
            return JsonSerializer.Deserialize<InfoProjects>(await API.Req.RequestAsync(
                httpMethod: HttpMethod.Get,
                LinkParam: "Projects"));
        }

        public async Task<infoProject> GetProjectInfoAsync(string IDProject)
        {
            Dictionary<string, string> bodyID = new Dictionary<string, string>()
            {
                { "id", IDProject }
            };

            return JsonSerializer.Deserialize<infoProject>(await API.Req.RequestAsync(
                httpMethod: HttpMethod.Get,
                LinkParam: "Licensing",
                BodyUrlEncode: bodyID));
        }
    }
}
