using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JobMatcher.Tests
{
    [TestFixture]
    public class CandidateRepositoryTests
    {
        [Test]
        public async Task GetCandidatesAsync_Success()
        {
            var config = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();


            var serviceBaseUrl = config["ServiceBaseUrl"];

            var repository = new CandidateRepository(config, new HttpClient());
            var candidates = await repository.GetCandidatesAsync();
            Assert.IsTrue(candidates.Length > 0);

            var candidate1 = candidates.OrderBy(c => c.CandidateId).First();

            Assert.IsTrue(candidate1.CandidateId > 0);
            Assert.IsTrue(candidate1.Name.Length > 0);
            Assert.IsTrue(candidate1.SkillTags.Length > 0);
        }
    }
}
