namespace frontend_sistema.Utils
{
    public static class HttpClientHelper
    {
        private static readonly HttpClient _httpClient = GerarHttpClient();

        private static HttpClient GerarHttpClient()
        {
            IConfiguration config = new ConfigurationBuilder().Build();
            var client = new HttpClient();
            client.BaseAddress = new Uri(config.GetSection("ApiSettings")
                                               .GetSection("BaseAddress").Value ?? "http://localhost:5050");
            return client;
        }

        public async static Task<string> GetAsync(string uriApiAction)
        {
            try
            {
                return await _httpClient.GetStringAsync(uriApiAction);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public async static Task<string> PostAsync(string uriApiAction, object content)
        {
            try
            {
                var httpResponse = await _httpClient.PostAsJsonAsync(uriApiAction, content);
                if(httpResponse.IsSuccessStatusCode)
                {
                    return await httpResponse.Content.ReadAsStringAsync();
                }
                return "Não foi possível realizar a operação. Causa: " + httpResponse.RequestMessage;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}