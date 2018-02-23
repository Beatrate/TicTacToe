using System;

namespace TicTacToe
{
	public class HumanPlayer : IPlayer
	{
		private FieldSelectorPool selectorPool;
		private FieldState field;
		private Player identifier;
		private Action<FieldCell> finishMoveCallback;

		public HumanPlayer(FieldSelectorPool selectorPool, FieldState fieldState, Action<FieldCell> finishCallback, Player identifier)
		{
			this.selectorPool = selectorPool;
			field = fieldState;
			finishMoveCallback = finishCallback;
			this.identifier = identifier;
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
			field[args.Row, args.Column].OwnedBy = identifier;
			selectorPool.CellSelected -= HandleCellSelection;
			finishMoveCallback(field[args.Row, args.Column]);
		}
	}
}