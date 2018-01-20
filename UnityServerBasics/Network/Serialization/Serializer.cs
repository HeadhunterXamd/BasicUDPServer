using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityServerBasics.Network.Serialization
{
    public class Serializer
    {
        private ISerializer _networkSerializer;

        public Serializer(Type t)
        {
            _networkSerializer = (ISerializer)Activator.CreateInstance(t);
        }

        public byte[] Serialize(object message)
        {
            return _networkSerializer.Serialize(message);
        }

        public object Deserialize(byte[] data)
        {
            return _networkSerializer.Deserialize(data);
        }
    }
}
