using JobMatcher.Repository;
using JobMatcher.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobMatcher.Controllers
{
	[ApiController]
	[Route("jobs")]
	public class JobController : ControllerBase
	{
		[HttpGet]
		public async Task<IEnumerable<JobWithCandidate>> Get()
		{
			var config = new ConfigurationBuilder()
									.AddJsonFile("appsettings.json")
									.Build();

			var serviceBaseUrl = config["ServiceBaseUrl"];
			var httpClient = new HttpClient();
			var candidateRepository = new CandidateRepository(httpClient, serviceBaseUrl);
			var jobRepository = new JobRepository(httpClient, serviceBaseUrl);
			var matchingService = new MatchingService();

			var manager = new JobMatchingManager(matchingService, candidateRepository, jobRepository);
			return await manager.GetJobWithBestMatchedCandidateAsync();
		}
	}
}
