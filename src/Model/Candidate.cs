using JobMatcher.Model;
using System;
using System.Text.Json.Serialization;

namespace JobMatcher
{
	public class Candidate
	{
		public int CandidateId { get; set; }

		public string Name { get; set; }

		public string SkillTags { get; set; }

		[JsonIgnore]
		public string[] OrderedSkills => SkillTags.GetOrderedSkills();
	}
}
