using System;

namespace TicTacToe
{
	public class CellSelectedEventArgs : EventArgs
	{
		public int Row { get; private set; }
		public int Column { get; private set; }

		public CellSelectedEventArgs(int row, int column)
		{
			Row = row;
			Column = column;
		}
	}
}