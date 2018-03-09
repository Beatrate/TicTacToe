using UnityEngine;
using UnityEngine.SceneManagement;
using DG.DeInspektor.Attributes;

namespace TicTacToe
{
	public class PlayerSelectorScreen : MonoBehaviour
	{
		[SerializeField]
		[DeEmptyAlert]
		private GameObject menuScreen;

		public void OnCancel()
		{
			gameObject.SetActive(false);
			menuScreen.SetActive(true);
		}

		public void OnContinue()
		{
			SceneManager.LoadSceneAsync("Field");
		}
	}
}