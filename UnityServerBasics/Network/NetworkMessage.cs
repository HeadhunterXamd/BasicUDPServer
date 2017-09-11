using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityServerBasics.game;
using UnityServerBasics.Network.Serialization;

/// <summary>
/// Thi is a basic network message wrapper so the messaging can be better managed.
/// </summary>
namespace UnityServerBasics.Network
{
	[Serializable]
	public class NetworkMessage : Serialization.INetworkSerializer
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
		/// this is for the Congestion control.
		/// </summary>
		public int Sequence { get; private set; }

		/// <summary>
		/// the body of the message, can contain data or connection info.
		/// When sending data of certain objects, like a player.<para/>
		/// Use the Guid from the player object to identify the object.
		/// Like this: "GUID of playerObject|messageBody"
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

		///// <summary>
		///// Serialize the <see cref="NetworkMessage"/> in to bytes.
		///// </summary>
		///// <param name="_message">The message to serialize.</param>
		///// <returns>A <see cref="byte[]"/></returns>
		//public static byte[] Serialize(NetworkMessage _message)
		//{
		//	try
		//	{
		//		MemoryStream memStream = new MemoryStream();
		//		IFormatter formatter = new BinaryFormatter();
		//		// write the serializable class to the memory stream.
		//		formatter.Serialize(memStream, _message);
		//		memStream.Position = 0;
		//		// return the memory stream as a byte[]
		//		return memStream.ToArray();
		//	}
		//	catch (Exception)
		//	{
		//		throw new Exceptions.SerializeNetworkException("The message could not be serialized");
		//	}
		//}

		///// <summary>
		///// 
		///// </summary>
		///// <param name="_message"></param>
		///// <returns></returns>
		//public static NetworkMessage Deserialize(byte[] _message)
		//{
		//	try
		//	{
		//		MemoryStream memStream = new MemoryStream();
		//		memStream.Write(_message, 0, _message.Length);
		//		IFormatter formatter = new BinaryFormatter();
		//		return (NetworkMessage)formatter.Deserialize(memStream);
		//	}
		//	catch (Exception)
		//	{
		//		throw new Exceptions.SerializeNetworkException("The message could not be deserialized");
		//	}
		//}
	}
}
