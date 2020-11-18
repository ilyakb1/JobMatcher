using JobMatcher.Repository;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobMatcher.Tests
{
	[TestFixture]
	public class JobRepositoryTests
	{
		[Test]
		public async Task GetJobsAsync_Success()
		{
			var config = new ConfigurationBuilder()
									.AddJsonFile("DevConfig.json")
									.Build();


			var serviceBaseUrl = config["ServiceBaseUrl"];

			var repository = new JobRepository(new HttpClient(), serviceBaseUrl);
			var jobs = await repository.GetJobsAsync();
			Assert.IsTrue(jobs.Length > 0);

			var jobs1 = jobs.OrderBy(c => c.JobId).First();

			Assert.IsTrue(jobs1.JobId > 0);
			Assert.IsTrue(jobs1.Name.Length > 0);
			Assert.IsTrue(jobs1.Skills.Length > 0);
			Assert.IsTrue(jobs1.Company.Length > 0);
		}
	}
}
