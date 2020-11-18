using System;

namespace JobMatcher
{
	public class JobWithCandidate
	{
		public Job Job { get; set; }

		public Candidate Candidate { get; set; }

		public string Bla => "Test";
	}
}
