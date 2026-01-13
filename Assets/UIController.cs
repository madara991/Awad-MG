using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button[] levelesButons;

	// we add this functions make sure the listeners is not empty fro level manager that destroy with loading scene
    private void Start()
    {
		for (int i = 0; i < levelesButons.Length; i++)
		{
			int index = i;
			levelesButons[i].onClick.AddListener(() =>
			{
				LevelManager.Instance.SetLevelSelected(index + 1);
				LevelManager.Instance.LoadScene("game");
			});

			levelesButons[i].onClick.AddListener(() =>
			{
				
			});
		}
	}
}
