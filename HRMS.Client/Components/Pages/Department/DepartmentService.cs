namespace HRMS.Client.Components.Pages.Department
{
    public class DepartmentService
    {
        private readonly HttpClient _httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DepartmentModel>> GetDepartmentsAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7070/DepartmentApi?showDeleted=false");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<DepartmentModel>>();
            }
            return new List<DepartmentModel>();
        }
    }
}
