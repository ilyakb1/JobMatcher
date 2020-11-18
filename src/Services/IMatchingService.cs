namespace JobMatcher.Services
{
	public interface IMatchingService
	{
		Candidate Match(Job job, Candidate[] candidates);
	}
}