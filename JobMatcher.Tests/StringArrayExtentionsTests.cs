using JobMatcher.Model;
using NUnit.Framework;

namespace JobMatcher.Tests
{
	[TestFixture]
	public class StringArrayExtentionsTests
	{
		[Test]
		public void GetOrderedSkills_Empty()
		{
			var output = StringArrayExtentions.GetOrderedSkills("");
			Assert.AreEqual(0, output.Length);
		}

		[Test]
		public void GetOrderedSkills()
		{
			var output = StringArrayExtentions.GetOrderedSkills("detail, maintenance, powerpoint, data-entry,housekeeping");
			Assert.AreEqual(5, output.Length);
			Assert.AreEqual("detail", output[0]);
			Assert.AreEqual("maintenance", output[1]);
			Assert.AreEqual("powerpoint", output[2]);
			Assert.AreEqual("data-entry", output[3]);
			Assert.AreEqual("housekeeping", output[4]);
		}

	}
}
