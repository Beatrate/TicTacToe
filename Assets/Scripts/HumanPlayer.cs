using System;

namespace TicTacToe
{
	public class HumanPlayer : IPlayer
	{
		private FieldSelectorPool selectorPool;
		private FieldState field;
		private Action<FieldCell> finishMoveCallback;

		public HumanPlayer(FieldSelectorPool selectorPool, FieldState fieldState, Action<FieldCell> finishCallback)
		{
			this.selectorPool = selectorPool;
			field = fieldState;
			finishMoveCallback = finishCallback;
		}

		public void MakeMove()
		{
			selectorPool.CellSelected += HandleCellSelection;
		}

		private void HandleCellSelection(object sender, CellSelectedEventArgs args)
		{
			if(!field[args.Row, args.Column].Free)
			{
				return;
			}
			selectorPool.CellSelected -= HandleCellSelection;
			finishMoveCallback(field[args.Row, args.Column]);
		}
	}
}