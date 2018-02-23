﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.DeInspektor.Attributes;

namespace TicTacToe
{
	public class MatchDirector : MonoBehaviour
	{
		[SerializeField]
		[DeEmptyAlert]
		private FieldVisualizer fieldVisualizer;
		[SerializeField]
		[DeEmptyAlert]
		private FieldSelectorPool selectorPool;
		private Player currentPlayer = Player.Player1;
		private Dictionary<Player, IPlayer> players = new Dictionary<Player, IPlayer>();
		private bool moveFinished = true;
		private MatchState state = MatchState.InProgress;

		public FieldState Field { get; private set; } = new FieldState();

		private void Awake()
		{
			// TODO: Implement player type loading.
			players.Add(Player.Player1, new HumanPlayer(selectorPool, Field, OnCellSelected, Player.Player1));
			players.Add(Player.Player2, new HumanPlayer(selectorPool, Field, OnCellSelected, Player.Player2));
		}

		private void Start()
		{
			StartCoroutine(ProgressMatch());
		}

		private IEnumerator ProgressMatch()
		{
			while(true)
			{
				moveFinished = false;
				players[currentPlayer].MakeMove();
				yield return new WaitUntil(() => moveFinished);
				if(state == MatchState.Won)
				{
					Debug.Log($"{nameof(currentPlayer)} won");
					yield break;
				}
				else if(state == MatchState.Tie)
				{
					Debug.Log($"Tied");
					yield break;
				}
				currentPlayer = currentPlayer == Player.Player1 ? Player.Player2 : Player.Player1;
			}
		}

		private void OnCellSelected(FieldCell cell)
		{
			fieldVisualizer.UpdateCell(cell.Row, cell.Column, currentPlayer);
			if(Field.FindWinnerRow(cell) || Field.FindWinnerColumn(cell) || Field.FindWinnerDiagonal(cell) || Field.FindWinnerAntidiagonal(cell))
			{
				state = MatchState.Won;
			}
			if(Field.FindFreeCells().Count == 0)
			{
				state = MatchState.Tie;
			}
			moveFinished = true;
		}
	}
}