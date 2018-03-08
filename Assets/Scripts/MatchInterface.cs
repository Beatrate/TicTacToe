using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using DG.DeInspektor.Attributes;

namespace TicTacToe
{
	public class MatchInterface : MonoBehaviour
	{
		[SerializeField]
		[DeEmptyAlert]
		private GameObject interfaceObject;
		[SerializeField]
		[DeEmptyAlert]
		private TMPro.TextMeshProUGUI matchOutcomeHeader;
		[SerializeField]
		private UnityEvent matchResetRequested;

		public void OnMatchEnded(Player winner)
		{
			if(winner == Player.None)
			{
				matchOutcomeHeader.text = "Tie";
			}
			else
			{
				matchOutcomeHeader.text = winner == Player.Player1 ? "Player 1 won" : "Player 2 won";
			}
			interfaceObject.SetActive(true);
		}

		public void OnMatchResetRequested()
		{
			interfaceObject.SetActive(false);
			matchResetRequested.Invoke();
		}

		public void OnExit()
		{
			SceneManager.LoadSceneAsync("Menu");
		}
	}
}