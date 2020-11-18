namespace JobMatcher
{
	public interface IJobWithCandidate
	{
		string Bla { get; }
		Candidate Candidate { get; set; }
		Job Job { get; set; }
	}
}