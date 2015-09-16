using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityServerBasics.game;

namespace UnityServerBasics.Network
{
	[Serializable]
	class NetworkMessage
	{
		/// <summary>
		/// unique identifier for the networking system.
		/// </summary>
		public Guid GUID { get; private set; }

		/// <summary>
		/// The sender of this message.
		/// </summary>
		public Player Sender { get; private set; }

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
		public NetworkMessage(string _sMessage, Player _cPlayer, int _iSequence = 0) 
		{
			Body = _sMessage;
			if (_iSequence != 0)
				Sequence = _iSequence;
			SendTime = new DateTime().Millisecond;
			GUID = Guid.NewGuid();
			Sender = _cPlayer;
		}

		/// <summary>
		/// Serialize the <see cref="NetworkMessage"/> in to bytes.
		/// </summary>
		/// <param name="_message">The message to serialize.</param>
		/// <returns>A <see cref="byte[]"/></returns>
		public static byte[] Serialize(NetworkMessage _message)
		{
			try
			{
				MemoryStream memStream = new MemoryStream();
				IFormatter formatter = new BinaryFormatter();
				formatter.Serialize(memStream, _message);
				memStream.Position = 0;
				return memStream.ToArray();
			}
			catch (Exception)
			{
				throw new Exceptions.SerializeNetworkException();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="_message"></param>
		/// <returns></returns>
		public static NetworkMessage Deserialize(byte[] _message)
		{
			try
			{
				MemoryStream memStream = new MemoryStream();
				memStream.Write(_message, 0, _message.Length);
				IFormatter formatter = new BinaryFormatter();
				return (NetworkMessage)formatter.Deserialize(memStream);
			}
			catch (Exception)
			{
				throw new Exceptions.SerializeNetworkException();
			}
		}
	}
}
