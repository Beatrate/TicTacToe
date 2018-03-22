using System;

namespace TicTacToe
{
	public class HumanPlayer : IPlayer
	{
		private ICellSelectionProvider selectionProvider;
		private FieldState field;
		private Action<FieldCell> finishMoveCallback;

		public HumanPlayer(ICellSelectionProvider provider, FieldState fieldState, Action<FieldCell> finishCallback)
		{
			selectionProvider = provider;
			field = fieldState;
			finishMoveCallback = finishCallback;
		}

		public void MakeMove()
		{
			selectionProvider.CellSelected += HandleCellSelection;
		}

		private void HandleCellSelection(object sender, CellSelectedEventArgs args)
		{
			if(!field[args.Row, args.Column].Free)
			{
				return;
			}
			selectionProvider.CellSelected -= HandleCellSelection;
			finishMoveCallback(field[args.Row, args.Column]);
		}
	}
}