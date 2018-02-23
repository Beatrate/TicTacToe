using System;
using UnityEngine;
using UnityEngine.UI;
using DG.DeInspektor.Attributes;

namespace TicTacToe
{
	public class FieldSelectorPool : MonoBehaviour
	{
		[SerializeField]
		private Button[] selectors;

		public event EventHandler<CellSelectedEventArgs> CellSelected;

		private void Start()
		{
			for(int row = 0; row < FieldState.Dimension; ++row)
			{
				for(int column = 0; column < FieldState.Dimension; ++column)
				{
					// Prevent reference capture by the lambda.
					int copyRow = row;
					int copyColumn = column;
					selectors[row * FieldState.Dimension + column].onClick.AddListener(() => CellSelected?.Invoke(this, new CellSelectedEventArgs(copyRow, copyColumn)));
				}
			}
		}
	}
}