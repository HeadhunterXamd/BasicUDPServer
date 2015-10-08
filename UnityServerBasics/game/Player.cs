using System;

namespace UnityServerBasics.game
{
	/// <summary>
	/// A player wrapper so the server can track the state of the player.
	/// </summary>
	class Player
	{
		public Guid GUID { get; set; }
		public Vector Position { get; set; }
		private string Address { get; set; }
		public float Orientation { get; set; }
		public bool OnGround { get; set; }

		/// <summary>
		/// The player wrapper to manage the players on the server.
		/// </summary>
		/// <param name="_pos"> the position of the player.</param>
		/// <param name="_address">The IP address of the player.</param>
		/// <param name="_ori">The orientation of the player.</param>
		/// <param name="_OnGround">Boolean to check if the playe is on the ground.</param>
		public Player(Vector _pos, string _address, float _ori, bool _OnGround)
		{
			GUID = Guid.NewGuid();
			Position = _pos;
			Address = _address;
			Orientation = _ori;
			OnGround = _OnGround;
		}

	}
}
