using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityServerBasics.game
{
	class Player
	{
		public Guid GUID { get; set; }
		private Vector Position { get; set; }
		private string Address { get; set; }

		public Player(Vector _pos, string _address)
		{
			GUID = Guid.NewGuid();
			Position = _pos;
			Address = _address;
		}

		/// <summary>
		/// Change the position of the player.
		/// </summary>
		/// <param name="_cNewPosition">The new position of the player.</param>
		public void SetPosition(Vector _cNewPosition)
		{
			Position = _cNewPosition;
		}
	}
}
