using System;
using System.Runtime.Serialization;

namespace UnityServerBasics.Network.Exceptions
{
	internal class IndexOutOfBoundsException : Exception
	{
		public IndexOutOfBoundsException()
		{
		}

		public IndexOutOfBoundsException(string _message) : base(_message)
		{
		}

		public IndexOutOfBoundsException(string _message, Exception _innerException) : base(_message, _innerException)
		{
		}

		protected IndexOutOfBoundsException(SerializationInfo _info, StreamingContext _context) : base(_info, _context)
		{
		}
	}
}