using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobMatcher
{
    public class CandidateRepository : ICandidateRepository
    {
        readonly HttpClient httpClient;
        readonly string baseUrl;

        public CandidateRepository(IConfiguration configuration, HttpClient httpClient)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            this.baseUrl = configuration["ServiceBaseUrl"];

            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl));
            }
        }


        public async Task<Candidate[]> GetCandidatesAsync()
        {
            string url = $"{baseUrl}/candidates";
            var reply = await httpClient.GetAsync(url);

            if (reply.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new InvalidOperationException($"Rest call {url} return error {reply.ReasonPhrase}");
            }

            return JsonConvert.DeserializeObject<Candidate[]>(await reply.Content.ReadAsStringAsync());
        }
    }
}
