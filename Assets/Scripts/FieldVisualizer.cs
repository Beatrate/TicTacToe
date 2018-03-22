using System;
using UnityEngine;
using UnityEngine.UI;
using DG.DeInspektor.Attributes;

namespace TicTacToe
{
	public class FieldVisualizer : MonoBehaviour, ICellSelectionProvider
	{
		[SerializeField]
		[DeEmptyAlert]
		private VisualCell[] cells;
		[SerializeField]
		[DeEmptyAlert]
		private Button[] selectors;

		public event EventHandler<CellSelectedEventArgs> CellSelected;

		private void Awake()
		{
			for(int row = 0; row < FieldState.Dimension; ++row)
			{
				for(int column = 0; column < FieldState.Dimension; ++column)
				{
					// Prevent reference capture by the lambda.
					int copyRow = row;
					int copyColumn = column;
					var coord = row * FieldState.Dimension + column;
					selectors[row * FieldState.Dimension + column].onClick.AddListener(() => CellSelected?.Invoke(this, new CellSelectedEventArgs(copyRow, copyColumn)));
				}
			}
		}

		public void UpdateCell(int row, int column, Player currentPlayer)
		{
			cells[row * FieldState.Dimension + column].Owner = currentPlayer;
		}

		public void ResetAll()
		{
			foreach(VisualCell cell in cells)
			{
				cell.Owner = Player.None;
			}
		}
	}
}