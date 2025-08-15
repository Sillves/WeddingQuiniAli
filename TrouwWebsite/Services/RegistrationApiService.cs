using System.Text.Json;
using TrouwWebsite.Models;

namespace TrouwWebsite.Services
{
    public class RegistrationApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public RegistrationApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration.GetValue<string>("ApiBaseUrl")
                ?? "https://trouw-functions-1755253825.azurewebsites.net/api";
        }

        public async Task<Registration> CreateRegistrationAsync(Registration registration)
        {
            var json = JsonSerializer.Serialize(registration);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync($"{_baseUrl}/SaveRegistration", content);
            response.EnsureSuccessStatusCode();
            
            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Registration>(responseJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<List<Registration>> GetAllRegistrationsAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/GetRegistrations");
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Registration>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<Registration>();
        }
    }
}