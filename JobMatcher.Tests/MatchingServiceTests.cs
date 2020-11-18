using JobMatcher.Services;
using NUnit.Framework;

namespace JobMatcher.Tests
{
	[TestFixture]
	public class MatchingServiceTests
	{
		[Test]
		public void Match_SingleOptions()
		{
			var candidate1 = new Candidate() { CandidateId = 1, Name = "Chan Bravo", SkillTags = "reliable, reliable, ms-office, xcode, detail" };
			var candidate2 = new Candidate() { CandidateId = 2, Name = "Thomasine To", SkillTags = "illustrator, oration, sterilisation, kotlin, outlook" };
			var candidate3 = new Candidate() { CandidateId = 3, Name = "Lester Scheidt", SkillTags = "placements, iOS, entertainment, mobile, xcode" };
			var candidate4 = new Candidate() { CandidateId = 4, Name = "Pandora Hubble", SkillTags = "aphra-registration, sales, ms-office, xcode, outlook" };

			var candidates = new[] { candidate1, candidate2, candidate3, candidate4 };


			var job = new Job() { Company = "Surile", JobId = 2, Name = "Reception", Skills = "word, placements, data-entry, communication" };

			var service = new MatchingService();
			var bestCandidate = service.Match(job, candidates);

			Assert.NotNull(bestCandidate);
			Assert.AreEqual(3, bestCandidate.CandidateId);
		}

		[Test]
		public void Match_MultipleOptions()
		{
			var candidate1 = new Candidate() { CandidateId = 1, Name = "Chan Bravo", SkillTags = "reliable, reliable, ms-office, xcode, detail" };
			var candidate2 = new Candidate() { CandidateId = 2, Name = "Thomasine To", SkillTags = "illustrator, oration, sterilisation, kotlin, outlook" };
			var candidate3 = new Candidate() { CandidateId = 3, Name = "Lester Scheidt", SkillTags = "placements, iOS, entertainment, mobile, xcode" };
			var candidate4 = new Candidate() { CandidateId = 4, Name = "Pandora Hubble", SkillTags = "aphra-registration, sales, ms-office, xcode, outlook" };

			var candidates = new[] { candidate1, candidate2, candidate3, candidate4 };


			var job = new Job() { Company = "Surile", JobId = 2, Name = "Reception", Skills = "ms-office, word, outlook, data-entry, communication" };

			var service = new MatchingService();
			var bestCandidate = service.Match(job, candidates);

			Assert.NotNull(bestCandidate);
			Assert.AreEqual(4, bestCandidate.CandidateId);
		}

		[Test]
		public void Match_None()
		{
			var candidate1 = new Candidate() { CandidateId = 1, Name = "Chan Bravo", SkillTags = "reliable, reliable, ms-office, xcode, detail" };
			var candidate2 = new Candidate() { CandidateId = 2, Name = "Thomasine To", SkillTags = "illustrator, oration, sterilisation, kotlin, outlook" };
			var candidate3 = new Candidate() { CandidateId = 3, Name = "Lester Scheidt", SkillTags = "placements, iOS, entertainment, mobile, xcode" };
			var candidate4 = new Candidate() { CandidateId = 4, Name = "Pandora Hubble", SkillTags = "aphra-registration, sales, ms-office, xcode, outlook" };

			var candidates = new[] { candidate1, candidate2, candidate3, candidate4 };


			var job = new Job() { Company = "Surile", JobId = 2, Name = "Reception", Skills = "word, data-entry, communication" };

			var service = new MatchingService();
			var bestCandidate = service.Match(job, candidates);

			Assert.Null(bestCandidate);
		}
	}
}
