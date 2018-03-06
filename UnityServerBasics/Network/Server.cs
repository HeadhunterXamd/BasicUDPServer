using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityServerBasics.game;
using UnityServerBasics.Network.Serialization;
using UnityServerBasics.Utilities;

namespace UnityServerBasics.Network
{
    public enum SerializerType : byte
    {
        XML = 0xa,
        JSON = 0xb,
        BINARY = 0xc
    }


	/// <summary>
	/// this is a basic server class.
	/// </summary>
	public class Server : IDisposable
	{
		#region Vars
		private Thread _tServerThread;
		private readonly int _iPort;
		private UdpClient _cListener;
		private IPEndPoint _cEndPoint;
		public EventQueue<NetworkMessage> _lMessageBacklog { get; private set; }
		public EventList<Hub> _lPlayerRooms { get; private set; }
        private SerializerType _eSerializerType;
        private Serializer _cSerializer;
		private bool _bEnableListener;

		/// <summary>
		/// a delegate function is like a blueprint, this shows the parameters the event gives when it fires.
		/// </summary>
		/// <param name="_lMessage"></param>
		public delegate void OnMessageReceived(NetworkMessage _lMessage);


        private delegate void _messageArrived(byte[] data);

        private event _messageArrived messageArrived;


		/// <summary>
		/// when you receive a message this event fires
		/// </summary>
		private event OnMessageReceived MessageReceived;

		/// <summary>
		/// get the latest instance of the Server.
		/// </summary>
		public static Server Instance { get; private set; }

		#endregion

		/// <summary>
		/// start a small server that listens to UDP messages through _port 1337(as indicated when initializing the server instance).
		/// </summary>
		/// <param name="_port"></param>
		/// <param name="messageBacklog"></param>
		public Server(int _port, EventQueue<NetworkMessage> messageBacklog = null, SerializerType serializer = SerializerType.XML)
		{
			_iPort = _port;
            _lMessageBacklog = messageBacklog ?? new EventQueue<NetworkMessage>();
			_lPlayerRooms = new EventList<Hub>();
			Instance = this;
			Console.WriteLine("Setting up the server...");
			messageArrived += ParseMessage;
            _eSerializerType = serializer;
            CreateSerializer(serializer);
		}

		/// <summary>
		/// here you start the server to listen to the specified _port.
		/// </summary>
		/// <returns></returns>
		public bool StartServer()
		{
			_tServerThread = new Thread(Listener) {IsBackground = true};
			Console.WriteLine("Starting the listener...");
			_bEnableListener = true;
			_tServerThread.Start();
			return true;
		}

		/// <summary>
		/// here you can get the status of the Thread where the server is running
		/// </summary>
		/// <returns></returns>
		public string Status()
		{
			var state = _tServerThread.ThreadState;
			return state.ToString();
		}

		/// <summary>
		/// this is the function that is running on a separate thread, this listens to the incoming messages.
		/// </summary>
		private void Listener()
		{
			_cListener = new UdpClient(_iPort, AddressFamily.InterNetwork);

			_cEndPoint = new IPEndPoint(IPAddress.Any, _iPort);

			while (_bEnableListener)
			{
				try
				{
					byte[] message = _cListener.Receive(ref _cEndPoint);
					// here you have received your message, you can do with it what you want.
					// The message is an serialized Networkmessage, which is a wrapper for the content of the message.
					// I launch the event that gives the messageData to the eventlisteners
					messageArrived(message);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					return;
				}
			}
		}

        public void SendMessage(NetworkMessage message, IPAddress target)
        {
            UdpClient sender = new UdpClient(_iPort + 1, AddressFamily.InterNetwork);
            IPEndPoint endPoint = new IPEndPoint(target, _iPort+ 1);

            byte[] mess = _cSerializer.Serialize(message);
            byte[] newmess = new byte[mess.Length + 1];
            // first byte is the indicator which kind of serialization we use.
            newmess[0] = (byte)_eSerializerType;
            // the new format will be [serializertype, message]
            for (int i = 1; i < newmess.Length; i++)
            {
                newmess[i] = mess[i - 1];
            }
            sender.Send(newmess, newmess.Length - 1, endPoint);
        }


        private void CreateSerializer(SerializerType serializer)
        {
            switch (serializer)
            {
                case SerializerType.JSON:
                case SerializerType.XML:
                    _cSerializer = new Serializer(typeof(XMLSerializer));
                    break;
                case SerializerType.BINARY:
                    _cSerializer = new Serializer(typeof(BinarySerializer));
                    break;
            }
        }

		#region EventManagment

		/// <summary>
		/// The function called after a message came in.
		/// the format of the bytes is always, first byte the encoding type/the serializer used to encode the message.
        /// the bytes after that are the message.
		/// </summary>
		/// <param name="_lMessage"></param>
		private void ParseMessage(byte[] _lMessage)
		{
			try {
                byte[] mess = new byte[_lMessage.Length - 1];
                for (int i = 1; i < mess.Length; i++)
                {
                    mess[i] = _lMessage[i];
                }
				CreateSerializer((SerializerType)_lMessage[0]);

				NetworkMessage message = _cSerializer.Deserialize(mess) as NetworkMessage;
				_lMessageBacklog.Enqueue(message);
                MessageReceived?.Invoke(_lMessageBacklog.Dequeue());
			}
			catch (Exception e)
			{
				throw new Exception("The string given is not encoded correctly or not complete.", e);
			}
		}

		/// <summary>
		/// This method allows you to get subscribed to the MessageReceived event
		/// </summary>
		/// <param name="_method"> the method to run when this event fires </param>
		public void SubscribeToMessageReceived(OnMessageReceived _method)
		{
			MessageReceived += _method;
		} 

		/// <summary>
		/// Unsubscribe from this event
		/// </summary>
		/// <param name="_method"> the method you want to unsubscribe from this event </param>
		public void UnsubscribeToMessageReceived(OnMessageReceived _method)
		{
			MessageReceived -= _method;
		}

		/// <summary>
		/// <see cref="IDisposable.Dispose"/>
		/// </summary>
		public void Dispose()
		{
			Console.WriteLine("Disabling the listener...");
			_cListener?.Close();
			_cEndPoint = null;
			_bEnableListener = false;
			Console.WriteLine("Shutting down...");
			_tServerThread?.Abort();
		}
		#endregion
	}
}
