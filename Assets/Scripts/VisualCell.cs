using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
	public class VisualCell : MonoBehaviour
	{
		[SerializeField]
		private Image cross;
		[SerializeField]
		private Image circle;

		public Player Owner
		{
			get
			{
				return owner;
			}
			set
			{
				owner = value;
				if(value == Player.None)
				{
					cross.enabled = circle.enabled = false;
				}
				else if(value == Player.Player1)
				{
					circle.enabled = false;
					cross.enabled = true;
				}
				else
				{
					cross.enabled = false;
					circle.enabled = true;
				}
			}
		}
		private Player owner;
	}
}