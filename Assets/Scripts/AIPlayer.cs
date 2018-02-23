using System;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
	public class AIPlayer : IPlayer
	{
		private Action<FieldCell> finishCallback;
		private FieldState field;
		private Player player;

		public AIPlayer(Action<FieldCell> moveFinishCallback, Player identificator)
		{
			finishCallback = moveFinishCallback;
			player = identificator;
		}

		public void MakeMove()
		{

		}

		private void MinMax(FieldState field, Player currentPlayer)
		{
			List<FieldCell> freeCells = field.FindFreeCells();
		}
	}
}