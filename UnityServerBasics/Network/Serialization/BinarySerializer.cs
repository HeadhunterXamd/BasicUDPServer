using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace UnityServerBasics.Network.Serialization
{
    public class BinarySerializer : ISerializer
    {
        public byte[] Serialize(object serializer)
        {
            try
            {
                MemoryStream memStream = new MemoryStream();
                IFormatter formatter = new BinaryFormatter();
                // write the serializable class to the memory stream.
                formatter.Serialize(memStream, serializer);
                memStream.Position = 0;
                // return the memory stream as a byte[]
                return memStream.ToArray();
            }
            catch (Exception)
            {
                throw new SerializationException();
            }
        }

        public object Deserialize(byte[] xmlData)
        {
            try
            {
                MemoryStream memStream = new MemoryStream();
                memStream.Write(xmlData, 0, xmlData.Length);
                IFormatter formatter = new BinaryFormatter();
                return (NetworkMessage)formatter.Deserialize(memStream);
            }
            catch (Exception)
            {
                throw new SerializationException();
            }
        }
    }
}
