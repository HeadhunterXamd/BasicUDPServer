using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnityServerBasics.Network
{
	/// <summary>
	/// This is for debugging only
	/// </summary>
	class Printer
	{
		public Printer()
		{
			
			Server.Instance.SubscribeToMessageReceived(printEvent);
		}

		private void printEvent(NetworkMessage _lmessage)
		{
			Console.WriteLine(_lmessage);
		}
	}
}
