using AssessmentApi.Models;
using Newtonsoft.Json;

namespace AssessmentApi.Service
{
    public interface IBackEndApiService
    {
        Task<List<WeatherForecast?>> GetApi1();
        Task<List<PollDirection?>> GetApi2();
    }

    public class BackEndApiService : IBackEndApiService
    {
        private readonly HttpClient _httpClient;

        public BackEndApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<WeatherForecast?>> GetApi1()
        {
            await Task.Delay(2000);

            //actually need to put this in a single call to make sure single instance of client is used to avoid deadlocks
            //TODO: -Use IHttpClientFactory to create and manage single instance of client to avoid deadlocks
            
            //var client = new HttpClient();
            var response = await _httpClient.GetAsync($"https://localhost:7113/Weather");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<List<WeatherForecast?>>(json);

            //TODO handle null, which can mean rework type, return empty list, return bool and aggregate results into an object
            return model; //return task ?? Task.FromResult(false); // convert to bool to handle null
        }

        public async Task<List<PollDirection?>> GetApi2()
        {
            //var client = new HttpClient();
            var response = await _httpClient.GetAsync($"https://localhost:7113/Directions");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<List<PollDirection?>>(json);

            return model;
        }
    }
}
