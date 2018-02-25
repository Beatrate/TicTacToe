using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
	public class FieldCell
	{
		public Player OwnedBy { get; set; }
		public bool Free => OwnedBy == Player.None;
		public int Row { get; private set; }
		public int Column { get; private set; }

		public FieldCell(int row, int column, Player player = Player.None)
		{
			Row = row;
			Column = column;
			OwnedBy = player;
		}

		public FieldCell(FieldCell other) : this(other.Row, other.Column, other.OwnedBy)
		{

		}
	}
}