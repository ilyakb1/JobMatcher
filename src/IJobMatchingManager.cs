using System.Threading.Tasks;

namespace JobMatcher
{
    public interface IJobMatchingManager
    {
        Task<JobWithCandidate[]> GetJobWithBestMatchedCandidateAsync();
    }
}