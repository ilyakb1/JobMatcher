using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobMatcher.Controllers
{
    [ApiController]
    [Route("jobs")]
    public class JobController : ControllerBase
    {
        private readonly IJobMatchingManager jobMatchingManager;

        public JobController(IJobMatchingManager jobMatchingManager)
        {
            this.jobMatchingManager = jobMatchingManager ?? throw new System.ArgumentNullException(nameof(jobMatchingManager));
        }

        [HttpGet]
        public async Task<IEnumerable<JobWithCandidate>> Get()
        {
            return await jobMatchingManager.GetJobWithBestMatchedCandidateAsync();
        }
    }
}
