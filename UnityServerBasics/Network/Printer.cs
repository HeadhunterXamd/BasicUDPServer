using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnityServerBasics.Network
{
	class Printer
	{
		public Printer()
		{
			
			Server.StaticSubscribeToMessageReceived(printEvent);
		}

		private void printEvent(byte[] _lmessage)
		{
			string message = Encoding.ASCII.GetString(_lmessage);
			Console.WriteLine(message);
		}
	}
}
