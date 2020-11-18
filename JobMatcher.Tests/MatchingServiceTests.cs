using JobMatcher.Services;
using NUnit.Framework;

namespace JobMatcher.Tests
{
	[TestFixture]
	public class MatchingServiceTests
	{
		[Test]
		public void Match_First()
		{
			var candidate1 = new Candidate() { CandidateId = 1, Name = "Chan Bravo", SkillTags = "reliable, reliable, ms-office, xcode, detail" };
			var candidate2 = new Candidate() { CandidateId = 2, Name = "Thomasine To", SkillTags = "illustrator, oration, sterilisation, kotlin, outlook" };
			var candidate3 = new Candidate() { CandidateId = 3, Name = "Lester Scheidt", SkillTags = "placements, iOS, entertainment, mobile, xcode" };
			var candidate4 = new Candidate() { CandidateId = 4, Name = "Pandora Hubble", SkillTags = "aphra-registration, sales, reception, xcode, fastlane" };

			var candidates = new[] { candidate1, candidate2, candidate3, candidate4 };


			var job = new Job() { Company = "Surile", JobId = 2, Name = "Reception", Skills = "detail, ms-office, word, outlook, data-entry, communication" };

			var service = new MatchingService();
			var bestCandidate = service.Match(job, candidates);

			Assert.NotNull(bestCandidate);
			Assert.AreEqual(1, bestCandidate.CandidateId);

		}
	}
}
