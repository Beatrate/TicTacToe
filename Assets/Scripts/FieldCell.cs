using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
	public class FieldCell
	{
		public Player OwnedBy { get; set; } = Player.None;
		public bool Free => OwnedBy == Player.None;
		public int Row { get; private set; }
		public int Column { get; private set; }

		public FieldCell(int row, int column)
		{
			Row = row;
			Column = column;
		}
	}
}