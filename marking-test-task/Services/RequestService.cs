using System.Net.Http;
using System.Reflection;
using System.Text.Json;

namespace marking_test_task.Services
{
    public class Responce<TResult>
    {
        public TResult? Result { get; set; }
        public string Status { get; set; }
    }

    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient;

        public RequestService()
        {
            _httpClient = new HttpClient();
        }

        public Responce<TResult?> Get<TResult>(string url)
        {
            var responce = _httpClient.GetAsync(url);
            var json = responce.Result.Content.ReadAsStringAsync().Result;

            var serializedContent = JsonSerializer.Deserialize<TResult>(json.ToString());
            var status = responce.Result.StatusCode;

            return new Responce<TResult?>
            {
                Result = serializedContent,
                Status = status.ToString()
            };
        }

        public Task<Responce<TResult>> PostAsync<TRequest, TResult>()
        {
            throw new NotImplementedException($"Method {MethodBase.GetCurrentMethod()!.Name}.");
        }
    }
}
