using JobMatcher.Model;
using System;
using System.Text.Json.Serialization;

namespace JobMatcher
{
	public class Job
	{
		public int JobId { get; set; }

		public string Name { get; set; }

		public string Company { get; set; }

		public string Skills { get; set; }

		[JsonIgnore]
		public string[] OrderedSkills => Skills.GetOrderedSkills();
	}
}
