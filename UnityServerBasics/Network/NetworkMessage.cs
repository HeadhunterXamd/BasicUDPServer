using System;

namespace UnityServerBasics.Network
{
	class NetworkMessage
	{
		/// <summary>
		/// unique identifier for the networking system.
		/// </summary>
		public Guid GUID { get; private set; }

		/// <summary>
		/// if the message are in sequence this should be higher than 0,
		/// this can be used for bigger messages.
		/// </summary>
		public int Sequence { get; private set; }

		/// <summary>
		/// the body of the message, can contain data or connection info.
		/// When sending data of certain objects, like a player:
		/// use the Guid from the player object to identify the object.
		/// </summary>
		public string Body { get; private set; }

		/// <summary>
		/// time for ttr calculation
		/// </summary>
		public int SendTime { get; private set; }

		/// <summary>
		/// A Network message struct, for fast collection of the data.
		/// </summary>
		/// <param name="_lMessage">the data to be sent to the server</param>
		/// <param name="_iSequence">if the message is part of a sequence this should not be 0</param>
		public NetworkMessage(string _sMessage, int _iSequence = 0) 
		{
			Body = _sMessage;
			if (_iSequence != 0)
				Sequence = _iSequence;
			SendTime = new DateTime().Millisecond;
			GUID = Guid.NewGuid();
		}
	}
}
