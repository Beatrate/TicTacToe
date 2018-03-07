using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
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
		[SerializeField]
		private UnityEventPlayer matchEnded;
		private Player currentPlayer;
		private Dictionary<Player, IPlayer> players = new Dictionary<Player, IPlayer>();
		private bool moveFinished = true;
		private MatchState state;

		public FieldState Field { get; private set; } = new FieldState();

		private void Start()
		{
			players.Add(Player.Player1, new HumanPlayer(selectorPool, Field, OnCellSelected));
			players.Add(Player.Player2, new AIPlayer(Field, OnCellSelected, Player.Player2));
			ResetMatch();
		}

		public void ResetMatch()
		{
			Field.Reset();
			currentPlayer = Player.Player1;
			state = MatchState.InProgress;
			fieldVisualizer.ResetAll();
			StartCoroutine(ProgressMatch());
		}

		private IEnumerator ProgressMatch()
		{
			var wait = new WaitUntil(() => moveFinished);
			while(true)
			{
				moveFinished = false;
				players[currentPlayer].MakeMove();
				yield return wait;
				if(state == MatchState.Won)
				{
					matchEnded.Invoke(currentPlayer);
					Debug.Log($"{(currentPlayer == Player.Player1 ? "Player 1" : "Player 2")} won");
					yield break;
				}
				else if(state == MatchState.Tie)
				{
					matchEnded.Invoke(Player.None);
					Debug.Log($"Tied");
					yield break;
				}
				currentPlayer = currentPlayer == Player.Player1 ? Player.Player2 : Player.Player1;
			}
		}

		private void OnCellSelected(FieldCell cell)
		{
			cell.OwnedBy = currentPlayer;
			fieldVisualizer.UpdateCell(cell.Row, cell.Column, currentPlayer);
			Debug.Log($"{currentPlayer} made turn {cell.Column} {cell.Row}");
			Debug.Log(Field);
			if(Field.FindWinner(cell))
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