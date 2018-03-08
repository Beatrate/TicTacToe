using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.DeInspektor.Attributes;

namespace TicTacToe
{
	public class MenuController : MonoBehaviour
	{
		[SerializeField]
		[DeEmptyAlert]
		private GameObject playPanel;
		[SerializeField]
		[DeEmptyAlert]
		private TMPro.TMP_Dropdown player1Dropdown;
		[SerializeField]
		[DeEmptyAlert]
		private TMPro.TMP_Dropdown player2Dropdown;

		private void Start()
		{
			OnPlayer1Change(0);
			OnPlayer2Change(0);
		}

		public void OnExit()
		{
			Application.Quit();
		}

		public void OnPlay()
		{
			playPanel.SetActive(true);
			gameObject.SetActive(false);
		}

		public void OnCancelPlay()
		{
			playPanel.SetActive(false);
			gameObject.SetActive(true);
		}

		public void OnPlayer1Change(int index)
		{
			GameProfile.SetPlayerType(Player.Player1, player1Dropdown.options[index].text == "human" ? PlayerType.Human : PlayerType.AI);
		}

		public void OnPlayer2Change(int index)
		{
			GameProfile.SetPlayerType(Player.Player2, player2Dropdown.options[index].text == "human" ? PlayerType.Human : PlayerType.AI);
		}

		public void OnContinue()
		{
			SceneManager.LoadSceneAsync("Field");
		}
	}
}