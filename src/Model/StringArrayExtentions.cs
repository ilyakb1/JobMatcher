using System;
using System.Linq;

namespace JobMatcher.Model
{
	public static class StringArrayExtentions
	{
		public static string[] GetOrderedSkills(this string skillsInOrderString)
		{
			var skills = skillsInOrderString.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
			return skills.Select(s => s.Trim()).ToArray();
		}
	}
}
