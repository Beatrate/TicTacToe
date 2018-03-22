using System;
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
		private UnityEventPlayer matchEnded;
		private Player currentPlayer;
		private Dictionary<Player, IPlayer> players = new Dictionary<Player, IPlayer>();
		private bool moveFinished = true;
		private MatchState state;

		public FieldState Field { get; private set; } = new FieldState();

		private void Start()
		{
			PreparePlayer(Player.Player1);
			PreparePlayer(Player.Player2);
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
					yield break;
				}
				else if(state == MatchState.Tie)
				{
					matchEnded.Invoke(Player.None);
					yield break;
				}
				currentPlayer = currentPlayer == Player.Player1 ? Player.Player2 : Player.Player1;
			}
		}

		private void OnCellSelected(FieldCell cell)
		{
			cell.OwnedBy = currentPlayer;
			Debug.Log(Field);
			fieldVisualizer.UpdateCell(cell.Row, cell.Column, currentPlayer);
			if(Field.FindWinner(cell))
			{
				state = MatchState.Won;
			}
			else if(Field.FindFreeCells().Count == 0)
			{
				state = MatchState.Tie;
			}
			moveFinished = true;
		}

		private void PreparePlayer(Player identificator)
		{
			if(GameProfile.GetPlayerType(identificator) == PlayerType.Human)
			{
				players.Add(identificator, new HumanPlayer(fieldVisualizer, Field, OnCellSelected));
			}
			else
			{
				players.Add(identificator, new AIPlayer(Field, OnCellSelected, identificator));
			}
		}
	}
}