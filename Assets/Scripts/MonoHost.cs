using System;
using System.Collections;
using UnityEngine;

namespace TicTacToe
{
	public class MonoHost : MonoBehaviour
	{
		private static MonoBehaviour instance;

		public static void ScheduleCoroutine(IEnumerator coroutine)
		{
			if(!instance)
			{
				GameObject monoHost = new GameObject("MonoHost");
				instance = monoHost.AddComponent<MonoHost>();
			}
			instance.StartCoroutine(coroutine);
		}
	}
}