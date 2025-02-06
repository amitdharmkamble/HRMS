using HRMS.Client.Components.Pages.Department;

namespace HRMS.Client.Components.Pages.Designations
{
    public class DesignationService
    {
        private readonly HttpClient _httpClient;

        public DesignationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DesignationModel>> GetDesignationsAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7070/Designations");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<DesignationModel>>();
            }
            return new List<DesignationModel>();
        }
    }
}
