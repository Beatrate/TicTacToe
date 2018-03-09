using UnityEngine;
using DG.DeInspektor.Attributes;

namespace TicTacToe
{
	public class PlayerSelector : MonoBehaviour
	{
		[SerializeField]
		[DeEmptyAlert]
		private TMPro.TMP_Dropdown dropdown;
		[SerializeField]
		private Player player;
		[SerializeField]
		[DeToggleButton]
		private bool updateOnStart = false;

		private void Start()
		{
			if(updateOnStart)
			{
				OnPlayerChange(0);
			}
		}

		public void OnPlayerChange(int index)
		{
			GameProfile.SetPlayerType(player, dropdown.options[index].text == "human" ? PlayerType.Human : PlayerType.AI);
		}
	}
}