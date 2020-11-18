using System.Linq;

namespace JobMatcher.Services
{
	public class MatchingService : IMatchingService
	{
		public Candidate Match(Job job, Candidate[] candidates)
		{
			var matchedCandidates = MatchSkills(job.OrderedSkills, candidates);
			if (matchedCandidates.Length != candidates.Length)
			{
				return matchedCandidates.FirstOrDefault();
			}

			return null;
		}

		static Candidate[] MatchSkills(string[] skills, Candidate[] candidates)
		{
			var currentCandidates = candidates;

			foreach (var skill in skills)
			{
				var filteredCandidates = MatchSkill(skill, currentCandidates);

				if (filteredCandidates != null && filteredCandidates.Length > 0)
				{
					currentCandidates = filteredCandidates;
				}
			}

			return currentCandidates;
		}

		static Candidate[] MatchSkill(string skill, Candidate[] candidates)
		{
			var maxCandidateSkillNumber = candidates.Max(c => c.OrderedSkills.Length);

			for (int i = 0; i < maxCandidateSkillNumber; i++)
			{
				var filteredCandidates = candidates.Where(c => c.OrderedSkills.Length > i && c.OrderedSkills[i] == skill).ToArray();
				if (filteredCandidates.Length > 0)
				{
					return filteredCandidates;
				}
			}

			return null;
		}
	}
}
