using System.Collections.Generic;

namespace TicTacToe
{
	public class GameProfile
	{
		private static readonly GameProfile instance = new GameProfile();
		private Dictionary<Player, PlayerType> players = new Dictionary<Player, PlayerType>()
		{
			{ Player.Player1, PlayerType.Human },
			{ Player.Player2, PlayerType.Human }
		};

		private GameProfile()
		{

		}

		public static PlayerType GetPlayerType(Player identificator)
		{
			return instance.players[identificator];
		}

		public static void SetPlayerType(Player identificator, PlayerType type)
		{
			instance.players[identificator] = type;
		}
	}
}