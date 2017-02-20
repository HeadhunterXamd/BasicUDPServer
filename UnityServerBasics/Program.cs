using System;
using UnityServerBasics.Network;

namespace UnityServerBasics
{
	class Program
	{

		static void Main(string[] args)
		{
			bool once = false;

			Server _server = new Server(1337);
			Printer _printer = new Printer();
			while (true)
			{
                if (once == false)
                {
                    bool startServer = _server.StartServer();
                    Console.WriteLine("starting the server");
                    once = true;
                }
			}
		}
	}
}
