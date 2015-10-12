using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityServerBasics.Utilities;

namespace UnityServerBasics.Network
{

	/// <summary>
	/// this is a basic server class.
	/// </summary>
	class Server : IDisposable
	{
		private Thread _serverThread;
		private readonly int _port;
		private UdpClient _listener;
		private IPEndPoint _endPoint;
		public EventQueue<NetworkMessage> MessageBacklog { get; private set; }

		/// <summary>
		/// a delegate function is like a blueprint, this shows the parameters the event gives when it fires.
		/// </summary>
		/// <param name="_lMessage"></param>
		public delegate void OnMessageReceived(byte[] _lMessage);


		/// <summary>
		/// when you receive a message this event fires
		/// </summary>
		private event OnMessageReceived MessageReceived;

		/// <summary>
		/// get the latest instance of the Server.
		/// </summary>
		public static Server Instance { get; private set; }


		/// <summary>
		/// start a small server that listens to UDP messages through _port 1337(as indicated when initializing the server instance).
		/// </summary>
		/// <param name="_port"></param>
		/// <param name="_messageBacklog"></param>
		public Server(int _port, EventQueue<NetworkMessage> _messageBacklog)
		{
			this._port = _port;
			MessageBacklog = _messageBacklog;
			Instance = this;
			Console.WriteLine("Setting up the server...");
			MessageReceived += ParseMessage;
		}

		/// <summary>
		/// here you start the server to listen to the specified _port.
		/// </summary>
		/// <returns></returns>
		public bool StartServer()
		{
			_serverThread = new Thread(Listener) {IsBackground = true};
			Console.WriteLine("Starting the listener...");
			_serverThread.Start();
			return true;
		}

		/// <summary>
		/// here you can get the status of the Thread where the server is running
		/// </summary>
		/// <returns></returns>
		public string Status()
		{
			var state = _serverThread.ThreadState;
			return state.ToString();
		}

		/// <summary>
		/// this is the function that is running on a separate thread, this listens to the incoming messages.
		/// </summary>
		private void Listener()
		{
			_listener = new UdpClient(_port, AddressFamily.InterNetwork);

			_endPoint = new IPEndPoint(IPAddress.Any, _port);

			while (true)
			{
				try
				{
					byte[] message = _listener.Receive(ref _endPoint);
					// here you have received your message, you can do with it what you want.
					// The message is an serialized Networkmessage, which is a wrapper for the content of the message.
					// I launch the event that gives the messageData to the eventlisteners
					MessageReceived(message);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					return;
				}
			}
		}

		#region EventManagment

		/// <summary>
		/// The function called after a message came in.
		/// </summary>
		/// <param name="_lMessage"></param>
		private void ParseMessage(byte[] _lMessage)
		{
			NetworkMessage message = NetworkMessage.Deserialize(_lMessage);
			MessageBacklog.Enqueue(message);
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
			_listener.Close();
			_endPoint = null;
			_serverThread.Abort();
		}
		#endregion
	}
}
