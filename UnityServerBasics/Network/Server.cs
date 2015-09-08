using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UnityServerBasics.Network
{

	/// <summary>
	/// this is a basic server class.
	/// </summary>
	class Server
	{
		private static Server m_cThis;
		private Thread _serverThread;
		private readonly int _port;
		private UdpClient _listener;
		private IPEndPoint _endPoint;


		/// <summary>
		/// a delegate function is like a blueprint, so the function which uses the delegate knows what the parameters are to use.
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
		public static Server Instance
		{
			get { return m_cThis; }
		}


		/// <summary>
		/// start a small server that listens to UDP messages through port 1337(as indicated when initializing the server instance).
		/// </summary>
		/// <param name="port"></param>
		public Server(int port)
		{
			_port = port;
			// make it run on a separate thread so it is not blocking the application from running.
			m_cThis = this;
		}

		/// <summary>
		/// here you start the server to listen to the specified port.
		/// </summary>
		/// <returns></returns>
		public bool StartServer()
		{
			_serverThread = new Thread(Listener);
			_serverThread.IsBackground = true;
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
					//here you have received your message, you can do with it what you want.
					//string data = Encoding.ASCII.GetString(message);
					//data = data.Replace(" ", "");
					//var dataList = data.Split('|');
					//if (dataList[1].Contains("INPUT"))
					//{
					//	Console.WriteLine("input = " + dataList[dataList.Length-1]);
					//}
					// the message is split into a list so you can get separate data parts of the message.
					// the message is: Identifier|GameName|type|sender|info you want to send
					// the message is in, so you can do with it whatever you want.
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
		/// A static version of the event subscription method
		/// </summary>
		/// <param name="_method"> the method to run when this event fires </param>
		//public static void StaticSubscribeToMessageReceived(OnMessageReceived _method)
		//{
		//	m_cThis.MessageReceived += _method;
		//}

		/// <summary>
		/// A static version of the unsubscribe method
		/// </summary>
		/// <param name="_method"> the method you want to unsubscribe from this event </param>
		//public static void StaticUnsubscribeToMessageReceived(OnMessageReceived _method)
		//{
		//	m_cThis.MessageReceived -= _method;
		//}

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
		#endregion
	}
}
