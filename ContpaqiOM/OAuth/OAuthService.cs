using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace ContpaqiOM.OAuth
{
    public class OAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _authUrl;
        private readonly string _accessTokenUrl;

        public OAuthService(HttpClient httpClient, string clientId, string clientSecret, string authUrl, string accessTokenUrl)
        {
            _httpClient = httpClient;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _authUrl = authUrl;
            _accessTokenUrl = accessTokenUrl;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _accessTokenUrl);

            var body = new StringContent($"grant_type=client_credentials&client_id={_clientId}&client_secret={_clientSecret}", Encoding.UTF8, "application/x-www-form-urlencoded");
            request.Content = body;

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(responseContent);

            return jsonDoc.RootElement.GetProperty("access_token").GetString();
        }
    }
}