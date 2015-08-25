using System;

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

		/// <summary>
		/// A Network message struct, for fast collection of the data.
		/// </summary>
		/// <param name="_lMessage"></param>
		public NetworkMessage(byte[] _lMessage)
		{

		}
	}
}
