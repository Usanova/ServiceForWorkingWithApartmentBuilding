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

            var token = JsonConvert.DeserializeObject<Token>(await response.Content.ReadAsStringAsync());

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

            var token = JsonConvert.DeserializeObject<Token>(await response.Content.ReadAsStringAsync());

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
    }
}
