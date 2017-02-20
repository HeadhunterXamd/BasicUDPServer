using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityServerBasics.Utilities
{
    /// <summary>
    /// This is a hub for string utlities, like random string generation and caseinsensitive comparison.
    /// </summary>
	public static class StringUtilities
	{
		/// <summary>
		/// generate a random string
		/// </summary>
		/// <param name="_length">the length of the string you want to generate</param>
		/// <returns></returns>
		public static string GenerateRandomString(int _length)
		{
			string source = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXY0Z123456789";
			string retStr = "";
			for (int i = 0; i < _length; i++)
			{
				retStr += source[i];
			}
			return retStr;
		}

        /// <summary>
        /// Compare the two strings, without checking the case.
        /// </summary>
        /// <param name="origin">The first string to compare</param>
        /// <param name="other">The second screen to compare</param>
        /// <returns>true if the string is the same.</returns>
        public static bool CompareCaseInsensitive(string origin, string other)
        {
            return origin.ToLower() == other.ToLower();
        }

	}
}
