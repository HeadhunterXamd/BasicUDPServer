using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityServerBasics.Network.Serialization
{
    public class Serializer
    {
        private INetworkSerializer _networkSerializer;

        public Serializer(Type t)
        {
            _networkSerializer = (INetworkSerializer)Activator.CreateInstance(t);
        }

        public byte[] Serialize(NetworkMessage message)
        {
            return _networkSerializer.Serialize(message);
        }

        public NetworkMessage Deserialize(byte[] data)
        {
            return _networkSerializer.Deserialize(data);
        }
    }
}
