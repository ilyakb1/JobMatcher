using System.Threading.Tasks;

namespace JobMatcher
{
	public interface ICandidateRepository
	{
		Task<Candidate[]> GetCandidatesAsync();
	}
}