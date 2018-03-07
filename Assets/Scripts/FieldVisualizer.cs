using UnityEngine;
using UnityEngine.UI;
using DG.DeInspektor.Attributes;

namespace TicTacToe
{
	public class FieldVisualizer : MonoBehaviour
	{
		[SerializeField]
		private Image[] cells;
		[SerializeField]
		[DeEmptyAlert]
		private GameSkin skin;

		public void UpdateCell(int row, int column, Player currentPlayer)
		{
			Image current = cells[row * FieldState.Dimension + column];
			current.sprite = skin.GetPlayerSprite(currentPlayer);
			current.color = skin.GetPlayerTint(currentPlayer);
			current.enabled = true;
		}

		public void ResetAll()
		{
			foreach(Image image in cells)
			{
				image.enabled = false;
				image.sprite = null;
			}
		}
	}
}