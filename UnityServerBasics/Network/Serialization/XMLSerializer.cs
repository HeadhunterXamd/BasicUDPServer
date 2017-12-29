using System;
using System.IO;
using System.Xml.Serialization;
using UnityServerBasics.Network.Exceptions;

namespace UnityServerBasics.Network.Serialization
{
	/// <summary>
	/// Network serialization interface.
	/// implement this for the serialization.
	/// Do implement the attributes for the serialization.
	/// </summary>
	[Serializable]
	// ReSharper disable once InconsistentNaming
	public class XMLSerializer : INetworkSerializer
	{
        /// <summary>
        /// Serialize the object that implements the <see cref="XMLSerializer"/> interface.
        /// </summary>
        /// <param name="toSerialize">The object to serialize</param>
        /// <returns>A string of xml data.</returns>
        public byte[] Serialize(INetworkSerializer toSerialize)
		{
			try
			{
				XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());
				using (StringWriter textWriter = new StringWriter())
				{
					xmlSerializer.Serialize(textWriter, toSerialize);
					return Convert.FromBase64String(textWriter.ToString());
				}
			}
			catch (Exception)
			{

				throw new SerializeNetworkException();
			}
		}

	    /// <summary>
		/// Deserialize the string of Xml data.
		/// </summary>
		/// <typeparam name="T">The type of object to deserialzie to.</typeparam>
		/// <param name="xmlData">the Xml string to deserialize</param>
		/// <returns>The <see cref="T"/> object</returns>
		public NetworkMessage Deserialize(byte[] xmlData)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(NetworkMessage));
				using (StreamReader reader = new StreamReader(Convert.ToBase64String(xmlData)))
				{
					return (NetworkMessage)serializer.Deserialize(reader);
				}
			}
			catch (Exception)
			{
				throw new SerializeNetworkException();
			}

		}

	    
	}

    
}
