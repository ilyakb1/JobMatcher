using System.Threading.Tasks;

namespace JobMatcher.Repository
{
	public interface IJobRepository
	{
		Task<Job[]> GetJobsAsync();
	}
}