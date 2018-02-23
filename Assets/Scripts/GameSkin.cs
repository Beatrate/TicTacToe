using System;
using UnityEngine;
using UnityEngine.UI;
using DG.DeInspektor.Attributes;

namespace TicTacToe
{
	[CreateAssetMenu(fileName = "Skin", menuName = "Game Skin")]
	public class GameSkin : ScriptableObject
	{
		[SerializeField]
		[DeImagePreview(emptyAlert = true)]
		[DeHeader("Player 1")]
		[DeBeginGroup]
		private Sprite player1Sprite;
		[SerializeField]
		[DeEndGroup]
		private Color player1Tint = Color.white;
		[SerializeField]
		[DeImagePreview(emptyAlert = true)]
		[DeHeader("Player 2")]
		[DeBeginGroup]
		private Sprite player2Sprite;
		[SerializeField]
		[DeEndGroup]
		private Color player2Tint = Color.white;

		public Sprite GetPlayerSprite(Player player)
		{
			if(player == Player.Player1)
			{
				return player1Sprite;
			}
			else if(player == Player.Player2)
			{
				return player2Sprite;
			}

			throw new NotImplementedException(nameof(player));
		}

		public Color GetPlayerTint(Player player)
		{
			if(player == Player.Player1)
			{
				return player1Tint;
			}
			else if(player == Player.Player2)
			{
				return player2Tint;
			}

			throw new NotImplementedException(nameof(player));
		}
	}
}