using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityServerBasics.Network
{
	class NetworkMessage
	{
		private int UID { get; set; }
		private int Sequence { get; set; }

		/// <summary>
		/// time for ttr calculation
		/// </summary>
		private DateTime Time { get; set; }

	}
}
