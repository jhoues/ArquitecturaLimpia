using BaseLibrary.DTOs;

namespace ClientLibrary.Helpers
{
    /// <summary>
    /// Helper class for creating HttpClient instances with different configurations.
    /// </summary>
    public class GetHttpClient
    {
        private const string HeaderKey = "Authorization";
        private readonly IHttpClientFactory httpClientFactory;
        private readonly LocalStorageService localStorageService;

        /// <summary>
        /// Initializes a new instance of the GetHttpClient class.
        /// </summary>
        /// <param name="httpClientFactory">The IHttpClientFactory instance used to create HttpClient instances.</param>
        /// <param name="localStorageService">The LocalStorageService instance used to get the token.</param>
        public GetHttpClient(IHttpClientFactory httpClientFactory, LocalStorageService localStorageService)
        {
            this.httpClientFactory = httpClientFactory;
            this.localStorageService = localStorageService;
        }

        /// <summary>
        /// Creates a HttpClient instance for authenticated requests.
        /// </summary>
        /// <returns>A HttpClient instance with Authorization header if token exists.</returns>
        public async Task<HttpClient> GetPrivateHttpClient()
        {
            var client = httpClientFactory.CreateClient("SystemApiClient");
            var stringToken = await localStorageService.GetToken();
            if (string.IsNullOrEmpty(stringToken)) return client;

            var deserializeToken = Serializations.DeserializeJsonString<UserSession>(stringToken);
            if (deserializeToken == null) return client;

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", deserializeToken.Token);
            return client;
        }

        /// <summary>
        /// Creates a HttpClient instance for non-authenticated requests.
        /// </summary>
        /// <returns>A HttpClient instance without Authorization header.</returns>
        public HttpClient GetPublicHttpClient()
        {
            var client = httpClientFactory.CreateClient("SystemApiClient");
            client.DefaultRequestHeaders.Remove(HeaderKey);
            return client;
        }
    }
}

