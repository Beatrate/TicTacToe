using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacToe
{
	public class AIPlayer : IPlayer
	{
		private Action<FieldCell> finishCallback;
		private FieldState field;
		private Player player;

		public AIPlayer(FieldState field, Action<FieldCell> moveFinishCallback, Player identificator)
		{
			this.field = field;
			finishCallback = moveFinishCallback;
			player = identificator;
		}

		public void MakeMove()
		{
			FieldCell bestMove = new FieldCell(0, 0);
			MinMax(ref bestMove, player, null);
			finishCallback(bestMove);
		}

		private int MinMax(ref FieldCell bestMove, Player currentPlayer, FieldCell cell, int depth = 0, int alpha = int.MinValue, int beta = int.MaxValue)
		{
			List<FieldCell> freeCells = field.FindFreeCells();
			if((cell != null) && field.FindWinner(cell))
			{
				if(cell.OwnedBy == player)
				{
					return 10 - depth;
				}
				else
				{
					return depth - 10;
				}
			}
			if(freeCells.Count == 0)
			{
				return 0;
			}

			if(currentPlayer == player)
			{
				int score = int.MinValue;
				foreach(FieldCell freeCell in freeCells)
				{
					freeCell.OwnedBy = currentPlayer;
					if(currentPlayer == player)
					{
						int minmax = MinMax(ref bestMove, player == Player.Player1 ? Player.Player2 : Player.Player1, freeCell, depth + 1, alpha, beta);
						freeCell.OwnedBy = Player.None;
						if(minmax > score)
						{
							score = minmax;
							if(depth == 0)
							{
								bestMove = freeCell;
							}
						}
						alpha = Mathf.Max(alpha, score);
						if(beta <= alpha)
						{
							break;
						}
					}
				}
				return score;
			}
			else
			{
				int score = int.MaxValue;
				foreach(FieldCell freeCell in freeCells)
				{
					freeCell.OwnedBy = currentPlayer;
					score = Mathf.Min(score, MinMax(ref bestMove, player, freeCell, depth + 1, alpha, beta));
					freeCell.OwnedBy = Player.None;
					beta = Mathf.Min(beta, score);
					if(beta <= alpha)
					{
						break;
					}
				}
				return score;
			}
		}
	}
}