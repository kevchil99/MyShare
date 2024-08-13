using AssessmentApi.Models;
using Newtonsoft.Json;

namespace AssessmentApi.Service
{
    public class BackEndApi
    {
        public async Task<List<WeatherForecast?>> GetApi1()
        {
            await Task.Delay(2000);

            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7113/Weather");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<List<WeatherForecast?>>(json);

            return model;
        }

        public async Task<List<PollDirection?>> GetApi2()
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7113/Directions");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<List<PollDirection?>>(json);

            return model;
        }
    }
}
