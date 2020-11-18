using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobMatcher.Model
{
	public static class StringArrayExtentions
	{
		public static string[] GetOrderedSkills(this string skillsInOrderString)
		{
			var skills = skillsInOrderString.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
			Array.ForEach(skills, s => s.Trim());
			return skills;
		}
	}
}
