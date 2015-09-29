﻿using System.Collections.Generic;

namespace UnityServerBasics.game
{
	/// <summary>
	/// This is a "game room".
	/// </summary>
	class Hub
	{

		public int PlayerAmount { get; private set; }
		public string Name { get; private set; }
		private List<Player> Players;

		/// <summary>
		/// Create a hub which manages all the players in a game.
		/// </summary>
		/// <param name="_playerAmount">The maximum amount of players allowed in this room.</param>
		/// <param name="_name">The name of the room.</param>
		public Hub(int _playerAmount, string _name)
		{
			PlayerAmount = _playerAmount;
			Players = new List<Player>();
			Name = _name;
		}

		/// <summary>
		/// Let a <see cref="Player"/> try to join the Hub.
		/// </summary>
		/// <param name="_player"></param>
		/// <returns></returns>
		public bool Join(Player _player)
		{
			if (Players.Count < PlayerAmount + 1)
			{
				Players.Add(_player);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Let a <see cref="Player"/> leave the Hub.
		/// </summary>
		/// <param name="_player"></param>
		public void Leave(Player _player)
		{
			for (int i = 0; i < Players.Count; i++)
			{
				if (Players[i].GUID == _player.GUID)
				{
					Players.RemoveAt(i);
				}
			}
		}
	}
}
