using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UnityServerBasics.Network.Exceptions
{
	class NetworkException : Exception
	{
		public NetworkException()
		{
		}

		public NetworkException(string message) : base(message)
		{
		}

		public NetworkException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected NetworkException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}

	class SerializeNetworkException : NetworkException
	{
		public SerializeNetworkException()
		{
		}

		public SerializeNetworkException(string message) : base(message)
		{
		}

		public SerializeNetworkException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected SerializeNetworkException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
