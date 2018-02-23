﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace TicTacToe
{
	public class FieldState
	{
		public const int Dimension = 3;
		private FieldCell[,] cells = new FieldCell[Dimension, Dimension];

		public FieldState()
		{
			for(int x = 0; x < Dimension; ++x)
			{
				for(int y = 0; y < Dimension; ++y)
				{
					cells[x, y] = new FieldCell(x, y);
				}
			}
		}

		public FieldState(FieldState other)
		{
			Array.Copy(other.cells, cells, Dimension * Dimension);
		}

		public List<FieldCell> FindFreeCells()
		{
			List<FieldCell> freeCells = new List<FieldCell>();
			foreach(FieldCell cell in cells)
			{
				if(cell.Free)
				{
					freeCells.Add(cell);
				}
			}
			return freeCells;
		}

		public FieldCell this[int x, int y] => cells[x, y];

		public bool FindWinnerRow(FieldCell lastCell)
		{
			Player lastPlayer = Player.None;
			for(int y = 0; y < cells.GetLength(0); ++y)
			{
				FieldCell current = cells[lastCell.Row, y];
				if(current.Free || ((y != 0) && (current.OwnedBy != lastPlayer)))
				{
					return false;
				}
				lastPlayer = current.OwnedBy;
			}
			return true;
		}

		public bool FindWinnerColumn(FieldCell lastCell)
		{
			Player lastPlayer = Player.None;
			for(int x = 0; x < cells.GetLength(0); ++x)
			{
				FieldCell current = cells[x, lastCell.Column];
				if(current.Free || ((x != 0) && (current.OwnedBy != lastPlayer)))
				{
					return false;
				}
				lastPlayer = current.OwnedBy;
			}
			return true;
		}

		public bool FindWinnerDiagonal(FieldCell lastCell)
		{
			if(lastCell.Row == lastCell.Column)
			{
				Player lastPlayer = Player.None;
				for(int x = 0; x < cells.GetLength(0); ++x)
				{
					FieldCell current = cells[x, x];
					if(current.Free || ((x != 0) && (current.OwnedBy != lastPlayer)))
					{
						return false;
					}
					lastPlayer = current.OwnedBy;
				}
				return true;
			}
			return false;
		}

		public bool FindWinnerAntidiagonal(FieldCell lastCell)
		{
			if(lastCell.Row == cells.GetLength(0) - 1 - lastCell.Column)
			{
				Player lastPlayer = Player.None;
				for(int y = 0; y < cells.GetLength(0); ++y)
				{
					FieldCell current = cells[y, cells.GetLength(0) - 1 - y];
					if(current.Free || ((y != 0) && (current.OwnedBy != lastPlayer)))
					{
						return false;
					}
					lastPlayer = current.OwnedBy;
				}
				return true;
			}
			return false;
		}
	}
}