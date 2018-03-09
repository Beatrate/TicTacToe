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
		private GameObject playerSelectorScreen;

		public void OnExit()
		{
			Application.Quit();
		}

		public void OnPlay()
		{
			gameObject.SetActive(false);
			playerSelectorScreen.SetActive(true);
		}
	}
}