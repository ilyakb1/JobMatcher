using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobMatcher.Repository
{
	public class JobRepository : IJobRepository
	{
		readonly HttpClient httpClient;
		readonly string baseUrl;

		public JobRepository(HttpClient httpClient, string baseUrl)
		{
			this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
			this.baseUrl = baseUrl;
			baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
		}


		public async Task<Job[]> GetJobsAsync()
		{
			string url = $"{baseUrl}/jobs";
			var reply = await httpClient.GetAsync(url);

			if (reply.StatusCode != System.Net.HttpStatusCode.OK)
			{
				throw new InvalidOperationException($"Rest call {url} return error {reply.ReasonPhrase}");
			}

			return JsonConvert.DeserializeObject<Job[]>(await reply.Content.ReadAsStringAsync());
		}
	}
}
