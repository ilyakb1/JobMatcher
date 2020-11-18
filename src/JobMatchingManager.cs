using JobMatcher.Repository;
using JobMatcher.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobMatcher
{
	public class JobMatchingManager
	{
		readonly IMatchingService matchingService;
		readonly ICandidateRepository candidateRepository;
		readonly IJobRepository jobRepository;

		public JobMatchingManager(IMatchingService matchingService, ICandidateRepository candidateRepository, IJobRepository jobRepository)
		{
			this.matchingService = matchingService ?? throw new ArgumentNullException(nameof(matchingService));
			this.candidateRepository = candidateRepository ?? throw new ArgumentNullException(nameof(candidateRepository));
			this.jobRepository = jobRepository;
		}

		public async Task<JobWithCandidate[]> GetJobWithBestMatchedCandidateAsync()
		{

			var candidatesTask = candidateRepository.GetCandidatesAsync();
			var jobsTask = jobRepository.GetJobsAsync();

			await Task.WhenAll(candidatesTask, jobsTask);

			var jobs = jobsTask.Result;
			var candidates = candidatesTask.Result;

			var output = new List<JobWithCandidate>();
			foreach (var job in jobs)
			{
				var bestCandidate = matchingService.Match(job, candidates);
				var jobWithCandidate = new JobWithCandidate() { Job = job };
				if (bestCandidate != null)
				{
					jobWithCandidate.Candidate = bestCandidate;
				}

				output.Add(jobWithCandidate);
			}


			return output.ToArray();
		}
	}
}
