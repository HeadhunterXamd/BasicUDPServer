using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityServerBasics.Utilities
{
	class StringUtilities
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


	}
}
