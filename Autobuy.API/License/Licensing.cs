using Autobuy.License;
using Autobuy.License.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Autobuy
{
    public class Licensing
    {
        public string projectID { get; set; }
        public string projectName { get; set; }

        public Licensing(string projectID, string projectName)
        {
            this.projectID = projectID;
            this.projectName = projectName;
        }

        public async Task<license> CreateLicenseAsync(LicenseInfo licenseInfo)
        {
            if (string.IsNullOrEmpty(licenseInfo.Email))
                throw new Exception("You must write an email!");

            Dictionary<string, string> bodyParams = new Dictionary<string, string>()
            {
                { "ProjectId", projectID },
                { "TimeExpired", licenseInfo.ExpireDate.ToUniversalTime().ToString() },
                { "Email", licenseInfo.Email }
            };

            return JsonSerializer.Deserialize<license>(await API.Req.RequestAsync(
                httpMethod: HttpMethod.Post,
                LinkParam: "Licensing",
                BodyUrlEncode: bodyParams));
        }

        public async Task DeleteLicenseAsync(string LicenseKey)
        {
            if (string.IsNullOrEmpty(LicenseKey))
                throw new Exception("You must write an License Key.");

            Dictionary<string, string> bodyParams = new Dictionary<string, string>()
            {
                { "id", LicenseKey }
            };

            try
            {
                await API.Req.RequestAsync(
                    httpMethod: HttpMethod.Delete,
                    LinkParam: "Licensing",
                    BodyUrlEncode: bodyParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateLicenseAsync(updateLicense updateLicenseInfo)
        {

            Dictionary<string, string> bodyParams = new Dictionary<string, string>()
            {
                { "id", updateLicenseInfo.LicenseKey },
                { "TimeExpired", updateLicenseInfo.TimeExpired.ToString() },
                { "Email", updateLicenseInfo.Email },
                { "isBan", updateLicenseInfo.isBan.ToString() },
                { "BanReason", updateLicenseInfo.BanReason },
                { "HardwareId", updateLicenseInfo.HardwareId }
            };

            await API.Req.RequestAsync(
                httpMethod: HttpMethod.Put,
                LinkParam: "Licensing",
                BodyUrlEncode: bodyParams);
        }

        public async Task<bool> verifyHwidAsync(string licenseKey)
        {
            var hwid = HwidComputer.Get();

            Dictionary<string, string> bodyParams = new Dictionary<string, string>()
            {
                { "Id", licenseKey },
                { "HardwareId", hwid }
            };

            switch (await API.Req.RequestAsync(
                httpMethod: HttpMethod.Post,
                LinkParam: "Licensing/VerifyHardwareId",
                BodyUrlEncode: bodyParams))
            {
                case "Hardware Id does not match!":
                    return false;

                case "Hardware Id set!":
                    return true;

                case "Hardware Id Verified!":
                    return true;

                default:
                    return false;
            }
        }

        public async Task<bool> AuthKeyAsync(string licenseKey)
        {
            // From this method, I got the idea of: https://github.com/AustralianDeveloper/AutoBuyIO.NET
            // but async

            if (!Regex.IsMatch(licenseKey, @"^[A-Za-z0-9]{8}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{12}$"))
                throw new Exception("Invalid license Key Format.");

            Dictionary<string, string> bodyParams = new Dictionary<string, string>()
            {
                { "Id", licenseKey }
            };

            license response;

            try
            {
                response = JsonSerializer.Deserialize<license>(await API.Req.RequestAsync(
                    httpMethod: HttpMethod.Get,
                    LinkParam: "Licensing",
                    BodyUrlEncode: bodyParams));
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

            if (response.projectName != projectName ||
                response.projectId != projectID)
            {
                throw new Exception("Your license is not for this project!");
            }

            if (response.isBan)
            {
                Console.WriteLine($"\n License banned, Reason: {response.banReason}");
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (response.hardwareId != HwidComputer.Get())
            {
                Console.WriteLine($"\n Your HWID for {projectName} doesn't match!");
                Console.ReadLine();
                Environment.Exit(0);
            }

            if (Convert.ToInt32(ConvertToUnixTime(Convert.ToDateTime(response.timeExpired))) <= (int)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds)
            {
                Console.WriteLine($" Your key for {projectName} has expired!");
                Console.ReadLine();
                Environment.Exit(0);
            }

            return true;
        }

        public long ConvertToUnixTime(DateTime datetime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return (long)(datetime - sTime).TotalSeconds;
        }
    }
}
