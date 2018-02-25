using System;
using System.Collections;
using System.Collections.Generic;
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
			List<FieldCell> freeCells = field.FindFreeCells();
			Tuple<int, FieldCell> bestMove = new Tuple<int, FieldCell>(-1000, new FieldCell(0, 0));
			foreach(FieldCell cell in freeCells)
			{
				FieldState newField = new FieldState(field);
				newField[cell.Row, cell.Column].OwnedBy = player;
				int score = MinMax(newField, player == Player.Player1 ? Player.Player2 : Player.Player1, newField[cell.Row, cell.Column]);
				if(score > bestMove.Item1)
				{
					bestMove = new Tuple<int, FieldCell>(score, cell);
				}
			}
			finishCallback(bestMove.Item2);
		}

		private int MinMax(FieldState fieldState, Player currentPlayer, FieldCell cell, int depth = 0)
		{
			++depth;
			List<FieldCell> freeCells = fieldState.FindFreeCells();
			if(fieldState.FindWinner(cell))
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

			List<int> scores = new List<int>();
			foreach(FieldCell freeCell in freeCells)
			{
				FieldState newField = new FieldState(fieldState);
				newField[freeCell.Row, freeCell.Column].OwnedBy = currentPlayer;
				if(currentPlayer == player)
				{
					scores.Add(MinMax(newField, player == Player.Player1 ? Player.Player2 : Player.Player1, newField[freeCell.Row, freeCell.Column], depth));
				}
				else
				{
					scores.Add(MinMax(newField, player, newField[freeCell.Row, freeCell.Column], depth));
				}

			}
			scores.Sort();
			if(currentPlayer == player)
			{
				return scores[scores.Count - 1];
			}
			else
			{
				return scores[0];
			}
		}
	}
}