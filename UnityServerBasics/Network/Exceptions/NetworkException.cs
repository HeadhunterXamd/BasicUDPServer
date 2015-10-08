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

		public NetworkException(string _message) : base(_message)
		{
		}

		public NetworkException(string _message, Exception _innerException) : base(_message, _innerException)
		{
		}

		protected NetworkException(SerializationInfo _info, StreamingContext _context) : base(_info, _context)
		{
		}
	}

	class SerializeNetworkException : NetworkException
	{
		public SerializeNetworkException()
		{
		}

		public SerializeNetworkException(string _message) : base(_message)
		{
		}

		public SerializeNetworkException(string _message, Exception _innerException) : base(_message, _innerException)
		{
		}

		protected SerializeNetworkException(SerializationInfo _info, StreamingContext _context) : base(_info, _context)
		{
		}
	}
}
