using System;

namespace TicTacToe
{
	public interface ICellSelectionProvider
	{
		event EventHandler<CellSelectedEventArgs> CellSelected;
	}
}