using Newtonsoft.Json;
using ServiceForWorkingWithApartmentBuildingClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ServiceForWorkingWithApartmentBuildingClient
{
    public sealed class Server
    {
        public static async Task<List<string>> GetAllAddresses()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.GetAsync("https://localhost:44303/tenats/addresses");
            var addresses  = JsonConvert.DeserializeObject<IEnumerable<AddressView>>(await response.Content.ReadAsStringAsync());
            return addresses
                .Select(a => a.Address)
                .ToList();
        }

        public static async Task<bool> Login(LoginTenatBinding binding)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.PostAsJsonAsync("https://localhost:44303/Login", binding);

            //var token = JsonConvert.DeserializeObject<Token>(await response.Content.ReadAsStringAsync());

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else 
                return false;
        }

        public static async Task<bool> Register(CreateTenantBinding binding)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.PostAsJsonAsync("https://localhost:44303/Register", binding);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public static async Task<bool> LoginManagementCompany(LoginManagementCompanyBinding binding)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.PostAsJsonAsync("https://localhost:44303/LoginManagementCompany", binding);

            //var token = JsonConvert.DeserializeObject<Token>(await response.Content.ReadAsStringAsync());

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public static async Task<bool> RegisterManagementCompany(CreateManagementCompanyBinding binding)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.PostAsJsonAsync("https://localhost:44303/RegisterManagementCompany", binding);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public static async Task<ProfileView> GetTenantProfile
            (string name, string surname, string password)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
               client.GetAsync($"https://localhost:44303/tenants/profile/{name}/{surname}/{password}");

            var profile = JsonConvert.DeserializeObject<ProfileView>
                (await response.Content.ReadAsStringAsync());

            return profile;
        }

        public static async Task<ManagementCompanyProfileView> GetManagementCompanyProfile
            (string managementCompanyName)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
               client.GetAsync($"https://localhost:44303/managementCompany/profile/{managementCompanyName}");

            var profile = JsonConvert.DeserializeObject<ManagementCompanyProfileView>
                (await response.Content.ReadAsStringAsync());

            return profile;
        }

        public static async Task CreateAnnouncementByBuildingId(string buildingId, CreateAnnouncementBinding binding)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.PostAsJsonAsync($"https://localhost:44303/announcement/buildings/{buildingId}", binding);
        }

        public static async Task<List<AnnouncementReference>> GetAnnouncementsForTenant(string tenantId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.GetAsync($"https://localhost:44303/announcement/tenants/{tenantId}");

            var announcements = JsonConvert.DeserializeObject<Page<AnnouncementReference>>(await response.Content.ReadAsStringAsync());

            return announcements.Values.ToList();
        }

        public static async Task CreatePollByBuildingId(string buildingId, CreatePollBinding binding)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.PostAsJsonAsync($"https://localhost:44303/polls/buildings/{buildingId}", binding);
        }

        public static async Task<List<PollReference>> GetPollsFromManagementCompany(string managementCompanyId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.GetAsync($"https://localhost:44303/polls/managementCompany/{managementCompanyId}");

            var polls = JsonConvert.DeserializeObject<IEnumerable<PollReference>>(await response.Content.ReadAsStringAsync());

            return polls.ToList();
        }

        public static async Task<List<PollReference>> GetPollsForTeant(string tenantId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.GetAsync($"https://localhost:44303/polls/tenant/{tenantId}");

            var polls = JsonConvert.DeserializeObject<IEnumerable<PollReference>>(await response.Content.ReadAsStringAsync());

            return polls.ToList();
        }

        public static async Task<List<AnswerOptionReference>> GetAnswerOption(string pollId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.GetAsync($"https://localhost:44303/polls/answers/{pollId}");

            var answers = JsonConvert.DeserializeObject<IEnumerable<AnswerOptionReference>>(await response.Content.ReadAsStringAsync());

            return answers.ToList();
        }

        public static async Task ToVoke(string pollId, string answerOptionId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.PostAsJsonAsync($"https://localhost:44303/polls/{pollId}/answer/{answerOptionId}", new { });
        }

        public static async Task ClosePoll(string pollId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.DeleteAsync($"https://localhost:44303/polls/{pollId}");
        }

        public static async Task<bool> CreateBuildingByManagementCompanyId(string managementCompanyId, CreateBuildingBinding binding)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.PostAsJsonAsync($"https://localhost:44303/building/{managementCompanyId}", binding);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }

        public static async Task<List<BuildingReference>> GetBuildings(string managementCompanyId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.GetAsync($"https://localhost:44303/building/{managementCompanyId}");

            var buildings = JsonConvert.DeserializeObject<IEnumerable<BuildingReference>>
                (await response.Content.ReadAsStringAsync());

            return buildings.ToList();
        }

        public static async Task<string> OpenMeetingForBuilding(string buildingId, CreateMeetingBinding binding)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.PostAsJsonAsync($"https://localhost:44303/meetings/buindings/{buildingId}", binding);

            return JsonConvert.DeserializeObject<string>
                (await response.Content.ReadAsStringAsync());
        }

        public static async Task CloseMeetingForBuilding(string meetingId)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("User-Agent", "ServiceForWorking");

            HttpResponseMessage response = await
                client.DeleteAsync($"https://localhost:44303/meetings/buindings/{meetingId}");
        }
    }
}

