using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobMatcher.Controllers
{
	[ApiController]
	[Route("jobs")]
	public class JobController : ControllerBase
	{
		readonly ILogger<JobController> _logger;

		public JobController(ILogger<JobController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<JobWithCandidate> Get()
		{
			var job1 = new Job() { Company = "Company 1", JobId = 1, Name = "Job 11", Skills = "Skill1, Skill 2" };
			var job2 = new Job() { Company = "Company 1", JobId = 2, Name = "Job 12", Skills = "Skill2, Skill 3" };
			var job3 = new Job() { Company = "Company 2", JobId = 3, Name = "Job 21", Skills = "Skill4, Skill 5, Skill6" };


			var candidate1 = new Candidate() { CandidateId = 1,  Name = "Candidate 1", SkillTags = "Skill5, Skill 6" };
			var candidate2 = new Candidate() { CandidateId = 2,  Name = "Candidate 2", SkillTags = "Skill1, Skill 3" };
			var candidate3 = new Candidate() { CandidateId = 3,  Name = "Candidate 3", SkillTags = "Skill2, Skill 5, Skill6" };

			var output = new List<JobWithCandidate>();

			output.Add(new JobWithCandidate() { Candidate = candidate1, Job = job1 });
			output.Add(new JobWithCandidate() { Candidate = candidate2, Job = job2 });
			output.Add(new JobWithCandidate() { Candidate = candidate3, Job = job3 });


			return output;
		}
	}
}
